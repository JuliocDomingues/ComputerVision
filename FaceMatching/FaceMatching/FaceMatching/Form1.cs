using System;
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

        private void ProcessFrame(Object sender, EventArgs e)
        {
            imageMat = _videoCapture.RetrieveMat();

            picFace.Image = Services.FaceDetect.DetectFaces(imageMat);

            picSmallFace.Image = Services.FaceDetect.SmallImage;

            if (saveBtn)
            {
                Services.SaveImages.SaveImage(Services.FaceDetect.SmallImage, txtName.Text);
                saveBtn = false;
            }

        }

        private void picSmallFace_Click(object sender, EventArgs e)
        {

        }
    }
}
