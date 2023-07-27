using System;
using System.Collections.Generic;
using System.Text;
using TestCommon;
using System.Linq;

namespace A5
{
    public class Q3ImprovingQuickSort:Processor
    {
        public Q3ImprovingQuickSort(string testDataName) : base(testDataName)
        { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, long[], long[]>)Solve);

        public static long[] Solve(long n, long[] a)
        {
            var sth= RandomizedSort(a.ToList()).ToArray();
            return sth;
        }
        private static List<long> RandomizedSort(List<long> a)
        {
            if (a.Count == 1 || a.Count == 0)
            {
                return a;
            }
            var rand = new Random().Next(a.Count - 1);
            (a[0] , a[rand]) = (a[rand] , a[0]);
            List<long> middle = new List<long>{a[0]};
            List<long> left = new List<long>();
            List<long> right = new List<long>();
            for (int i = 1 ; i<a.Count ; i++)
            {
                if (a[0] < a[i])
                {
                    right.Add(a[i]);
                }
                else if (a[i] < a[0] )
                {
                    left.Add(a[i]);
                }
                else
                {
                    middle.Add(a[i]);
                }
            }
            List<long> SortedLeft = RandomizedSort(left);
            List<long> SortedRight = RandomizedSort(right);
            return SortedLeft.Concat(middle).Concat(SortedRight).ToList();
        }
    }
}
