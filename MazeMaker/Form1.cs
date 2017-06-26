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

            //Populate the drop down menu
            NameValue prim = new NameValue("Prim's Algorithm", "0");
            NameValue backtrack = new NameValue("Recursive Backtracking", "1");
            NameValue kruskal = new NameValue("Kruskal's Algorithm", "2");
            NameValue eller = new NameValue("Eller's Algorithm", "3");
            cmbAlgorithm.Items.Add(prim);
            cmbAlgorithm.Items.Add(backtrack);
            cmbAlgorithm.Items.Add(kruskal);
            cmbAlgorithm.Items.Add(eller);
            cmbAlgorithm.SelectedIndex = 0;

            //Fill the preview box with a black white gradient
            Bitmap black = new Bitmap(1, 1);
            black.SetPixel(0, 0, Color.Black);
            setImage(black);
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
            int width = 0, height = 0;

            //Check the width and height inputs are vailid
            try
            {
                width = int.Parse(txtWidth.Text);
                height = int.Parse(txtHeight.Text);
            }
            catch (FormatException ex)
            {
                MessageBox.Show(ex.Message, "Format Error",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (ArgumentNullException ex)
            {
                MessageBox.Show(ex.Message, "Null Value Error",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            //If the requested maze is above the minimum requirements
            if (width > 4 && height > 4)
            {
                MazeGenerator mazeGen = new PrimMaze(width, height);

                int dropdownSelection = cmbAlgorithm.SelectedIndex;
                if (dropdownSelection == 0) { mazeGen = new PrimMaze(width, height); }
                if (dropdownSelection == 1) { mazeGen = new BacktrackingMaze(width, height); }
                if (dropdownSelection == 2) { mazeGen = new KruskalMaze(width, height); }
                if (dropdownSelection == 3) { mazeGen = new EllerMaze(width, height); }

                bmp = new BitmapCreator();
                bmp.generateBitmap(mazeGen.generateMaze());
                btnSave.Enabled = true;

                //Generate a maze name
                int type = cmbAlgorithm.SelectedIndex;
                string typeName = "Maze_";
                if (type == 0) { typeName = "Prim_"; }
                if (type == 1) { typeName = "Backtrack_"; }
                if (type == 2) { typeName = "Kruskal_"; }
                if (type == 3) { typeName = "Eller_"; }

                string size = width.ToString() + "X" + height.ToString();

                //If a file already exists add the next available number to the name
                string name = typeName + size;
                string numName = name;
                int count = 1;
                while (File.Exists(txtDir.Text + numName + ".bmp"))
                {
                    numName = name + "_" + count;
                    count++;               
                }

                txtName.Text = numName;

                //Display the generated maze in the preview window
                setImage(bmp.mazeImage);
            }
            else
            {
               MessageBox.Show("Maze must be at least 5 by 5", "Maze Invalid",
               MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string dir = txtDir.Text;
            string name = txtName.Text;

            if (Directory.Exists(dir))
            {
                string saveLocation = dir + name + ".bmp";

                bmp.saveBitmap(saveLocation);
            }
            else
            {
               MessageBox.Show("The requested save directory doesn't exist", "Directory Invalid",
               MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            if (fbd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                txtDir.Text = fbd.SelectedPath;
            }
        }
    }

    public class NameValue
    {
        private string dataName;
        private string dataValue;

        public NameValue(string dataName, string dataValue)
        {
            DataName = dataName;
            DataValue = dataValue;
        }

        public string DataName
        {
            get { return dataName; }
            set { dataName = value; }
        }

        public string DataValue
        {
            get { return dataValue; }
            set { dataValue = value; }
        }

        public override string ToString()
        {
            return dataName;
        }
    }
}
