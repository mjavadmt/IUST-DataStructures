using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TestCommon;

namespace A8
{
    public class Q2TreeHeight : Processor
    {
        public Q2TreeHeight(string testDataName) : base(testDataName)
        { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, long[], long>)Solve);

        public long Solve(long nodeCount, long[] tree)
        {
            long[] heights = new long[nodeCount];
            var root = tree.ToList().IndexOf(-1);
            heights[root] = 1;
            for (int vertex = 0; vertex < nodeCount; vertex++)
            {
                var height = 0;
                long current = vertex;
                while (current != -1)
                {
                    height += 1;
                    current = tree[current];
                    if (current < 0)
                    {
                        continue;
                    }
                    if (heights[current] != 0)
                    {
                        heights[vertex] = heights[current] + height;
                        break;
                    }
                }
            }
            return heights.Max();
        }
    }
}
