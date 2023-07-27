using System;

namespace C8
{
    class Program
    {
        static void Main(string[] args)
        {
            DisjointSets ds = new DisjointSets(4);
            ds.union(0, 1);
            ds.union(1, 3);

            for (int i = 0; i < 4; i++)
                Console.WriteLine(ds.find(i));
        }
    }
}
