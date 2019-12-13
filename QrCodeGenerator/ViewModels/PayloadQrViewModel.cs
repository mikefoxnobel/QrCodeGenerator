using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using MaterialDesignThemes.Wpf;
using Microsoft.Win32;
using Prism.Commands;
using Prism.Mvvm;
using QrCodeGenerator.Helpers;
using QrCodeGenerator.Models;
using QrCodeGenerator.ViewModels.PayloadViewModels;
using QrCodeGenerator.Views;
using QrCodeGenerator.Views.PayloadViews;
using QRCoder;

namespace QrCodeGenerator.ViewModels
{
    public class PayloadQrViewModel : BindableBase
    {
        private QrCodeHelper _helper => Core.Instance.QrHelper;
        private SaveFileDialog _saveFileDialog;
        #region Field
        private ImageSource _image = null;
        private SnackbarMessageQueue _messageQueue = new SnackbarMessageQueue(TimeSpan.FromSeconds(0.5));
        private PayloadViewBase _selectedPayloadView;
        private Dictionary<string, PayloadViewBase> _payloadViewList = new Dictionary<string, PayloadViewBase>();
        #endregion

        #region Property
        public ImageSource Image
        {
            get { return this._image; }
            set { this.SetProperty(ref this._image, value); }
        }

        public SnackbarMessageQueue MessageQueue
        {
            get { return this._messageQueue; }
            set { this.SetProperty(ref this._messageQueue, value); }
        }

        public PayloadViewBase SelectedPayloadView
        {
            get { return this._selectedPayloadView; }
            set { this._selectedPayloadView = value; }
        }

        public Dictionary<string, PayloadViewBase> PayloadViewList
        {
            get { return this._payloadViewList; }
            set { this._payloadViewList = value; }
        }

        public IPayloadViewModel PayloadViewModel => this.SelectedPayloadView?.PayloadViewModel;

        public PayloadGenerator.Payload Payload => this.PayloadViewModel?.Payload;
        #endregion

        #region Command
        public ICommand GenerateCommand => new DelegateCommand(this.OnGenerate);
        public ICommand SaveCommand => new DelegateCommand<PayloadGenerator.Payload>(this.OnSave);
        public ICommand CopyCommand => new DelegateCommand(this.OnCopy);

        #endregion

        public PayloadQrViewModel()
        {
            this.InitPayloadViewList();
        }

        private void InitPayloadViewList()
        {
            this.PayloadViewList.Add("Wifi", new WifiPayloadView());
            this.PayloadViewList.Add("Bezahl Code", new BezahlCodePayloadView());
            this.PayloadViewList.Add("Bitcoin Address", new BitcoinAddressPayloadView());
            this.PayloadViewList.Add("Bookmark", new BookmarkPayloadView());
            this.PayloadViewList.Add("Calendar Event", new CalendarEventPayloadView());
            this.PayloadViewList.Add("Contact Data", new ContactDataPayloadView());
            this.PayloadViewList.Add("Geolocation", new GeolocationPayloadView());
            this.PayloadViewList.Add("Girocode", new GirocodePayloadView());
            this.PayloadViewList.Add("Mail", new MailPayloadView());
            this.PayloadViewList.Add("MMS", new MmsPayloadView());
            this.PayloadViewList.Add("Monero Transaction", new MoneroTransactionPayloadView());
            this.PayloadViewList.Add("One Time Password", new OneTimePasswordPayloadView());
            this.PayloadViewList.Add("Phone Number", new PhoneNumberPayloadView());
            this.PayloadViewList.Add("Shadow Socks Config", new ShadowSocksConfigPayloadView());
            this.PayloadViewList.Add("Skype Call", new SkypeCallPayloadView());
            this.PayloadViewList.Add("Slovenian UPN QR", new SlovenianUpnQrPayloadView());
            this.PayloadViewList.Add("SMS", new SmsPayloadView());
            this.PayloadViewList.Add("Swiss QR Code", new SwissQrCodePayloadView());
            this.PayloadViewList.Add("URL", new UrlPayloadView());
            this.PayloadViewList.Add("WhatsApp Message", new WhatsAppMessagePayloadView());

            this.SelectedPayloadView = this.PayloadViewList["Wifi"];
        }

        private void SetImage(PayloadGenerator.Payload payload)
        {
            Bitmap bitmap = this._helper.GenerateQrBitmap(payload);
            this.Image = bitmap.ToWpfBitmap();
        }

        private void OnGenerate()
        {
            this.SetImage(this.Payload);
        }

        private void OnCopy()
        {
            if (this.Image != null)
            {
                Clipboard.SetImage(this.Image as BitmapSource);
                this.MessageQueue.Enqueue("QR Code copied to clipboard.");
            }
            else
            {
                this.MessageQueue.Enqueue("No QR Code to copy.");
            }
        }

        private void OnSave(PayloadGenerator.Payload payload)
        {
            if (this._saveFileDialog == null)
            {
                this._saveFileDialog = new SaveFileDialog()
                {
                    AddExtension = true,
                    OverwritePrompt = true,
                };

            }

            this._saveFileDialog.Filter = $"{this._helper.Config.Codec.FilenameExtension}|{this._helper.Config.Codec.FilenameExtension}";
            this._saveFileDialog.DefaultExt = this._helper.Config.Codec.FilenameExtension.Split(';')[0].Replace("*.", "");

            bool? result = this._saveFileDialog.ShowDialog();
            if (result.HasValue && result.Value)
            {
                Bitmap bitmap = this._helper.GenerateAndSaveQrBitmap(payload, this._saveFileDialog.FileName);
                this.Image = bitmap.ToWpfBitmap();
                this.MessageQueue.Enqueue("Image Saved.");
            }
        }

    }
}
