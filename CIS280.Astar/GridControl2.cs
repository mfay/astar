using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace CIS280.Astar
{
    public partial class GridControl2 : UserControl
    {
        private readonly Pen pen = Pens.Black;
        private readonly List<Terrain> points = new List<Terrain>();
        private List<Point> path;
        private Test clickType;
        private Point? start;
        private Point? end;
        private double weight = 1.0;

        public GridControl2()
        {
            GridSize = new Size(10, 10);
            InitializeComponent();
        }

        public Size GridSize { get; set; }

        protected override void OnResize(EventArgs e)
        {
            Invalidate();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            DrawGrid(g);
        }

        protected override void OnMouseClick(MouseEventArgs e)
        {
            if (null == clickType) return;

            int x = e.X/(Width/GridSize.Width);
            int y = e.Y/(Height/GridSize.Height);

            switch (clickType.Name)
            {
                case "Start":
                    start = new Point(x, y);
                    if (end.HasValue && x == end.Value.X && y == end.Value.Y) end = null;
                    path = null;
                    break;
                case "End":
                    end = new Point(x, y);
                    if (start.HasValue && x == start.Value.X && y == start.Value.Y) start = null;
                    path = null;
                    break;
                default:
                    var square = new Square();
                    square.weight = clickType.Weight;
                    square.backgroundColor = clickType.BackgroundColor;
                    square.imageName = clickType.ImageName;
                    square.x = x;
                    square.y = y;

                    AddTerrain(new Terrain(square));
                    break;
            }

            Invalidate();
        }

        private void AddTerrain(Terrain terrain)
        {
            if (null == terrain) return;

            Terrain tt = points.Find(t => t.Square.x == terrain.Square.x && t.Square.y == terrain.Square.y);
            if (null != tt)
            {
                points.Remove(tt);
            }

            points.Add(terrain);
        }

        private void DrawGrid(Graphics g)
        {
            int w = Width - Width%GridSize.Width - 1;
            int h = Height - Height%GridSize.Height - 1;
            int gw = Width/GridSize.Width;
            int gh = Height/GridSize.Height;

            g.SmoothingMode = SmoothingMode.AntiAlias;

            foreach (Terrain pt in points)
            {
                pt.Draw(g, gw, gh);
            }

            g.DrawRectangle(pen, 0, 0, w, h);

            for (int x = 0; x < GridSize.Width; x++)
            {
                g.DrawLine(pen, x*gw, 0, x*gw, h);
            }

            for (int y = 0; y < GridSize.Width; y++)
            {
                g.DrawLine(pen, 0, y*gh, w, y*gh);
            }



            if (null != path)
            {
                GraphicsPath gp = new GraphicsPath();
                int len = path.Count - 1;
                g.FillRectangle(Brushes.DarkBlue, path[0].X * gw + gw / 4, path[0].Y * gh + gh / 4, gw / 2, gh / 2);
                g.FillEllipse(Brushes.DarkBlue, path[len].X * gw + gw / 4, path[len].Y * gh + gh / 4, gw / 2, gh / 2);
                for (int i = 0; i < len; i++)
                {
                    var pt1 = new Point(path[i].X * gw + gw / 2, path[i].Y * gh + gh / 2);
                    var pt2 = new Point(path[i + 1].X * gw + gw / 2, path[i + 1].Y * gh + gh / 2);
                    gp.AddLine(pt1, pt2);
                }
                g.DrawPath(Pens.DarkBlue, gp);
            }
            else
            {
                if (start.HasValue)
                {
                    g.FillEllipse(Brushes.DarkBlue, start.Value.X * gw + gw / 4, start.Value.Y * gh + gh / 4, gw / 2, gh / 2);
                    
                }
                if (end.HasValue)
                {
                    g.FillRectangle(Brushes.DarkBlue,end.Value.X * gw + gw / 4, end.Value.Y * gh + gh / 4, gw / 2, gh / 2);
                    
                }
            }
        }

        public Map GetMap()
        {
            Map m = new Map();
            foreach (Terrain terrain in points)
            {
                m.Add(terrain.Square);
            }
            return m;
        }

        public void SetMap(Map map)
        {
            points.Clear();
            foreach (Square square in map.squares)
            {
                points.Add(new Terrain(square));
            }
            Invalidate();
        }

        public void SetPath(List<Point> path)
        {
            this.path = path;
            Invalidate();
        }

        public void SetTerrain(Test selectedItem)
        {
            clickType = selectedItem;
        }

        public Node[,] FetchMatrix()
        {
            var nodes = new Node[GridSize.Width,GridSize.Height];
            for (int x = 0; x < GridSize.Width; x++)
            {
                for (int y = 0; y < GridSize.Height; y++)
                {
                    Node n = new Node(x, y);
                    n.weight = weight;
                    nodes[x, y] = n;
                }
            }

            foreach (Terrain terrain in points)
            {
                Node n = new Node(terrain.Square.x, terrain.Square.y);
                n.weight = terrain.Square.weight;
                nodes[terrain.Square.x, terrain.Square.y] = n;
            }
            return nodes;
        }

        public Point? GetStartLoc()
        {
            return start;
        }

        public Point? GetEndLoc()
        {
            return end;
        }

        public void SetEmptyWeight(double weight)
        {
            this.weight = weight;
        }

        public void ClearMap()
        {
            path = null;
            points.Clear();
            Invalidate();
        }
    }
}