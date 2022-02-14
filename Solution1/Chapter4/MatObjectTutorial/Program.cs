using System;
using OpenCvSharp;

namespace MatObjectTutorial
{
    class Program
    {
        static void Main(string[] args)
        {
            //Mat mat = new Mat(30, 40, MatType.CV_8UC3, new Scalar(0, 0, 255));
            //Mat mat1 = new Mat(new Size(140, 230), MatType.CV_8UC3, new Scalar(0, 174, 255));
            //Cv2.ImShow("m", mat);
            //Cv2.ImShow("m1", mat1);

            string path = @"../../../imagedata/lena.jpg";
            Mat colorImage = Cv2.ImRead(path, ImreadModes.Color);

            Cv2.ImShow("original", colorImage);
            //Mat clonedImage = colorImage.Clone();
            //Cv2.ImShow("cloned", clonedImage);


            /*
            Mat anotherClonedImage = new();
            colorImage.CopyTo(anotherClonedImage); -> // Don't working in 4.5 version of OpenCvSharp4 and 4.0 version of OpenCvSharp3 
            Cv2.ImShow("anotherCloned", anotherClonedImage);
            */

            //Mat[] channels;
            //Cv2.Split(colorImage, out channels);
            //Cv2.ImShow("Blue", channels[0]);
            //Cv2.ImShow("Green", channels[1]);
            //Cv2.ImShow("Red", channels[2]);

            //Mat roiImage = new Mat(colorImage, new Rect(50,50,250,250));
            //Cv2.ImShow("Roi", roiImage);

            int numRows = colorImage.Rows;
            int numCols = colorImage.Cols;
            Mat cImage = colorImage.Clone();

            //for(int y = 0; y < numRows; y++)
            //{
            //    for(int x = 0; x < numCols; x++)
            //    {
            //        Vec3b pixel = cImage.Get<Vec3b>(y, x);
            //        byte blue = pixel.Item0;
            //        byte green = pixel.Item1;
            //        byte red = pixel.Item2;

            //        Swap(ref blue, ref red, ref pixel.Item0, ref pixel.Item2); // Ref is a pointer in C

            //        //byte temp = blue;
            //        //pixel.Item0 = red;
            //        //pixel.Item2 = temp;

            //        cImage.Set<Vec3b>(y, x, pixel);
            //    }
            //}

            //Cv2.ImShow("Swapped", cImage);


            var indexer = cImage.GetGenericIndexer<Vec3b>();

            for (int y = 100; y < numRows - 100; y++)
            {
                for (int x = 100; x < numCols - 100; x++)
                {
                    Vec3b pixel = indexer[y, x];
                    byte blue = pixel.Item0;
                    byte green = pixel.Item1;
                    byte red = pixel.Item2;

                    Swap(ref blue, ref red, ref pixel.Item0, ref pixel.Item2); // Ref is a pointer in C

                    //byte temp = blue;
                    //pixel.Item0 = red;
                    //pixel.Item2 = temp;

                    indexer[y, x] = pixel;
                }
            }


            //MatOfByte3 mat3 = new MatOfByte3(cImage); -> This class is not disponible in 4.5 version of OpenCvSharp4 and 4.0 version of OpenCvSharp3
            //var indexer = mat3.GetIndexer();
            //for (int y = 100; y < numRows - 100; y++)
            //{
            //    for (int x = 100; x < numCols - 100; x++)
            //    {
            //        Vec3b pixel = indexer[y, x];
            //        byte blue = pixel.Item0;
            //        byte green = pixel.Item1;
            //        byte red = pixel.Item2;

            //        Swap(ref blue, ref red, ref pixel.Item0, ref pixel.Item2); // Ref is a pointer in C

            //        //byte temp = blue;
            //        //pixel.Item0 = red;
            //        //pixel.Item2 = temp;

            //        indexer[y, x] = pixel;
            //    }
            //}

            Cv2.ImShow("Swapped", cImage);


            Cv2.WaitKey();
            Cv2.DestroyAllWindows();
        }

        static void Swap(ref byte blue,ref byte red, ref byte item, ref byte item1)
        {
            byte temp = blue;
            item = red;
            item1 = temp;
        }
    }
}