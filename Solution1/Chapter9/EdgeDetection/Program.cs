using System;
using OpenCvSharp;

namespace EdgeDetection
{
    class Program
    {
        static void Main(string[] args)
        {
            //int kSize = 3;
            Mat image = Cv2.ImRead(@"../../../imagedata/castle.jpg", ImreadModes.Color);

            //Cv2.CvtColor(image, image, ColorConversionCodes.BGR2GRAY);
            //Cv2.Resize(image, image, new Size(400, 400), 0.8, 0.8, InterpolationFlags.Area);
            ////Mat sobelX = new Mat(image.Rows, image.Cols, MatType.CV_8U);
            ////Mat sobelY = new Mat(image.Rows, image.Cols, MatType.CV_8U);

            //Mat sobelX64 = new Mat(image.Rows, image.Cols, MatType.CV_64F);
            //Mat sobelY64 = new Mat(image.Rows, image.Cols, MatType.CV_64F);

            ////Cv2.Sobel(image, sobelX, MatType.CV_8U, 1, 0, kSize);
            ////Cv2.Sobel(image, sobelY, MatType.CV_8U, 0, 1, kSize);

            //Cv2.Sobel(image, sobelX64, MatType.CV_64F, 1, 0, kSize);
            //Cv2.Sobel(image, sobelY64, MatType.CV_64F, 0, 1, kSize);

            //Mat sobelXY = new();
            //Mat sobelXY64 = new();
            ////Cv2.Add(sobelX, sobelY, sobelXY);

            //Cv2.ConvertScaleAbs(sobelX64, sobelX64);
            //Cv2.ConvertScaleAbs(sobelY64, sobelY64);
            //Cv2.Add(sobelX64, sobelY64, sobelXY64);

            ////Cv2.ImShow("SobelX", sobelX);
            ////Cv2.ImShow("SobelY", sobelY);
            //Cv2.ImShow("Original", image);
            //Cv2.ImShow("SobelXY64", sobelXY64);
            //Cv2.ImShow("SobelY64", sobelY64);
            //Cv2.ImShow("SobelX64", sobelX64);

            //sobelXY64.ConvertTo(sobelXY, MatType.CV_8U);

            //Cv2.ImShow("SobelXYBoth", sobelXY);

            //Mat edgesL1 = new();
            //Mat edgesL2 = new();

            //Cv2.Canny(image, edgesL2, 125, 350, 3, true);
            //Cv2.Canny(image, edgesL1, 125, 350, 3, false);

            //Cv2.ImShow("Original", image);
            //Cv2.ImShow("edgesL1", edgesL1);
            //Cv2.ImShow("edgesL2", edgesL2);

            CannyTrackBarDemo t = new CannyTrackBarDemo(@"../../../imagedata/seychelles.jpg", 100);
            t.TrackBar();

            Cv2.WaitKey();
            Cv2.DestroyAllWindows();
        }
    }
}