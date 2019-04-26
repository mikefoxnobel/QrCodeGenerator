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
        public List<KeyValuePair<int, string>> AllVersions { get; } = new List<KeyValuePair<int, string>>();
        public Dictionary<QRCodeGenerator.ECCLevel, int> AllEccPercentage { get; } = new Dictionary<QRCodeGenerator.ECCLevel, int>()
        {
            { QRCodeGenerator.ECCLevel.L, 7 },
            { QRCodeGenerator.ECCLevel.M, 15 },
            { QRCodeGenerator.ECCLevel.Q, 25 },
            { QRCodeGenerator.ECCLevel.H, 30 }
        };

        public BitmapImage IconBitmapImage => this.Config.IconBitmap?.ToWpfBitmap();

        public int SelectedEccPercentage => this.AllEccPercentage[this.Config.EccLevel];
        #endregion

        #region Command
        public ICommand ChangeIconCommand => new DelegateCommand(this.OnChangeIcon);
        #endregion

        #region Event

        public ConfigurationViewModel()
        {
            this.AllVersions.Add(new KeyValuePair<int, string>(-1, "Auto"));
            for (int i = 1; i <= 40; i++)
            {
                this.AllVersions.Add(new KeyValuePair<int, string>(i, i.ToString()));
            }
            this.Config.PropertyChanged += Config_PropertyChanged;
        }

        private void Config_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            switch (e.PropertyName)
            {
                case nameof(this.Config.EccLevel):
                    this.RaisePropertyChanged(nameof(this.SelectedEccPercentage));
                    break;
            }
        }

        private void OnChangeIcon()
        {
            if (this._iconOpenFileDialog == null)
            {
                this._iconOpenFileDialog = new OpenFileDialog
                {
                    Filter = "Image files (*.bmp, *.jpg, *.jpeg, *.jpe, *.jfif, *.png, *.gif, *.tif, *.tiff) | *.bmp; *.jpg; *.jpeg; *.jpe; *.jfif; *.png; *.gif; *.tif; *.tiff; | All files | *",
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
