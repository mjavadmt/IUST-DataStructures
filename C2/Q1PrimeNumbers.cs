using System;
using System.Collections.Generic;
using System.Text;
using TestCommon;

namespace C2
{
    public class Q1PrimeNumbers : Processor
    {
        public Q1PrimeNumbers(string testDataName) : base(testDataName)
        { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<string, string>)Solve);

        public static string Solve(string a)
        {
            string MakeStr = "";
            int int_a = int.Parse(a);
            if (IsPrime(int_a))
                return $"{a}";
            int i = 2;
            int exponent = 0;
            while (int_a != 1)
            {

                if (int_a % i == 0)
                {
                    int_a /= i;
                    exponent += 1;
                }
                else
                {
                    if (exponent == 1)
                    {
                        MakeStr += $"{i}";
                        MakeStr += '*';

                    }
                    else if (exponent > 1)
                    {
                        MakeStr += $"{i}^{exponent}";
                        MakeStr += '*';
                    }
                    i++;
                    exponent = 0;
                }

            }
            if (exponent == 1)
            {
                MakeStr += $"{i}";
                MakeStr += '*';

            }
            else if (exponent > 1)
            {
                MakeStr += $"{i}^{exponent}";
                MakeStr += '*';
            }
            

            MakeStr = MakeStr.Remove(MakeStr.Length - 1);
            return MakeStr;
        }

        public static bool IsPrime(int n)
        {
            for (int i = 2; i < (int)Math.Sqrt(n) + 1; i++)
            {
                if (n % i == 0)
                {
                    return false;
                }
            }
            return true;
        }

    }
}
