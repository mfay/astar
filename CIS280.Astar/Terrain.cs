using System;
using System.Drawing;
using System.IO;
using System.Reflection;

namespace CIS280.Astar
{
    public class Terrain
    {
        private readonly Brush brush;
        private readonly Image drawable;
        private readonly Square square;

        public Terrain(Square square)
        {
            this.square = square;
            if (!string.IsNullOrEmpty(square.imageName))
            {
                Assembly assembly = this.GetType().Assembly;
                string resourceName = string.Format("CIS280.Astar.Resources.{0}", square.imageName);
                Stream stream = assembly.GetManifestResourceStream(resourceName);
                if (null == stream)
                {
                    throw new Exception("Failed to load resource: " + resourceName);
                }
                drawable = new Bitmap(stream);
            }
            if (!string.IsNullOrEmpty(square.backgroundColor))
            {
                Color c = Color.FromName(square.backgroundColor);
                brush = new SolidBrush(c);
            }
        }

        public double Weight
        {
            get { return square.weight; }
        }

        public Square Square
        {
            get { return square; }
        }

        public void Draw(Graphics g, int width, int height)
        {
            int x = square.x*width;
            int y = square.y*height;

            if (null != brush)
            {
                g.FillRectangle(brush, new Rectangle(x, y, width, height));
            }
            if (null != drawable)
            {
                g.DrawImage(drawable, x, y, width, height);
            }
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != typeof (Terrain)) return false;
            return Equals((Terrain) obj);
        }

        public bool Equals(Terrain other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Equals(other.square, square);
        }

        public override int GetHashCode()
        {
            return (square != null ? square.GetHashCode() : 0);
        }
    }
}