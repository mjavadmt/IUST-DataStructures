using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestCommon;

namespace A2
{
    public class Q1NaiveMaxPairWise : Processor
    {
        public Q1NaiveMaxPairWise(string testDataName) : base(testDataName) { }
        public override string Process(string inStr) => 
            Solve(inStr.Split(new char[] { '\n', '\r', ' ' },
                StringSplitOptions.RemoveEmptyEntries)
                 .Select(s => long.Parse(s))
                 .ToArray()).ToString();

        public static long Solve(long[] numbers)
        {
            long CurrentMost = numbers[0]*numbers[1];
            for (int i = 0 ; i<numbers.Length ; i++)
            {
                for (int j = i+1 ; j<numbers.Length ; j++)
                {
                    if (numbers[i]*numbers[j] > CurrentMost)
                    {
                        CurrentMost = numbers[i]*numbers[j];
                    }
                }
            }
            return CurrentMost;
        }
    }
}

