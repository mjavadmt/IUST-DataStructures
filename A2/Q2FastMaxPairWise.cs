using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestCommon;

namespace A2
{
    public class Q2FastMaxPairWise : Processor
    {
        public Q2FastMaxPairWise(string testDataName) : base(testDataName) { }
        public override string Process(string inStr) => 
            Solve(inStr.Split(new char[] { '\n', '\r', ' ' },
                StringSplitOptions.RemoveEmptyEntries)
                 .Select(s => long.Parse(s))
                 .ToArray()).ToString();

        public static long Solve(long[] numbers)
        {
            int FirstIndex = 0 ;
            int SecondIndex = 0 ;
            for (int i = 1 ; i<numbers.Length ; i++)
            {
                if (numbers[FirstIndex] < numbers[i])
                {
                    FirstIndex = i;
                }
            }
            if (FirstIndex == 0)
            {
                SecondIndex = 1;
            }
            for (int i = 1 ; i<numbers.Length ; i++)
            {
                if (i != FirstIndex && numbers[SecondIndex] < numbers[i])
                {
                    SecondIndex = i ;
                }
            }
            return numbers[SecondIndex] * numbers[FirstIndex] ;
        }
    }
}
