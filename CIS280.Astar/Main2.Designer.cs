namespace CIS280.Astar
{
    partial class Main2
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.button1 = new System.Windows.Forms.Button();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.button2 = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.button3 = new System.Windows.Forms.Button();
            this.openFileDialog2 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog2 = new System.Windows.Forms.SaveFileDialog();
            this.gridControl21 = new CIS280.Astar.GridControl2();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnRunTest = new System.Windows.Forms.Button();
            this.cbDiagonal = new System.Windows.Forms.CheckBox();
            this.btnClearMap = new System.Windows.Forms.Button();
            this.statusStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 329);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(527, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(0, 17);
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Location = new System.Drawing.Point(104, 19);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "Save";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.SaveGrid_Click);
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.Filter = "Map file|*.map";
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button2.Location = new System.Drawing.Point(6, 19);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 3;
            this.button2.Text = "Load";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.LoadGrid_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.Filter = "Map file|*.map";
            // 
            // comboBox1
            // 
            this.comboBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(7, 48);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(173, 21);
            this.comboBox1.TabIndex = 4;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // button3
            // 
            this.button3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button3.Location = new System.Drawing.Point(7, 19);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 5;
            this.button3.Text = "Load";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.LoadTerrain_Click);
            // 
            // openFileDialog2
            // 
            this.openFileDialog2.Filter = "Terrain list|*.list";
            // 
            // saveFileDialog2
            // 
            this.saveFileDialog2.Filter = "Terrain list|*.list";
            // 
            // gridControl21
            // 
            this.gridControl21.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gridControl21.GridSize = new System.Drawing.Size(10, 10);
            this.gridControl21.Location = new System.Drawing.Point(12, 12);
            this.gridControl21.Name = "gridControl21";
            this.gridControl21.Size = new System.Drawing.Size(300, 300);
            this.gridControl21.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button3);
            this.groupBox1.Controls.Add(this.comboBox1);
            this.groupBox1.Location = new System.Drawing.Point(324, 79);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(190, 83);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Terrain";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.button2);
            this.groupBox2.Controls.Add(this.button1);
            this.groupBox2.Location = new System.Drawing.Point(324, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(190, 53);
            this.groupBox2.TabIndex = 9;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Maps";
            // 
            // btnRunTest
            // 
            this.btnRunTest.Location = new System.Drawing.Point(324, 179);
            this.btnRunTest.Name = "btnRunTest";
            this.btnRunTest.Size = new System.Drawing.Size(98, 23);
            this.btnRunTest.TabIndex = 10;
            this.btnRunTest.Text = "Run A*";
            this.btnRunTest.UseVisualStyleBackColor = true;
            this.btnRunTest.Click += new System.EventHandler(this.btnRunTest_Click);
            // 
            // cbDiagonal
            // 
            this.cbDiagonal.AutoSize = true;
            this.cbDiagonal.Checked = true;
            this.cbDiagonal.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbDiagonal.Location = new System.Drawing.Point(324, 294);
            this.cbDiagonal.Name = "cbDiagonal";
            this.cbDiagonal.Size = new System.Drawing.Size(138, 17);
            this.cbDiagonal.TabIndex = 11;
            this.cbDiagonal.Text = "check to allow diagonal";
            this.cbDiagonal.UseVisualStyleBackColor = true;
            // 
            // btnClearMap
            // 
            this.btnClearMap.Location = new System.Drawing.Point(324, 209);
            this.btnClearMap.Name = "btnClearMap";
            this.btnClearMap.Size = new System.Drawing.Size(98, 23);
            this.btnClearMap.TabIndex = 12;
            this.btnClearMap.Text = "Clear map";
            this.btnClearMap.UseVisualStyleBackColor = true;
            this.btnClearMap.Click += new System.EventHandler(this.btnClearMap_Click);
            // 
            // Main2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(527, 351);
            this.Controls.Add(this.btnClearMap);
            this.Controls.Add(this.cbDiagonal);
            this.Controls.Add(this.btnRunTest);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.gridControl21);
            this.Name = "Main2";
            this.Text = "A*";
            this.Load += new System.EventHandler(this.Main2_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GridControl2 gridControl21;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.OpenFileDialog openFileDialog2;
        private System.Windows.Forms.SaveFileDialog saveFileDialog2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnRunTest;
        private System.Windows.Forms.CheckBox cbDiagonal;
        private System.Windows.Forms.Button btnClearMap;
    }
}