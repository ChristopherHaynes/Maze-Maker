using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace MazeMaker
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            MazeGenerator mazeGen = new MazeGenerator(10, 10);

            while (mazeGen.wallList.Count > 0)
            {
                mazeGen.selectWall();
            }

            BitmapCreator bmp = new BitmapCreator();
            bmp.generateBitmap(mazeGen.mazeMap);

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MazeImageWindow());            
        }
    }
}
