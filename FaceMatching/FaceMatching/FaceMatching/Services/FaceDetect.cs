
using System.Drawing;
using System.IO;
using System.Linq;
using FaceRecognitionDotNet;
using OpenCvSharp;

namespace FaceMatching.Services
{  
    public class FaceDetect
    {
        #region Variables
        private static readonly FaceRecognition _faceRecognition = FaceRecognition.Create(Path.GetFullPath("models"));
        private static string modelPath = @".\models\";
        #endregion

        #region Getters/Setters
        public static Bitmap SmallImage { get; set; }
        #endregion

        public static Bitmap DetectFaces(Mat MatImage)
        {
            Enum.TryParse<Model>(modelPath, out var model);
            return DetectFaces(MatImage, model);
        }

        public static Bitmap DetectFaces(Mat MatImage, Model model)
        {
            Bitmap bitmapImage = Helpers.ConvertersHelper.MatToBitmap(MatImage);

            using (var faceRecimage = FaceRecognition.LoadImage(bitmapImage))
            {
                var faceLocations = _faceRecognition.FaceLocations(faceRecimage, 0, model).ToArray();

                //var faces = FaceRecognition.CropFaces(faceRecimage, faceLocations);

                if (faceLocations.Count() > 0)
                {
                    foreach(var faceLocation in faceLocations)
                    {
                        using (Graphics graphics = Graphics.FromImage(bitmapImage))
                        {
                            using (Pen pen = new Pen(Color.Red))
                            {  
                                var pt1 = new System.Drawing.Point(faceLocation.Left, faceLocation.Top);
                                var pt2 = new System.Drawing.Size(faceLocation.Right - faceLocation.Left, faceLocation.Bottom - faceLocation.Top);
                                SmallImage = Helpers.ImageManipulation.ResizeBitmap(
                                    Helpers.ImageManipulation.CropBitmap(bitmapImage, new Rectangle(pt1, pt2)),
                                    250, 250);
                                graphics.DrawRectangle(pen, new Rectangle(pt1, pt2));
                            }
                        }
                    }
                }
                
            }
            return bitmapImage;
        }
    }
}
