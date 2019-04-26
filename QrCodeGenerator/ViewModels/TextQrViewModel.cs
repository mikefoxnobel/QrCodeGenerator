using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using MaterialDesignThemes.Wpf;
using Prism.Commands;
using QrCodeGenerator.Helpers;
using QrCodeGenerator.Models;
using SaveFileDialog = Microsoft.Win32.SaveFileDialog;

namespace QrCodeGenerator.ViewModels
{
    public class TextQrViewModel : BindableBase
    {
        private QrCodeHelper _helper => Core.Instance.QrHelper;
        private SaveFileDialog _saveFileDialog;
        #region Field
        private string _text = string.Empty;
        private ImageSource _image = null;
        private SnackbarMessageQueue _messageQueue = new SnackbarMessageQueue(TimeSpan.FromSeconds(0.5));
        #endregion

        #region Property
        public string Text
        {
            get { return this._text; }
            set { this.SetProperty(ref this._text, value); }
        }

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
        #endregion

        #region Command
        public ICommand GenerateCommand => new DelegateCommand<string>(this.OnGenerate);
        public ICommand SaveCommand => new DelegateCommand<string>(this.OnSave);
        public ICommand CopyCommand => new DelegateCommand(this.OnCopy);
        #endregion

        private void SetImage(string text)
        {
            Bitmap bitmap = this._helper.GenerateQrBitmap(text);
            this.Image = bitmap.ToWpfBitmap();
        }

        private void OnGenerate(string text)
        {
            this.SetImage(text);
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

        private void OnSave(string text)
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
                Bitmap bitmap = this._helper.GenerateAndSaveQrBitmap(text, this._saveFileDialog.FileName);
                this.Image = bitmap.ToWpfBitmap();
                this.MessageQueue.Enqueue("Image Saved.");
            }
        }
    }
}
