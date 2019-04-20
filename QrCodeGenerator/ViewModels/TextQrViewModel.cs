using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using Microsoft.Win32;
using Prism.Commands;
using QrCodeGenerator.Helpers;
using QrCodeGenerator.Models;

namespace QrCodeGenerator.ViewModels
{
    public class TextQrViewModel : BindableBase
    {
        private QrCodeHelper _helper => Core.Instance.QrHelper;
        private SaveFileDialog _saveFileDialog;
        #region Field
        private string _text = string.Empty;
        private ImageSource _image = null;
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
        #endregion

        #region Command
        public ICommand GenerateCommand => new DelegateCommand<string>(this.OnGenerate);
        public ICommand SaveCommand => new DelegateCommand<string>(this.OnSave);
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
            }
        }
    }
}
