using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TestCommon;

namespace A6
{
    public class Q4LCSOfTwo : Processor
    {
        public Q4LCSOfTwo(string testDataName) : base(testDataName) { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long[], long[], long>)Solve);

        public static long Solve(long[] seq1, long[] seq2)
        {
            // write your code here
            long[,] l = new long[seq2.Length+1, seq1.Length+1];
            // int i = 0 ;
            // int j = 0;
            for (int i =0 ; i<seq2.Length + 1; i++)
            {
                for (int j = 0; j<seq1.Length + 1;j++)
                {
                    if ( i == 0 && j == 0)
                        continue;
                    else if ( i == 0)
                        l[i,j] = l[i,j-1] + 1;
                    else if ( j == 0)
                        l[i,j] = l[i-1,j] + 1;
                    else if (seq1[j-1] == seq2[i-1])
                        l[i,j] = new long[]{l[i - 1,j - 1], l[i,j - 1] + 1, l[i - 1,j] + 1}.Min();
                    else if (seq1[j-1] != seq2[i-1])
                        l[i,j] = new long[]{ l[i,j - 1] + 1, l[i - 1,j] + 1}.Min();

                }
            }
            var ii = seq2 .Length;
            var jj = seq1.Length;
            long matches_numbers = 0;
            while (ii != 0 && jj != 0)
            {
                if (seq1[jj-1] == seq2[ii-1] && l[ii - 1,jj - 1] <= l[ii,jj - 1] && l[ii - 1,jj - 1] <= l[ii - 1,jj])
                {
                    matches_numbers ++;
                    ii --;
                    jj --;
                }
                else
                {
                    if (l[ii,jj - 1] < l[ii - 1,jj])
                        jj --;
                    else
                        ii --;
                }
            }
                
            return matches_numbers;
        }
    }
}
