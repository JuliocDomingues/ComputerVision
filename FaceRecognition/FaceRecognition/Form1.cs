using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OpenCvSharp;
using OpenCvSharp.Extensions;
using FaceRecognitionDotNet;
using Emgu.CV;
using Emgu.CV.Structure;


namespace FaceDetection
{
    public partial class Form1 : Form
    {
        

        #region Variables
        private VideoCapture _capture = null;
        OpenCvSharp.Mat _frame = new OpenCvSharp.Mat();
        private bool detectFace = false;
        private bool addPerson = false;
        private bool savePerson = false;
        private Emgu.CV.CascadeClassifier mCascadeClassifier;
        private OpenCvSharp.Mat smallFace = new OpenCvSharp.Mat();
        private FaceRecognitionDotNet.FaceRecognition mFaceRecognition;
        private string path;
        private string git;
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
            mCascadeClassifier = new Emgu.CV.CascadeClassifier("haarcascade_frontalface_alt.xml");
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
            _frame = GetFrame(_capture, 1.0);
            _capture.Retrieve(_frame, 0);

            Bitmap bitmap = new Bitmap(MatToBitmap(_frame));

            if (detectFace)
            {   
                Rectangle[] rectangles = DetectFaces(bitmap);

                if(rectangles.Count() > 0)
                {
                    foreach(Rectangle rect in rectangles)
                    { 
                        if (addPerson)
                        {
                            imgFace.Image = ResizeBitmap(CropBitmap(bitmap, rect), imgFace.Width, imgFace.Height);
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
                        else
                        {
                            using (Graphics graphics = Graphics.FromImage(bitmap))
                            {
                                using (Pen pen = new Pen(Color.Red, 1))
                                {
                                    graphics.DrawRectangle(pen, rect);
                                }
                            }
                        }
                    }
                }
            }
            imgCapture.Image = bitmap;
        }

        private Rectangle[] DetectFaces(Bitmap currentFrame)
        {
            Image<Bgr, Byte> grayImage = new Image<Bgr, Byte>(currentFrame);
            Rectangle[] rectangles = mCascadeClassifier.DetectMultiScale(grayImage, 1.1, 3);

            return rectangles;
        }

        #endregion

        #region Helper Functions

        public Bitmap ResizeBitmap(Bitmap bmp, int width, int height)
        {
            Bitmap result = new Bitmap(width, height);
            using (Graphics g = Graphics.FromImage(result))
            {
                g.DrawImage(bmp, 0, 0, width, height);
            }

            return result;
        }

        private static Bitmap CropBitmap(Bitmap image, Rectangle rect)
        {
            Bitmap tmpImage = new Bitmap(image);
            Bitmap cropImage = tmpImage.Clone(rect, tmpImage.PixelFormat);

            return cropImage;
        }

        private static Bitmap MatToBitmap(OpenCvSharp.Mat mat)
        {
            return OpenCvSharp.Extensions.BitmapConverter.ToBitmap(mat);
        }
        private static OpenCvSharp.Mat GetFrame(VideoCapture cap, double scalingFactor)
        {
            OpenCvSharp.Mat frame = new OpenCvSharp.Mat();
            bool ret = cap.Read(frame);
            Cv2.Resize(frame, frame, new OpenCvSharp.Size(), fx: scalingFactor, fy: scalingFactor, interpolation: InterpolationFlags.Area);
            return frame;
        }
        #endregion

    }
}
