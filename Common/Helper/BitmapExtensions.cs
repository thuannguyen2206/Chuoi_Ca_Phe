using QRCoder;
using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using static QRCoder.PayloadGenerator;

namespace Common.Helper
{
    public static class BitmapExtensions
    {
        public static string CreateQRCodeBitMap(string content)
        {
            QRCodeGenerator qrGenerator = new QRCodeGenerator();
            QRCodeData qrCodeData = qrGenerator.CreateQrCode(content, QRCodeGenerator.ECCLevel.Q);
            QRCode qrCode = new QRCode(qrCodeData);
            Bitmap qrCodeImage = qrCode.GetGraphic(20);
            byte[] qrCodeByte = BitmapToByteArray(qrCodeImage);
            return string.Format("data:image/png;base64,{0}", Convert.ToBase64String(qrCodeByte));
        }

        public static string CreateQRCodeBitMapAsUrl(string url)
        {
            Url generator = new Url(url);
            string payload = generator.ToString();

            QRCodeGenerator qrGenerator = new QRCodeGenerator();
            QRCodeData qrCodeData = qrGenerator.CreateQrCode(payload, QRCodeGenerator.ECCLevel.Q);
            QRCode qrCode = new QRCode(qrCodeData);
            var qrCodeAsBitmap = qrCode.GetGraphic(20);
            byte[] qrCodeByte = BitmapToByteArray(qrCodeAsBitmap);
            return string.Format("data:image/png;base64,{0}", Convert.ToBase64String(qrCodeByte));
        }

        private static byte[] BitmapToByteArray(this Bitmap bitmap)
        {
            using MemoryStream stream = new MemoryStream();
            bitmap.Save(stream, ImageFormat.Png);
            return stream.ToArray();
        }

    }
}
