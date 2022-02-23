using System;
using System.Drawing;
using System.Windows.Forms;
using OpenCvSharp;
using OpenCvSharp.Extensions;
using FaceMatching.Helpers;

namespace FaceMatching
{
    public partial class Form1 : Form
    {
        #region Variables
        private VideoCapture _videoCapture;
        private Mat imageMat = new Mat();

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

        private void ProcessFrame(Object sender, EventArgs e)
        {
            imageMat = _videoCapture.RetrieveMat();

            picFace.Image = Services.FaceDetect.DetectFaces(imageMat);

            picSmallFace.Image = Services.FaceDetect.SmallImage;
        }

    }
}
