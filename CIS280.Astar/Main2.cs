using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace CIS280.Astar
{
    public partial class Main2 : Form
    {
        public Main2()
        {
            InitializeComponent();
        }

        private void Main2_Load(object sender, EventArgs e)
        {
            double defaultWeight = 2.0;

            TestContainer t = new TestContainer();
            var t1 = new Test {Name = "Start", BackgroundColor = "brown", Weight = 2.5};
            t.Add(t1);
            t1 = new Test {Name = "End", BackgroundColor = "brown", Weight = 2.5};
            t.Add(t1);
            t1 = new Test {Name = "Clear", BackgroundColor = "Control", Weight = defaultWeight};
            t.Add(t1);


            t1 = new Test {Name = "Tree", ImageName = "Tree 1b.ico", Weight = defaultWeight*2.5};
            t.Add(t1);
            t1 = new Test {Name = "Fern", ImageName = "Fern 1.ico", Weight = defaultWeight*1.7};
            t.Add(t1);
            t1 = new Test {Name = "Shrubbery", ImageName = "Tree Ikebana Darker.ico", Weight = defaultWeight*1.23};
            t.Add(t1);

            t1 = new Test {Name = "Mud", BackgroundColor = "sienna", Weight = defaultWeight*2};
            t.Add(t1);
            t1 = new Test {Name = "Stream", BackgroundColor = "steelblue", Weight = defaultWeight*2};
            t.Add(t1);
            t1 = new Test {Name = "Grass", BackgroundColor = "green", Weight = defaultWeight*.5};
            t.Add(t1);
            t1 = new Test {Name = "Road", BackgroundColor = "gold", Weight = defaultWeight*.25};
            t.Add(t1);

            gridControl21.SetEmptyWeight(defaultWeight);

            BindTerrain(t);
        }

        private void SaveGrid_Click(object sender, EventArgs e)
        {
            // save the grid
            if (saveFileDialog1.ShowDialog() != DialogResult.OK) return;

            Map map = gridControl21.GetMap();

            var s = new XmlSerializer(typeof (Map));
            var stream = saveFileDialog1.OpenFile();
            s.Serialize(stream, map);
            stream.Close();
        }

        private void LoadGrid_Click(object sender, EventArgs e)
        {
            // load grid
            if (openFileDialog1.ShowDialog() != DialogResult.OK) return;

            var s = new XmlSerializer(typeof (Map));
            var stream = openFileDialog1.OpenFile();
            Map map = (Map) s.Deserialize(stream);
            stream.Close();

            gridControl21.SetMap(map);
        }

        private void LoadTerrain_Click(object sender, EventArgs e)
        {
            if (openFileDialog2.ShowDialog() != DialogResult.OK) return;

            var s = new XmlSerializer(typeof (TestContainer));
            var stream = openFileDialog2.OpenFile();
            TestContainer map = (TestContainer) s.Deserialize(stream);
            stream.Close();


            var t1 = new Test {Name = "Start", BackgroundColor = "brown", Weight = 2.5};
            map.Insert(0, t1);
            t1 = new Test {Name = "End", BackgroundColor = "brown", Weight = 2.5};
            map.Insert(1, t1);

            BindTerrain(map);
            //comboBox1.DataSource = map.squares;
        }

        private void BindTerrain(TestContainer map)
        {
            comboBox1.DataSource = map;
            comboBox1.DisplayMember = "Name";
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            var cb = (ComboBox) sender;
            gridControl21.SetTerrain((Test) cb.SelectedItem);
        }

        private void btnRunTest_Click(object sender, EventArgs e)
        {
            Node[,] grid = gridControl21.FetchMatrix();


            Node mytest = grid[1, 0];
            double w = mytest.weight;

            Point? startLoc = gridControl21.GetStartLoc();
            Point? goalLoc = gridControl21.GetEndLoc();

            if (!startLoc.HasValue || !goalLoc.HasValue)
            {
                MessageBox.Show("You must set a start and end point first");
                return;
            }

            FirstRun fr = new FirstRun(startLoc.Value, goalLoc.Value, grid);
            fr.orthogonalOnly = !cbDiagonal.Checked;

            Node path = fr.GetPath();

            if (null == path)
            {
                MessageBox.Show("Could not find path", "Path is null");
            }
            else
            {
                List<Point> f = new List<Point>();
                Node n = path;
                while (n != null)
                {
                    f.Add(new Point(n.x, n.y));
                    n = n.parent;
                }
                gridControl21.SetPath(f);
            }
        }

        private void btnClearMap_Click(object sender, EventArgs e)
        {
            gridControl21.ClearMap();
        }
    }

    public class TestContainer : List<Test>
    {
    }

    public class Test
    {
        public string Name { get; set; }
        public string BackgroundColor { get; set; }
        public string ImageName { get; set; }
        public double Weight { get; set; }
    }

    public class Square
    {
        public double weight;
        public string imageName;
        public string backgroundColor;
        public int x;
        public int y;
    }

    public class Map
    {
        public List<Square> squares = new List<Square>();

        public void Add(Square square)
        {
            squares.Add(square);
        }
    }
}