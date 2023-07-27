using System;
using System.Collections.Generic;
using System.Text;
using TestCommon;
using System.Linq;

namespace A7
{
    public class Q3MaximizingArithmeticExpression : Processor
    {
        public Q3MaximizingArithmeticExpression(string testDataName) : base(testDataName) { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<string, long>)Solve);

        public long Solve(string expression)
        {
            List<long> list_numbers = expression.Split(new char[] { '+', '-', '*' }).Select(x => long.Parse(x)).ToList();
            List<char> list_operations = new List<char>();
            foreach (var i in expression)
            {
                if (i == '+' || i == '-' || i == '*')
                {
                    list_operations.Add(i);
                }
            }
            long count_numbers = list_numbers.Count;
            long[,] two_dimensional_maximum = new long[count_numbers,count_numbers];
            long[,] two_dimensional_minimum = new long[count_numbers,count_numbers];
            for (long i = 0 ; i < count_numbers ; i++)
            {
                two_dimensional_maximum[i,i] = list_numbers[(int)i];
                two_dimensional_minimum[i,i] = list_numbers[(int)i];
            }
            for (long s = 1 ; s<count_numbers ; s++)
            {
                for ( long i = 0 ; i<count_numbers - s ; i++)
                {
                    var j = i + s;
                    (two_dimensional_minimum[i,j],two_dimensional_maximum[i,j]) = MinMax(i , j , two_dimensional_maximum , two_dimensional_minimum , list_operations);
                }
            }

            return two_dimensional_maximum[0,count_numbers - 1];
        }
        private static (long , long) MinMax(long i , long j , long[,] max_l , long[,] min_l , List<char> operations)
        {
            long min_so_far = int.MaxValue;
            long max_so_far = int.MinValue;
            for (long k = i ; k < j ; k++)
            {
                long m1 = evalt(max_l[i,k],max_l[k+1,j],operations[(int)k]);
                long m2 = evalt(max_l[i,k],min_l[k+1,j],operations[(int)k]);
                long m3 = evalt(min_l[i,k],max_l[k+1,j],operations[(int)k]);
                long m4 = evalt(min_l[i,k],min_l[k+1,j],operations[(int)k]);
                min_so_far = new long[]{min_so_far, m1, m2, m3, m4}.Min();
                max_so_far = new long[]{max_so_far, m1, m2, m3, m4}.Max();
            }
            return (min_so_far , max_so_far);
        }
        private static long evalt(long a , long b , char op)
        {
            if (op == '+')
                return a + b;
            if ( op == '-')
                return a - b;
            if ( op == '*')
                return a * b;
            return 0;
        }
    }
}
