namespace MazeMaker
{
    partial class MazeImageWindow
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
            this.mazePictureBox = new System.Windows.Forms.PictureBox();
            this.btnGenerate = new System.Windows.Forms.Button();
            this.lblMazeWidth = new System.Windows.Forms.Label();
            this.lblMazeHeight = new System.Windows.Forms.Label();
            this.txtWidth = new System.Windows.Forms.TextBox();
            this.txtHeight = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.lblDirectory = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.txtDir = new System.Windows.Forms.TextBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.cmbAlgorithm = new System.Windows.Forms.ComboBox();
            this.lblAlgorithm = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.mazePictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // mazePictureBox
            // 
            this.mazePictureBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.mazePictureBox.Location = new System.Drawing.Point(322, 32);
            this.mazePictureBox.Name = "mazePictureBox";
            this.mazePictureBox.Size = new System.Drawing.Size(460, 460);
            this.mazePictureBox.TabIndex = 0;
            this.mazePictureBox.TabStop = false;
            this.mazePictureBox.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // btnGenerate
            // 
            this.btnGenerate.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGenerate.Location = new System.Drawing.Point(111, 230);
            this.btnGenerate.Name = "btnGenerate";
            this.btnGenerate.Size = new System.Drawing.Size(75, 23);
            this.btnGenerate.TabIndex = 1;
            this.btnGenerate.Text = "Generate";
            this.btnGenerate.UseVisualStyleBackColor = true;
            this.btnGenerate.Click += new System.EventHandler(this.button1_Click);
            // 
            // lblMazeWidth
            // 
            this.lblMazeWidth.AutoSize = true;
            this.lblMazeWidth.Location = new System.Drawing.Point(79, 135);
            this.lblMazeWidth.Name = "lblMazeWidth";
            this.lblMazeWidth.Size = new System.Drawing.Size(64, 13);
            this.lblMazeWidth.TabIndex = 2;
            this.lblMazeWidth.Text = "Maze Width";
            // 
            // lblMazeHeight
            // 
            this.lblMazeHeight.AutoSize = true;
            this.lblMazeHeight.Location = new System.Drawing.Point(76, 177);
            this.lblMazeHeight.Name = "lblMazeHeight";
            this.lblMazeHeight.Size = new System.Drawing.Size(67, 13);
            this.lblMazeHeight.TabIndex = 3;
            this.lblMazeHeight.Text = "Maze Height";
            // 
            // txtWidth
            // 
            this.txtWidth.Location = new System.Drawing.Point(163, 132);
            this.txtWidth.Name = "txtWidth";
            this.txtWidth.Size = new System.Drawing.Size(54, 20);
            this.txtWidth.TabIndex = 4;
            this.txtWidth.Text = "100";
            // 
            // txtHeight
            // 
            this.txtHeight.Location = new System.Drawing.Point(163, 174);
            this.txtHeight.Name = "txtHeight";
            this.txtHeight.Size = new System.Drawing.Size(54, 20);
            this.txtHeight.TabIndex = 5;
            this.txtHeight.Text = "100";
            // 
            // btnSave
            // 
            this.btnSave.Enabled = false;
            this.btnSave.Location = new System.Drawing.Point(112, 447);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 6;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // lblDirectory
            // 
            this.lblDirectory.AutoSize = true;
            this.lblDirectory.Location = new System.Drawing.Point(20, 329);
            this.lblDirectory.Name = "lblDirectory";
            this.lblDirectory.Size = new System.Drawing.Size(77, 13);
            this.lblDirectory.TabIndex = 7;
            this.lblDirectory.Text = "Save Directory";
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(20, 379);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(54, 13);
            this.lblName.TabIndex = 8;
            this.lblName.Text = "File Name";
            // 
            // txtDir
            // 
            this.txtDir.Location = new System.Drawing.Point(23, 345);
            this.txtDir.Name = "txtDir";
            this.txtDir.Size = new System.Drawing.Size(199, 20);
            this.txtDir.TabIndex = 9;
            this.txtDir.Text = "C:\\\\MazeImages\\";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(23, 395);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(263, 20);
            this.txtName.TabIndex = 10;
            this.txtName.Text = "MazeMap";
            // 
            // btnBrowse
            // 
            this.btnBrowse.Location = new System.Drawing.Point(228, 344);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(58, 23);
            this.btnBrowse.TabIndex = 11;
            this.btnBrowse.Text = "Browse";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // cmbAlgorithm
            // 
            this.cmbAlgorithm.FormattingEnabled = true;
            this.cmbAlgorithm.Location = new System.Drawing.Point(23, 85);
            this.cmbAlgorithm.Name = "cmbAlgorithm";
            this.cmbAlgorithm.Size = new System.Drawing.Size(263, 21);
            this.cmbAlgorithm.TabIndex = 12;
            // 
            // lblAlgorithm
            // 
            this.lblAlgorithm.AutoSize = true;
            this.lblAlgorithm.Location = new System.Drawing.Point(20, 69);
            this.lblAlgorithm.Name = "lblAlgorithm";
            this.lblAlgorithm.Size = new System.Drawing.Size(134, 13);
            this.lblAlgorithm.TabIndex = 13;
            this.lblAlgorithm.Text = "Maze Generation Algorithm";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(319, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 13);
            this.label1.TabIndex = 14;
            this.label1.Text = "Maze Preview";
            // 
            // MazeImageWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(809, 525);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblAlgorithm);
            this.Controls.Add(this.cmbAlgorithm);
            this.Controls.Add(this.btnBrowse);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.txtDir);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.lblDirectory);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.txtHeight);
            this.Controls.Add(this.txtWidth);
            this.Controls.Add(this.lblMazeHeight);
            this.Controls.Add(this.lblMazeWidth);
            this.Controls.Add(this.btnGenerate);
            this.Controls.Add(this.mazePictureBox);
            this.Name = "MazeImageWindow";
            this.Text = "Maze Image Window";
            ((System.ComponentModel.ISupportInitialize)(this.mazePictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox mazePictureBox;
        private System.Windows.Forms.Button btnGenerate;
        private System.Windows.Forms.Label lblMazeWidth;
        private System.Windows.Forms.Label lblMazeHeight;
        private System.Windows.Forms.TextBox txtWidth;
        private System.Windows.Forms.TextBox txtHeight;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label lblDirectory;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.TextBox txtDir;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.ComboBox cmbAlgorithm;
        private System.Windows.Forms.Label lblAlgorithm;
        private System.Windows.Forms.Label label1;
    }
}

