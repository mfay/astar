using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace CIS280.Astar
{
    public partial class GridControl : UserControl
    {
        private IClickBehavior clickBehavior;
        public Size gridSize = new Size(10, 10); // 10x10 grid
        public Size BlockSize { get; private set; }
        private BarrierCollection points = new BarrierCollection();

        public GridControl()
        {
            clickBehavior = new ClickBehavior<Start>(this);
            InitializeComponent();
            //SetStyle(ControlStyles.AllPaintingInWmPaint |
            //         ControlStyles.UserPaint |
            //         ControlStyles.DoubleBuffer, true);
            ComputeBlockSize();
        }

        private void ComputeBlockSize()
        {
            int w = Width/gridSize.Width;
            int h = Height/gridSize.Height;
            BlockSize = new Size(w, h);
        }

        public BarrierCollection GetBarriers()
        {
            return points;
        }

        public void SetBarriers(BarrierCollection barrier)
        {
            points = barrier;
            Invalidate();
        }

        private void AddBarrier(Barrier barrier)
        {
            Barrier b = points.Find(i => i.point == barrier.point);
            if (null != b) points.Remove(b);
            points.Add(barrier);
        }

        public List<Barrier> GetBarriers<T>()
        {
            List<Barrier> barriers = new List<Barrier>();

            foreach (Barrier barrier in points)
            {
                if (barrier is T) barriers.Add(barrier);
            }
            return barriers;
        }

        private void RemoveBarriers(List<Barrier> barriers)
        {
            points.RemoveAll(i => barriers.Contains(i));
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            ComputeBlockSize();
            Invalidate();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            g.DrawRectangle(Pens.Black, 0, 0, Width - 1, Height - 1);

            for (int x = 0; x < Width; x += BlockSize.Width)
            {
                g.DrawLine(Pens.Black, x, 0, x, Height);
            }
            for (int y = 0; y < Height; y += BlockSize.Height)
            {
                g.DrawLine(Pens.Black, 0, y, Width, y);
            }
            foreach (Barrier barrier in points)
            {
                barrier.Draw(g);
            }
        }

        protected override void OnMouseClick(MouseEventArgs e)
        {
            clickBehavior.SetPoint(e.X, e.Y);
            Invalidate();
        }

        public void SetClickBehavior(string behaviorString)
        {
            switch (behaviorString)
            {
                case "Start":
                    clickBehavior = new ClickBehavior<Start>(this);
                    break;
                case "End":
                    clickBehavior = new ClickBehavior<End>(this);
                    break;
                case "Tree":
                    clickBehavior = new ClickBehavior<Tree>(this, true);
                    break;
                case "Brush":
                    clickBehavior = new ClickBehavior<Bush>(this, true);
                    break;
                case "Mud":
                    clickBehavior = new ClickBehavior<Mud>(this, true);
                    break;
                case "Fern":
                    clickBehavior = new ClickBehavior<Fern>(this, true);
                    break;
                case "Road":
                    clickBehavior = new ClickBehavior<Road>(this, true);
                    break;
                case "Gravel":
                    clickBehavior = new ClickBehavior<Gravel>(this, true);
                    break;
            }
        }

        internal interface IClickBehavior
        {
            void SetPoint(int x, int y);
        }

        internal abstract class BaseClickBehavior : IClickBehavior
        {
            protected GridControl parent;

            protected BaseClickBehavior(GridControl parent)
            {
                this.parent = parent;
            }

            public abstract void SetPoint(int x, int y);
        }

        internal class NullClickBehavior : IClickBehavior
        {
            public void SetPoint(int x, int y)
            {
            }
        }

        internal class ClickBehavior<T> : IClickBehavior where T : Barrier, new()
        {
            private readonly GridControl parent;
            private readonly bool allowMultiple;

            public ClickBehavior(GridControl parent)
                : this(parent, false)
            {
            }

            public ClickBehavior(GridControl parent, bool allowMultiple)
            {
                this.parent = parent;
                this.allowMultiple = allowMultiple;
            }

            public void SetPoint(int x, int y)
            {
                if (!allowMultiple)
                {
                    List<Barrier> barriers = parent.GetBarriers<T>();
                    if (barriers.Count > 0) parent.RemoveBarriers(barriers);
                }

                var t = new T();
                var pt = parent.TranslatePoint(x, y);
                t.point = pt;
                parent.Resize += t.Resize;
                parent.AddBarrier(t);
            }
        }

        private Point TranslatePoint(int x, int y)
        {
            int tx = (x/BlockSize.Width)*BlockSize.Width;
            int ty = (y/BlockSize.Height)*BlockSize.Height;
            return new Point(tx, ty);
        }
    }

    public class Entity
    {
        [XmlArray]
        public Dictionary<string, string> properties = new Dictionary<string, string>();

        public string this[string index]
        {
            get { return properties[index]; }
            set { properties[index] = value; }
        }
    }
}