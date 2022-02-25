using DlibDotNet;
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
        public static bool MatchFace(Bitmap image)
        {
            string[] folders = Directory.GetDirectories(Form1.pathEncoding, "*", SearchOption.AllDirectories);

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
                        bool flag = false;

                        foreach (var encoding in facesEncodings)
                            foreach(var compareFace in FaceRecognition.CompareFaces(encodingImage, encoding))
                            {
                                var pathName = file.Split('_');
                                var name = pathName[0].ToString().Split('\\').Last();

                                if (compareFace)
                                    Console.WriteLine("Result: {0}, Name: {1}, IMG: {2}", compareFace, name, file);
                                else
                                    Console.WriteLine("Result: {0}, Name: Unknown, IMG: {1}", compareFace, file);

                                flag = true;
                            }

                        if (!flag)
                            Console.WriteLine("Result: False, Name: Unknown, IMG: {0}", file);
                    }
                }
            }
            return true;
        }
    }
}