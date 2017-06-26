using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazeMaker
{
    class EllerMaze : MazeGenerator
    {
        //Dictonary to find a set given a tile
        Dictionary<Tile, List<Tile>> setLookup;
        //List of all the sets in a row
        List<List<Tile>> setList;
        //List of all tiles in a row from left to right
        List<Tile> tileList;

        public EllerMaze(int width, int height)
        {
            setLookup = new Dictionary<Tile, List<Tile>>();
            setList = new List<List<Tile>>();
            tileList = new List<Tile>();
            this.width = width;
            this.height = height;

            mazeMap = new bool[width, height];
            Array.Clear(mazeMap, 0, mazeMap.Length);
        }

        public void joinSets()
        {
            for (int i = 0; i < tileList.Count - 1; i++)
            {
                Tile currentTile = tileList[i];
                Tile nextTile = tileList[i + 1];

                //If the tiles are not in the same set merge them 50% of the time
                if (setLookup[currentTile] != setLookup[nextTile] && rand.Next(2) > 0)
                {
                    List<Tile> leftSet = setLookup[currentTile];
                    List<Tile> rightSet = setLookup[nextTile];
                    int leftSize = leftSet.Count;
                    int rightSize = rightSet.Count;

                    if (leftSize >= rightSize) {
                        //Remove the right set from the set list
                        setList.Remove(rightSet);

                        //Combine the two sets into a one set
                        foreach (Tile t in rightSet)
                        {
                            setLookup.Remove(t);
                            leftSet.Add(t);
                            setLookup.Add(t, leftSet);
                        }
                    }
                    else
                    {
                        //Remove the right set from the set list
                        setList.Remove(leftSet);

                        //Combine the two sets into a one set
                        foreach (Tile t in leftSet)
                        {
                            setLookup.Remove(t);
                            rightSet.Add(t);
                            setLookup.Add(t, rightSet);
                        }
                    }

                    //Join the paths on the maze map
                    int x = currentTile.x + 1;
                    int y = currentTile.y;
                    mazeMap[x, y] = true;
                }
            }
            //Empty the dictionary so it can be populated for the next row
            setLookup.Clear();
        }

        public void extendLayer(int newY)
        {
            //Clear the current layer's tile list
            tileList.Clear();

            foreach (List<Tile> set in setList) {
                //If the set contains only 1 tile it must be extended
                if (set.Count == 1)
                {
                    //Extend the first tile of each down to the next layer
                    Tile firstTile = new Tile(set[0].x, set[0].y);
                    firstTile.y += 2;
                    set.Add(firstTile);
                    set.Remove(set[0]);
                    //Add the tile and set to the dictionary and tile list
                    setLookup.Add(firstTile, set);
                    tileList.Add(firstTile);
                    //Draw the vertical connection on the maze map
                    mazeMap[firstTile.x, firstTile.y - 1] = true;
                    mazeMap[firstTile.x, firstTile.y] = true;
                }
                else
                {
                    List<Tile> newSet = new List<Tile>();
                    int randomIndex = rand.Next(set.Count);

                    Tile currentTile = set[randomIndex];
                    Tile randTile = new Tile(currentTile.x, currentTile.y + 2);
                     
                    //Add the new tile and set to the dictionary and tile list
                    setLookup.Add(randTile, newSet);
                    tileList.Add(randTile);
                    //Draw the vertical connection on the mazemap
                    mazeMap[randTile.x, randTile.y - 1] = true;
                    mazeMap[randTile.x, randTile.y] = true;

                    //Every remaining tile in the set has a 50% chance of extending to the next layer  
                    for (int i = 0; i < set.Count; i++)
                    {
                        if (rand.Next(2) > 0 && set[i] != currentTile && set[i].y + 2 == newY)
                        {
                            Tile newTile = new Tile (set[i].x, set[i].y + 2);
                            newSet.Add(newTile);
                            //Add the new tile to the tile list and dictionary
                            setLookup.Add(newTile, newSet);
                            tileList.Add(newTile);
                            //Draw the vertical connection on the mazemap
                            mazeMap[newTile.x, newTile.y - 1] = true;
                            mazeMap[newTile.x, newTile.y] = true;
                        }
                        if (set[i] == currentTile)
                        {
                            newSet.Add(randTile);
                        }                       
                    } 

                }
            }
            setList.Clear();
        }

        public void populateLayer(int y)
        {
            List<Tile> extendedTiles = new List<Tile>();

            foreach (Tile tile in tileList)
            {
                if (extendedTiles.Count > 0)
                {
                    int exTileIndex = extendedTiles.Count - 1;
                    while (tile.x < extendedTiles[exTileIndex].x && exTileIndex > 0)
                    {
                        if (exTileIndex > 0) { exTileIndex--; }
                    }
                    extendedTiles.Insert(exTileIndex + 1, tile);
                }
                else
                {
                    extendedTiles.Add(tile);
                }
            }

            //Now the extended paths are added to the set list the tile list can be cleared
            tileList.Clear();

            //Counter for index of extended tiles
            int index = 0;
            for (int x = 1; x < width - 1; x += 2)
            {
                Tile testTile = new Tile(x, y);

                if (mazeMap[x, y] == true)
                {
                    //If the tile was extended from the previous layer and has not already been added to the set list
                    if (!setList.Contains(setLookup[extendedTiles[index]]))
                    {
                        setList.Add(setLookup[extendedTiles[index]]);
                    }

                    tileList.Add(extendedTiles[index]);

                    index++;
                }

                //If the tile was not extended from the previous layer
                if (mazeMap[x, y] == false)
                {
                    List<Tile> newSet = new List<Tile>();
                    newSet.Add(testTile);
                    //Add the new set to the set list
                    setList.Add(newSet);
                    //Add the tile and new set to the dictionary
                    setLookup.Add(testTile, newSet);
                    //Add the tile to the tile list
                    tileList.Add(testTile);
                    //Mark the tile as a path on the maze map
                    mazeMap[x, y] = true;
                }
            }
        }

        public override bool[,] generateMaze()
        {
            for (int y = 1; y < height - 3; y += 2)
            {
                populateLayer(y);
                joinSets();
                extendLayer(y + 2);
            }

            populateLayer(height - 2);
            joinSets();
            finishPaths();

            return mazeMap;
        }
    }
}
