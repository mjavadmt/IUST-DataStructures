using System;
using System.Collections.Generic;
using System.Linq;
using TestCommon;

namespace C7
{
    public class Q2HungryFrogPath : Processor
    {
        public Q2HungryFrogPath(string testDataName) : base(testDataName)
        {
        }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, long, long[][], long[]>)Solve);


        public static long[] Solve(long n, long p, long[][] numbers)
        {
            long[] path = new long[n];
            var two_list = get_path(n,p, numbers);
            path[n-1] = (two_list.Item1.Last() > two_list.Item2.Last()) ? 0 : 1;
            for (int i = two_list.Item1.Count - 1 ; i >= 1 ; i--)
            {
                if (path[i] == 1)
                {
                    if (two_list.Item1[i-1] + numbers[1][i] - p == two_list.Item2[i] )
                        path[i-1] = 0;
                    else if (two_list.Item2[i - 1] + numbers[1][i] == two_list.Item2[i])
                        path[i-1] = 1;
                }
                else
                {
                    if (two_list.Item2[i-1] + numbers[0][i] - p == two_list.Item1[i])
                        path[i-1] = 1;
                    else if (two_list.Item1[i-1] + numbers[0][i] == two_list.Item1[i])
                        path[i-1] = 0;
                }
            }
            return path;
        }
        public static (List<long>, List<long>) get_path(long n, long p, long[][] numbers)
        {
            List<long> for_up = new List<long>(){numbers[0][0]};
            List<long> for_down = new List<long>(){numbers[1][0]};
            // 6 2
            // 1 2 3 4 7 1
            // 4 5 1 4 1 7
            for (long i = 1 ; i<numbers[0].Length ; i++)
            {
                for_up.Add(Math.Max(for_up[(int)i - 1] + numbers[0][i],for_down[(int)i-1] - p + numbers[0][i]));
                for_down.Add(Math.Max(for_down[(int)i - 1] + numbers[1][i],for_up[(int)i-1] - p + numbers[1][i]));
            }
            return (for_up, for_down);
        }
    }
}
