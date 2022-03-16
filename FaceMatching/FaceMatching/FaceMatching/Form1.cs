using System;
using System.Drawing;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using FaceRecognitionDotNet;
using OpenCvSharp;

namespace FaceMatching
{
    public partial class Form1 : Form
    {

        #region Paths
        private readonly string pathScriptEncoding = @"C:\Users\estagio.sst17\Documents\studycsharp\ComputerVision\FaceMatching\FaceMatching\FaceMatching\Scripts\EncodingFromDir.py";
        private readonly string pathScriptVerify = @"C:\Users\estagio.sst17\Documents\studycsharp\ComputerVision\FaceMatching\FaceMatching\FaceMatching\Scripts\VerifyDistances.py";
        #endregion

        #region Variables
        private VideoCapture _videoCapture;
        private Mat imageMat = new Mat();
        private bool saveBtn = false;
        private bool recognizeBtn = false;
        private bool chooseBtn = false;
        private bool exeBtn = false;
        #endregion

        #region Getters/Setters
        public static FaceRecognition _FaceRecognition { get; private set; } = FaceRecognition.Create(Path.GetFullPath("models"));
        public static string path { get; private set; } = @"C:\Users\estagio.sst17\Documents\studycsharp\ComputerVision\FaceMatching\FaceMatching\FaceMatching\Results";
        public static string pathEncoding { get; private set; } = Directory.GetCurrentDirectory() + @"\Encodings";
        #endregion

        #region Constructor
        public Form1()
        {
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);

            if (!Directory.Exists(pathEncoding))
                Directory.CreateDirectory(pathEncoding);

            //Image_UltraFace.DataContext = algorithmsViewModels[Model.AlogrithmType.UltraFace];

            InitializeComponent();
        }
        #endregion

        #region Buttons
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
        #endregion

        #region Process Frame
        private void ProcessFrame(Object sender, EventArgs e)
        {

            if (chooseBtn)
            {
                using (OpenFileDialog openFD = new OpenFileDialog())
                {
                    if (openFD.ShowDialog() == DialogResult.OK)
                    {
                        txtFileName.Text = Path.GetFileName(openFD.FileName);

                        Cv2.ImShow("img", Helpers.ConvertersHelper.BitmapToMat(
                            new Bitmap(openFD.FileName)));

                        Bitmap img = Services.FaceDetect.DetectFaces(
                            Helpers.ConvertersHelper.BitmapToMat(
                            new Bitmap(openFD.FileName)));

                        var name = txtFileName.Text.Split('_');
                        Services.SaveImages.SaveImage(Services.FaceDetect.SmallImage, name[0]);
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

                if (btnExec.Enabled == true && Services.FaceDetect.SmallImage != null)
                {
                    btnExec.PerformClick();
                }

                picFace.Image = image;
                picSmallFace.Image = Services.FaceDetect.SmallImage;
            }
        }
        #endregion

        #region Asyncs Buttons
        private async void btnExec_Click(object sender, EventArgs e)
        {
            this.btnExec.Enabled = false;

            string pathImage = Services.FaceDetect.SmallImage != null ? Services.SaveImages.SaveImage(Services.FaceDetect.SmallImage, "Unknown") : String.Empty;

            if (pathImage != String.Empty)
            {
                var task = Task.Factory.StartNew(() =>
                Services.CallScript.RunScript(pathScriptVerify, pathImage));

                await task;

                Console.WriteLine(task.Result);
            }
            this.btnExec.Enabled = true;
        }

        private async void btnExecEnc_Click(object sender, EventArgs e)
        {
            this.btnExecEnc.Enabled = false;

            var task = Task.Factory.StartNew(() =>
                Services.CallScript.RunScript(pathScriptEncoding, ""));

            await task;

            this.btnExecEnc.Enabled = true;
            Console.WriteLine(task.Result);
        }
        #endregion

        private void picSmallFace_Click(object sender, EventArgs e)
        {
        }
    }
}
