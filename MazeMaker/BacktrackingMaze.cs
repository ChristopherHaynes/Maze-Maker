using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazeMaker
{
    class BacktrackingMaze : MazeGenerator
    {
        //List behaving as a stack to remember current tile position
        List<Tile> pathList;

        public BacktrackingMaze(int width, int height)
        {
            pathList = new List<Tile>();
            this.width = width;
            this.height = height;

            mazeMap = new bool[width, height];
            Array.Clear(mazeMap, 0, mazeMap.Length);

            //Select a starting position at random (not outer edge)           
            int startX = rand.Next(2, width - 2);
            int startY = rand.Next(2, height - 2);
            mazeMap[startX, startY] = true;

            //Push the first position onto the "Stack"
            Tile startWall = new Tile();
            startWall.x = startX; startWall.y = startY;
            pathList.Add(startWall);
        }

        public override bool[,] generateMaze()
        {
            while (pathList.Count > 0)
            {
                stepForward();
            }

            if (pathList.Count == 0)
            {
                finishPaths();
            }
            return mazeMap;
        }

        private void stepForward()
        {
            //Pop the last added position off the list
            Tile currentPos = pathList[pathList.Count - 1];
            int x = currentPos.x;
            int y = currentPos.y;

            //Record viable directions
            List<string> directions = new List<string>();

            //North
            if (y + 3 < height && mazeMap[x, y + 2] == false) { directions.Add("N"); }
            
            //East
            if (x + 3 < width && mazeMap[x + 2, y] == false) { directions.Add("E"); }
           
            //South
            if (y - 3 > 0 && mazeMap[x, y - 2] == false) { directions.Add("S"); }
            
            //West
            if (x - 3 > 0 && mazeMap[x - 2, y] == false) { directions.Add("W"); }

            if (directions.Count > 0)
            {
                int index = rand.Next(directions.Count);
                string direct = directions[index];
                Tile newPos = new Tile();

                if (direct == "N")
                {
                    mazeMap[x, y + 2] = true; mazeMap[x, y + 1] = true;
                    newPos.x = x;
                    newPos.y = y + 2;
                }
                if (direct == "E")
                {
                    mazeMap[x + 2, y] = true; mazeMap[x + 1, y] = true;
                    newPos.x = x + 2;
                    newPos.y = y;
                }
                if (direct == "S")
                {
                    mazeMap[x, y - 2] = true; mazeMap[x, y - 1] = true;
                    newPos.x = x;
                    newPos.y = y - 2;
                }
                if (direct == "W")
                {
                    mazeMap[x - 2, y] = true; mazeMap[x - 1, y] = true;
                    newPos.x = x - 2;
                    newPos.y = y;
                }
                pathList.Add(newPos);
            }
            else
            {
                pathList.RemoveAt(pathList.Count - 1);
            }
        }
    }
}
