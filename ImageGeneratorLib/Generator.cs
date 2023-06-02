using System.Runtime.InteropServices;
using System.Drawing;
using SixLabors.ImageSharp.Formats.Jpeg;
using Color = SixLabors.ImageSharp.Color;
using SixLabors.ImageSharp.Formats.Png;

namespace ImageGeneratorLib
{
    public static class Generator
    {
        public static string GetOs()
        {
            return RuntimeInformation.OSDescription;
        }

        public static string GetRnd()
        {
            return new Random().Next().ToString();
        }

        public static string GetImage()
        {
            Bitmap bitmap = new Bitmap(1000, 800, System.Drawing.Imaging.PixelFormat.Format32bppPArgb);
            Graphics graphics = Graphics.FromImage(bitmap);

            using var ms = new MemoryStream();

            bitmap.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);

            return Convert.ToBase64String(ms.GetBuffer());
        }

        public static string GetImageImageSharp()
        {
            int width = 640;
            int height = 480;

            using var ms = new MemoryStream();
            using Image<Rgba32> image = new(width, height);
            image.Mutate(x => x.BackgroundColor(Color.FromRgb(12, 152, 0)));


            image.Save(ms, new PngEncoder());

            return Convert.ToBase64String(ms.GetBuffer());

        }
    }
}