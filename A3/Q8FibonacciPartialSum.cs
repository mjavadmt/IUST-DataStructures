using System;
using TestCommon;

namespace A3
{
    public class Q8FibonacciPartialSum : Processor
    {
        public Q8FibonacciPartialSum(string testDataName) : base(testDataName) { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, long, long>)Solve);

        public long Solve(long a, long b)
        {
            if (a > b)
            {
                (a , b) = (b , a);
            }
            long remainder = 0 ;
            remainder = SumFibn(b) - SumFibn(a -1);
            if (remainder < 0)
                remainder += 10 ;
            return remainder;
        }
        public static long SumFibn(long n)
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
