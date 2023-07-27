using System;
using System.Collections.Generic;
using System.Text;
using TestCommon;

namespace A5
{
    public class Q1BinarySearch : Processor
    {
        public Q1BinarySearch(string testDataName) : base(testDataName)
        { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long[], long [], long[]>)Solve);


        public static long[] Solve(long[] a, long[] b) 
        {
            long lentgh_a = a.Length;
            long[] Indexes = new long[b.Length];
            for (long i = 0 ; i<b.Length ; i++)
            {
                Indexes[i] = MyBinarySearch(a,b[i],0,lentgh_a-1);
            }
            return Indexes;
        }
        private static long MyBinarySearch(long[] a,long number,long left,long right)
        {
            if (left > right)
                return -1;
            long mid = (left+right)/2;
            if (a[mid] > number)
                return MyBinarySearch(a, number, left, mid - 1);
            if (a[mid] < number)
                return MyBinarySearch(a, number, mid+1 , right);
            if (a[mid] == number)
                return mid;
            return 0;
        }
    }
}
