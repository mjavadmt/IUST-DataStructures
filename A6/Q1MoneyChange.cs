using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestCommon;

namespace A6
{
    public class Q1MoneyChange: Processor
    {
        private static readonly int[] COINS = new int[] {1, 3, 4};

        public Q1MoneyChange(string testDataName) : base(testDataName) { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, long>) Solve);

        public long Solve(long n)
        {
            long[] l_numbers = new long[n+1];
            for (int i = 1 ; i<n+1;i++)
            {
                l_numbers[i] = int.MaxValue;
            }
            var l_coins = new long[]{1,3,4};
            for (int i = 1; i<n+1;i++)
            {
                foreach (var coin in l_coins)
                {
                    if (coin <= i)
                    {
                        if (l_numbers[i - coin] + 1 < l_numbers[i])
                        {
                            l_numbers[i] = l_numbers[i - coin] + 1;
                        }
                    }
                }
            }
            return l_numbers.Last();
        }
    }
}
