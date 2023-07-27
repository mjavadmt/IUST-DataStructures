using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TestCommon;

namespace A6
{
    public class Q5LCSOfThree: Processor
    {
        public Q5LCSOfThree(string testDataName) : base(testDataName) { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long[], long[], long[], long>)Solve);

        public long Solve(long[] seq1, long[] seq2, long[] seq3)
        {
            // write your code here
            long[,,] D3=new long[seq1.Length+1,seq2.Length+1,seq3.Length+1];
            for(var x=1;x<seq1.Length+1;x++)
            {
                for(var y=1;y<seq2.Length+1;y++)
                {
                    for(var z=1;z<seq3.Length+1;z++)
                    {
                        var node_match = D3[x - 1,y - 1,z - 1] + 1;
                        var node_dismatch = D3[x - 1,y - 1,z - 1];
                        var node1 = D3[x - 1,y - 1,z];
                        var node2 = D3[x - 1,y,z - 1];
                        var node3 = D3[x - 1,y,z];
                        var node4 = D3[x,y - 1,z - 1];
                        var node5 = D3[x,y - 1,z];
                        var node6 = D3[x,y,z - 1];
                    if ( seq1[x - 1] == seq2[y - 1] && seq2[y-1] == seq3[z - 1]&& seq1[x-1]==seq3[z-1])
                    D3[x,y,z] = new long[]{node1, node2, node3, node4, node5, node6, node_match}.Max();
                    else
                        D3[x,y,z] = new long[]{node1, node2, node3, node4, node5, node6, node_dismatch}.Max();
                    }
                }
            }
            return D3[seq1.Length,seq2.Length,seq3.Length];
        }
    }
}
