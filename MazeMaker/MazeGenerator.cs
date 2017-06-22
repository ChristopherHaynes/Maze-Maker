using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazeMaker
{
    class MazeGenerator
    {      
        //Size of the maze in pixels     
        protected int width, height;
        protected Random rand = new Random();

        //2D Array representing the maze map
        protected bool[,] mazeMap;

        public virtual bool[,] generateMaze()
        {
            bool[,] defaultMaze = new bool[5,5];
            return defaultMaze;
        }
    }
}
