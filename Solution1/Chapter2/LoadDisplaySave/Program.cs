using System;
using OpenCvSharp;

namespace LoadDisplaySave
{
    class Program
    {
        static void Main(string[] args)
        {
            if(args == null)
            {
                Console.WriteLine("Args is null!");
            }
            else
            {
                string fileName = args[0];
                Console.WriteLine(fileName);
                Mat image = Cv2.ImRead(fileName, ImreadModes.Grayscale);
                Cv2.ImShow("Lena", image);
                Cv2.ImWrite(@"../../../imagedata/savedLena.jpg", image);
                Cv2.WaitKey();
                Cv2.DestroyAllWindows();
            }
        }
           
    }
}
