using System;
using TestCommon;

namespace A3
{
    public class Q4GCD : Processor
    {
        public Q4GCD(string testDataName) : base(testDataName) { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, long, long>)Solve);

        public static long Solve(long a, long b)
        {
            // gcd(a,b) = gcd(b , rem(a,b))
            if ( b > a)
            {
                (a , b) = (b , a);
            }
            while ( b != 0)
            {
                (a , b) = (b , a%b) ;
                
            }
            return a;
        }
    }
}
