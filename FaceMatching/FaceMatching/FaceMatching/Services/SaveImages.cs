using System;
using System.Drawing;
using System.IO;

namespace FaceMatching.Services
{
    public class SaveImages
    {
        #region Getters/Setters
        public static string nameIgm { get; private set; }
        #endregion

        public static void SaveImage(Bitmap image, string name)
        {
            nameIgm = @"\" + name + "_" + DateTime.Now.ToString("dd-mm-yyyy-hh-mm-ss");

            if (!Directory.Exists(Form1.path + @"\" + name))
                Directory.CreateDirectory(Form1.path + @"\" + name);

            image.Save(Form1.path + @"\" + name + nameIgm + ".jpg");

            EncodingImages.EncodingImg(image, name);
        }
    }
}
