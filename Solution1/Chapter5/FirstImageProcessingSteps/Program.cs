using System;
using OpenCvSharp;

namespace FirstImageProcessingSteps
{
    class Program
    {
        static void Main(string[] args)
        {
            Mat image = Cv2.ImRead(@"../../../imagedata/lena.jpg", ImreadModes.Color);
            Cv2.ImShow("Original", image);
            //string path = @"../../../imagedata/lena.jpg";
            //Mat image = Cv2.ImRead(path, ImreadModes.Color);

            //float[] data = { 1, 0, 50, 0, 1, 50 };
            //Mat M = new Mat(2, 3, MatType.CV_32FC1, data);
            //Mat dest = new Mat();
            //Cv2.WarpAffine(image, dest, M, new Size(image.Width, image.Height));
            //Cv2.ImShow("Shifted", dest);

            //var center = new Point2f(image.Width/2, image.Height/2);
            //double angle = -45.0;
            //Mat RM = Cv2.GetRotationMatrix2D(center, angle, 0.50);
            //Cv2.WarpAffine(image, dest, RM, new Size(image.Width, image.Height));
            //Cv2.ImShow("Rotation", dest);

            //Mat dest = new();
            //Cv2.Resize(image, dest, new Size(image.Width/2, image.Height/2));
            //Cv2.ImShow("Resized1", dest);

            //Mat dest1 = new();
            //Cv2.Resize(image, dest1, new Size(0, 0), 0.5, 0.5);
            //Cv2.ImShow("Resized2", dest1);

            //Mat dst1 = new();
            //Mat dst2 = new();
            //Mat dst3 = new();
            //Cv2.Flip(image, dst1, FlipMode.X);
            //Cv2.Flip(image, dst2, FlipMode.Y);
            //Cv2.Flip(image, dst3, FlipMode.XY);
            //Cv2.ImShow("dst1", dst1);
            //Cv2.ImShow("dst2", dst2);
            //Cv2.ImShow("dst3", dst3);

            Mat image1 = Mat.Zeros(new Size(400, 200), MatType.CV_8UC1);
            Mat image2 = Mat.Zeros(new Size(400, 200), MatType.CV_8UC1);

            Cv2.Rectangle(image1, new Rect(new Point(0, 0), new Size(image1.Cols/2, image1.Rows)), new Scalar(255,255,255), -1);
            Cv2.ImShow("image1", image1);

            Cv2.Rectangle(image2, new Rect(new Point(150, 100), new Size(200, 50)), new Scalar(255, 255, 255), -1);
            Cv2.ImShow("image2", image2);

            Mat andOp = new();
            Cv2.BitwiseAnd(image1, image2, andOp);
            Cv2.ImShow("andPop", andOp);

            Mat orOp = new();
            Cv2.BitwiseOr(image1, image2, orOp);
            Cv2.ImShow("orOp", orOp);

            Mat xorOp = new();
            Cv2.BitwiseXor(image1, image2, xorOp);
            Cv2.ImShow("xorOp", xorOp);

            Mat notOp = new();
            Cv2.BitwiseNot(image1, notOp);
            Cv2.ImShow("notOp", notOp);

            Cv2.WaitKey();
            Cv2.DestroyAllWindows();

        }
    }
}
