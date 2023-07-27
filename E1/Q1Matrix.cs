using System;
using System.Linq;
using System.Threading;
using TestCommon;
using System.Collections.Generic;

namespace E1
{
    public class Q1Matrix : Processor
    {
        public Q1Matrix(string testDataName) : base(testDataName)
        {
        }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, long[], long[], long[,]>)Solve);

        public static long[,] Solve(long n, long[] rows,long[] columns)
        {
            long[,] res = new long[n, n];
            long complete = 0 ;
            while (complete < n)
            {
                var index_max = rows.ToList().IndexOf(rows.Max()) ;
                
                for (int i = 0 ; i<columns.Length ; i++)
                {
                    if (columns[i] != 0)
                    {
                        res[index_max,i] = 1;
                        columns[i]-= 1;
                        rows[index_max] -= 1;
                        if (rows[index_max] == 0)
                        {
                            break;
                        }
                    }
                }
                rows[index_max] = -1;
                complete ++ ;
            }
            return res;
        }
        
    }
}
