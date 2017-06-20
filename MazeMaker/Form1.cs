using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace MazeMaker
{
    public partial class MazeImageWindow : Form
    {
        BitmapCreator bmp;

        public MazeImageWindow()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        public void setImage(Bitmap image)
        {
            mazePictureBox.Refresh();
            mazePictureBox.SizeMode = PictureBoxSizeMode.CenterImage;
            mazePictureBox.BorderStyle = BorderStyle.Fixed3D;
            mazePictureBox.Image = image;
            mazePictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            mazePictureBox.Update();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int width = int.Parse(txtWidth.Text);
            int height = int.Parse(txtHeight.Text);
            MazeGenerator mazeGen = new MazeGenerator(width,height);

            while (mazeGen.wallList.Count > 0)
            {
                mazeGen.selectWall();
            }
            mazeGen.finishPaths();

            bmp = new BitmapCreator();
            bmp.generateBitmap(mazeGen.mazeMap);
            btnSave.Enabled = true;

           /* FileStream fs = File.Open("MazeMap.bmp", FileMode.Open);
            Bitmap image = new Bitmap(fs);
            fs.Close();
            fs.Dispose(); */

            setImage(bmp.mazeImage);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string dir = txtDir.Text.ToString();
            string name = txtName.Text.ToString();

            string saveLocation = dir + name + ".bmp";

            bmp.saveBitmap(saveLocation);
        }
    }
}
