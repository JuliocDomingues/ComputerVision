using System;
using System.Drawing;
using System.IO;

namespace FaceMatching.Services
{
    public class SaveImages
    {
        #region Variables
        #endregion

        public static void SaveImage(Bitmap image, string name)
        {
            string path = Directory.GetCurrentDirectory() + @"\SavedImages" + @"\" + name;

            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);

            image.Save(path + @"\" + name + "_" + DateTime.Now.ToString("dd-mm-yyyy-hh-mm-ss") + ".jpg");
        }
    }
}
