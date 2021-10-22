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
    public partial class Form1 : Form
    {
        List<Hit> hits;

        public Form1()
        {
            InitializeComponent();
            hits = new List<Hit>();
        }

        private void loadButton_Click(object sender, EventArgs e)
        {
            DialogResult res = openFileDialog1.ShowDialog();
            if(res == DialogResult.OK)
            {
                fastaText.Text = System.IO.File.ReadAllText(openFileDialog1.FileName);
            }
        }

        /**
         * Reverse complementer generator
         * */
        private string revseq(string seq)
        {
            StringBuilder reverse = new StringBuilder();
            for(int i = seq.Length - 1; i >= 0; i--)
            {
                switch (seq[i]){
                    case 'A':
                    case 'a':
                        reverse.Append('T');
                        break;
                    case 'T':
                    case 't':
                        reverse.Append('A');
                        break;
                    case 'G':
                    case 'g':
                        reverse.Append('C');
                        break;
                    case 'C':
                    case 'c':
                        reverse.Append('G');
                        break;
                    default:
                        reverse.Append(seq[i]);
                        break;
                }
            }
            return reverse.ToString();
        }

        void fuzznuc(string header, string seq, string pattern, int mismatch, bool iscomplement)
        {
            string upattern = pattern.ToUpper();
            for(int i = 0; i < seq.Length - upattern.Length; i++)
            {
                string subseq = seq.Substring(i, upattern.Length).ToUpper();
                int m = 0;
                bool target = true;
                for(int j = 0; j < upattern.Length; j++)
                {
                    if(subseq[j] != upattern[j])
                    {
                        m++;
                        if(m > mismatch)
                        {
                            target = false;
                            break;
                        }
                    }
                }
                if (target)
                {
                    Hit onehit = new Hit(header, i + 1, m, iscomplement, subseq);
                    hits.Add(onehit);
                }
            }
        }

        void fastaparser(string fasta, string pattern, int mismatch, bool iscomplement)
        {
            System.IO.StringReader strread = new System.IO.StringReader(fasta);
            string line;
            string header = "";
            StringBuilder seqentry = new StringBuilder();

            while( (line = strread.ReadLine()) != null)
            {
                if (line.StartsWith(">"))
                {
                    if( seqentry.Length != 0)
                    {
                        fuzznuc(header, seqentry.ToString(), pattern, mismatch, iscomplement);
                    }
                    header = line.Substring(1);
                    seqentry = new StringBuilder();
                }
                else
                {
                    seqentry.Append(line);
                }
            }
            fuzznuc(header, seqentry.ToString(), pattern, mismatch, iscomplement);
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            hits.Clear();
            if (fastaText.TextLength == 0)
            {
                MessageBox.Show("Sequence no specified");
                return;
            }
            if(patternBox.TextLength == 0)
            {
                MessageBox.Show("Pattern not specified");
                return;
            }

            int mismatch = Convert.ToInt32(mismatchCount.Value);

            fastaparser(fastaText.Text, patternBox.Text, mismatch, false);

            if (checkBox1.Checked)
            {
                fastaparser(fastaText.Text, revseq(patternBox.Text), mismatch, true);
            }

            Results res = new Results();
            res.addResults(hits);
            res.Show();
        }
    }
}
