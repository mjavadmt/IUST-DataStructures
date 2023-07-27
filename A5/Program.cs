using System;

namespace A5
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            // var ret = Q3ImprovingQuickSort.Solve(5,new long[]{2,3,9,2,2});
            // var bin = Q1BinarySearch.Solve(new long[]{ 1,5,8,12,13}, new long[]{8,1,23,1,11});
            // var major = Q2MajorityElement.Solve(0,new long[]{2,3,2,9});
            // var inv_number= Q4NumberOfInversions.Solve(2,new long[]{5,4,3,2,1});
            var close = Q6ClosestPoints.Solve(10,new long[]{4,-2,-3,-1,2,-4,1,-1,3,-4,-2},new long[]{4,-2,-4,3,3,0,1,-1,-1,2,4});
        }
    }
}
