using System;
using System.Collections.Generic;
using System.Text;
using TestCommon;
using System.Linq;

namespace A7
{
    public class Q2PartitioningSouvenirs : Processor
    {
        public Q2PartitioningSouvenirs(string testDataName) : base(testDataName) { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, long[], long>)Solve);

        public long Solve(long souvenirsCount, long[] souvenirs)
        {
            long total_weight = souvenirs.Sum();
            if (souvenirsCount < 3)
                return 0;
            if (total_weight % 3 != 0)
                return 0;
            return Partition((int) total_weight / 3 , souvenirsCount , souvenirs);
        }
        private static long Partition(long W, long n, long[] items)
        {
            long count = 0;
            long[,] values = new long[W+1,n+1];
            for (long i = 1 ; i < W + 1 ; i++)
            {
                for (long j = 1 ; j<n+1 ; j++)
                {
                    values[i,j] = values[i,j-1];
                    if (items[j - 1] <= i)
                    {
                        long temp = values[i - items[j-1],j-1] + items[j-1];
                        if (temp > values[i,j])
                        {
                            values[i,j] = temp;
                        }
                    }
                    if (values[i,j] == W)
                        count ++ ;
                }
            }
            if (count < 3)
                return 0;
            else
                return 1; 
        } 
    }
}
