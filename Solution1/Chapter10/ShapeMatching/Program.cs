using System;
using OpenCvSharp;

namespace ShapeMatching
{
    class Program
    {
        static void Main(string[] args)
        {
            Mat image1 = Cv2.ImRead(@"../../../imagedata/star.png");
            Mat image2 = Cv2.ImRead(@"../../../imagedata/shapes.png");

            var refContour = GetRefContour(image1);
            var inputContours = GetAllContours(image2);

            Point[]? closestCountour = null;

            double minDist = 0.0;
            Mat contourImg = image2.Clone();

            Cv2.ImShow("Contours", contourImg);
            Cv2.ImShow("Ref", image1);

            int i = 0;

            foreach(var contour in inputContours)
            {
                double ret = Cv2.MatchShapes(refContour, contour, ShapeMatchModes.I3);
                Console.WriteLine("Contour {0} mathcs in {1}", i, ret);
                if (minDist == 0.0 | ret < minDist) 
                { 
                    minDist = ret; 
                    closestCountour = contour;
                }
                i++;
            }
            Console.WriteLine("Chosen {0}", minDist);
            Cv2.DrawContours(image2, new Point[][] { closestCountour }, 0, new Scalar(0, 0, 0), thickness: 3);
            Cv2.ImShow("Best Matching", image2);
            Cv2.WaitKey();

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

        static Point[] GetRefContour(Mat image)
        {
            var contours = GetAllContours(image);

            foreach(var contour in contours)
            {
                var area = Cv2.ContourArea(contour);
                var imgArea = image.Width * image.Height;
                var ratio = area / (float)imgArea;
                if (ratio > 0.10 && ratio < 0.8)
                    return contour;
            }
            return contours[0];
        }
    }
}