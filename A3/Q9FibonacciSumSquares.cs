using System;
using TestCommon;

namespace A3
{
    public class Q9FibonacciSumSquares : Processor
    {
        public Q9FibonacciSumSquares(string testDataName) : base(testDataName) { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, long>)Solve);

        public long Solve(long n)
        {
            if (n <=1)
            {
                return n; 
            }
            return (EachFib(n) * EachFib(n+1)) % 10;

        }

        private static long EachFib(long n)
        {
            long a = 0;
            long b = 1;
            for (int i = 0; i < (n) % 60; i++)
            {
                (a, b) = (b, (a + b) % 10);
            }
            return a;
        }
    }
}
