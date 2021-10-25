using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuzzWin
{
    class Match
    {
        private Dictionary<Char, Dictionary<Char, int>> matchmatrix;

        public Match()
        {
            matchmatrix = new Dictionary<char, Dictionary<char, int>>();

            // Set everything to 1 (mismatch)
            string nucleotides = "ATGCNRYKMSWBDHV";
            for(int i = 0; i < nucleotides.Length; i++)
            {
                matchmatrix.Add(nucleotides[i], new Dictionary<char, int>());
                for(int j = 0; j < nucleotides.Length; j++)
                {
                    matchmatrix[nucleotides[i]][nucleotides[j]] = 1;
                }
            }

            matchmatrix['A']['A'] = 0;
            matchmatrix['T']['T'] = 0;
            matchmatrix['C']['C'] = 0;
            matchmatrix['G']['G'] = 0;
            matchmatrix['R']['R'] = 0;
            matchmatrix['N']['N'] = 0;
            matchmatrix['Y']['Y'] = 0;
            matchmatrix['K']['K'] = 0;
            matchmatrix['M']['M'] = 0;
            matchmatrix['S']['S'] = 0;
            matchmatrix['W']['W'] = 0;
            matchmatrix['B']['B'] = 0;
            matchmatrix['D']['D'] = 0;
            matchmatrix['H']['H'] = 0;
            matchmatrix['V']['V'] = 0;

            matchmatrix['N']['A'] = 0;
            matchmatrix['N']['T'] = 0;
            matchmatrix['N']['G'] = 0;
            matchmatrix['N']['C'] = 0;

            matchmatrix['A']['N'] = 0;
            matchmatrix['T']['N'] = 0;
            matchmatrix['G']['N'] = 0;
            matchmatrix['C']['N'] = 0;

            matchmatrix['R']['A'] = 0;
            matchmatrix['R']['G'] = 0;

            matchmatrix['A']['R'] = 0;
            matchmatrix['G']['R'] = 0;

            matchmatrix['Y']['T'] = 0;
            matchmatrix['Y']['C'] = 0;

            matchmatrix['T']['Y'] = 0;
            matchmatrix['C']['Y'] = 0;

            matchmatrix['K']['G'] = 0;
            matchmatrix['K']['T'] = 0;

            matchmatrix['G']['K'] = 0;
            matchmatrix['T']['K'] = 0;

            matchmatrix['M']['A'] = 0;
            matchmatrix['M']['C'] = 0;

            matchmatrix['A']['M'] = 0;
            matchmatrix['C']['M'] = 0;

            matchmatrix['S']['G'] = 0;
            matchmatrix['S']['C'] = 0;

            matchmatrix['G']['S'] = 0;
            matchmatrix['C']['S'] = 0;

            matchmatrix['W']['A'] = 0;
            matchmatrix['W']['T'] = 0;

            matchmatrix['A']['W'] = 0;
            matchmatrix['T']['W'] = 0;

            matchmatrix['B']['C'] = 0;
            matchmatrix['B']['G'] = 0;
            matchmatrix['B']['T'] = 0;

            matchmatrix['C']['B'] = 0;
            matchmatrix['G']['B'] = 0;
            matchmatrix['T']['B'] = 0;

            matchmatrix['D']['A'] = 0;
            matchmatrix['D']['G'] = 0;
            matchmatrix['D']['T'] = 0;

            matchmatrix['A']['D'] = 0;
            matchmatrix['G']['D'] = 0;
            matchmatrix['T']['D'] = 0;

            matchmatrix['H']['A'] = 0;
            matchmatrix['H']['C'] = 0;
            matchmatrix['H']['T'] = 0;

            matchmatrix['A']['H'] = 0;
            matchmatrix['C']['H'] = 0;
            matchmatrix['T']['H'] = 0;

            matchmatrix['V']['A'] = 0;
            matchmatrix['V']['C'] = 0;
            matchmatrix['V']['G'] = 0;

            matchmatrix['A']['V'] = 0;
            matchmatrix['C']['V'] = 0;
            matchmatrix['G']['V'] = 0;
        }

        public int getmatch(char a, char b)
        {
            if(matchmatrix.ContainsKey(a) && matchmatrix[a].ContainsKey(b))
            {
                return matchmatrix[a][b];
            }
            return 1;
        }
    }
}
