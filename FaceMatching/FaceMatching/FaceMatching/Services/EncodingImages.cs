using FaceRecognitionDotNet;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;

namespace FaceMatching.Services
{
    public class EncodingImages
    {
        public static void EncodingImg(Bitmap image, string name)
        {
            var imageBit = FaceRecognition.LoadImage(image);
            var encodingImage = Form1._FaceRecognition.FaceEncodings(imageBit, model: Model.Cnn).ToArray();

            var dest = $"{Form1.pathEncoding + @"\" + name + SaveImages.nameIgm}.dat";

            if (!Directory.Exists(Form1.pathEncoding + @"\" + name))
                Directory.CreateDirectory(Form1.pathEncoding + @"\" + name);

            if (File.Exists(dest))
                File.Delete(dest);

            var bf = new BinaryFormatter();
            using (var fs = new FileStream(dest, FileMode.OpenOrCreate))
                bf.Serialize(fs, encodingImage);
        }
    }
}
