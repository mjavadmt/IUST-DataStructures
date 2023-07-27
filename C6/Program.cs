using System;
using System.IO;
using System.Linq;

namespace C6
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            long[][] prizes = new long[5][];
            // prizes[0] = new long[]{0,15};
            // prizes[1] = new long[]{16,10};
            // prizes[2] = new long[]{10,9};
            // prizes[3] = new long[]{13,0};
            // prizes[4] = new long[]{15,10};
            // prizes[5] = new long[]{13,9};
            // prizes[6] = new long[]{11,11};
            // prizes[7] = new long[]{18,15};
            // prizes[8] = new long[]{0,9};
            prizes[0] = new long[]{8,0,10};
            prizes[1] = new long[]{10,8,10};
            prizes[2] = new long[]{5,5,10};
            prizes[3] = new long[]{0,9,9};
            prizes[4] = new long[]{5,8,10};
            // System.Console.WriteLine(prizes[0][2]);
            Q1Game.Solve(7,5,prizes:readinp());
        }
        static long[][] readinp()
        {
            string path = @"C:\git\DS99001\Class\C6\C6.Tests\TestData\C6.TD1\In_18.txt";
            var listed = File.ReadAllLines(path).Skip(1).ToList();
            long[][] made = new long[listed.Count][];
            int s = 0;
            foreach (var l in listed)
            {
                made[s] =  make_longarray(l);
                s++;
            }
            return made;
        }
        static long[] make_longarray(string inp)
        {
            var splited = inp.Split(new char[]{' '},StringSplitOptions.RemoveEmptyEntries);
            long[] made = new long[splited.Length];
            for (int i = 0 ; i < splited.Length ; i++)
            {
                made[i] = long.Parse(splited[i]);
            }
            return made;
        }
    }
}
