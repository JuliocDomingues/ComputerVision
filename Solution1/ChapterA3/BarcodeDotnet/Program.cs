using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenCvSharp;
using ZXing;
using ZXing.Common;
using OpenCvSharp.Extensions;

namespace BarcodeDotnet
{
    class Program
    {
        static void Main(string[] args)
        {

            string fileName = "barcode01.jpg";
            Console.WriteLine("\nProcessing: {0}", fileName);
            Boolean debug = true;
            var image = new Mat(fileName);

            if (debug)
            {
                Cv2.ImShow("Source", image);
                Cv2.WaitKey(1);
            }

            var gray = new Mat();
            var channels = image.Channels();
            if (channels > 1)
            {
                Cv2.CvtColor(image, gray, ColorConversionCodes.BGRA2GRAY);
            }
            else
            {
                image.CopyTo(gray);
            }


            var gradX = new Mat();
            Cv2.Sobel(gray, gradX, MatType.CV_32F, xorder: 1, yorder: 0, ksize: -1);

            var gradY = new Mat();
            Cv2.Sobel(gray, gradY, MatType.CV_32F, xorder: 0, yorder: 1, ksize: -1);

            var gradient = new Mat();
            Cv2.Subtract(gradX, gradY, gradient);
            Cv2.ConvertScaleAbs(gradient, gradient);

            if (debug)
            {
                Cv2.ImShow("Gradient", gradient);
                Cv2.WaitKey(1);
            }

            var blurred = new Mat();
            Cv2.Blur(gradient, blurred, new Size(9, 9));

            double thresh = 210;
            var threshImage = new Mat();
            Cv2.Threshold(blurred, threshImage, thresh, 255, ThresholdTypes.Binary);

            if (debug)
            {
                Cv2.ImShow("Thresh", threshImage);
                Cv2.WaitKey(1);
            }

            var kernel = Cv2.GetStructuringElement(MorphShapes.Rect, new Size(21, 7));
            var closed = new Mat();
            Cv2.MorphologyEx(threshImage, closed, MorphTypes.Close, kernel);

            if (debug)
            {
                Cv2.ImShow("Closed", closed);
                Cv2.WaitKey(1);
            }

            Cv2.Erode(closed, closed, null, iterations: 4);
            Cv2.Dilate(closed, closed, null, iterations: 4);

            if (debug)
            {
                Cv2.ImShow("Erode & Dilate", closed);
                Cv2.WaitKey(1);
            }


            Cv2.FindContours(
                closed,
                out Point[][] contours,
                out HierarchyIndex[] hierarchyIndexes,
                mode: RetrievalModes.External,
                method: ContourApproximationModes.ApproxSimple);

            if (contours.Length == 0)
            {
                throw new NotSupportedException("Couldn't find any object in the image.");
            }

            contours = contours.OrderByDescending(x => Cv2.ContourArea(x)).ToArray();

            var lcr = Cv2.BoundingRect(contours[0]);

            Console.WriteLine("x,y,w,h" + lcr.X + "," + lcr.Y + "," + lcr.Width + "," + lcr.Height);
            var barcode = new Mat(image, lcr);
            Cv2.CvtColor(barcode, barcode, ColorConversionCodes.BGRA2GRAY);

            Cv2.ImShow("Barcode", barcode);
            Cv2.WaitKey(1);


            var barcodeClone = barcode.Clone();
            var barcodeFinal = GetBarcodeContainer(barcodeClone);



            Cv2.Rectangle(image,
                new Point(lcr.X, lcr.Y),
                new Point(lcr.X + lcr.Width, lcr.Y + lcr.Height),
                new Scalar(0, 255, 0),
                2);
            if (debug)
            {
                Cv2.ImShow("Segmented Source", image);
                Cv2.WaitKey(1);
            }
            var result = DecodeBarcode(barcodeFinal.ToBitmap());
            if (!string.IsNullOrWhiteSpace(result))
            {
                Console.WriteLine("Success!");
            }
            else
            {
                Console.WriteLine("Error decoding the barcode!");
            }
            Cv2.WaitKey(0);
            Cv2.DestroyAllWindows();

        }

        private static Mat GetBarcodeContainer(Mat barcode)
        {
            var barcodeContainer = new Mat(new Size(barcode.Width + 30, barcode.Height + 30), MatType.CV_8U, Scalar.White);
            var barcodeRect = new Rect(new Point(15, 15), new Size(barcode.Width, barcode.Height));
            var roi = barcodeContainer[barcodeRect];
            barcode.CopyTo(roi);

            Cv2.ImShow("Enhanced Barcode", barcodeContainer);
            Cv2.WaitKey(1);
            return barcodeContainer;
        }

        private static string DecodeBarcode(System.Drawing.Bitmap barcodeBitmap)
        {
            var source = new BitmapLuminanceSource(barcodeBitmap);

            var reader = new BarcodeReader(null, null, ls => new GlobalHistogramBinarizer(ls))
            {
                AutoRotate = true,
                TryInverted = true,
                Options = new DecodingOptions
                {
                    TryHarder = true
                }
            };

            var result = reader.Decode(source);
            if (result == null)
            {
                Console.WriteLine("Decode failed.");
                return string.Empty;

            }

            Console.WriteLine("BarcodeFormat: {0}", result.BarcodeFormat);
            Console.WriteLine("Result: {0}", result.Text);



            var writer = new BarcodeWriter
            {
                Format = result.BarcodeFormat,
                Options = { Width = 200, Height = 50, Margin = 4 },
                Renderer = new ZXing.Rendering.BitmapRenderer()
            };
            var barcodeImage = writer.Write(result.Text);
            Cv2.ImShow("BarcodeWriter", barcodeImage.ToMat());

            return result.Text;
        }

    }
}
