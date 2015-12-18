using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace CIS280.Astar
{
    public class Node
    {
        public Node()
        {
        }

        public Node(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public double weight;
        public Node parent;
        public int x;
        public int y;
        public double g; // cost from start
        public double h; // cost to goal

        public double f
        {
            get { return h + g; }
        }
    }

    public class PriorityQueue
    {
        private readonly List<Node> list = new List<Node>();

        public void Add(Node node)
        {
            list.Add(node);
        }

        public Node PeekAtNext()
        {
            if (list.Count == 0) return null;
            double min = list.Min(x => x.f);
            Node n = list.Find(x => x.f == min);
            return n;
        }

        public Node Next()
        {
            Node n = PeekAtNext();
            if (n != null)
            {
                list.Remove(n);
            }
            return n;
        }

        public bool IsEmpty()
        {
            return list.Count == 0;
        }

        public bool Contains(Node node)
        {
            return list.Contains(node);
        }
    }


    public class FirstRun : IAstar
    {
        private readonly Point startLoc;
        private readonly Point goalLoc;
        private readonly Node[,] grid;

        public FirstRun(Point startLoc, Point goalLoc, Node[,] grid)
        {
            this.goalLoc = goalLoc;
            this.startLoc = startLoc;
            this.grid = grid;
        }

        public bool orthogonalOnly;

        public Node GetPath()
        {
            var openList = new PriorityQueue();
            var closedList = new PriorityQueue();

            Node start = new Node(startLoc.X, startLoc.Y);
            start.g = 0.0;
            start.h = CostToGoal(start);

            openList.Add(start);

            Node currentNode;
            while ((currentNode = openList.Next()) != null)
            {
                if (currentNode.x == goalLoc.X && currentNode.y == goalLoc.Y)
                {
                    // we are out of here!
                    return currentNode;
                }
                closedList.Add(currentNode);

                List<Node> neighbors = GetNeighbors(currentNode);
                foreach (Node neighbor in neighbors)
                {
                    if (closedList.Contains(neighbor)) continue;

                    double tenativeG = currentNode.g + CalcDistance(currentNode, neighbor) + neighbor.weight;

                    if (neighbor.g <= 0.0)
                    {
                        neighbor.g = tenativeG;
                    }
                    bool tenativeIsBetter = false;

                    if (!openList.Contains(neighbor))
                    {
                        openList.Add(neighbor);
                        tenativeIsBetter = true;
                    }
                    else if (tenativeG < neighbor.g)
                    {
                        tenativeIsBetter = true;
                    }

                    if (tenativeIsBetter)
                    {
                        neighbor.parent = currentNode;
                        neighbor.g = tenativeG;
                        neighbor.h = CostToGoal(neighbor);
                    }
                }
            }
            return null;
        }

        private static double CalcDistance(Node n1, Node n2)
        {
            return Math.Sqrt(Math.Pow(n1.x - n2.x, 2) * Math.Pow(n1.y - n2.y, 2));
        }

        private double CostToGoal(Node n)
        {
            // Euclidean
            return Math.Sqrt(Math.Pow((n.x - goalLoc.X), 2) + Math.Pow((n.y - goalLoc.Y), 2));
        }

        private List<Node> GetNeighbors(Node n)
        {
            var neighbors = new List<Node>();
            int w = grid.GetUpperBound(0);
            int h = grid.GetUpperBound(1);

            if (n.x + 1 <= w)
            {
                neighbors.Add(grid[n.x + 1, n.y]);
            }
            if (n.y + 1 <= h)
            {
                neighbors.Add(grid[n.x, n.y + 1]);
            }
            if (n.x - 1 >= 0)
            {
                neighbors.Add(grid[n.x - 1, n.y]);
            }
            if (n.y - 1 >= 0)
            {
                neighbors.Add(grid[n.x, n.y - 1]);
            }
            if (!orthogonalOnly)
            {
                if (n.x - 1 >= 0 && n.y - 1 >= 0)
                {
                    neighbors.Add(grid[n.x - 1, n.y - 1]);
                }
                if (n.x + 1 <= w && n.y - 1 >= 0)
                {
                    neighbors.Add(grid[n.x + 1, n.y - 1]);
                }
                if (n.x - 1 >= 0 && n.y + 1 <= h)
                {
                    neighbors.Add(grid[n.x - 1, n.y + 1]);
                }
                if (n.x + 1 <= w && n.y + 1 <= h)
                {
                    neighbors.Add(grid[n.x + 1, n.y + 1]);
                }
            }

            return neighbors;
        }
    }
}