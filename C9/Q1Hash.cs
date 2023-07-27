using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestCommon;

namespace C9
{
    public class Q1Hash : Processor
    {
        public Q1Hash(string testDataName) : base(testDataName) { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<string, string, long>)Solve);

        public long Solve(string s1, string s2)
        {
            if (s1.Length > s2.Length) 
                (s1, s2) = (s2, s1);

            int s1_len = s1.Length, s2_len = s2.Length;
            int counter = 0;
            for (int i = 1; i <= s1_len; i++)
            {
                if ((s2_len % i == 0) && (s1_len % i == 0))
                {
                    string d = s1.Substring(0, i);
                    bool CheckAllSub = true;
                    for (int j = i; j < s1.Length; j += i)
                    {
                        string sub1 = s1.Substring(j, i);
                        if (d != sub1)
                        {
                            CheckAllSub = false;
                            break;
                        }
                    }
                    if (CheckAllSub)
                    {
                        for (int j = 0; j < s2.Length; j += i)
                        {
                            string sub2 = s2.Substring(j, i);
                            if (d != sub2)
                            {
                                CheckAllSub = false;
                                break;
                            }
                        }
                    }
                    if (CheckAllSub)
                    {
                        counter++;
                    }
                }
            }
            return counter;
        }
        
    }
}