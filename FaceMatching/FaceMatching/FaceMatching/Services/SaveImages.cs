using System;
using System.Drawing;
using System.IO;

namespace FaceMatching.Services
{
    public class SaveImages
    {
        #region Getters/Setters
        public static string nameImg { get; private set; }
        #endregion

        #region Save Image
        public static string SaveImage(Bitmap image, string name)
        {
            nameImg = @"\" + name + "_" + DateTime.Now.ToString("dd-mm-yyyy-hh-mm-ss");

            if (!Directory.Exists(Form1.path + @"\" + name))
                Directory.CreateDirectory(Form1.path + @"\" + name);

            image.Save(Form1.path + @"\" + name + nameImg + ".jpg");

            return Form1.path + @"\" + name + nameImg + ".jpg";
            //EncodingImages.EncodingImg(image, name);
        }
        #endregion
    }
}
