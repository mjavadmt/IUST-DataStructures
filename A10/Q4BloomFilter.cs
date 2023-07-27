// Bloom filter: https://www.jasondavies.com/bloomfilter/
using System;
using System.Collections;
using System.Linq;
using TestCommon;


namespace A10
{
    public class Q4BloomFilter
    {
        BitArray Filter;
        Func<string, int>[] HashFunctions;
        public const long BigPrimeNumber = 1000000007;
        public const long ChosenX = 263;


        public Q4BloomFilter(int filterSize, int hashFnCount)
        {
            Filter = new BitArray(filterSize);
            HashFunctions = new Func<string, int>[hashFnCount];
            HashFunctions[0] = (s) => (hash_func(s,filterSize));
            HashFunctions[1] = (s) => (CalculateHash_1(s,true,filterSize));
            HashFunctions[2] = (s) => (CalculateHash_2(s,filterSize));
        }
        static int CalculateHash_1(string read, bool lowTolerance , int modulo)
        {
            UInt64 hashedValue = 0;
            int i = 0;
            while (i < read.Length)
            {
                hashedValue += read.ElementAt(i) * (UInt64)Math.Pow(31, i);
                if (lowTolerance) i += 2;
                else i++;
            }
            int to_be_returned = (int)hashedValue % modulo;
            if (to_be_returned < 0)
            {
                to_be_returned += modulo;
            }
            return to_be_returned;
        }
        static int CalculateHash_2(string read, int modulo)
        {
            UInt64 hashedValue = 3074457345618258791ul;
            for (int i = 0; i < read.Length; i++)
            {
                hashedValue += read[i];
                hashedValue *= 3074457345618258799ul;
            }
            int to_be_returned = (int)hashedValue % modulo;
            if (to_be_returned < 0)
            {
                to_be_returned += modulo;
            }
            return to_be_returned;
        }
        private int hash_func(string s, int modulo)
        {

            long hash = 0;
            foreach (var c in s.Reverse())
            {
                hash = (hash * ChosenX + (int)c) % BigPrimeNumber;
            }
            return (int)hash % modulo;
        }
        public void Add(string str)
        {
            for (int i = 0; i < HashFunctions.Length; i++)
            {
                Filter[HashFunctions[i](str)] = true;
            }
        }

        public bool Test(string str)
        {
            for (int i = 0; i < HashFunctions.Length; i++)
            {
                if (Filter[HashFunctions[i](str)] == true)
                {
                    continue;
                }
                return false;
            }
            return true;
        }
    }
}