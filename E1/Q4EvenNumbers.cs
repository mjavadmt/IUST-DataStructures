using System;
using System.Linq;
using System.Threading;
using TestCommon;
using static System.Math;

namespace E1
{
    public class Q4EvenNumbers : Processor
    {
        public Q4EvenNumbers(string testDataName) : base(testDataName)
        {
        }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, long[],long>)Solve);

        public static long Solve(long n, long[] nums)
        {
            //Your code
			return 0;
        }
    }
}
