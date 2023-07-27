using System;

namespace C1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");  
            Q2BinarySearch q2 = new Q2BinarySearch("ow");
            long c = Q2BinarySearch.BinarySearch(new long[]{5 ,8} ,new long[] {1,2,7,8,9} , 0 , 4 );
            System.Console.WriteLine(c);
        }
    }
}
