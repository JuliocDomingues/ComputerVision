using System;
using OpenCvSharp;

namespace HistogramExercise
{
    class Program
    {
        static void Main(string[] args)
        {
            Mat image = Cv2.ImRead(@"../../../imagedata/lena.jpg", ImreadModes.Color);
            
            Mat[] channels;
            Cv2.Split(image, out channels);

            //Cv2.ImShow("Blue", channels[0]);
            //Cv2.ImShow("Green", channels[1]);
            //Cv2.ImShow("Red", channels[2]);

            Mat histogram = ComputeHistogram(channels[0]);
            Mat histogram1 = ComputeHistogram(channels[1]);
            Mat histogram2 = ComputeHistogram(channels[2]);
            
            PlotHistogram(histogram, histogram1, histogram2);

            Cv2.WaitKey(0);
            Cv2.DestroyAllWindows();
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

        static void PlotHistogram(Mat histogram, Mat histogram1, Mat histogram2)
        {
            int plotWidth = 1024, plotHeight = 400;

            int binWidth = (plotWidth / histogram.Rows);
            Mat canvas = new Mat(plotHeight, plotWidth, MatType.CV_8UC3, new Scalar(0, 0, 0));

            int binWidth1 = (plotWidth / histogram1.Rows);
            Mat canvas1 = new Mat(plotHeight, plotWidth, MatType.CV_8UC3, new Scalar(0, 0, 0));

            int binWidth2 = (plotWidth / histogram2.Rows);
            Mat canvas2 = new Mat(plotHeight, plotWidth, MatType.CV_8UC3, new Scalar(0, 0, 0));

            Cv2.Normalize(histogram, histogram, 0, plotHeight, NormTypes.MinMax);
            Cv2.Normalize(histogram1, histogram1, 0, plotHeight, NormTypes.MinMax);
            Cv2.Normalize(histogram2, histogram2, 0, plotHeight, NormTypes.MinMax);

            for (int rows = 1; rows < histogram.Rows; ++rows)
            {
                Cv2.Line(canvas,
                new Point((binWidth * (rows - 1)), (plotHeight - (float)(histogram.Get<float>(rows - 1, 0)))),
                new Point(binWidth * rows, (plotHeight - (float)(histogram.Get<float>(rows, 0)))),
                new Scalar(255, 0, 0), 2);//.At substitute for .Get
            }

            for(int rows = 1; rows < histogram1.Rows; ++rows)
            {
                Cv2.Line(canvas1,
                new Point((binWidth1 * (rows - 1)), (plotHeight - (float)(histogram1.Get<float>(rows - 1, 0)))),
                new Point(binWidth1 * rows, (plotHeight - (float)(histogram1.Get<float>(rows, 0)))),
                new Scalar(0, 255, 0), 2);
            }

            for (int rows = 1; rows < histogram2.Rows; ++rows)
            {
                Cv2.Line(canvas2,
                new Point((binWidth2 * (rows - 1)), (plotHeight - (float)(histogram2.Get<float>(rows - 1, 0)))),
                new Point(binWidth2 * rows, (plotHeight - (float)(histogram2.Get<float>(rows, 0)))),
                new Scalar(0, 0, 255), 2);
            }

            Mat print =  canvas + canvas1 + canvas2;

            Cv2.ImShow("Histogram", print);
        }
    }
}