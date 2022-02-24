using System;
using System.Drawing;
using System.Windows.Forms;
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

        public Form1()
        {
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
                Services.MatchFaces.MatchFace(image);
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
