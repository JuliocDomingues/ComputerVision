using System;
using OpenCvSharp;

namespace ContourDetection
{
    class Program
    {
        static void Main(string[] args)
        {
            Mat image = Cv2.ImRead(@"../../../imagedata/opencvlogo.png");

            Point[][] contours = GetAllContours(image);
            Mat imageClone = image.Clone();
            Cv2.DrawContours(imageClone, contours, -1, new Scalar(0, 0, 0), thickness: 3);
            Cv2.ImShow("ContoursClone", imageClone);
            Cv2.ImShow("Contours", image);

            Cv2.WaitKey();
        }

        static Point[][] GetAllContours(Mat image)
        {
            Mat refGray = new();
            Cv2.CvtColor(image, refGray, ColorConversionCodes.BGR2GRAY);

            Mat thresh = new();
            Cv2.Threshold(refGray, thresh, 127, 255, ThresholdTypes.Binary);
            Cv2.FindContours(thresh, out Point[][] contours, out _, RetrievalModes.List, ContourApproximationModes.ApproxSimple);

            return contours;
        }
    }
}