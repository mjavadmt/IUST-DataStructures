using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using TestCommon;

namespace E1
{
    public class Q3Competition : Processor
    {
        public Q3Competition(string testDataName) : base(testDataName)
        {
        }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, long[],long>)Solve);

        public static long Solve(long n, long[] powers)
        {
            if (powers.Length == 2)
            {
                return powers[0] + powers[1];
            }
            var first_half = SubArray(powers,0,(int)(powers.Length/2));
            var second_half = SubArray(powers,(int)(powers.Length/2), powers.Length - (int)(powers.Length/2));
            long best_first_part = Solve(0,first_half);
            long best_second_part = Solve(0,second_half);
            return Math.Max(best_first_part + second_half.Max() , best_second_part + first_half.Max());
        }
        
        public static Type_[] SubArray<Type_>(Type_[] data, int index, int length)
        {
            Type_[] result = new Type_[length];
            Array.Copy(data, index, result, 0, length);
            return result;
        }
    }
}
