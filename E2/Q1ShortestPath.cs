using System;
using System.Collections.Generic;
using System.Text;
using TestCommon;

namespace E2
{
    public class Q1ShortestPath: Processor
    {
        public Q1ShortestPath(string testDataName) : base(testDataName)
        {}

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, long[][], long[]>)Solve);


        public static long[] Solve(long nodeCount, long[][] matrix)
        {
            for (int i = 0 ; i < nodeCount ; i++)
            {
                long[][] new_matrix = new long[nodeCount][];
                for (int k = 0 ; k < nodeCount ; k++)
                {
                    new_matrix[k] = new long[nodeCount];
                }
                for (int m = 0 ; m< nodeCount ; m++)
                {
                    for (int n = 0 ; n< nodeCount ; n++)
                    {
                        if ( m == n)
                        {
                            continue;
                        }
                        if (m == i)
                        {
                            new_matrix[m][n] = matrix[i][n];
                        }
                        else if ( n == i)
                        {
                            new_matrix[m][n] = matrix[m][i];
                        }
                        else
                        {
                            new_matrix[m][n] = Math.Min(matrix[m][n] , matrix[m][i] + matrix[i][n]);
                        }
                    }
                }
                matrix = new_matrix;
                // new_matrix[i] = matrix[i];
                // for (int j = 0 ; j<nodeCount ; j++)
                // {
                //     new_matrix[i][j] = matrix[i][j];
                // }
            }
            long[] make_output = new long[nodeCount * nodeCount - nodeCount];
            long initializer = 0;
            for (int i = 0 ; i< nodeCount ; i++)
            {
                for (int j = 0 ; j < nodeCount ; j++)
                {
                    if (i != j)
                    {
                        make_output[initializer] = matrix[i][j];
                        initializer ++;
                    }
                }
            }
            return make_output;
        }
    }
}
