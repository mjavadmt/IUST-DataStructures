using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TestCommon;

namespace A4
{
    public class Q3MaximizingOnlineAdRevenue : Processor
    {
        public Q3MaximizingOnlineAdRevenue(string testDataName) : base(testDataName)
        {}

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, long[], long[], long>) Solve);


        public virtual long Solve(long slotCount, long[] adRevenue, long[] averageDailyClick)
        {
            long Max_possible = 0;
            Array.Sort(averageDailyClick);
            Array.Sort(adRevenue);
            for (int i=0;i<slotCount;i++)
            {
                Max_possible += adRevenue[i] * averageDailyClick[i];
            }
            return Max_possible;
        }
    }
}
