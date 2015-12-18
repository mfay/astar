using System;
using System.Collections.Generic;
using System.Drawing;
using System.Xml.Serialization;
using CIS280.Astar.Properties;

namespace CIS280.Astar
{
    public abstract class Barrier
    {
        protected Size size = new Size(25, 25);
        public Point point;
        public abstract void Draw(Graphics g);

        public void Resize(object source, EventArgs e)
        {
            var ctrl = source as GridControl;
            if (null == ctrl) return;
            size = ctrl.BlockSize;
        }
    }

    [XmlInclude(typeof (Barrier)), XmlInclude(typeof (ImageBarrier))]
    public class BarrierCollection : List<Barrier>
    {
    }

    public abstract class ImageBarrier : Barrier
    {
        public override void Draw(Graphics g)
        {
            g.DrawImage(GetDrawable(), point.X, point.Y, size.Width, size.Height);
        }

        protected abstract Image GetDrawable();
    }

    public class Mud : Barrier
    {
        public override void Draw(Graphics g)
        {
            g.FillRectangle(Brushes.SaddleBrown, point.X + 1, point.Y + 1, size.Width - 1, size.Height - 1);
        }
    }

    public class Road : Barrier
    {
        public override void Draw(Graphics g)
        {
            g.FillRectangle(Brushes.PaleGoldenrod, point.X + 1, point.Y + 1, size.Width - 1, size.Height - 1);
        }
    }

    public class Gravel : Barrier
    {
        public override void Draw(Graphics g)
        {
            g.FillRectangle(Brushes.LightSlateGray, point.X + 1, point.Y + 1, size.Width - 1, size.Height - 1);
        }
    }

    public class Start : ImageBarrier
    {
        protected override Image GetDrawable()
        {
            return Resources.Office_Girl.ToBitmap();
        }
    }

    public class End : ImageBarrier
    {
        protected override Image GetDrawable()
        {
            return Resources.Close_2.ToBitmap();
        }
    }

    public class Tree : ImageBarrier
    {
        protected override Image GetDrawable()
        {
            return Resources.Tree_1b.ToBitmap();
        }
    }

    public class Bush : ImageBarrier
    {
        protected override Image GetDrawable()
        {
            return Resources.Tree_Ikebana_Darker.ToBitmap();
        }
    }

    public class Fern : ImageBarrier
    {
        protected override Image GetDrawable()
        {
            return Resources.Fern_1.ToBitmap();
        }
    }
}