using System;
using System.Diagnostics;

namespace A6
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Stopwatch s1 = new Stopwatch();
            s1.Start();
            // var ret = Q2PrimitiveCalculator.Solve(21);
            var a = s1.ElapsedMilliseconds;
            var ret3 = Q4LCSOfTwo.Solve(new long[]{19,0,17,13,6}, new long[]{16,19,0,13,10,18,1,3});
            
        }
    }
}
