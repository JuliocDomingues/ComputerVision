namespace FaceDetection
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
            this.imgCapture = new System.Windows.Forms.PictureBox();
            this.btnCapture = new System.Windows.Forms.Button();
            this.btnDetectFace = new System.Windows.Forms.Button();
            this.btnAddFace = new System.Windows.Forms.Button();
            this.txtName = new System.Windows.Forms.TextBox();
            this.imgFace = new System.Windows.Forms.PictureBox();
            this.btnSave = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.imgCapture)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgFace)).BeginInit();
            this.SuspendLayout();
            // 
            // imgCapture
            // 
            this.imgCapture.Location = new System.Drawing.Point(2, 2);
            this.imgCapture.Name = "imgCapture";
            this.imgCapture.Size = new System.Drawing.Size(714, 554);
            this.imgCapture.TabIndex = 0;
            this.imgCapture.TabStop = false;
            this.imgCapture.Click += new System.EventHandler(this.imgCapture_Click);
            // 
            // btnCapture
            // 
            this.btnCapture.Location = new System.Drawing.Point(722, 12);
            this.btnCapture.Name = "btnCapture";
            this.btnCapture.Size = new System.Drawing.Size(206, 30);
            this.btnCapture.TabIndex = 1;
            this.btnCapture.Text = "Capture";
            this.btnCapture.UseVisualStyleBackColor = true;
            this.btnCapture.Click += new System.EventHandler(this.btnCapture_Click);
            // 
            // btnDetectFace
            // 
            this.btnDetectFace.Location = new System.Drawing.Point(722, 48);
            this.btnDetectFace.Name = "btnDetectFace";
            this.btnDetectFace.Size = new System.Drawing.Size(206, 31);
            this.btnDetectFace.TabIndex = 2;
            this.btnDetectFace.Text = "Detect Face";
            this.btnDetectFace.UseVisualStyleBackColor = true;
            this.btnDetectFace.Click += new System.EventHandler(this.btnDetectFace_Click);
            // 
            // btnAddFace
            // 
            this.btnAddFace.Location = new System.Drawing.Point(722, 85);
            this.btnAddFace.Name = "btnAddFace";
            this.btnAddFace.Size = new System.Drawing.Size(206, 28);
            this.btnAddFace.TabIndex = 3;
            this.btnAddFace.Text = "Add Face";
            this.btnAddFace.UseVisualStyleBackColor = true;
            this.btnAddFace.Click += new System.EventHandler(this.btnAddFace_Click);
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(722, 270);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(206, 22);
            this.txtName.TabIndex = 4;
            // 
            // imgFace
            // 
            this.imgFace.Location = new System.Drawing.Point(722, 119);
            this.imgFace.Name = "imgFace";
            this.imgFace.Size = new System.Drawing.Size(206, 145);
            this.imgFace.TabIndex = 5;
            this.imgFace.TabStop = false;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(722, 298);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(206, 27);
            this.btnSave.TabIndex = 6;
            this.btnSave.Text = "Save Image";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(940, 559);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.imgFace);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.btnAddFace);
            this.Controls.Add(this.btnDetectFace);
            this.Controls.Add(this.btnCapture);
            this.Controls.Add(this.imgCapture);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.imgCapture)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgFace)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox imgCapture;
        private System.Windows.Forms.Button btnCapture;
        private System.Windows.Forms.Button btnDetectFace;
        private System.Windows.Forms.Button btnAddFace;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.PictureBox imgFace;
        private System.Windows.Forms.Button btnSave;
    }
}

