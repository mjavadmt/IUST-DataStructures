using System;
using System.Collections.Generic;
using TestCommon;

namespace A9
{
    public class Q1ConvertIntoHeap : Processor
    {
        public Q1ConvertIntoHeap(string testDataName) : base(testDataName)
        { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long[], Tuple<long, long>[]>)Solve);

        public Tuple<long, long>[] Solve(long[] array)
        {
            List<Tuple<long,long>> swaps_list = new List<Tuple<long, long>>();
            long swaps_count = 0;
            for (int i = (int)((array.Length - 1)/2); i >= 0 ; i--)
            {
                swaps_count += SiftDown(i,array,swaps_list);
            }
            return swaps_list.ToArray();
        }
        private long SiftDown(long index, long[] heap_list,List<Tuple<long,long>> swaps)
        {
            long children_1 = 2 * index + 1;
            long children_2 = 2 * index + 2;
            long swaps_count = 0;
            while (children_2 < heap_list.Length && heap_list[index] > Math.Min(heap_list[children_1],heap_list[children_2]))
            {
                if (Math.Min(heap_list[children_1],heap_list[children_2]) == heap_list[children_1])
                {
                    (heap_list[children_1],heap_list[index]) = (heap_list[index],heap_list[children_1]);
                    swaps.Add(Tuple.Create(index, children_1));
                    index = children_1;
                }
                else
                {
                    (heap_list[children_2],heap_list[index]) = (heap_list[index],heap_list[children_2]);
                    swaps.Add(Tuple.Create(index, children_2));
                    index = children_2;
                }
                children_1 = 2 * index + 1;
                children_2 = 2 * index + 2;
                swaps_count ++;
            }
            if (children_1 < heap_list.Length && heap_list[children_1] < heap_list[index])
            {
                (heap_list[children_1],heap_list[index]) = (heap_list[index],heap_list[children_1]);
                swaps.Add(Tuple.Create(index, children_1));
                swaps_count ++ ;
            }
            return swaps_count;
        }
    }
}
