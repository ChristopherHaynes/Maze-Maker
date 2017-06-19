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
            mazePictureBox.Image = image;
            mazePictureBox.Update();
        }
    }
}
