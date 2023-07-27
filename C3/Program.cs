using System;

namespace C3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            var ret = Q1MaximumPerimeterTriangle.Solve(6, new long[]{1,1,1,5,3, 2});
            System.Console.WriteLine();
        }
    }
}
