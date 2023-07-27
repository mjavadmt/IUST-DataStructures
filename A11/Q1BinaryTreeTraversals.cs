using System;
using System.Collections.Generic;
using System.Text;
using TestCommon;
using System.Linq;

namespace A11
{
    public class Q1BinaryTreeTraversals : Processor
    {
        public Q1BinaryTreeTraversals(string testDataName) : base(testDataName) { }
        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long[][], long[][]>)Solve);

        public long[][] Solve(long[][] nodes)
        {
            long[][] ipp = new long[3][];
            ipp[0] = InOrder(nodes , 0).ToArray();
            ipp[1] = PreOrder(nodes , 0).ToArray();
            ipp[2] = PostOrder(nodes , 0).ToArray();
            return ipp;
        }
        public List<long> PreOrder(long[][] nodes , long root)
        {
            if (root == -1)
            {
                return new List<long>();
            }
            List<long> pre_order_tarverese = new List<long>();
            pre_order_tarverese.Add(nodes[root][0]);
            pre_order_tarverese.AddRange(PreOrder(nodes , nodes[root][1]));
            pre_order_tarverese.AddRange(PreOrder(nodes , nodes[root][2]));
            return pre_order_tarverese;
        }
        public List<long> PostOrder(long[][] nodes , long root)
        {
            if (root == -1)
            {
                return new List<long>();
            }
            List<long> post_order_tarverese = new List<long>();
            post_order_tarverese.AddRange(PostOrder(nodes , nodes[root][1]));
            post_order_tarverese.AddRange(PostOrder(nodes , nodes[root][2]));
            post_order_tarverese.Add(nodes[root][0]);
            return post_order_tarverese;
        }
        public List<long> InOrder(long[][] nodes , long root)
        {
            if (root == -1)
            {
                return new List<long>();
            }
            List<long> in_order_tarverese = new List<long>();
            in_order_tarverese.AddRange(InOrder(nodes , nodes[root][1]));
            in_order_tarverese.Add(nodes[root][0]);
            in_order_tarverese.AddRange(InOrder(nodes , nodes[root][2]));
            return in_order_tarverese;
        }
    }
}

