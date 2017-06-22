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
        Random rand = new Random();

        //2D Array representing the maze map
        private bool[,] mazeMap;
        //List of all the available unvisited wall positions
        private List<Wall> wallList;

        //Initialise the generator and set the size of the maze map
        public MazeGenerator(int width, int height)
        {
            wallList = new List<Wall>();
            this.width = width;
            this.height = height;

            mazeMap = new bool[width, height];
            Array.Clear(mazeMap, 0, mazeMap.Length);

            //Select a starting position at random (not outer edge)           
            int startX = rand.Next(1, width - 2);
            int startY = rand.Next(1, height - 2);
            mazeMap[startX, startY] = true;

            //Add the surrounding walls of the start position to the wall list
            updateWallList(startX, startY);
        }

        public bool[,] generateMaze()
        {
            //Check to see if there are any more walls in the list
            while (wallList.Count > 0)
            {
                selectWall();
            }

            //When the wall list is empty add the entrance and exit paths
            if (wallList.Count == 0)
            {
                finishPaths();
            }

            return mazeMap;
        }
        
        //Add surrounding walls to the wall list
        private void updateWallList(int tileX, int tileY)
        {
            Wall newWall = new Wall();

            //North
            if (tileY + 1 < height)
            {
                if (mazeMap[tileX, tileY + 2] == false)
                {
                    newWall.wallX = tileX;
                    newWall.wallY = tileY + 2;
                    wallList.Add(newWall);
                }
            }
            //East
            if (tileX + 1 < width)
            {
                if (mazeMap[tileX + 2, tileY] == false)
                {
                    newWall.wallX = tileX + 2;
                    newWall.wallY = tileY;
                    wallList.Add(newWall);
                }
            }
            if (tileY - 2 > 0)
            {
                //South
                if (mazeMap[tileX, tileY - 2] == false)
                {
                    newWall.wallX = tileX;
                    newWall.wallY = tileY - 2;
                    wallList.Add(newWall);
                }
            }
            if (tileX - 2 > 0)
            {
                //West
                if (mazeMap[tileX - 2, tileY] == false)
                {
                    newWall.wallX = tileX - 2;
                    newWall.wallY = tileY;
                    wallList.Add(newWall);
                }
            }
        }

        //Randomly select a wall from the wall list, end program if the list is empty
        private void selectWall()
        {
            if (wallList.Count > 0)
            {
                int listPos = rand.Next(wallList.Count);
                checkSurroundingTiles(wallList[listPos].wallX, wallList[listPos].wallY, wallList[listPos]);
            }         
           
        }

        //Check surrounding tiles to see if they are paths
        private void checkSurroundingTiles(int wallX, int wallY, Wall wall)
        {
            if (wallX > 1 && wallX < width - 2 && wallY > 1 && wallY < height - 2 && mazeMap[wallX, wallY] == false)
            {
                //List of viable connections 1 = north, 2 = east, 3 = south, 4 = west 
                List<int> pathDirection = new List<int>();
                bool north = mazeMap[wallX, wallY + 2];
                bool east = mazeMap[wallX + 2, wallY];
                bool south = mazeMap[wallX, wallY - 2];
                bool west = mazeMap[wallX - 2, wallY];
                int pathCount = 0;

                //Count the amount of paths surrounding the examined tile
                if (north == true) { pathCount++; pathDirection.Add(1); }
                if (east == true) { pathCount++; pathDirection.Add(2); }
                if (south == true) { pathCount++; pathDirection.Add(3); }
                if (west == true) { pathCount++; pathDirection.Add(4); }

                //If there are viable paths, pick one randomly and join to it
                if (pathDirection.Count > 0)
                {
                    int index = rand.Next(pathDirection.Count);
                    int direction = pathDirection[index];
                    if (direction == 1) { mazeMap[wallX, wallY + 1] = true; }
                    if (direction == 2) { mazeMap[wallX + 1, wallY] = true; }
                    if (direction == 3) { mazeMap[wallX, wallY - 1] = true; }
                    if (direction == 4) { mazeMap[wallX - 1, wallY] = true; }
                    mazeMap[wallX, wallY] = true;
                    updateWallList(wallX, wallY);
                }
            }
            //Remove this wall from the list as it has been turned into a path
            wallList.Remove(wall);            
        }

        private Wall findExit()
        {
            Wall exit = new Wall();
            //Find the top left path and mark that wall as the entrance
            for (int i = 0; i < width; i++) {
                for (int j = 0; j < height; j++)
                {
                    if (mazeMap[j, i] == true)
                    {
                        exit.wallX = j;
                        exit.wallY = i;                        
                    }
                }
            }
            return exit;
        }

        private Wall findEntrance()
        {
            Wall entrance = new Wall();
            //Find the bottom right path and mark that wall as the exit
            for (int i = width - 1; i > 0; i--) {
                for (int j = height - 1; j > 0; j--)
                {
                    if (mazeMap[j, i] == true)
                    {
                        entrance.wallX = j;
                        entrance.wallY = i;
                    }
                }
            }
            return entrance;
        }

        private void finishPaths()
        {
            Wall entrance = findEntrance();
            Wall exit = findExit();

            int entranceX = entrance.wallX;
            int entranceY = entrance.wallY;
            int exitX = exit.wallX;
            int exitY = exit.wallY;

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
