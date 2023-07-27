using System;
using System.Collections.Generic;
using System.Text;
using TestCommon;

namespace A4
{
    public class Q1ChangingMoney : Processor
    {
        public Q1ChangingMoney(string testDataName) : base(testDataName)
        {}

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, long>) Solve);


        public virtual long Solve(long money)
        {
            if (money == 28)
            {
                System.Console.WriteLine();
            }
            List<long> coins = new List<long>{10,5,1};
            long count = 0; 
            int initializer = 0;
            while (money != 0)
            {
                long each = (money / coins[initializer]);
                count += each;
                money -=  each*coins[initializer];
                initializer ++ ;
                
            }
            return count;
        }
    }
}
