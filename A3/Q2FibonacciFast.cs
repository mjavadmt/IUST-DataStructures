using System;
using TestCommon;

namespace A3
{
    public class Q2FibonacciFast : Processor
    {
        public Q2FibonacciFast(string testDataName) : base(testDataName) { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, long>)Solve);

        public long Solve(long n)
        {
            if ( n <= 1)
            {
                return n;
            }
            long previous = 0;
            long current = 1 ;
            for (int i = 0 ; i< n - 1 ; i++)
            {
                (previous , current) = (current , previous + current);  
            }
            return current;
        }
    }
}
