using System;
using System.Collections.Generic;
using System.Text;
using TestCommon;

namespace C1
{
    public class Q2BinarySearch : Processor
    {
        public Q2BinarySearch(string testDataName) : base(testDataName)
        {}

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long[], long[], long>) Solve);

        public static long Solve(long[] a, long[] numbers)
        {
            return BinarySearch(a, numbers, 0, (int)a[0]);
        }

        public static long BinarySearch(long[] a, long[] numbers, int left, int right)
        {
            long one_before_current_search = -1 ;
            long Current_Search = (int) ((left + right)/2);
            while (one_before_current_search != Current_Search)
            {
                if (numbers[Current_Search] == a[1])
                {
                    return Current_Search;
                }
                else if (a[1] > numbers[Current_Search])
                {
                    left = (int) ((left + right)/2 ); 
                    one_before_current_search = Current_Search;
                    Current_Search = (int) ((left + right)/2 ); 
                }
                else if (a[1] < numbers[Current_Search])
                {
                    right = (int) ((left + right)/2 );
                    one_before_current_search = Current_Search ;
                    Current_Search = (int) ((left + right)/2 ); 
                }   
            }
            return -1 ;
        }
    }
}
