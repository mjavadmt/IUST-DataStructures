using System;
using System.Collections.Generic;
using System.Text;
using TestCommon;

namespace A5
{
    public class Q5OrganizingLottery:Processor
    {
        public Q5OrganizingLottery(string testDataName) : base(testDataName)
        {}
        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long[], long[], long[], long[]>)Solve);

        public virtual long[] Solve(long[] points, long[] startSegments, long[] endSegment)
        {
            long length = startSegments.Length;
            long[] cnt = new long[points.Length];
            Array.Sort(startSegments);
            Array.Sort(endSegment);
            for (long i = 0 ; i<points.Length; i++)
            {
                long left = MyBinarySearchLeft(startSegments,points[i],0,length-1);
                long right = MyBinarySearchRight(endSegment,points[i],0,length-1);
                cnt[i] = left + 1 - right ;
            }
            //write your code here
            return cnt;
        }
        private static long MyBinarySearchLeft(long[] a,long number,long left,long right)
        {
            if (left > right)
                return right;
            long mid = (left+right)/2;
            if (a[mid] > number)
                return MyBinarySearchLeft(a, number, left, mid - 1);
            if (a[mid] < number)
                return MyBinarySearchLeft(a, number, mid+1 , right);
            if (a[mid] == number)
            {
                long ind = mid;
                for (long i= mid+1;i<a.Length;i++)
                {
                    if (a[i] != a[mid])
                    {
                        break;
                    }
                    ind += 1;
                }
                return ind;
            }
            return 0;
        }
        private static long MyBinarySearchRight(long[] a,long number,long left,long right)
        {
            if (left > right)
                return left;
            long mid = (left+right)/2;
            if (a[mid] > number)
                return MyBinarySearchRight(a, number, left, mid - 1);
            if (a[mid] < number)
                return MyBinarySearchRight(a, number, mid+1 , right);
            if (a[mid] == number)
            {
                long ind = mid;
                for (long i= mid-1;i>-1;i--)
                {
                    if (a[i] != a[mid])
                    {
                        break;
                    }
                    ind -= 1;
                }
                return ind;
            }
            return 0;
        }
    }
}
