using System.Drawing;
using System.IO;
using System.Linq;
using OpenCvSharp;
using OpenCvSharp.Extensions;
using UltraFaceDotNet;

namespace FaceMatching.Services
{  
    public class FaceDetect
    {
        #region Variables
        //private static string modelPath = @".\models\";
        #endregion

        #region Getters/Setters
        public static Bitmap SmallImage { get; set; }
        #endregion

        #region FaceRecognitionDotNet
        //public static Bitmap DetectFaces(Mat MatImage)
        //{
        //    Enum.TryParse<Model>(modelPath, out var model);
        //    return DetectFaces(MatImage, model);
        //}

        //public static Bitmap DetectFaces(Mat MatImage, Model model)
        //{
        //    Bitmap bitmapImage = Helpers.ConvertersHelper.MatToBitmap(MatImage);

        //    using (var faceRecimage = FaceRecognition.LoadImage(bitmapImage))
        //    {
        //        var faceLocations = Form1._FaceRecognition.FaceLocations(faceRecimage, 0, model).ToArray();
        //        //var faces = FaceRecognition.CropFaces(faceRecimage, faceLocations);

        //        if (faceLocations.Count() > 0)
        //        {
        //            foreach (var faceLocation in faceLocations)
        //            {
        //                using (Graphics graphics = Graphics.FromImage(bitmapImage))
        //                {
        //                    using (Pen pen = new Pen(Color.Red))
        //                    {
        //                        var pt1 = new System.Drawing.Point(faceLocation.Left, faceLocation.Top);
        //                        var pt2 = new System.Drawing.Size(faceLocation.Right - faceLocation.Left, faceLocation.Bottom - faceLocation.Top);
        //                        SmallImage = Helpers.ImageManipulation.ResizeBitmap(
        //                            Helpers.ImageManipulation.CropBitmap(bitmapImage, new Rectangle(pt1, pt2)),
        //                            250, 250);
        //                        graphics.DrawRectangle(pen, new Rectangle(pt1, pt2));
        //                    }
        //                }
        //            }
        //        }
        //    }
        //    return bitmapImage;
        //}
        #endregion

        #region UltraFace
        private static UltraFaceParameter _param = new UltraFaceParameter()
        {
            BinFilePath = Path.Combine("models", "RFB-320.bin"),
            ParamFilePath = Path.Combine("models", "RFB-320.param"),
            InputWidth = 320,
            InputLength = 240,
            NumThread = 1,
            ScoreThreshold = .7f
        };

        public static Bitmap DetectFaces(Mat image)
        {
            using (var ultraFace = UltraFace.Create(_param))
            {
                using (var inMat = NcnnDotNet.Mat.FromPixels(image.Data, NcnnDotNet.PixelType.Bgr2Rgb, image.Cols, image.Rows))
                {
                    var faceInfos = ultraFace.Detect(inMat).ToArray();

                    foreach(var face in faceInfos)
                    {
                        SmallImage = Helpers.ImageManipulation.ResizeBitmap(
                            Helpers.ImageManipulation.CropBitmap(image.ToBitmap(), new Rectangle((int)face.X1, (int)face.Y1, (int)face.X2 - (int)face.X1, (int)face.Y2 - (int)face.Y1)),
                            250, 250);

                        image.Rectangle(new Rect((int)face.X1, (int)face.Y1, (int)face.X2 - (int)face.X1, (int)face.Y2 - (int)face.Y1), Scalar.Red);
                    }
                }
                return Helpers.ConvertersHelper.MatToBitmap(image);
            }
        }
        #endregion
    }
}
