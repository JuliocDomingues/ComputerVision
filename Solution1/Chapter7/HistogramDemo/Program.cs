using System;
using OpenCvSharp;

namespace HistogramDemo
{
    class Program 
    {
        static void Main(string[] args)
        {
            Mat image = Cv2.ImRead(@"../../../imagedata/lena.jpg", ImreadModes.Grayscale);
            Mat histogram = ComputeHistogram(image);
            PlotHistogram(histogram);
        }

        static Mat ComputeHistogram(Mat image)
        {
            Mat histogram = new();
            Rangef[] ranges = { new Rangef(0, 256), };
            int[] channels = new int[] { 0 };
            int[] hitSize = new int[] { 256 };

            Cv2.CalcHist(new Mat[] { image }, channels, null, histogram, 1, hitSize, ranges);

            return histogram;
        }

        static void PlotHistogram(Mat histogram)
        {
            int plotWidth = 1024, plotHeight = 400;
            int binWidth = (plotWidth / histogram.Rows);
            Mat canvas = new Mat(plotHeight, plotWidth, MatType.CV_8UC3, new Scalar(0, 0, 0));
            Cv2.Normalize(histogram, histogram, 0, plotHeight, NormTypes.MinMax);
            for(int rows = 1; rows < histogram.Rows; ++rows)
            {
                Cv2.Line(canvas,
                new Point((binWidth * (rows - 1)), (plotHeight - (float)(histogram.Get<float>(rows - 1, 0)))),
                new Point(binWidth * rows, (plotHeight - (float)(histogram.Get<float>(rows, 0)))),
                new Scalar(125, 125, 125), 2);//.At substitute for .Get 
            }
            Cv2.ImShow("Histogram", canvas);
            Cv2.WaitKey(0);
            Cv2.DestroyAllWindows();
        }
    }
}