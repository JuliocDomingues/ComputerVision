using FaceRecognitionDotNet;
using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;

namespace FaceMatching.Services
{
    public class MatchFaces
    {
        #region Math Face
        public static bool MatchFace(Bitmap image)
        {
            string[] folders = Directory.GetDirectories(Form1.pathEncoding, "*", SearchOption.AllDirectories);

            OpenCvSharp.Cv2.CvtColor(Helpers.ConvertersHelper.BitmapToMat(image), Helpers.ConvertersHelper.BitmapToMat(image), OpenCvSharp.ColorConversionCodes.RGB2GRAY);

            var imageBit = FaceRecognition.LoadImage(image);

            var encodingImage = Form1._FaceRecognition.FaceEncodings(imageBit, model: Model.Cnn).ToArray();

            var bf = new BinaryFormatter();

            foreach (string folder in folders)
            {
                string[] files = Directory.GetFiles(folder, "*");

                foreach (string file in files)
                {
                    using (FileStream stream = new FileStream(file, FileMode.Open))
                    {
                        var facesEncodings = (System.Collections.Generic.IEnumerable<FaceEncoding>)bf.Deserialize(stream);

                        //Cosine Similiarity

                        Console.WriteLine("-----------------------Cosine Distance-----------------------");

                        foreach (var encoding in facesEncodings)
                            foreach(var compareFace in Helpers.CosineSimiliarity.CalculateCosine(encodingImage, encoding))
                            {
                                var pathName = file.Split('_');
                                var name = pathName[0].ToString().Split('\\').Last();

                                if (compareFace <= 0.07)
                                    Console.WriteLine("Result: {0}, Name: {1}, IMG: {2}", compareFace, name, file);
                                else
                                    Console.WriteLine("Result: {0}, Name: Unknown, IMG: {1}", compareFace, file);
                            }

                        //Compare Faces

                        Console.WriteLine("-----------------------Compare Faces-----------------------");

                        foreach (var encoding in facesEncodings)
                            foreach (var compareFace in FaceRecognition.CompareFaces(encodingImage, encoding, 0.55))
                            {
                                var pathName = file.Split('_');
                                var name = pathName[0].ToString().Split('\\').Last();

                                if (compareFace)
                                    Console.WriteLine("Result: {0}, Name: {1}, IMG: {2}", compareFace, name, file);
                                else
                                    Console.WriteLine("Result: {0}, Name: Unknown, IMG: {1}", compareFace, file);
                            }
                    }
                }
            }
            return true;
        }
        #endregion
    }
}