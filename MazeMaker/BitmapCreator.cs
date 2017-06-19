using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

namespace MazeMaker
{
    class BitmapCreator
    {
        public void generateBitmap(bool[,] rawMap)
        {
            int width, height;

            width = rawMap.GetLength(0);
            height = rawMap.GetLength(1);

            Bitmap mazeImage = new Bitmap(width, height);

            for (int i = 0; i < width; i++) {
                for (int j = 0; j < height; j++)
                {
                    if (rawMap[i, j] == true)
                    {
                        mazeImage.SetPixel(i, j, Color.White);
                    }
                    else
                    {
                        mazeImage.SetPixel(i, j, Color.Black);
                    }
                }
            }

            mazeImage.Save("test.bmp");
        }       
    }
}
