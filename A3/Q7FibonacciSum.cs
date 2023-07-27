using System;
using TestCommon;

namespace A3
{
    public class Q7FibonacciSum : Processor
    {
        public Q7FibonacciSum(string testDataName) : base(testDataName) { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, long>)Solve);

        public long Solve(long n)
        {
            long a = 0;
            long b = 1;
            long s = 0;
            for (int i = 0; i < (n % 60); i++)
            {
                s += b;
                s %= 10;
                (a, b) = (b, a + b);
            }
            return s;
        }
    }
}
