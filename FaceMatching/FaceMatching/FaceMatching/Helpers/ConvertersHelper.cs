using OpenCvSharp;
using OpenCvSharp.Extensions;
using System.Drawing;

namespace FaceMatching.Helpers
{
    public class ConvertersHelper
    {
        public static Bitmap MatToBitmap(Mat image)
        {
            Cv2.Resize(image, image, new OpenCvSharp.Size(1280, 720));
            return BitmapConverter.ToBitmap(image);
        }

        public static Mat BitmapToMat(Bitmap image)
        {
            return BitmapConverter.ToMat(image);
        }
    }
}
