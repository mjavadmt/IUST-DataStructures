using System;

namespace C10
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Q1Huffman q1 = new Q1Huffman("asdasd");
            q1.Solve("ABACA");
        }
    }
}
