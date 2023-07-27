using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using TestCommon;

namespace E2
{
    public class Q3HashTableAttack : Processor
    {
        public Q3HashTableAttack (string testDataName) : base(testDataName) 
        {
        }

        public override string Process(string inStr)
        {
            long bucketCount = long.Parse(inStr);
            return string.Join("\n", Solve(bucketCount));
        }

        public static string[] Solve(long bucketCount)
        {
            char[] s = new char[4];
            for (int j = 0 ; j < 3 ; j++)
            {
                s[j] =  Numbers[new Random().Next(1,9)];
            }
            s[3] = LowChars[new Random().Next(1,25)];
            var hash_s = GetBucketNumber(s.ToString(), bucketCount);
            long count = (long)(bucketCount * 0.9);
            string[] equal_bucket = new string[count];
            long initializer = 0;
            int i = 0;
            while(equal_bucket[count - 1] == null)
            {
                string str_making = initializer.ToString();
                if (GetBucketNumber(str_making , bucketCount) == hash_s)
                {
                    equal_bucket[i] = str_making;
                    i ++ ;
                }
                initializer ++ ;
            }
            return equal_bucket;
        }

        #region Chars
        static char[] LowChars = Enumerable
            .Range(0, 26)
            .Select(n => (char)('a' + n))
            .ToArray();

        static char[] CapChars = Enumerable
            .Range(0, 26)
            .Select(n => (char)('A' + n))
            .ToArray();

        static char[] Numbers = Enumerable
            .Range(0, 10)
            .Select(n => (char)('0' + n))
            .ToArray();

        static char[] AllChars = 
            LowChars.Concat(CapChars).Concat(Numbers).ToArray();
        #endregion


        // پیاده‌سازی مورد استفاده دات‌نت برای پیدا کردن شماره باکت
        // https://referencesource.microsoft.com/#mscorlib/system/collections/generic/dictionary.cs,bcd13bb775d408f1
        public static long GetBucketNumber(string str, long bucketCount) =>
            (str.GetHashCode() & 0x7FFFFFFF) % bucketCount;
    }
}
