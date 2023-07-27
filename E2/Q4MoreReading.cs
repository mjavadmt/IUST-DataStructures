using System;
using System.Collections.Generic;
using System.Text;
using TestCommon;

namespace E2
{
    public class Q4MoreReading: Processor
    {
        public Q4MoreReading(string testDataName) : base(testDataName)
        {}

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long,long,long,long, long[][], long>)Solve);


        public static long Solve(long nodeCount,long edgeCount,long libraryPrice, long roadPrice,long[][] edges)
        {
            return 0;
        }
    }
}
