using QRCoder;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using MaterialDesignThemes.Wpf;
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

        public Bitmap GenerateQrBitmap(PayloadGenerator.Payload payload)
        {
            QRCode qrCode = this.CreateQrCode(payload);
            return this.CreateBitmap(qrCode);
        }

        public Bitmap GenerateQrBitmap(string text)
        {
            QRCode qrCode = this.CreateQrCode(text);
            return this.CreateBitmap(qrCode);
        }

        public Bitmap GenerateAndSaveQrBitmap(string text, string filename)
        {
            Bitmap bitmap = this.GenerateQrBitmap(text);
            bitmap.Save(filename, this.Config.Codec, this.Config.EncoderParameters);
            Graphics gfx = Graphics.FromImage(bitmap);
            return bitmap;
        }

        public Bitmap GenerateAndSaveQrBitmap(PayloadGenerator.Payload payload, string filename)
        {
            Bitmap bitmap = this.GenerateQrBitmap(payload);
            bitmap.Save(filename, this.Config.Codec, this.Config.EncoderParameters);
            return bitmap;
        }

        private QRCode CreateQrCode(PayloadGenerator.Payload payload)
        {
            QRCodeData qrCodeData = this._qrGenerator.CreateQrCode(payload, this._config.EccLevel);
            return new QRCode(qrCodeData);
        }

        private QRCode CreateQrCode(string text)
        {
            QRCodeData qrCodeData = this._qrGenerator.CreateQrCode(text, this._config.EccLevel, this._config.ForceUtf8, this._config.Utf8Bom, this._config.EciMode, this._config.RequestedVersion);
            return new QRCode(qrCodeData);
        }

        private Bitmap CreateBitmap(QRCode qrCode)
        {
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

        private Color GetColor(Bitmap bitmap, int rowIndex, int columnIndex)
        {
            var bitmapData = bitmap.LockBits(new Rectangle(rowIndex, columnIndex, 1, 1), ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);
            var length = bitmapData.Stride * bitmapData.Height;

            byte[] bytes = new byte[length];

            // Copy bitmap to byte[]
            Marshal.Copy(bitmapData.Scan0, bytes, 0, length);
            bitmap.UnlockBits(bitmapData);

            return Color.FromArgb(bytes[0], bytes[1], bytes[2], bytes[3]);
        }
    }
}
