using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TestCommon;

namespace A4
{
    public class Q5MaximizeNumberOfPrizePlaces : Processor
    {
        public Q5MaximizeNumberOfPrizePlaces(string testDataName) : base(testDataName)
        {}

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, long[]>) Solve);


        public virtual long[] Solve(long n)
        {
            List<long> summands = new List<long>();
            int initilaizer = 1;
            long s = 0;
            while (s <= n)
            {
                s += initilaizer;
                summands.Add(initilaizer);
                initilaizer ++ ;
            }
            summands.Remove(summands[summands.Count-1]);
            summands.Remove(summands[summands.Count-1]);
            summands.Add(n - summands.Sum());
            return summands.ToArray();
        }
    }
}

