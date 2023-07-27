using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TestCommon;

namespace A4
{
    public class Q4CollectingSignatures : Processor
    {
        public Q4CollectingSignatures(string testDataName) : base(testDataName)
        {}

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, long[], long[], long>) Solve);

        private static bool HaveSubscribe(List<long> a, List<long> b)
        {
            if ((a[1] < b[0]) || (b[1] < a[0]))
                return false;
            return true;  
        }
        private static List<long> Subscribe(List<long> a, List<long> b)
        {
            return new List<long>{Math.Max(a[0] , b[0]) , Math.Min(a[1],b[1])}; 
        }

        public virtual long Solve(long tenantCount, long[] startTimes, long[] endTimes)
        {
            long counts = 0;
            List<List<long>> StartEnds = new List<List<long>>();
            for (int i = 0 ; i<tenantCount ; i++)
            {
                StartEnds.Add(new List<long>{startTimes[i],endTimes[i]});
            }
            var sorted_start_ends = StartEnds.OrderByDescending(x => x[0]).ToList();
            var subscribe_segment = sorted_start_ends[0];
            for (int i = 0 ; i< tenantCount -1 ; i++)
            {
                if (HaveSubscribe(subscribe_segment , sorted_start_ends[i+1]))
                {
                    subscribe_segment = Subscribe(subscribe_segment,sorted_start_ends[i+1]);
                }
                else
                {
                    counts ++ ;
                    subscribe_segment = sorted_start_ends[i+1];
                }
            }
            counts ++;
            return counts;
        }
    }
}
