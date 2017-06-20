using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MazeMaker
{
    public partial class MazeImageWindow : Form
    {
        public MazeImageWindow()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        public void setImage(Bitmap image)
        {
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

            BitmapCreator bmp = new BitmapCreator();
            bmp.generateBitmap(mazeGen.mazeMap);
            Bitmap image = new Bitmap("MazeMap.bmp");
            setImage(image);
        }
    }
}
