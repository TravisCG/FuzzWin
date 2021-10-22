using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FuzzWin
{
    public partial class Results : Form
    {
        public Results()
        {
            InitializeComponent();
        }

        public void addResults(List<Hit> hits)
        {
            dataGridView1.ColumnCount = 5;
            dataGridView1.Columns[0].Name = "Sequence ID";
            dataGridView1.Columns[1].Name = "Start position";
            dataGridView1.Columns[2].Name = "Mismatch";
            dataGridView1.Columns[3].Name = "Reverse complementer?";
            dataGridView1.Columns[4].Name = "Sequence";

            foreach(Hit h in hits)
            {
                dataGridView1.Rows.Add(h.getRow());
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult res = saveFileDialog1.ShowDialog();
            if (res == DialogResult.OK)
            {
                System.IO.StreamWriter output = new System.IO.StreamWriter(saveFileDialog1.FileName);
                output.WriteLine("SequenceID\tStart_position\tMismatch\tIs_reverse_complementer\tSequence");
                for (int i = 0; i < dataGridView1.RowCount; i++)
                {
                    StringBuilder outline = new StringBuilder();
                    outline.Append(dataGridView1.Rows[i].Cells[0].Value);
                    outline.Append('\t');
                    outline.Append(dataGridView1.Rows[i].Cells[1].Value);
                    outline.Append('\t');
                    outline.Append(dataGridView1.Rows[i].Cells[2].Value);
                    outline.Append('\t');
                    outline.Append(dataGridView1.Rows[i].Cells[3].Value);
                    outline.Append('\t');
                    outline.Append(dataGridView1.Rows[i].Cells[4].Value);
                    output.WriteLine(outline);
                }
                output.Close();
            }
        }
    }
}
