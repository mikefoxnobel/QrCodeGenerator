using System.Drawing;
using QrCodeGenerator.Models;
using QRCoder;

namespace QrCodeGenerator.Helpers
{
    public interface IQrCodeHelper
    {
        QrGeneralConfiguration Config { get; set; }
        Bitmap GenerateQrBitmap(PayloadGenerator.Payload payload);
        Bitmap GenerateQrBitmap(string text);
        Bitmap GenerateAndSaveQrBitmap(string text, string filename);
        Bitmap GenerateAndSaveQrBitmap(PayloadGenerator.Payload payload, string filename);
    }
}