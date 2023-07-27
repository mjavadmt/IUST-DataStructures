using System;
using TestCommon;
using System.Linq;

namespace C3
{
    public class Q1MaximumPerimeterTriangle : Processor
    {
        public Q1MaximumPerimeterTriangle(string testDataName) : base(testDataName)
        { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, long[], long[]>)Solve);

        public static long[] Solve(long len,long[] edges)
        {
            Array.Sort(edges);
            for (long i = len-1 ; i>=2 ; i--)
            {
                if (edges[i]<edges[i-1]+edges[i-2])
                {
                    return new long[]{edges[i-2],edges[i-1],edges[i]};
                }
            }
            return new long[]{-1};
        }
    }
}
