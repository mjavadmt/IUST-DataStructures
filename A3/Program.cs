using System;
using System.Collections.Generic;
using System.Linq;

namespace A3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            string[] c = { "one", "two", "three", "four", "five" };
            var q6 = Q6FibonacciMod.Solve(239 , 1000);
            long[] me = new long[]{3};
            long[] c1 =SubArray(me , 0 , (int)(me.Length/2)) ;
            long[] d2 = SubArray(me , (int)(me.Length/2) , me.Length - (int)(me.Length/2));
            // var segment = new ArraySegment<string>(c, 1, 2);
            // SubArray()
            long[] a = new long[] { 0 , 1 , 2 ,3 };
            long[] b = new long[] { 5 , 6 ,7, 8 };
            Q1MergeSort q1 = new Q1MergeSort("q1");
            var mysol = q1.Solve(0 , new long[] { 42, 35, 47, 11 , 27});
            sort_two(a, b);
        }
        public static long[] SubArray(long[] data, int index, int length)
        {
            long[] result = new long[length];
            Array.Copy(data, index, result, 0, length);
            return result;
        }
        static long[] sort_two(long[] a, long[] b)
        {
            long[] sorted = new long[a.Length + b.Length];
            int curr_index_j = 0;
            int curr_index_i = 0;
            int initializer = 0;
            for (int i = 0; i < a.Length; i++)
            {
                int curr_index_copy = curr_index_j;
                for (int j = curr_index_copy; j < b.Length; j++)
                {
                    if (a[i] > b[j])
                    {
                        sorted[initializer] = b[j];
                        curr_index_j++;
                        initializer ++;
                    }
                    else
                    {
                        sorted[initializer] = a[i];
                        curr_index_i++;
                        initializer ++;
                        break;
                    }
                }
            }
            for (int i = curr_index_j; i < b.Length; i++)
            {
                sorted[initializer] = b[i];
                initializer ++ ;
            }
            for (int i = curr_index_i; i < a.Length; i++)
            {
                sorted[initializer] = a[i];
                initializer ++ ;
            }
            return sorted.ToArray();
        }
    }

}
