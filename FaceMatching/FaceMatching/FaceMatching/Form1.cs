using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using FaceRecognitionDotNet;
using OpenCvSharp;

namespace FaceMatching
{
    public partial class Form1 : Form
    {
        #region Variables
        private VideoCapture _videoCapture;
        private Mat imageMat = new Mat();
        private bool saveBtn = false;
        private bool recognizeBtn = false;
        #endregion

        #region Getters/Setters
        public static FaceRecognition _FaceRecognition { get; private set; } = FaceRecognition.Create(Path.GetFullPath("models"));
        public static string path { get; private set; } = Directory.GetCurrentDirectory() + @"\SavedImages";

        public static string pathEncoding { get; private set; } = Directory.GetCurrentDirectory() + @"\Encodings";
        #endregion

        public Form1()
        {
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);

            if (!Directory.Exists(pathEncoding))
                Directory.CreateDirectory(pathEncoding);

            InitializeComponent();
        }

        private void btnCapture_Click(object sender, EventArgs e)
        {
            _videoCapture = new VideoCapture(0);
            
            Application.Idle += ProcessFrame;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            saveBtn = true;
        }
        private void btnRecognize_Click(object sender, EventArgs e)
        {
            recognizeBtn = true;
        }

        private void ProcessFrame(Object sender, EventArgs e)
        {
            imageMat = _videoCapture.RetrieveMat();

            Bitmap image = Services.FaceDetect.DetectFaces(imageMat);

            if (saveBtn)
            {
                Services.SaveImages.SaveImage(Services.FaceDetect.SmallImage, txtName.Text);
                saveBtn = false;
                
            }

            if (recognizeBtn)
            {
                Services.MatchFaces.MatchFace(Services.FaceDetect.SmallImage);
                Console.WriteLine("********************************************************");
                recognizeBtn = false;
            }

            picFace.Image = image;
            picSmallFace.Image = Services.FaceDetect.SmallImage;

        }

        private void picSmallFace_Click(object sender, EventArgs e)
        {

        }
    }
}
