using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace A4
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            // var ret = Q7MaxSubarraySum.Solve(7, new long[]{95, -76 , -72 , 2 , 4 , 23 , 34});
            var a = new long[]{1,2};
            var b = new long[]{0,3};
            // var c = a+b;
            var ans = Q7MaxSubarraySum.Solve(8,new long[]{2 , -3 ,4 , -1 , 2 ,1 , 5 ,-3});
            var ans2 = Q7MaxSubarraySum.Solve(8,new long[]{2 , 2 ,2 , 2 , 2 ,2 , 2 ,2});
            long[] read = readfile();
            var uncorrect = Q7MaxSubarraySum.Solve(read.Length, read);
            var ok = Q7MaxSubarraySum.NewMethod(read.Length,read);
        }
        static long[] readfile()
        {
            string path = @"C:\git\DS99001\A4\A4.Tests\TestData\A4.TD7\In_04.txt";
            List<long> tobereturned = new List<long>();
            foreach(var line in File.ReadAllLines(path).Skip(1))
            {
                tobereturned.Add(long.Parse(line));
            } 
            return tobereturned.ToArray();
        }
    }
}
