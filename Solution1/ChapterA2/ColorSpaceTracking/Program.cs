using System;
using OpenCvSharp;

namespace ColorSpaceTracking
{
    class Program
    {
        static void Main(string[] args)
        {
            var cap = new VideoCapture(0);
            double scalingFactor = 1.0;

            var lower = new Scalar(80, 40, 40);
            var upper = new Scalar(120, 255, 255);

            while (true)
            {
                var frame = GetFrame(cap, scalingFactor);

                Mat hsvFrame = new();
                Cv2.CvtColor(frame, hsvFrame, ColorConversionCodes.BGR2HSV);

                Mat mask = new();
                Cv2.InRange(hsvFrame, lower, upper, mask);

                Mat res = new();
                Cv2.BitwiseAnd(frame, frame, res, mask: mask);
                Cv2.MedianBlur(res, res, ksize: 5);

                Cv2.ImShow("Original image", frame);
                Cv2.ImShow("Color Detector", res);

                var c = Cv2.WaitKey(10);

                if (c == 27)
                    break;
            }
            Cv2.DestroyAllWindows();
        }

        private static Mat GetFrame(VideoCapture cap, double scalingFactor)
        {
            Mat frame = new();
            bool ret = cap.Read(frame);
            Cv2.Resize(frame, frame, new Size(), fx: scalingFactor, fy: scalingFactor, interpolation: InterpolationFlags.Area);
            return frame;
        }   
    }
}