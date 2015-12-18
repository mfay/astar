using System;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace CIS280.Astar
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = 0;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            gridControl1.SetClickBehavior(comboBox1.SelectedItem.ToString());
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // save the grid
            if (saveFileDialog1.ShowDialog() != DialogResult.OK) return;

            Entity i = new Entity();
            i["Name"] = "Mark";
            i["Color"] = "Blue";

            var s = new XmlSerializer(typeof(Entity));
            var stream = saveFileDialog1.OpenFile();
            s.Serialize(stream, i);
            stream.Close();
        }

        private void loadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // load the grid
        }
    }
}