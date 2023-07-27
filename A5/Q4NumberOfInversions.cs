using System;
using System.Collections.Generic;
using System.Text;
using TestCommon;


namespace A5
{
    public class Q4NumberOfInversions:Processor
    {

        public Q4NumberOfInversions(string testDataName) : base(testDataName)
        { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, long[], long>)Solve);

        public static long Solve(long n, long[] a)
        {
            return MergeSort(n,a).Item2;
        }
        public static Tuple<long[],long> MergeSort(long n, long[] a)
        {
            if (a.Length == 1)
            {
                return Tuple.Create(a,(long)0);
            }
            else
            {
                var (c, inv1) = MergeSort(0 , SubArray(a , 0 , (int)(a.Length/2))) ;
                var (d, inv2) = MergeSort(0 , SubArray(a , (int)(a.Length/2), a.Length - (int)(a.Length/2))); 
                var (sorted_list , inversin_number) = sort_two(c,d);
                return Tuple.Create(sorted_list, inv1 + inv2 + inversin_number);    
            }
        }
        public static Type_[] SubArray<Type_>(Type_[] data, int index, int length)
        {
            Type_[] result = new Type_[length];
            Array.Copy(data, index, result, 0, length);
            return result;
        }
        static Tuple<long[],long> sort_two(long[] a, long[] b)
        {
            long[] sorted = new long[a.Length + b.Length];
            int curr_index_j = 0;
            int curr_index_i = 0;
            int initializer = 0;
            long inversin_number = 0;
            long s = 0;
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
                        s += 1;
                    }
                    else
                    {
                        sorted[initializer] = a[i];
                        inversin_number += s;
                        // curr_index_i++; 
                        // does not differ below from beyond
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
                inversin_number += s;
            }
            return Tuple.Create(sorted,inversin_number);
        }
    }
}
