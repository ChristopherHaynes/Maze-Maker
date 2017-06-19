using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazeMaker
{
    //Co-ordinates for a wall position
    struct Wall
    {
        public int wallX, wallY;
    }

    //Generate a fresh maze to the presented parameters
    class MazeGenerator
    {   
        //Size of the maze in pixels     
        private int width, height;

        //2D Array representing the maze map
        public bool[,] mazeMap;
        //List of all the available unvisited wall positions
        public List<Wall> wallList;

        //Initialise the generator and set the size of the maze map
        public MazeGenerator(int width, int height)
        {
            wallList = new List<Wall>();
            this.width = width;
            this.height = height;

            mazeMap = new bool[width, height];
            Array.Clear(mazeMap, 0, mazeMap.Length);

            //Select a starting position at random (not outer edge)
            Random rand = new Random();
            int startX = rand.Next(1, width - 1);
            int startY = rand.Next(1, height - 1);
            mazeMap[startX, startY] = true;

            //Add the surrounding walls of the start position to the wall list
            updateWallList(startX, startY);
        }

        //Add surrounding walls to the wall list
        public void updateWallList(int tileX, int tileY)
        {
            Wall newWall = new Wall();

            //North
            if(mazeMap[tileX, tileY + 1] == false)
            {
                newWall.wallX = tileX;
                newWall.wallY = tileY + 1;
                wallList.Add(newWall);
            }
            //East
            if (mazeMap[tileX + 1, tileY] == false)
            {
                newWall.wallX = tileX + 1;
                newWall.wallY = tileY;
                wallList.Add(newWall);
            }
            //South
            if (mazeMap[tileX, tileY - 1] == false)
            {
                newWall.wallX = tileX;
                newWall.wallY = tileY - 1;
                wallList.Add(newWall);
            }
            //West
            if (mazeMap[tileX - 1, tileY] == false)
            {
                newWall.wallX = tileX - 1;
                newWall.wallY = tileY;
                wallList.Add(newWall);
            }
        }

        //Randomly select a wall from the wall list, end program if the list is empty
        public void selectWall()
        {
            Random rand = new Random();

            if (wallList.Count > 0)
            {
                int listPos = rand.Next(wallList.Count);
                checkSurroundingTiles(wallList[listPos].wallX, wallList[listPos].wallY, wallList[listPos]);
            }
           
        }

        //Check surrounding tiles to see if they are paths
        public void checkSurroundingTiles(int wallX, int wallY, Wall wall)
        {
            if (wallX > 0 && wallX < width - 1 && wallY > 0 && wallY < height - 1)
            {
                bool north = mazeMap[wallX, wallY + 1];
                bool east = mazeMap[wallX + 1, wallY];
                bool south = mazeMap[wallX, wallY - 1];
                bool west = mazeMap[wallX - 1, wallY];
                int pathCount = 0;

                //Count the amount of paths surrounding the examined tile
                if (north == true) { pathCount++; }
                if (east == true) { pathCount++; }
                if (south == true) { pathCount++; }
                if (west == true) { pathCount++; }

                //If there is 1 or less paths connect to this wall, turn this wall into a path
                if (pathCount <= 1)
                {
                    mazeMap[wallX, wallY] = true;
                    updateWallList(wallX, wallY);
                }
            }
            wallList.Remove(wall);
        }



    }
}
