using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TestCommon;

namespace A6
{
    public class Q3EditDistance : Processor
    {
        public Q3EditDistance(string testDataName) : base(testDataName) { }
        
        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<string, string, long>)Solve);

        public long Solve(string str1, string str2)
        {
            long[,] l = new long[str2.Length+1, str1.Length+1];
            // int i = 0 ;
            // int j = 0;
            for (int i =0 ; i<str2.Length + 1; i++)
            {
                for (int j = 0; j<str1.Length + 1;j++)
                {
                    if ( i == 0 && j == 0)
                        continue;
                    else if ( i == 0)
                        l[i,j] = l[i,j-1] + 1;
                    else if ( j == 0)
                        l[i,j] = l[i-1,j] + 1;
                    else if (str1[j-1] == str2[i-1])
                        l[i,j] = new long[]{l[i - 1,j - 1], l[i,j - 1] + 1, l[i - 1,j] + 1}.Min();
                    else if (str1[j-1] != str2[i-1])
                        l[i,j] = new long[]{l[i - 1,j - 1]+1, l[i,j - 1] + 1, l[i - 1,j] + 1}.Min();

                }
            }
            // write your code here
            return l[str2.Length, str1.Length];
        }
    }
}
