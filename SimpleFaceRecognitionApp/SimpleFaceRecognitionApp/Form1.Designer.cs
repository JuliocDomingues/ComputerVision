namespace SimpleFaceRecognitionApp
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
            this.picCapture = new System.Windows.Forms.PictureBox();
            this.btnCapture = new System.Windows.Forms.Button();
            this.btnDetectFaces = new System.Windows.Forms.Button();
            this.btnAddPerson = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.picDetected = new System.Windows.Forms.PictureBox();
            this.txtPersonName = new System.Windows.Forms.TextBox();
            this.btnTrain = new System.Windows.Forms.Button();
            this.btnRecognizePersons = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.picCapture)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picDetected)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // picCapture
            // 
            this.picCapture.Location = new System.Drawing.Point(3, 2);
            this.picCapture.Name = "picCapture";
            this.picCapture.Size = new System.Drawing.Size(731, 568);
            this.picCapture.TabIndex = 0;
            this.picCapture.TabStop = false;
            this.picCapture.Click += new System.EventHandler(this.picCapture_Click);
            // 
            // btnCapture
            // 
            this.btnCapture.Location = new System.Drawing.Point(740, 12);
            this.btnCapture.Name = "btnCapture";
            this.btnCapture.Size = new System.Drawing.Size(155, 24);
            this.btnCapture.TabIndex = 1;
            this.btnCapture.Text = "1. Capture";
            this.btnCapture.UseVisualStyleBackColor = true;
            this.btnCapture.Click += new System.EventHandler(this.btnCapture_Click_1);
            // 
            // btnDetectFaces
            // 
            this.btnDetectFaces.Location = new System.Drawing.Point(740, 42);
            this.btnDetectFaces.Name = "btnDetectFaces";
            this.btnDetectFaces.Size = new System.Drawing.Size(155, 23);
            this.btnDetectFaces.TabIndex = 2;
            this.btnDetectFaces.Text = "2. Detect Faces";
            this.btnDetectFaces.UseVisualStyleBackColor = true;
            this.btnDetectFaces.Click += new System.EventHandler(this.btnDetectFaces_Click);
            // 
            // btnAddPerson
            // 
            this.btnAddPerson.Location = new System.Drawing.Point(740, 71);
            this.btnAddPerson.Name = "btnAddPerson";
            this.btnAddPerson.Size = new System.Drawing.Size(155, 23);
            this.btnAddPerson.TabIndex = 3;
            this.btnAddPerson.Text = "3. Add Person";
            this.btnAddPerson.UseVisualStyleBackColor = true;
            this.btnAddPerson.Click += new System.EventHandler(this.btnAddPerson_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(739, 297);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(155, 23);
            this.btnSave.TabIndex = 4;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // picDetected
            // 
            this.picDetected.Location = new System.Drawing.Point(740, 105);
            this.picDetected.Name = "picDetected";
            this.picDetected.Size = new System.Drawing.Size(154, 154);
            this.picDetected.TabIndex = 5;
            this.picDetected.TabStop = false;
            // 
            // txtPersonName
            // 
            this.txtPersonName.Location = new System.Drawing.Point(740, 269);
            this.txtPersonName.Name = "txtPersonName";
            this.txtPersonName.Size = new System.Drawing.Size(154, 22);
            this.txtPersonName.TabIndex = 6;
            // 
            // btnTrain
            // 
            this.btnTrain.Location = new System.Drawing.Point(740, 326);
            this.btnTrain.Name = "btnTrain";
            this.btnTrain.Size = new System.Drawing.Size(154, 23);
            this.btnTrain.TabIndex = 7;
            this.btnTrain.Text = "4. Train Images";
            this.btnTrain.UseVisualStyleBackColor = true;
            this.btnTrain.Click += new System.EventHandler(this.btnTrain_Click);
            // 
            // btnRecognizePersons
            // 
            this.btnRecognizePersons.Location = new System.Drawing.Point(740, 355);
            this.btnRecognizePersons.Name = "btnRecognizePersons";
            this.btnRecognizePersons.Size = new System.Drawing.Size(154, 23);
            this.btnRecognizePersons.TabIndex = 8;
            this.btnRecognizePersons.Text = "5. Recognize Persons";
            this.btnRecognizePersons.UseVisualStyleBackColor = true;
            this.btnRecognizePersons.Click += new System.EventHandler(this.btnRecognizePersons_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(740, 384);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(153, 68);
            this.pictureBox1.TabIndex = 9;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Location = new System.Drawing.Point(738, 458);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(156, 66);
            this.pictureBox2.TabIndex = 10;
            this.pictureBox2.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(907, 582);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnRecognizePersons);
            this.Controls.Add(this.btnTrain);
            this.Controls.Add(this.txtPersonName);
            this.Controls.Add(this.picDetected);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnAddPerson);
            this.Controls.Add(this.btnDetectFaces);
            this.Controls.Add(this.btnCapture);
            this.Controls.Add(this.picCapture);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picCapture)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picDetected)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox picCapture;
        private System.Windows.Forms.Button btnCapture;
        private System.Windows.Forms.Button btnDetectFaces;
        private System.Windows.Forms.Button btnAddPerson;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.PictureBox picDetected;
        private System.Windows.Forms.TextBox txtPersonName;
        private System.Windows.Forms.Button btnTrain;
        private System.Windows.Forms.Button btnRecognizePersons;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
    }
}

