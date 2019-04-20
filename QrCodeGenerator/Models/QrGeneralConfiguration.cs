using Prism.Mvvm;
using QRCoder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Interop;
using Encoder = System.Text.Encoder;

namespace QrCodeGenerator.Models
{
    public class QrGeneralConfiguration : BindableBase
    {
        #region Fields

        private QRCodeGenerator.ECCLevel _eccLevel = QRCodeGenerator.ECCLevel.Q;
        private bool _forceUtf8 = false;
        private bool _utf8Bom = false;
        private QRCodeGenerator.EciMode _eciMode = QRCodeGenerator.EciMode.Default;
        private int _requestedVersion = -1;

        private Color _darkColor = Color.Black;
        private Color _lightColor = Color.White;
        private int _pixelsPerModule = 20;
        private bool _drawQuietZones = true;

        private bool _drawIcon = false;
        private Bitmap _iconBitmap = null;
        private int _iconSizePercent = 15;
        private int _iconBorderWidth = 6;

        private ImageFormat _format = ImageFormat.Jpeg;
        private ImageCodecInfo _codec;
        private int _dpi = 72;
        private int _quality = 80;
        #endregion

        #region Property
        #region Generator Configuration
        public QRCodeGenerator.ECCLevel EccLevel
        {
            get { return this._eccLevel; }
            set { this.SetProperty(ref this._eccLevel, value); }
        }
        public bool ForceUtf8
        {
            get { return this._forceUtf8; }
            set { this.SetProperty(ref this._forceUtf8, value); }
        }

        public bool Utf8Bom
        {
            get { return this._utf8Bom; }
            set { this.SetProperty(ref this._utf8Bom, value); }
        }

        public QRCodeGenerator.EciMode EciMode
        {
            get { return this._eciMode; }
            set { this.SetProperty(ref this._eciMode, value); }
        }

        public int RequestedVersion
        {
            get { return this._requestedVersion; }
            set { this.SetProperty(ref this._requestedVersion, value); }
        }

        #endregion

        #region Graphic Configuration
        public Color DarkColor
        {
            get { return this._darkColor; }
            set { this.SetProperty(ref this._darkColor, value); }
        }

        public Color LightColor
        {
            get { return this._lightColor; }
            set { this.SetProperty(ref this._lightColor, value); }
        }

        public int PixelsPerModule
        {
            get { return this._pixelsPerModule; }
            set { this.SetProperty(ref this._pixelsPerModule, value); }
        }

        public bool DrawQuietZones
        {
            get { return this._drawQuietZones; }
            set { this.SetProperty(ref this._drawQuietZones, value); }
        }
        #endregion

        #region Icon Related
        public bool DrawIcon
        {
            get { return this._drawIcon; }
            set { this.SetProperty(ref this._drawIcon, value); }
        }

        public Bitmap IconBitmap
        {
            get { return this._iconBitmap; }
            set { this.SetProperty(ref this._iconBitmap, value); }
        }

        public int IconSizePercent
        {
            get { return this._iconSizePercent; }
            set { this.SetProperty(ref this._iconSizePercent, value); }
        }

        public int IconBorderWidth
        {
            get { return this._iconBorderWidth; }
            set { this.SetProperty(ref this._iconBorderWidth, value); }
        }
        #endregion

        #region Codec
        public static IEnumerable<KeyValuePair<string, ImageFormat>> AllImageFormat { get; private set; } = new List<KeyValuePair<string, ImageFormat>>()
        {
            new KeyValuePair<string, ImageFormat>("BMP", ImageFormat.Bmp),
            new KeyValuePair<string, ImageFormat>("JPEG", ImageFormat.Jpeg),
            new KeyValuePair<string, ImageFormat>("GIF", ImageFormat.Gif),
            new KeyValuePair<string, ImageFormat>("TIFF", ImageFormat.Tiff),
            new KeyValuePair<string, ImageFormat>("PNG", ImageFormat.Png),
        };
        public static List<ImageCodecInfo> AllImageCodecInfos => ImageCodecInfo.GetImageEncoders().ToList();

        public ImageFormat Format
        {
            get => this._format;
            set => this.SetProperty(ref this._format, value);
        }

        public ImageCodecInfo Codec => AllImageCodecInfos.FirstOrDefault((codec) => codec.FormatID == this._format.Guid);
        public int Dpi
        {
            get { return this._dpi; }
            set { this.SetProperty(ref this._dpi, value); }
        }

        public int Quality
        {
            get { return this._quality; }
            set { this.SetProperty(ref this._quality, value); }
        }

        public EncoderParameters EncoderParameters
        {
            get
            {
                EncoderParameters encParams = new EncoderParameters(1);
                encParams.Param[0] = new EncoderParameter(System.Drawing.Imaging.Encoder.Quality, this._quality);
                return encParams;
            }
        }

        #endregion
        #endregion

        public QrGeneralConfiguration()
        {
        }
    }
}
