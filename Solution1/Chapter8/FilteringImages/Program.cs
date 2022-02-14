using System;
using OpenCvSharp;

namespace FilteringImages
{
    class Program
    {
        static void Main(string[] args)
        {
            Mat image = Cv2.ImRead(@"../../../imagedata/castle.jpg", ImreadModes.Color);
            var kernel3x3 = Mat.Ones(new Size(3, 3), MatType.CV_32F) / 9;
            var kernel5x5 = Mat.Ones(new Size(5, 5), MatType.CV_32F) / 25;
            Mat result3x3 = new();
            Mat result5x5 = new();
            Mat container = new Mat(image.Height, 3 * (image.Width) + 20 * 2, MatType.CV_8UC3);
            Mat container1 = new Mat(image.Height, 3 * (image.Width) + 40, MatType.CV_8UC3);

            Cv2.Filter2D(image, result3x3, -1, kernel3x3);
            Cv2.Filter2D(image, result5x5, -1, kernel5x5);

            container[new Rect(new Point(0, 0), new Size(image.Width, image.Height))] = image;
            container[new Rect(new Point(image.Width + 20, 0), new Size(image.Width, image.Height))] = result3x3;
            container[new Rect(new Point(2 * image.Width + 40, 0), new Size(image.Width, image.Height))] = result5x5;

            Cv2.ImShow("Side by Side", container);

            Mat result5x5Gaus = new();
            Mat result5x5Blur = new();
            Cv2.Blur(image, result5x5Blur, new Size(5, 5));
            container1[new Rect(new Point(0, 0), new Size(image.Width, image.Height))] = image;
            container1[new Rect(new Point(image.Width + 20, 0), new Size(image.Width, image.Height))] = result5x5Blur;

            Cv2.GaussianBlur(image, result5x5Gaus, new Size(5, 5), 1.5, 1.5);
            container1[new Rect(new Point(2 * image.Width + 40, 0), new Size(image.Width, image.Height))] = result5x5Gaus;

            Cv2.ImShow("Castel original and blurred and gaussian", container1);

            Cv2.WaitKey();
            Cv2.DestroyAllWindows();
        }
    }
}
