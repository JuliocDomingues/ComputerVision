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
        private bool chooseBtn = false;
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

            //Image_UltraFace.DataContext = algorithmsViewModels[Model.AlogrithmType.UltraFace];

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

        private void btnChoose_Click(object sender, EventArgs e)
        {
            chooseBtn = true;
        }

        private void ProcessFrame(Object sender, EventArgs e)
        {
            
            if (chooseBtn)
            {
                using (OpenFileDialog openFD = new OpenFileDialog())
                {
                    if(openFD.ShowDialog() == DialogResult.OK)
                    {
                        txtFileName.Text = Path.GetFileName(openFD.FileName);

                        Bitmap img = Services.FaceDetect.DetectFaces(
                            Helpers.ConvertersHelper.BitmapToMat(
                            new Bitmap(openFD.FileName)));

                        Services.MatchFaces.MatchFace(Services.FaceDetect.SmallImage);
                        Console.WriteLine("********************************************************");
                    }
                }
                chooseBtn = false;
            }

            else
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
        }

        private void picSmallFace_Click(object sender, EventArgs e)
        {

        }

        private void btnSaveDir_Click(object sender, EventArgs e)
        {

            string[] images = Directory.GetFiles("C:\\Users\\estagio.sst17\\Pictures\\imgs", "*.jpg");

           foreach (string image in images)
           {
                var img = new Bitmap(image);

                var nameChoose = image.Split('\\', '_');

                txtFileName.Text = nameChoose[5] + nameChoose[6];

                Bitmap imageChoose = Services.FaceDetect.DetectFaces(
                    Helpers.ConvertersHelper.BitmapToMat(img));

                picFace.Image = imageChoose;
                picSmallFace.Image = Services.FaceDetect.SmallImage;

                Services.SaveImages.SaveImage(Services.FaceDetect.SmallImage, nameChoose[5]);
           }         
        }

    }
}
