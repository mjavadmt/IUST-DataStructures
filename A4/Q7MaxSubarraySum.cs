using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TestCommon;

namespace A4
{
    public class Q7MaxSubarraySum : Processor
    {
        public Q7MaxSubarraySum(string testDataName) : base(testDataName)
        { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, long[], long>)Solve);


        public static long Solve(long n, long[] numbers)
        {
            long MaxSoFar = int.MinValue;
            long MaxFinished = 0;
            for (int i = 0 ; i<n ;i++)
            {
                MaxFinished += numbers[i];
                if (MaxSoFar < MaxFinished)
                {
                    MaxSoFar = MaxFinished;
                }
                if (MaxFinished < 0)
                {
                    MaxFinished = 0;
                }
            }
            return MaxSoFar;
        }

        private static long NewMethod1(long n, long[] numbers)
        {
            var numbers_copy = new long[n];
            Array.Copy(numbers, numbers_copy, n);
            long FirstMaxIndex = MaxIndex(numbers);
            long[] SubSoFar = new long[] { FirstMaxIndex, FirstMaxIndex };
            numbers_copy[FirstMaxIndex] = int.MinValue;
            long SecondMax = MaxIndex(numbers_copy);
            numbers_copy[SecondMax] = int.MinValue;
            long IndexFrom;
            long IndexTo;
            if (SecondMax < FirstMaxIndex)
            {
                IndexFrom = SecondMax;
                IndexTo = FirstMaxIndex - 1;
            }

            else
            {
                IndexFrom = FirstMaxIndex + 1;
                IndexTo = SecondMax;
            }
            long CheckSum = MySum(numbers, IndexFrom, IndexTo);
            while (CheckSum >= 0)
            {

                if (IndexFrom < SubSoFar[0])
                {
                    SubSoFar[0] = IndexFrom;
                }
                else if (IndexTo > SubSoFar[1])
                {
                    SubSoFar[1] = IndexTo;
                }
                if (SubSoFar[0] == 0 && SubSoFar[1] == n - 1)
                {
                    break;
                }
                long[] FirstSub = SubArray(numbers, 0, SubSoFar[0]);
                long[] SecondSub = SubArray(numbers, SubSoFar[1] + 1, n - (SubSoFar[1] + 1));
                var Merged = new long[FirstSub.Length + SecondSub.Length];
                FirstSub.CopyTo(Merged, 0);
                SecondSub.CopyTo(Merged, FirstSub.Length);
                long MaxMerged = Merged.Max();
                long ind = Array.FindIndex(numbers_copy, i => i == MaxMerged);
                numbers_copy[ind] = int.MinValue;
                if (ind < SubSoFar[0])
                {
                    IndexFrom = ind;
                    IndexTo = SubSoFar[0] - 1;
                }
                else
                {
                    IndexFrom = SubSoFar[1] + 1;
                    IndexTo = ind;
                }
                CheckSum = MySum(numbers, IndexFrom, IndexTo);
            }

            return MySum(numbers, SubSoFar[0], SubSoFar[1]);
        }

        public static T[] SubArray<T>(T[] array, long offset, long length)
        {
            T[] result = new T[length];
            Array.Copy(array, offset, result, 0, length);
            return result;
        }

        public static long MySum(long[] numbers, long IndexFrom, long IndexTo)
        {
            long S = 0;
            for (long i = IndexFrom; i < IndexTo + 1; i++)
            {
                S += numbers[i];
            }
            return S;
        }

        public static long MaxIndex(long[] numbers)
        {
            long Ind = 0;
            for (int i = 1; i < numbers.Length; i++)
            {
                if (numbers[i] > numbers[Ind])
                {
                    Ind = i;
                }
            }
            return Ind;
        }

        public static long NewMethod(long n, long[] numbers)
        {
            if (n == 9)
            {
                System.Console.WriteLine();
            }
            long MaxSoFar = numbers[0];
            for (int i = 0; i < n; i++)
            {
                long s = numbers[i];
                if (s > MaxSoFar)
                {
                    MaxSoFar = s;
                }
                for (int j = i + 1; j < n; j++)
                {
                    s += numbers[j];
                    if (s > MaxSoFar)
                    {
                        MaxSoFar = s;
                    }
                }
            }
            return MaxSoFar;
        }
    }
}
