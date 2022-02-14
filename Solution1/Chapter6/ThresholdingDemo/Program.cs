using System;
using OpenCvSharp;

namespace ThresholdingDemo
{
    class Program
    {
        static void Main(string[] args) 
        {
            //Mat img = Cv2.ImRead(@"../../../imagedata/messi5.jpg", ImreadModes.Color);
            //Cv2.ImShow("Original", img);

            Mat leaf = Cv2.ImRead(@"../../../imagedata/leaf.jpg", ImreadModes.Color);

            //Mat threshold = new Mat(new Size(img.Width, img.Height), MatType.CV_8UC3, new Scalar(0));
            //Cv2.Threshold(img, threshold, 15, 255, ThresholdTypes.Binary);
            //Cv2.ImShow("Thresh", threshold);

            //Mat threshold = new();
            //Mat grayscaled = new();
            //Cv2.CvtColor(img, grayscaled, ColorConversionCodes.BGR2GRAY);
            //Cv2.Threshold(grayscaled, threshold, 15, 255, ThresholdTypes.Binary);
            //Cv2.ImShow("CvtColor", threshold);

            //Mat adaptive = new();
            //Cv2.AdaptiveThreshold(grayscaled, adaptive, 255, AdaptiveThresholdTypes.GaussianC, ThresholdTypes.Binary, 11, 1);
            //Cv2.ImShow("Adaptive", adaptive);

            Mat grayscaledLeaf = new();
            Cv2.ImShow("leaf", leaf);

            Cv2.CvtColor(leaf, grayscaledLeaf, ColorConversionCodes.BGR2GRAY);
            Cv2.ImShow("gray leaf", grayscaledLeaf);

            Mat otsu = new();
            Cv2.Threshold(grayscaledLeaf, otsu, 0, 255, ThresholdTypes.Otsu | ThresholdTypes.Binary);
            Cv2.ImShow("Otsu", otsu);
            Cv2.ImWrite("otsu.jpg", otsu);

            Cv2.WaitKey();
            Cv2.DestroyAllWindows();
        }
    }
}