using System;
using TestCommon;
using System.Collections.Generic ;

namespace A3
{
    public class Q6FibonacciMod : Processor
    {
        public Q6FibonacciMod(string testDataName) : base(testDataName) { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, long, long>)Solve);

        public static long Solve(long a, long b)
        {
            List<long> LRemFibo = new List<long>(){0 , 1};
            for (int i = 2 ; i< a+1 ; i++)
            {
                long rem = (LRemFibo[i-1] + LRemFibo[i-2]) % b;
                LRemFibo.Add(rem);
                if ($"{LRemFibo[i - 2]}{LRemFibo[i - 1]}{LRemFibo[i]}" == "011" && i>2 )
                {
                    long period = (long) (i - 2) ;
                    long num = a % period ;
                    return LRemFibo[(int)(num)];
                }
            }
            return LRemFibo[LRemFibo.Count - 1];
          }

//         def find_period(s, to_find):
//     start = len(to_find)
//     try:
//         while True:
//             first_cmp = ""
//             second_cmp = ""
//             ind = s.index(to_find, start)
//             for i in range(0, ind):
//                 first_cmp += s[i]
//                 second_cmp += s[i + ind]
//             if first_cmp == second_cmp:
//                 return first_cmp
//             start = ind + 1
//     except:
//         return False


// # print(find_period())


// def find_rem_huge_fib(n, m):
//     whole_str = "0,1,"
//     make_str = ""
//     # make fibonacci
//     l_fibo = [0, 1]
//     LRemFibo = [0, 1]
//     made_period = ""
//     for i in range(2, n + 1):
//         fibo_i = l_fibo[i - 1] + l_fibo[i - 2]
//         l_fibo.append(fibo_i)
//         rem = fibo_i % m
//         LRemFibo.append(rem)
//         whole_str += str(rem)
//         whole_str += ','
//         if str(LRemFibo[i - 2]) + str(LRemFibo[i - 1]) + str(LRemFibo[i]) == '011':
//             period = find_period(whole_str, '0,1,1')
//             if period:
//                 split_with_comma = period.split(',')
//                 return split_with_comma[n % (len(split_with_comma)-1)]
//     return l_fibo[-1] % m
    }
}
