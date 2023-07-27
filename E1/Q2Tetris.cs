using System;
using System.Linq;
using System.Threading;
using TestCommon;
using System.Collections.Generic;
using System.Diagnostics;

namespace E1
{
    public class Q2Tetris : Processor
    {
        public Q2Tetris(string testDataName) : base(testDataName)
        {
        }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, long[], long>)Solve);

        public static long Solve(long n, long[] arr)
        {
            long max = arr.Max();
            long result = 0;
            long count = n;
            while ((count > 0) && (arr.Min() != max))
            {
                List<long> lst = new List<long>();
                int idx = Array.FindIndex(arr, 0 , (int)count, x => x != max);
                if (idx == -1) break;
                while (idx < count && arr[idx] != max) lst.Add(arr[idx++]);
                long sec_max= lst.Max();
                long delta = max - sec_max;
                result += delta;
                for (int j = 0 ; j<lst.Count ; j++)
                {
                    arr[idx - 1] += delta;
                    idx -- ;
                }
                idx = Array.FindIndex(arr , 0 , (int)count , x => x!= max);
                arr = arr.Skip(idx).ToArray();
                count -= idx;
            }
            return result;
        }

        // private static long NewMethod(long[] arr)
        // {
        //     Stopwatch s1 = new Stopwatch();
        //     s1.Start();
        //     long max_element = arr.Max();
        //     long count = 0;
        //     long processed = 0;
        //     while (arr.Min() != max_element)
        //     {
        //         // var walks = HowFarCanWeGo(arr,max_element,processed);
        //         (long, long) walks = (-1, -1);
        //         long start = -1;
        //         for (long i = processed; i < arr.Length; i++)
        //         {
        //             if (arr[i] != max_element)
        //             {
        //                 start = i;
        //                 break;
        //             }
        //         }
        //         long end = start + 1;
        //         for (long i = start + 1; i < arr.Length; i++)
        //         {
        //             if (arr[i] == max_element)
        //             {
        //                 break;
        //             }
        //             end += 1;
        //         }
        //         walks.Item1 = start;
        //         walks.Item2 = end;
        //         // var maximum = FindMax(walks.Item1, walks.Item2, arr);
        //         long maximum = int.MinValue;
        //         for (long i = start; i < end; i++)
        //         {
        //             if (arr[i] > maximum)
        //             {
        //                 maximum = arr[(int)i];
        //             }
        //         }
        //         var addition = max_element - maximum;
        //         for (long i = walks.Item1; i < walks.Item2; i++)
        //         {
        //             arr[i] += addition;
        //         }
        //         count += addition;
        //         processed = walks.Item1;
        //     }
        //     return count;
        // }

        // public static (long, long) HowFarCanWeGo(long[] arr, long max_element, long processed)
        // {
        //     long start = -1;

        //     for (long i = processed; i < arr.Length; i++)
        //     {
        //         if (arr[i] != max_element)
        //         {
        //             start = i;
        //             break;
        //         }
        //     }
        //     long end = start + 1;
        //     for (long i = start + 1; i < arr.Length; i++)
        //     {
        //         if (arr[i] == max_element)
        //         {
        //             break;
        //         }
        //         end += 1;
        //     }
        //     return (start, end);
        // }
        // public static long FindMax(long start, long end, long[] distance_to_max)
        // {
        //     long maximum = int.MinValue;
        //     for (long i = start; i < end; i++)
        //     {
        //         if (distance_to_max[i] > maximum)
        //         {
        //             maximum = distance_to_max[(int)i];
        //         }
        //     }
        //     return maximum;
        // }
        // public static Type_[] SubArray<Type_>(Type_[] data, int index, int length)
        // {
        //     Type_[] result = new Type_[length];
        //     Array.Copy(data, index, result, 0, length);
        //     return result;
        // }

        // public static long FindCount(List<long> subarray, long maximum)
        // {
        //     long count_inside = 0;
        //     subarray.Add(maximum);
        //     var sorted = subarray.Distinct().OrderBy(x => x).ToList();
        //     for (int i = 0; i < sorted.Count - 1; i++)
        //     {
        //         count_inside += sorted[i + 1] - sorted[i];
        //     }
        //     return count_inside;
        // }

        // public static long MinMoves(long[] arr)
        // {
        //     var list_array = arr.ToList();
        //     var maximum = arr.Max();
        //     var maxindexes = MaxIndexes(maximum, arr);
        //     long count = 0;
        //     var first_sub = SubArray(arr, 0, maxindexes[0]);
        //     count += FindCount(first_sub.ToList(), maximum);
        //     for (int i = 0; i < maxindexes.Length - 1; i++)
        //     {
        //         count += FindCount(SubArray(arr, maxindexes[i] + 1, maxindexes[i + 1] - (maxindexes[i] + 1)).ToList(), maximum);
        //     }
        //     var second_sub = SubArray(arr, maxindexes[maxindexes.Length - 1] + 1, arr.Length - (maxindexes[maxindexes.Length - 1] + 1));
        //     count += FindCount(second_sub.ToList(), maximum);
        //     return count;

        // }
        // public static int[] MaxIndexes(long maximum, long[] arr)
        // {
        //     List<int> Indexes = new List<int>();
        //     for (int i = 0; i < arr.Length; i++)
        //     {
        //         if (arr[i] == maximum)
        //             Indexes.Add(i);
        //     }
        //     return Indexes.ToArray();
        // }
    }
}
