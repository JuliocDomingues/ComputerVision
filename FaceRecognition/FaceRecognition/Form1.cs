using System;
using System.Linq;
using System.Windows.Forms;
using System.IO;
using OpenCvSharp;
using OpenCvSharp.Extensions;
using FaceRecognitionDotNet;
using CenterFaceDotNet;
using NcnnDotNet.OpenCV;
using System.Drawing;

namespace FaceDetection
{
    public partial class Form1 : Form
    {
        

        #region Variables
        private VideoCapture _capture = null;
        private bool detectFace = false;
        private bool addPerson = false;
        private bool savePerson = false;
        string path;
        OpenCvSharp.Mat image;
        OpenCvSharp.Mat currentFrame;
        Bitmap smallImage;

        //CenterFaceParameter param = new CenterFaceParameter
        //{
        //    BinFilePath = Directory.GetCurrentDirectory() + @"\centerface.bin",
        //    ParamFilePath = Directory.GetCurrentDirectory() + @"\centerface.param"
        //};

        private CenterFaceDotNet.CenterFace _centerFace = CenterFace.Create(new CenterFaceParameter
        {
            BinFilePath = Directory.GetCurrentDirectory() + @"\centerface.bin",
            ParamFilePath = Directory.GetCurrentDirectory() + @"\centerface.param"
        });


        #endregion

        #region Constructor
        public Form1()
        {
            InitializeComponent();
        }
        #endregion

        #region Functionalities
        private void imgCapture_Click(object sender, EventArgs e)
        {
            //Main Screen
        }

        private void btnCapture_Click(object sender, EventArgs e)
        {
            _capture = new VideoCapture(0);
            //mCascadeClassifier = new Emgu.CV.CascadeClassifier("haarcascade_frontalface_alt.xml");
            Application.Idle += ProcessFrame;
        }

        private void btnDetectFace_Click(object sender, EventArgs e)
        {
            detectFace = true;
        }

        private void btnAddFace_Click(object sender, EventArgs e)
        {
            addPerson = true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            savePerson = true;
        }
        #endregion

        #region Processing Functions
        private void ProcessFrame(object sender, EventArgs e)
        {
            image = GetFrame(_capture, 1.0);

            if (detectFace)
            {
                DetectFaces(image);

                if (addPerson)
                {
                    imgFace.Image = smallImage;

                    if (savePerson)
                    {
                        path = Directory.GetCurrentDirectory() + @"\SavedImages";

                        if (!Directory.Exists(path))
                            Directory.CreateDirectory(path);

                        imgFace.Image.Save(path + @"\" + txtName.Text + "_" + DateTime.Now.ToString("dddd, dd MMMM yyyy HH-mm-ss") + ".jpg");
                        savePerson = false;
                        addPerson = false;
                        imgFace.Image = null;
                    }
                }
            }

            imgCapture.Image = image.ToBitmap();
            #region Stopped
            //Bitmap bitmap = new Bitmap(MatToBitmap(_frame));

            //if (detectFace)
            //{   
            //    Rectangle[] rectangles = DetectFaces(bitmap);

            //    if(rectangles.Count() > 0)
            //    {
            //        foreach(Rectangle rect in rectangles)
            //        { 
            //            if (addPerson)
            //            {
            //                imgFace.Image = ResizeBitmap(CropBitmap(bitmap, rect), imgFace.Width, imgFace.Height);
            //                if (savePerson)
            //                {
            //                    path = Directory.GetCurrentDirectory() + @"\SavedImages";

            //                    if (!Directory.Exists(path))
            //                        Directory.CreateDirectory(path);

            //                    imgFace.Image.Save(path + @"\" + txtName.Text + "_" + DateTime.Now.ToString("dddd, dd MMMM yyyy HH-mm-ss") + ".jpg");
            //                    savePerson = false;
            //                    addPerson = false;
            //                    imgFace.Image = null;
            //                }
            //            }
            //            else
            //            {
            //                using (Graphics graphics = Graphics.FromImage(bitmap))
            //                {
            //                    using (Pen pen = new Pen(Color.Red, 1))
            //                    {
            //                        graphics.DrawRectangle(pen, rect);
            //                    }
            //                }
            //            }
            //        }
            //    }
            //}
            #endregion
        }

        private void DetectFaces(OpenCvSharp.Mat image)
        {
            #region Variables
            //var binPath = Directory.GetCurrentDirectory() + @"\centerface.bin";
            //var paramPath = Directory.GetCurrentDirectory() + @"\centerface.param";


            //var param = new CenterFaceParameter
            //{
            //    BinFilePath = binPath,
            //    ParamFilePath = paramPath
            //};
            #endregion

            //using (var centerFace = CenterFace.Create(param))
            //{
            var inMat = NcnnDotNet.Mat.FromPixels(image.Data, NcnnDotNet.PixelType.Bgr2Gray, image.Cols, image.Rows);
            var faceInfos = _centerFace.Detect(inMat, image.Cols, image.Rows).ToArray();

            if (!addPerson) 
            { 
                foreach (FaceInfo face in faceInfos)
                {
                    var pt1 = new OpenCvSharp.Point(face.X1, face.Y1);
                    var pt2 = new OpenCvSharp.Point(face.X2, face.Y2);
                    OpenCvSharp.Cv2.Rectangle(image, pt1, pt2, new Scalar(0, 255, 0), 2);

                    for (var j = 0; j < 5; j++)
                    {
                        var center = new OpenCvSharp.Point(face.Landmarks[2 * j], face.Landmarks[2 * j + 1]);
                        OpenCvSharp.Cv2.Circle(image, center, 2, new Scalar(255, 255, 0), 2);
                    }
                }
            }
            else
            {
                foreach (FaceInfo face in faceInfos)
                {
                    var pt1 = new System.Drawing.Point((int)face.X1, (int)face.Y1);
                    var size = new System.Drawing.Size((int)(face.X2 - face.X1), (int)(face.Y2 - face.Y1));

                    smallImage = ResizeBitmap(CropBitmap(image.ToBitmap(), new Rectangle(pt1, size)), imgFace.Width, imgFace.Height);
                }
            }
            //}
        }

        private static OpenCvSharp.Mat GetFrame(VideoCapture cap, double scalingFactor)
        {
            OpenCvSharp.Mat frame = new OpenCvSharp.Mat();
            bool ret = cap.Read(frame);
            OpenCvSharp.Cv2.Resize(frame, frame, new OpenCvSharp.Size(), fx: scalingFactor, fy: scalingFactor, interpolation: InterpolationFlags.Area);
            return frame;
        }

        private static Bitmap CropBitmap(Bitmap image, Rectangle rect)
        {
            Bitmap tmpImage = new Bitmap(image);
            Bitmap cropImage = tmpImage.Clone(rect, tmpImage.PixelFormat);

            return cropImage;
        }

        public Bitmap ResizeBitmap(Bitmap bmp, int width, int height)
        {
            Bitmap result = new Bitmap(width, height);
            using (Graphics g = Graphics.FromImage(result))
            {
                g.DrawImage(bmp, 0, 0, width, height);
            }

            return result;
        }
        #endregion

    }
}
