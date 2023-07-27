using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TestCommon;

namespace A3
{
    public class Q1MergeSort : Processor
    {
        public Q1MergeSort(string testDataName) : base(testDataName) { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, long[], long[]>)Solve);

        public long[] Solve(long n, long[] a)
        {
            if (a.Length == 1)
            {
                return a;
            }
            else
            {
                long[] c = Solve(0 , Q1MergeSort.SubArray(a , 0 , (int)(a.Length/2))) ;
                long[] d = Solve(0 , Q1MergeSort.SubArray(a , (int)(a.Length/2), a.Length - (int)(a.Length/2)));    
                return sort_two(c , d);
            }
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
            for (int i = curr_index_i; i < a.Length; i++)
            {
                int curr_index_copy = curr_index_j;
                for (int j = curr_index_copy; j < b.Length; j++)
                {
                    if (a[i] > b[j])
                    {
                        sorted[initializer] = b[j];
                        // curr_index_j++;
                        curr_index_j = j + 1;
                        initializer ++;
                    }
                    else
                    {
                        sorted[initializer] = a[i];
                        // curr_index_i++; 
                        // does not differ lower from upper
                        curr_index_i = i + 1;
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
            return sorted;
        }
    }
}

