namespace FaceMatching
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.picFace = new System.Windows.Forms.PictureBox();
            this.btnCapture = new System.Windows.Forms.Button();
            this.picSmallFace = new System.Windows.Forms.PictureBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnRecognize = new System.Windows.Forms.Button();
            this.txtName = new System.Windows.Forms.TextBox();
            this.btnChoose = new System.Windows.Forms.Button();
            this.txtFileName = new System.Windows.Forms.TextBox();
            this.btnSaveDir = new System.Windows.Forms.Button();
            this.btnExec = new System.Windows.Forms.Button();
            this.btnExecEnc = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.picFace)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picSmallFace)).BeginInit();
            this.SuspendLayout();
            // 
            // picFace
            // 
            this.picFace.Location = new System.Drawing.Point(0, 0);
            this.picFace.Name = "picFace";
            this.picFace.Size = new System.Drawing.Size(1280, 720);
            this.picFace.TabIndex = 0;
            this.picFace.TabStop = false;
            // 
            // btnCapture
            // 
            this.btnCapture.Location = new System.Drawing.Point(1309, 12);
            this.btnCapture.Name = "btnCapture";
            this.btnCapture.Size = new System.Drawing.Size(313, 34);
            this.btnCapture.TabIndex = 1;
            this.btnCapture.Text = "Start";
            this.btnCapture.UseVisualStyleBackColor = true;
            this.btnCapture.Click += new System.EventHandler(this.btnCapture_Click);
            // 
            // picSmallFace
            // 
            this.picSmallFace.Location = new System.Drawing.Point(1309, 52);
            this.picSmallFace.Name = "picSmallFace";
            this.picSmallFace.Size = new System.Drawing.Size(313, 313);
            this.picSmallFace.TabIndex = 2;
            this.picSmallFace.TabStop = false;
            this.picSmallFace.Click += new System.EventHandler(this.picSmallFace_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(1309, 399);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(156, 34);
            this.btnSave.TabIndex = 3;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnRecognize
            // 
            this.btnRecognize.Location = new System.Drawing.Point(1466, 399);
            this.btnRecognize.Name = "btnRecognize";
            this.btnRecognize.Size = new System.Drawing.Size(156, 34);
            this.btnRecognize.TabIndex = 4;
            this.btnRecognize.Text = "Recognize";
            this.btnRecognize.UseVisualStyleBackColor = true;
            this.btnRecognize.Click += new System.EventHandler(this.btnRecognize_Click);
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(1309, 371);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(313, 22);
            this.txtName.TabIndex = 5;
            // 
            // btnChoose
            // 
            this.btnChoose.Location = new System.Drawing.Point(1309, 439);
            this.btnChoose.Name = "btnChoose";
            this.btnChoose.Size = new System.Drawing.Size(313, 34);
            this.btnChoose.TabIndex = 6;
            this.btnChoose.Text = "Choose File";
            this.btnChoose.UseVisualStyleBackColor = true;
            this.btnChoose.Click += new System.EventHandler(this.btnChoose_Click);
            // 
            // txtFileName
            // 
            this.txtFileName.Location = new System.Drawing.Point(1309, 479);
            this.txtFileName.Name = "txtFileName";
            this.txtFileName.Size = new System.Drawing.Size(313, 22);
            this.txtFileName.TabIndex = 7;
            // 
            // btnSaveDir
            // 
            this.btnSaveDir.Location = new System.Drawing.Point(1309, 507);
            this.btnSaveDir.Name = "btnSaveDir";
            this.btnSaveDir.Size = new System.Drawing.Size(313, 34);
            this.btnSaveDir.TabIndex = 8;
            this.btnSaveDir.Text = "Save Images From Dir";
            this.btnSaveDir.UseVisualStyleBackColor = true;
            this.btnSaveDir.Click += new System.EventHandler(this.btnSaveDir_Click);
            // 
            // btnExec
            // 
            this.btnExec.Location = new System.Drawing.Point(1309, 677);
            this.btnExec.Name = "btnExec";
            this.btnExec.Size = new System.Drawing.Size(313, 34);
            this.btnExec.TabIndex = 9;
            this.btnExec.Text = "Execute Script Verify";
            this.btnExec.UseVisualStyleBackColor = true;
            this.btnExec.Click += new System.EventHandler(this.btnExec_Click);
            // 
            // btnExecEnc
            // 
            this.btnExecEnc.Location = new System.Drawing.Point(1309, 637);
            this.btnExecEnc.Name = "btnExecEnc";
            this.btnExecEnc.Size = new System.Drawing.Size(313, 34);
            this.btnExecEnc.TabIndex = 10;
            this.btnExecEnc.Text = "Execute Script Encoding";
            this.btnExecEnc.UseVisualStyleBackColor = true;
            this.btnExecEnc.Click += new System.EventHandler(this.btnExecEnc_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1651, 723);
            this.Controls.Add(this.btnExecEnc);
            this.Controls.Add(this.btnExec);
            this.Controls.Add(this.btnSaveDir);
            this.Controls.Add(this.txtFileName);
            this.Controls.Add(this.btnChoose);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.btnRecognize);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.picSmallFace);
            this.Controls.Add(this.btnCapture);
            this.Controls.Add(this.picFace);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.picFace)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picSmallFace)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox picFace;
        private System.Windows.Forms.Button btnCapture;
        private System.Windows.Forms.PictureBox picSmallFace;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnRecognize;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Button btnChoose;
        private System.Windows.Forms.TextBox txtFileName;
        private System.Windows.Forms.Button btnSaveDir;
        private System.Windows.Forms.Button btnExec;
        private System.Windows.Forms.Button btnExecEnc;
    }
}

