using System;
using OpenCvSharp;

namespace MorphologicalOperations
{
    class Program
    {
        static void Main(string[] args)
        {
            Mat image = Cv2.ImRead(@"../../../imagedata/morphology.png");
            //Mat kernel = Mat.Ones(new Size(3, 3), MatType.CV_8U);
            Mat kernel = Cv2.GetStructuringElement(MorphShapes.Ellipse, new Size(3, 3));
            Mat erosion3x3 = new();

            //Cv2.Erode(image, erosion3x3, kernel, iterations: 1);
            Cv2.ImShow("Original", image);
            //Cv2.ImShow("Eroded Once", erosion3x3);

            Cv2.Erode(image, erosion3x3, kernel, iterations: 5);
            Cv2.ImShow("Eroded 5 times", erosion3x3);

            Mat dilation3x3 = new();
            Cv2.Dilate(erosion3x3, dilation3x3, kernel, iterations: 2);
            Cv2.ImShow("Dilation 2 Times", dilation3x3);

            Cv2.WaitKey();
            Cv2.DestroyAllWindows();
        }
    }
}