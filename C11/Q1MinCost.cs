using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestCommon;

namespace C11
{
    public class Q1MinCost : Processor
    {
        public Q1MinCost(string testDataName) : base(testDataName) {
        }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, long[][], long, long, long>)Solve);


        public long Solve(long nodeCount, long[][] edges, long startNode, long endNode)
        {
            Graph G = new Graph(nodeCount);
            foreach (var edge in edges)
            {
                G.AddEdge(edge[0]-1, edge[1]-1, edge[2]);
            }
            return G.UCS(startNode-1, endNode-1);
        }
    }
}