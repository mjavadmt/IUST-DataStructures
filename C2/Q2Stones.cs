using System;
using System.Collections.Generic;
using TestCommon;

namespace C2
{
    public class Q2Stones : Processor
    {
        public Q2Stones(string testDataName) : base(testDataName)
        { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, long[], long>)Solve);


        public static long Solve(long n, long[] stones)
        {
            long Initializer = 1 ;
            long SumOfStones = 0 ;
            var Stones_length = stones.Length;
            while (SumOfStones < n)
            {
                if (Initializer == Stones_length + 1)
                {
                    return 0;
                }
                SumOfStones += stones[Initializer - 1];
                Initializer ++ ;
            }
            return Initializer - 1;
        }
    }
}
