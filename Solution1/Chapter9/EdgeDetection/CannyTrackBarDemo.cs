using OpenCvSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EdgeDetection
{
    public class CannyTrackBarDemo
    {
        private Mat src;
        //int maxBinaryValue = 500;
        int minThreshValue;
        CvTrackbar CvTrackbarHTValue;
        CvTrackbar CvTrackbarGradientType;
        Mat srcGray = new();
        Mat dst = new();
        Window MyWindow;

        public CannyTrackBarDemo(string fileName, int minThreshValue)
        {
            src = Cv2.ImRead(fileName, ImreadModes.Color);
            this.minThreshValue = minThreshValue;
        }

        public void TrackBar()
        {
            string trackbarGradientType = "Type";
            Cv2.CvtColor(src, srcGray, ColorConversionCodes.BGR2GRAY);

            MyWindow = new Window("Canny Track", WindowMode.AutoSize);

            CvTrackbarGradientType = MyWindow.CreateTrackbar(trackbarGradientType, 0, 1, CannyEdge);
            CvTrackbarHTValue = MyWindow.CreateTrackbar("HighThreshold", 0, 500, CannyEdge);

            CannyEdge(0);

            while (true)
            {
                int c;
                c = Cv2.WaitKey(20);

                if ((char)c == 27)
                    break;

            }
        }


        public void CannyEdge(int x)
        {
            bool L2 = true;

            if(CvTrackbarGradientType.Pos == 0)
                L2 = false;

            Cv2.Canny(srcGray, dst, minThreshValue, CvTrackbarHTValue.Pos, 3, L2);

            MyWindow.Image = dst;
        }
    }
}
