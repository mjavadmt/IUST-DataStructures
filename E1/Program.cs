using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace E1
{
    class Program
    {
        static void Main(string[] args)
        {
            // Q2Tetris.Solve()
            long[] input = inp(File.ReadAllText(@"C:\git\DS99001\E1\E1.Tests\TestData\E1.TD2\In_10.txt")) ;
            Q2Tetris.Solve(input.Length , input);
            Console.WriteLine("Hello World!");
            var subbed = SubArray(new long[]{4,3,1,3,7,2,1,7,7},9 , 0);
            // var newone = Q2Tetris.MinMoves(new long[]{5,4,3,5,5,6,3});
            // var res = Q1Matrix.Solve(4 , new long[]{1,2,3,4},new long[]{4,2,3,1});
            // var ret = Q2Tetris.Solve(9,new long[]{5, 5, 5, 4, 7, 7, 6, 6, 8});
            // var ret2 = Q2Tetris.Solve(5,new long[]{5,6,5,6,3,5,5});
            // var ret3 = Q2Tetris.Solve(27, inp("15 23 19 19 17 21 24 22 18 18 24 23 13 18 25 14 21 23 26 13 22 14 25 25 14 19 23"));
        }
        static long[] inp(string s)
        {
            var splitted = s.Split( new char[]{' ','\n', '\r'},StringSplitOptions.RemoveEmptyEntries);
            List<long> longedd = new List<long>();
            splitted = splitted.Skip(1).ToArray();
            foreach(var i in splitted)
                longedd.Add(long.Parse(i));
            return longedd.ToArray();
        }
        public static Type_[] SubArray<Type_>(Type_[] data, int index, int length)
        {
            Type_[] result = new Type_[length];
            Array.Copy(data, index, result, 0, length);
            return result;
        }
    }
}
