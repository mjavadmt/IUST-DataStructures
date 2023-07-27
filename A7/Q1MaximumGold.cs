using System;
using System.Collections.Generic;
using System.Text;
using TestCommon;

namespace A7
{
    public class Q1MaximumGold : Processor
    {
        public Q1MaximumGold(string testDataName) : base(testDataName) { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, long[], long>)Solve);

        public long Solve(long W, long[] goldBars)
        {
            long[,] values = new long[goldBars.Length + 1,W + 1];
            for (long i = 1 ; i<goldBars.Length + 1 ; i++ )
            {
                for (long j = 1 ; j< W + 1 ; j++)
                {
                    if (j < goldBars[i-1])
                    {
                        values[i,j] = values[i-1,j];
                    }
                    else
                    {
                        values[i,j] = Math.Max(values[i-1,j] ,values[i - 1,j - goldBars[i - 1]] + goldBars[i - 1]);
                    }
                }
            } 
            return values[goldBars.Length,W];
        }
    }
}
