using FaceRecognitionDotNet;
using OpenCvSharp;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;

namespace FaceMatching.Services
{
    public class MatchFaces
    {
        #region Variables
        private static readonly FaceRecognition _FaceRecognition = FaceRecognition.Create(Path.GetFullPath("models"));
        private static string path = Directory.GetCurrentDirectory() + @"\SavedImages";
        #endregion
        public static bool MatchFace(Bitmap image)
        {
            string[] folders = Directory.GetDirectories(path, "*", SearchOption.AllDirectories);
            var imageBit = FaceRecognition.LoadImage(image);
            var encodingImage = _FaceRecognition.FaceEncodings(imageBit).ToArray();

            foreach (string folder in folders)
            {
                string[] files = Directory.GetFiles(folder, "*");
                //int cont = 0;

                foreach (string file in files)
                {
                    using (var img = FaceRecognition.LoadImageFile(file))
                    {
                        var facesEncodings = _FaceRecognition.FaceEncodings(img).ToArray();
                        bool flag = false;

                        foreach (var encoding in facesEncodings)
                            foreach(var compareFace in FaceRecognition.CompareFaces(encodingImage, encoding))
                            {
                                var pathName = file.Split('_');
                                var name = pathName[0].ToString().Split('\\').Last();
                                Console.WriteLine("Result: {0}, Name: {1}, IMG: {2}", compareFace, name, file);

                                //string res = "True" + cont.ToString();
                                flag = true;
                                //Cv2.ImShow(res, Helpers.ConvertersHelper.BitmapToMat(img.ToBitmap()));

                            }

                        if (!flag)
                        {
                            //string res = "False" + cont.ToString();
                            //Cv2.ImShow(res, Helpers.ConvertersHelper.BitmapToMat(img.ToBitmap()));
                            Console.WriteLine("Result: False, IMG: {0}", file);
                        }
                        //cont++;
                    }
                }
            }
            return true;
        }
    }
}