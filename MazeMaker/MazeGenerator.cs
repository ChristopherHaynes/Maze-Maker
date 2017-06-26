using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazeMaker
{
    //Co-ordinates for a wall position
    class Tile
    {
        public int x, y;
        public Tile(int x, int y)
        {
            this.x = x; this.y = y;
        }
    }

    class MazeGenerator
    {
        //Size of the maze in pixels     
        protected int width, height;
        protected Random rand = new Random();

        //2D Array representing the maze map
        protected bool[,] mazeMap;

        //Start maze generation from outside the object
        public virtual bool[,] generateMaze()
        {
            bool[,] defaultMaze = new bool[5,5];
            return defaultMaze;
        }

        //Locate the bottom right path and return that position as the exit
        protected Tile findExit()
        {
            Tile exit = new Tile(width - 1, height - 1);

            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    if (mazeMap[i, j] == true)
                    {
                        exit = new Tile(i, j);
                    }
                }
            }
            return exit;
        }

        //Locate the top left path and return that position as the entrance
        protected Tile findEntrance()
        {
            Tile entrance = new Tile(0, 0);

            for (int i = width - 1; i > 0; i--)
            {
                for (int j = height - 1; j > 0; j--)
                {
                    if (mazeMap[i, j] == true)
                    {
                        entrance = new Tile (i, j);
                    }
                }
            }
            return entrance;
        }

        //Join the exit and entrance to the edges of the maze image
        protected void finishPaths()
        {
            Tile entrance = findEntrance();
            Tile exit = findExit();

            int entranceX = entrance.x;
            int entranceY = entrance.y;
            int exitX = exit.x;
            int exitY = exit.y;

            //Connect the entrance to the top of the image
            for (int i = entranceY - 1; i >= 0; i--)
            {
                mazeMap[entranceX, i] = true;
            }

            //Connect the exit to the bottom of the image
            for (int i = exitY + 1; i < height; i++)
            {
                mazeMap[exitX, i] = true;
            }
        }
    }
}
