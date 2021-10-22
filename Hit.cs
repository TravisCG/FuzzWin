using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuzzWin
{
    public class Hit
    {
        private string seqname;
        private int startpos;
        private int mismatch;
        private bool complement;
        private string hitseq;

        public Hit(string sname, int spos, int ms, bool comp, string hs)
        {
            seqname = sname;
            startpos = spos;
            mismatch = ms;
            complement = comp;
            hitseq = hs;
        }

        public string getName()
        {
            return seqname;
        }

        public int getPos()
        {
            return startpos;
        }

        public int getMismatch()
        {
            return mismatch;
        }

        public bool isComplement()
        {
            return complement;
        }

        public string getHitSeq()
        {
            return hitseq;
        }

        public string[] getRow()
        {
            string[] r = new string[5];
            r[0] = seqname;
            r[1] = Convert.ToString(startpos);
            r[2] = Convert.ToString(mismatch);
            r[3] = Convert.ToString(complement);
            r[4] = hitseq;
            return r;
        }
    }
}
