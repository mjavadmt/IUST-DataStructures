using System;
using System.Collections.Generic;
using System.Linq;
namespace C2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            // Q1PrimeNumbers q1 = new Q1PrimeNumbers("www");
            // string a = Q1PrimeNumbers.Solve("9159942");
            var a = Q2Stones.Solve(70, Convert_to_longarray("18 22 1 1 14 14"));
            // 39
            // 40 6 44 31 41 16 
            System.Console.WriteLine();
        }

        static long[] Convert_to_longarray(string s)
        {
            List<long> longarray = new List<long>();
            foreach (var lnum in s.Split())
            {
                longarray.Add(long.Parse(lnum));
            }
            return longarray.ToArray();
        }
    }
}
