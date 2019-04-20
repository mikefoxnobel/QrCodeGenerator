using QRCoder;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QrCodeGenerator.Models;

namespace QrCodeGenerator.Helpers
{
    public class QrCodeHelper
    {
        #region Field
        private QRCodeGenerator _qrGenerator = new QRCodeGenerator();

        private QrGeneralConfiguration _config = new QrGeneralConfiguration();

        #endregion
        #region Property
        public QrGeneralConfiguration Config
        {
            get { return this._config; }
            set { this._config = value; }
        }
        #endregion

        public Bitmap GenerateQrBitmap(string text)
        {
            QRCodeData qrCodeData = this._qrGenerator.CreateQrCode(text, this._config.EccLevel, this._config.ForceUtf8, this._config.Utf8Bom, this._config.EciMode, this._config.RequestedVersion);

            QRCode qrCode = new QRCode(qrCodeData);

            Bitmap qrCodeImage;
            if (this._config.DrawIcon)
            {
                qrCodeImage = qrCode.GetGraphic(this._config.PixelsPerModule, this._config.DarkColor, this._config.LightColor, this._config.IconBitmap, this._config.IconSizePercent, this._config.IconBorderWidth, this._config.DrawQuietZones);
            }
            else
            {
                qrCodeImage = qrCode.GetGraphic(this._config.PixelsPerModule, this._config.DarkColor, this._config.LightColor, this._config.DrawQuietZones);
            }

            qrCodeImage.SetResolution(this._config.Dpi, this._config.Dpi);

            return qrCodeImage;
        }

        public Bitmap GenerateAndSaveQrBitmap(string text, string filename)
        {
            Bitmap bitmap = this.GenerateQrBitmap(text);
            bitmap.Save(filename, this.Config.Codec, this.Config.EncoderParameters);
            return bitmap;
        }
    }
}
