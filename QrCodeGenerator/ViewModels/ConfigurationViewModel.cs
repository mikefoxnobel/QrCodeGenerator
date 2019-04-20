using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using Microsoft.Win32;
using Prism.Commands;
using QrCodeGenerator.Helpers;
using QrCodeGenerator.Models;
using QRCoder;

namespace QrCodeGenerator.ViewModels
{
    public class ConfigurationViewModel : BindableBase
    {
        #region Field

        private OpenFileDialog _iconOpenFileDialog;
        #endregion


        #region Property
        public QrGeneralConfiguration Config => Core.Instance.Config;
        public IEnumerable<KeyValuePair<QRCodeGenerator.ECCLevel, string>> AllEccLevel => EnumExtension.GetAllValuesAndDescriptions<QRCodeGenerator.ECCLevel>();
        public IEnumerable<KeyValuePair<QRCodeGenerator.EciMode, string>> AllEciMode => EnumExtension.GetAllValuesAndDescriptions<QRCodeGenerator.EciMode>();

        public BitmapImage IconBitmapImage => this.Config.IconBitmap?.ToWpfBitmap();
        #endregion

        #region Command
        public ICommand ChangeIconCommand => new DelegateCommand(OnChangeIcon);
        #endregion

        #region Event

        private void OnChangeIcon()
        {
            if (this._iconOpenFileDialog == null)
            {
                this._iconOpenFileDialog = new OpenFileDialog
                {
                    Filter = "Image files (*.jpg, *.jpeg, *.jpe, *.jfif, *.png) | *.jpg; *.jpeg; *.jpe; *.jfif; *.png; | All files | *",
                    InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures),
                    Multiselect = false,
                };
            }

            bool? result = this._iconOpenFileDialog.ShowDialog();
            if (result.HasValue && result.Value)
            {
                try
                {
                    Bitmap bitmap = new Bitmap(this._iconOpenFileDialog.FileName);
                    this.Config.IconBitmap = bitmap;
                    this.RaisePropertyChanged(nameof(this.IconBitmapImage));
                }
                catch (Exception ex)
                {
                    
                }
                
            }
        }
        #endregion

    }
}
