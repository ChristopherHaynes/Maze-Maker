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
            ((System.ComponentModel.ISupportInitialize)(this.mazePictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // mazePictureBox
            // 
            this.mazePictureBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.mazePictureBox.Location = new System.Drawing.Point(297, 12);
            this.mazePictureBox.Name = "mazePictureBox";
            this.mazePictureBox.Size = new System.Drawing.Size(500, 500);
            this.mazePictureBox.TabIndex = 0;
            this.mazePictureBox.TabStop = false;
            this.mazePictureBox.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // btnGenerate
            // 
            this.btnGenerate.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGenerate.Location = new System.Drawing.Point(61, 489);
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
            this.lblMazeWidth.Location = new System.Drawing.Point(72, 317);
            this.lblMazeWidth.Name = "lblMazeWidth";
            this.lblMazeWidth.Size = new System.Drawing.Size(64, 13);
            this.lblMazeWidth.TabIndex = 2;
            this.lblMazeWidth.Text = "Maze Width";
            // 
            // lblMazeHeight
            // 
            this.lblMazeHeight.AutoSize = true;
            this.lblMazeHeight.Location = new System.Drawing.Point(69, 359);
            this.lblMazeHeight.Name = "lblMazeHeight";
            this.lblMazeHeight.Size = new System.Drawing.Size(67, 13);
            this.lblMazeHeight.TabIndex = 3;
            this.lblMazeHeight.Text = "Maze Height";
            // 
            // txtWidth
            // 
            this.txtWidth.Location = new System.Drawing.Point(156, 314);
            this.txtWidth.Name = "txtWidth";
            this.txtWidth.Size = new System.Drawing.Size(54, 20);
            this.txtWidth.TabIndex = 4;
            this.txtWidth.Text = "50";
            // 
            // txtHeight
            // 
            this.txtHeight.Location = new System.Drawing.Point(156, 356);
            this.txtHeight.Name = "txtHeight";
            this.txtHeight.Size = new System.Drawing.Size(54, 20);
            this.txtHeight.TabIndex = 5;
            this.txtHeight.Text = "50";
            // 
            // btnSave
            // 
            this.btnSave.Enabled = false;
            this.btnSave.Location = new System.Drawing.Point(156, 489);
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
            this.lblDirectory.Location = new System.Drawing.Point(24, 207);
            this.lblDirectory.Name = "lblDirectory";
            this.lblDirectory.Size = new System.Drawing.Size(77, 13);
            this.lblDirectory.TabIndex = 7;
            this.lblDirectory.Text = "Save Directory";
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(47, 242);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(54, 13);
            this.lblName.TabIndex = 8;
            this.lblName.Text = "File Name";
            // 
            // txtDir
            // 
            this.txtDir.Location = new System.Drawing.Point(121, 207);
            this.txtDir.Name = "txtDir";
            this.txtDir.Size = new System.Drawing.Size(150, 20);
            this.txtDir.TabIndex = 9;
            this.txtDir.Text = "C:\\\\MazeImages\\";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(121, 242);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(150, 20);
            this.txtName.TabIndex = 10;
            this.txtName.Text = "MazeMap";
            // 
            // MazeImageWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(809, 525);
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
    }
}

