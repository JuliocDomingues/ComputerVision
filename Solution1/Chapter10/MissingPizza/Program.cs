using System;
using OpenCvSharp;

namespace MissingPizza
{
    class Program
    {
        static void Main(string[] args)
        {
            Mat image = Cv2.ImRead(@"../../../imagedata/pizzas.png");
            var contours = GetAllContours(image);
            double factor = 0.01;

            foreach(Point[] contour in contours)
            {
                double epsilon = factor * Cv2.ArcLength(contour, true);
                var contourNew = Cv2.ApproxPolyDP(contour, epsilon, true);
                bool convex = Cv2.IsContourConvex(contourNew);

                if (convex)
                    continue;

                Cv2.DrawContours(image, new Point[][] { contour }, 0, new Scalar(0, 0, 0), thickness: 2);
            }
            Cv2.ImShow("Image", image);
            Cv2.WaitKey();
            Cv2.DestroyAllWindows();
        }

        static Point[][] GetAllContours(Mat image)
        {
            Mat refGray = new();
            Cv2.CvtColor(image, refGray, ColorConversionCodes.BGR2GRAY);

            Mat thresh = new();
            Cv2.Threshold(refGray, thresh, 127, 255, 0);
            Cv2.FindContours(thresh.Clone(), out Point[][] contours, out _, RetrievalModes.List, ContourApproximationModes.ApproxSimple);

            return contours;
        }
    }
}