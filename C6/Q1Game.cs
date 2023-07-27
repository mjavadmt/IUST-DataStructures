using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TestCommon;

namespace C6
{
    public class Q1Game : Processor
    {
        public Q1Game(string testDataName) : base(testDataName)
        {}

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, long, long[][], long>)Solve);


        public static long Solve(long n, long m, long[][] prizes)
        {
            long[][] BestWay = new long[n][];
            for (int j = 0 ; j<n ; j++)
            {
                BestWay[j] = new long[m];
            }
            BestWay[n-1][m-1] = prizes[n-1][m-1];
            for (long i = m - 2; i >= 0 ; i--)
            {
                if (prizes[n-1][i] == 0)
                {
                    continue;
                }
                if (prizes[n-1][i+1] != 0)
                    BestWay[n-1][i] = BestWay[n-1][i+1] + prizes[n-1][i];
                else 
                {
                    BestWay[n-1][i] = prizes[n-1][i];
                }
            }
            long s = 0;
            for (long i = n - 3 ; i>= 0 ; i-=2)
            {
                if (s % 2 == 0)
                {
                    for (long j = m - 2 ; j>=0 ; j--)
                    {  
                        if (prizes[i][j] == 0)
                            continue;
                        if (prizes[i+2][j+1] != 0 && BestWay[i+2][j+1] != 0 && prizes[i][j+1] != 0 && BestWay[i][j+1] != 0)
                        {
                            BestWay[i][j] = Math.Max(prizes[i][j] + BestWay[i][j+1],prizes[i][j] + BestWay[i+2][j+1]);
                        }
                        else if (prizes[i+2][j+1] != 0 && BestWay[i+2][j+1] != 0)
                        {
                            BestWay[i][j] = prizes[i][j] + BestWay[i+2][j+1];
                        }
                        else if (prizes[i][j+1] != 0 && BestWay[i][j+1] != 0)
                        {
                            BestWay[i][j] = BestWay[i][j+1] + prizes[i][j];
                        }
                    }
                }
                else
                {
                    for (long j = m - 1 ; j>= 0 ; j--)
                    {
                        if (prizes[i][j] == 0)
                            continue;
                        if (j == m-1)
                        {
                            if (BestWay[i+2][j-1] != 0)
                            {
                                BestWay[i][j] = BestWay[i+2][j-1] + prizes[i][j];
                                
                            }
                            continue;
                        }
                        if (j == 0)
                        {
                            if (BestWay[i][j+1] != 0)
                            {
                                BestWay[i][j] = prizes[i][j] + BestWay[i][j+1];
                                
                            }
                            continue;
                        }
                        if (prizes[i+2][j-1] != 0 && BestWay[i+2][j-1] != 0 && prizes[i][j+1] != 0 && BestWay[i][j+1] != 0)
                            BestWay[i][j] = Math.Max(prizes[i][j] + BestWay[i][j+1],prizes[i][j] + BestWay[i+2][j-1]);
                        else if (prizes[i+2][j-1] != 0 && BestWay[i+2][j-1] != 0)
                            BestWay[i][j] = prizes[i][j] + BestWay[i+2][j-1];
                        else if (prizes[i][j+1] != 0 && BestWay[i][j+1] != 0)
                            BestWay[i][j] = prizes[i][j] + BestWay[i][j+1];

                    }
                }
                s ++;
            }
            return BestWay.First().Max();
        }
    }
}
