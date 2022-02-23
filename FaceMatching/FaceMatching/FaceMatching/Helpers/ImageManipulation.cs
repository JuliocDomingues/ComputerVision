using System.Drawing;


namespace FaceMatching.Helpers
{
    internal class ImageManipulation
    {
        public static Bitmap CropBitmap(Bitmap image, Rectangle rect)
        {
            Bitmap tmpImage = new Bitmap(image);
            Bitmap cropImage = tmpImage.Clone(rect, tmpImage.PixelFormat);

            return cropImage;
        }

        public static Bitmap ResizeBitmap(Bitmap bmp, int width, int height)
        {
            Bitmap result = new Bitmap(width, height);
            using (Graphics g = Graphics.FromImage(result))
            {
                g.DrawImage(bmp, 0, 0, width, height);
            }

            return result;
        }
    }
}
