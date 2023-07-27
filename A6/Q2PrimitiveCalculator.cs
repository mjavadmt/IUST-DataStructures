using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestCommon;

namespace A6
{
    public class Q2PrimitiveCalculator : Processor
    {
        public Q2PrimitiveCalculator(string testDataName) : base(testDataName) { }
        
        public override string Process(string inStr) => 
            TestTools.Process(inStr, (Func<long, long[]>) Solve);

        public static long[] Solve(long n)
        {
            List<long> dp =new List<long>(){-1,0};
            List<long> array =new List<long>(){0,1};
            for(var i=2 ; i<n+1;i++)
            {
                var count1=n;
                var count2=n;
                var count3=n;
                if(i%3==0)
                {
                    count3=dp[(int)Math.Floor((decimal)i/3)];
                }
                if(i%2==0)
                {
                    count2=dp[(int)Math.Floor((decimal)i/2)];
                }
                if(i-1>=0)
                {
                    count1=dp[i-1];
                }
                dp.Add(new long[]{count1+1,count2+1,count3+1}.Min());
                if(count3<=Math.Min(count1,count2))
                {
                    array.Add((long)Math.Floor((decimal)i/3));
                }
                else if(count2<=Math.Min(count1,count3))
                {
                    array.Add((long)Math.Floor((decimal)i/2));
                }
                else if(count1<=Math.Min(count2,count3))
                {
                    array.Add(i-1);
                }

            }
            var len=dp[(int)n];
            long[] arr2=new long[len+1];
            arr2[len]=n;
            for(var i=len;i>0;i--)
            {
                arr2[i-1]=array[(int)n];
                n=array[(int)n];
            }
            return arr2;
        }

        private static long[] NewMethod(long n)
        {
            List<List<long>> sequence_n = new List<List<long>>() { new List<long> { 0 }, new List<long> { 1 }, new List<long> { 1, 2 } };
            if (n == 1)
                return new long[] { 1 };
            List<long> fill_count = new List<long>() { 0, 0, 1 };
            for (int i = 3; i < n + 1; i++)
            {
                var rem_three = i % 3;
                var rem_two = i % 2;
                var count_divider_three = fill_count[(int)((i - rem_three) / 3)];
                var count_divider_two = fill_count[(int)((i - rem_two) / 2)];
                if (rem_three + count_divider_three <= rem_two + count_divider_two)
                {
                    fill_count.Add(rem_three + 1 + count_divider_three);
                    if (rem_three == 0)
                        sequence_n.Add(sequence_n[(int)((i - rem_three) / 3)].Concat(new List<long>() { i }).ToList());
                    else if (rem_three == 1)
                        sequence_n.Add(sequence_n[(int)((i - rem_three) / 3)].Concat(new List<long>() { i - rem_three, i + 1 - rem_three }).ToList());
                    else if (rem_three == 2)
                        sequence_n.Add(sequence_n[(int)((i - rem_three) / 3)].Concat(new List<long>() { i - rem_three, i + 1 - rem_three, i + 2 - rem_three }).ToList());
                }
                else
                {
                    fill_count.Add(rem_two + 1 + count_divider_two);
                    if (rem_two == 0)
                        sequence_n.Add(sequence_n[(int)((i - rem_two) / 2)].Concat(new List<long>() { i }).ToList());
                    else
                        sequence_n.Add(sequence_n[(int)((i - rem_two) / 2)].Concat(new List<long>() { i - rem_two, i + 1 - rem_two }).ToList());

                }
            }
            // write your code here
            return sequence_n.Last().ToArray();
        }
    }
}
