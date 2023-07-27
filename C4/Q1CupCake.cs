using System;
using System.Linq;
using System.Threading;
using TestCommon;

namespace C4
{
    public class Q1CupCake : Processor
    {
        public Q1CupCake(string testDataName) : base(testDataName)
        {
        }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long[], long[], long>)Solve);

        public static long Solve(long[] init,long[] prices)
        {
            if (init[1] == 1)
                return prices.Max();
            if (init[1] == 2)
                return new long[]{prices[0],prices[init[0]-1]}.Min();
            else
                return prices.Min();
        }
    }
}
