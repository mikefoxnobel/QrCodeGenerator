using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace QrCodeGenerator.Helpers
{
    public static class BitmapExtension
    {
        public static Bitmap ToWinFormsBitmap(this BitmapSource bitmapSource)
        {
            using (MemoryStream stream = new MemoryStream())
            {
                BitmapEncoder enc = new BmpBitmapEncoder();
                enc.Frames.Add(BitmapFrame.Create(bitmapSource));
                enc.Save(stream);

                using (var tempBitmap = new Bitmap(stream))
                {
                    // According to MSDN, one "must keep the stream open for the lifetime of the Bitmap."
                    // So we return a copy of the new bitmap, allowing us to dispose both the bitmap and the stream.
                    return new Bitmap(tempBitmap);
                }
            }
        }

        public static BitmapImage ToWpfBitmap(this Bitmap bitmap)
        {
            MemoryStream stream = new MemoryStream();
            bitmap.Save(stream, ImageFormat.Bmp);

            stream.Position = 0;
            BitmapImage result = new BitmapImage();
            result.BeginInit();
            // According to MSDN, "The default OnDemand cache option retains access to the stream until the image is needed."
            // Force the bitmap to load right now so we can dispose the stream.
            result.CacheOption = BitmapCacheOption.OnLoad;
            result.StreamSource = stream;
            result.EndInit();
            //result.Freeze();
            return result;
        }

        public static BitmapImage ToWpfBitmap(this System.Drawing.Image image)
        {
            using (MemoryStream memory = new MemoryStream())
            {
                image.Save(memory, ImageFormat.Png);
                memory.Position = 0;
                BitmapImage bitmapImage = new BitmapImage();
                bitmapImage.BeginInit();
                bitmapImage.StreamSource = memory;
                bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
                bitmapImage.EndInit();
                return bitmapImage;
            }
        }

        public static BitmapSource ToWpfBitmapSource(this Bitmap bitmap)
        {
            var bitmapData = bitmap.LockBits(
                new System.Drawing.Rectangle(0, 0, bitmap.Width, bitmap.Height),
                System.Drawing.Imaging.ImageLockMode.ReadOnly, bitmap.PixelFormat);

            var bitmapSource = BitmapSource.Create(
                bitmapData.Width, bitmapData.Height,
                bitmap.HorizontalResolution, bitmap.VerticalResolution,
                bitmap.PixelFormat.Convert(), null,
                bitmapData.Scan0, bitmapData.Stride * bitmapData.Height, bitmapData.Stride);

            bitmap.UnlockBits(bitmapData);
            return bitmapSource;
        }

        public static System.Windows.Media.PixelFormat Convert(this System.Drawing.Imaging.PixelFormat pixelFormat)
        {
            if (pixelFormat == System.Drawing.Imaging.PixelFormat.Format16bppGrayScale)
                return System.Windows.Media.PixelFormats.Gray16;
            if (pixelFormat == System.Drawing.Imaging.PixelFormat.Format16bppRgb555)
                return System.Windows.Media.PixelFormats.Bgr555;
            if (pixelFormat == System.Drawing.Imaging.PixelFormat.Format16bppRgb565)
                return System.Windows.Media.PixelFormats.Bgr565;

            if (pixelFormat == System.Drawing.Imaging.PixelFormat.Indexed)
                return System.Windows.Media.PixelFormats.Bgr101010;
            if (pixelFormat == System.Drawing.Imaging.PixelFormat.Format1bppIndexed)
                return System.Windows.Media.PixelFormats.Indexed1;
            if (pixelFormat == System.Drawing.Imaging.PixelFormat.Format4bppIndexed)
                return System.Windows.Media.PixelFormats.Indexed4;
            if (pixelFormat == System.Drawing.Imaging.PixelFormat.Format8bppIndexed)
                return System.Windows.Media.PixelFormats.Indexed8;

            //if (pixelFormat == System.Drawing.Imaging.PixelFormat.Format16bppArgb1555)
            //    return System.Windows.Media.PixelFormats.Bgr101010;

            if (pixelFormat == System.Drawing.Imaging.PixelFormat.Format24bppRgb)
                return System.Windows.Media.PixelFormats.Bgr24;

            if (pixelFormat == System.Drawing.Imaging.PixelFormat.Format32bppArgb)
                return System.Windows.Media.PixelFormats.Bgra32;
            if (pixelFormat == System.Drawing.Imaging.PixelFormat.Format32bppPArgb)
                return System.Windows.Media.PixelFormats.Pbgra32;
            if (pixelFormat == System.Drawing.Imaging.PixelFormat.Format32bppRgb)
                return System.Windows.Media.PixelFormats.Bgr32;

            if (pixelFormat == System.Drawing.Imaging.PixelFormat.Format48bppRgb)
                return System.Windows.Media.PixelFormats.Rgb48;

            if (pixelFormat == System.Drawing.Imaging.PixelFormat.Format64bppArgb)
                return System.Windows.Media.PixelFormats.Prgba64;

            // TODO :
            //if (pixelFormat == System.Drawing.Imaging.PixelFormat.Alpha)
            //    return System.Windows.Media.PixelFormats.;
            //if (pixelFormat == System.Drawing.Imaging.PixelFormat.Canonical)
            //    return System.Windows.Media.PixelFormats.;
            //if (pixelFormat == System.Drawing.Imaging.PixelFormat.DontCare)
            //    return System.Windows.Media.PixelFormats.;
            //if (pixelFormat == System.Drawing.Imaging.PixelFormat.Extended)
            //    return System.Windows.Media.PixelFormats.;
            //if (pixelFormat == System.Drawing.Imaging.PixelFormat.Gdi)
            //    return System.Windows.Media.PixelFormats.Default;
            //if (pixelFormat == System.Drawing.Imaging.PixelFormat.Max)
            //    return System.Windows.Media.PixelFormats.Default;
            //if (pixelFormat == System.Drawing.Imaging.PixelFormat.PAlpha)
            //    return System.Windows.Media.PixelFormats.Default;

            if (pixelFormat == System.Drawing.Imaging.PixelFormat.Undefined)
                return System.Windows.Media.PixelFormats.Default;

            throw new NotSupportedException("Convertion not supported with " + pixelFormat.ToString());
        }

        public static System.Drawing.Imaging.PixelFormat Convert(this System.Windows.Media.PixelFormat pixelFormat)
        {
            if (pixelFormat == System.Windows.Media.PixelFormats.Gray16)
                return System.Drawing.Imaging.PixelFormat.Format16bppGrayScale;
            if (pixelFormat == System.Windows.Media.PixelFormats.Bgr555)
                return System.Drawing.Imaging.PixelFormat.Format16bppRgb555;
            if (pixelFormat == System.Windows.Media.PixelFormats.Bgr565)
                return System.Drawing.Imaging.PixelFormat.Format16bppRgb565;

            if (pixelFormat == System.Windows.Media.PixelFormats.Bgr101010)
                return System.Drawing.Imaging.PixelFormat.Indexed;
            if (pixelFormat == System.Windows.Media.PixelFormats.Indexed1)
                return System.Drawing.Imaging.PixelFormat.Format1bppIndexed;
            if (pixelFormat == System.Windows.Media.PixelFormats.Indexed4)
                return System.Drawing.Imaging.PixelFormat.Format4bppIndexed;
            if (pixelFormat == System.Windows.Media.PixelFormats.Indexed8)
                return System.Drawing.Imaging.PixelFormat.Format8bppIndexed;

            //if (pixelFormat == System.Drawing.Imaging.PixelFormat.Format16bppArgb1555)
            //    return System.Windows.Media.PixelFormats.Bgr101010;

            if (pixelFormat == System.Windows.Media.PixelFormats.Bgr24)
                return System.Drawing.Imaging.PixelFormat.Format24bppRgb;

            if (pixelFormat == System.Windows.Media.PixelFormats.Bgr32)
                return System.Drawing.Imaging.PixelFormat.Format32bppArgb;
            if (pixelFormat == System.Windows.Media.PixelFormats.Pbgra32)
                return System.Drawing.Imaging.PixelFormat.Format32bppPArgb;
            if (pixelFormat == System.Windows.Media.PixelFormats.Bgr32)
                return System.Drawing.Imaging.PixelFormat.Format32bppRgb;

            if (pixelFormat == System.Windows.Media.PixelFormats.Rgb48)
                return System.Drawing.Imaging.PixelFormat.Format48bppRgb;

            if (pixelFormat == System.Windows.Media.PixelFormats.Prgba64)
                return System.Drawing.Imaging.PixelFormat.Format64bppArgb;

            // TODO :
            //if (pixelFormat == System.Windows.Media.PixelFormats.)
            //    return System.Drawing.Imaging.PixelFormat.Alpha;
            //if (pixelFormat == System.Windows.Media.PixelFormats.)
            //    return System.Drawing.Imaging.PixelFormat.Canonical;
            //if (pixelFormat == System.Windows.Media.PixelFormats.)
            //    return System.Drawing.Imaging.PixelFormat.DontCare;
            //    return System.Windows.Media.PixelFormats.;
            //if (pixelFormat == System.Windows.Media.PixelFormats.)
            //    return System.Drawing.Imaging.PixelFormat.Extended;
            //if (pixelFormat == System.Windows.Media.PixelFormats.)
            //    return System.Drawing.Imaging.PixelFormat.Gdi;
            //if (pixelFormat == System.Windows.Media.PixelFormats.)
            //    return System.Drawing.Imaging.PixelFormat.Max;
            //if (pixelFormat == System.Windows.Media.PixelFormats.)
            //    return System.Drawing.Imaging.PixelFormat.PAlpha;
            //if (pixelFormat == System.Windows.Media.PixelFormats.)
            //    return System.Drawing.Imaging.PixelFormat.Undefined;

            if (pixelFormat == System.Windows.Media.PixelFormats.Default)
                return System.Drawing.Imaging.PixelFormat.Undefined;

            throw new NotSupportedException("Convertion not supported with " + pixelFormat.ToString());
        }
    }
}
