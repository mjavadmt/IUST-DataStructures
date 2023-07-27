using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestCommon;

namespace C8
{
    public class Q1Number : Processor
    {
        public Q1Number(string testDataName) : base(testDataName) {
        }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, long[][], long>)Solve);

        public long Solve(long nodeCount, long[][] edges)
        {
            DisjointSets disjoint = new DisjointSets((int)nodeCount + 1);
            foreach ( var edge in edges)
            {
                disjoint.union((int)edge[0], (int)edge[1]);
            }
            HashSet<long> unique = new HashSet<long>();
            foreach ( var p in disjoint.parent)
            {
                unique.Add(disjoint.find(p));
            }
            return unique.Count - 1;
        }
    }
}
