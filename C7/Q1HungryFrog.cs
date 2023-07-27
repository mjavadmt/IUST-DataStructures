using System;
using TestCommon;
using System.Collections.Generic;
using System.Linq;

namespace C7
{
    public class Q1HungryFrog : Processor
    {
        public Q1HungryFrog(string testDataName) : base(testDataName)
        { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, long, long[][], long>)Solve);


        public virtual long Solve(long n, long p, long[][] numbers)
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
            return Math.Max(for_up.Last(),for_down.Last());
        }
    }
}
