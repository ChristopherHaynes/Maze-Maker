using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazeMaker
{
    //Generate a fresh maze to the presented parameters
    class PrimMaze : MazeGenerator
    {
        //List of all the available unvisited wall positions
        private List<Tile> wallList;

        //Initialise the generator and set the size of the maze map
        public PrimMaze(int width, int height)
        {
            wallList = new List<Tile>();
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

        public override bool[,] generateMaze()
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

        //Randomly select a wall from the wall list, end program if the list is empty
        private void selectWall()
        {
            if (wallList.Count > 0)
            {
                int listPos = rand.Next(wallList.Count);
                checkSurroundingTiles(wallList[listPos].x, wallList[listPos].y, wallList[listPos]);
            }         
           
        }

        //Check surrounding tiles to see if they are paths
        private void checkSurroundingTiles(int wallX, int wallY, Tile wall)
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

        //Add surrounding walls to the wall list
        private void updateWallList(int tileX, int tileY)
        {
            Tile newWall;

            //North
            if (tileY + 1 < height && mazeMap[tileX, tileY + 2] == false)
            {
                newWall = new Tile(tileX, tileY + 2);
                wallList.Add(newWall);
            }
            //East
            if (tileX + 1 < width && mazeMap[tileX + 2, tileY] == false)
            {
                newWall = new Tile(tileX + 2, tileY);
                wallList.Add(newWall);
            }
            //South
            if (tileY - 2 > 0 && mazeMap[tileX, tileY - 2] == false)
            {             
                newWall = new Tile(tileX, tileY - 2);
                wallList.Add(newWall);
            }
            //West
            if (tileX - 2 > 0 && mazeMap[tileX - 2, tileY] == false)
            {
                newWall = new Tile(tileX - 2, tileY);
                wallList.Add(newWall);
            }
        }   
    }
}
