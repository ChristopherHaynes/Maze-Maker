using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazeMaker
{
    //Representation of the vertex in a disjointed set
    class Vertex
    {
        public Vertex parent;

        //A Vertex with a parent of itself is a root node
        public Vertex() { this.parent = this; }
    }

    //Co-ordinates of both verticies which create the edge
    struct Edge
    {
        public int ax, ay;
        public int bx, by;
    }

    class KruskalMaze : MazeGenerator
    {
        //List behaving as a stack to remember current tile position
        Vertex[,] vertexList;
        List<Edge> edgeList;

        public KruskalMaze(int width, int height)
        {
            this.width = width;
            this.height = height;

            vertexList = new Vertex[width, height];
            edgeList = new List<Edge>();

            mazeMap = new bool[width, height];
            Array.Clear(mazeMap, 0, mazeMap.Length);

            //Populate the vertex list with all the possible path positions and edges        
            for (int x = 1; x < width - 1; x += 2) {
                for(int y = 1; y < height - 1; y += 2)
                {
                    //Add the vertex in its position to the list
                    vertexList[x, y] = new Vertex();

                    //Add the north and west edges for every vertex bigger than 1
                    Edge newEdge;
                    if (x > 1)
                    {
                        newEdge = new Edge();
                        newEdge.ax = x; newEdge.ay = y;
                        newEdge.bx = x - 2; newEdge.by = y;
                        edgeList.Add(newEdge);
                    }

                    if (y > 1)
                    {
                        newEdge = new Edge();
                        newEdge.ax = x; newEdge.ay = y;
                        newEdge.bx = x; newEdge.by = y - 2;
                        edgeList.Add(newEdge);
                    }

                    //Mark the vector positions as paths on the maze map
                    mazeMap[x, y] = true;
                }
            }
        }

        public override bool[,] generateMaze()
        {
            while (edgeList.Count > 0)
            {
                int pos = rand.Next(edgeList.Count);
                Edge testEdge = edgeList[pos];
                union(testEdge);
                edgeList.Remove(testEdge);
            }
            if (edgeList.Count == 0)
            {
                finishPaths();
            }
            return mazeMap;
        }

        //Navigate up the tree until the parent is found
        public Vertex findRoot(Vertex vertex)
        {
            while (vertex.parent != vertex)
            {
                vertex = vertex.parent;
            }
            return vertex;
        }

        //Check if two verticies share a common tree
        public bool commonTree(Vertex a, Vertex b)
        {
            bool result = false;

            Vertex rootA = findRoot(a);
            Vertex rootB = findRoot(b);

            if (rootA == rootB) { result = true; }

            return result;
        }

        //Combine two trees together
        public void union(Edge edge)
        {
            Vertex a = vertexList[edge.ax, edge.ay];
            Vertex b = vertexList[edge.bx, edge.by];

            //If the two verticies don't share the same tree
            if (!commonTree(a,b))
            {
                //Mark the join between the paths on the map
                int xOffset = edge.ax - edge.bx;
                int yOffset = edge.ay - edge.by;

                //If the path is west
                if (xOffset == 2) { mazeMap[edge.ax - 1, edge.ay] = true; }

                //If the path is north
                if (yOffset == 2) { mazeMap[edge.ax, edge.ay - 1] = true; }

                //Randomly choose one tree root to be the parent of the other
                Vertex rootA = findRoot(a);
                Vertex rootB = findRoot(b);

                int choice = rand.Next(2);
                if (choice == 0) { rootA.parent = rootB; }
                if (choice == 1) { rootB.parent = rootA; }
            }
        }
    }
}
