using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TestCommon;

namespace A4
{
    public class Q6MaximizeSalary : Processor
    {
        public Q6MaximizeSalary(string testDataName) : base(testDataName)
        {}

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, long[], string>) Solve);


        public static void MySort(long[] l)
        {
            for (int i = 0 ; i<l.Length ; i++)
            {
                for (int j = i+1 ; j<l.Length ; j++)
                {
                    long a = int.Parse(l[i].ToString() + l[j].ToString());
                    long b = int.Parse(l[j].ToString() + l[i].ToString());
                    if (b>a)
                    {
                        (l[i],l[j]) = (l[j],l[i]);
                    }
                }
            }
        }

        public virtual string Solve(long n, long[] numbers)
        {
            MySort(numbers);
            string make_str = "";
            foreach (var x in numbers)
            {
                make_str += x.ToString();
            }
            return make_str;
        }
    }
}

