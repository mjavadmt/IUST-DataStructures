using System;
using System.Collections.Generic;
using System.Linq;
using TestCommon;

namespace A10
{
    public class Q2HashingWithChain : Processor
    {
        public Q2HashingWithChain(string testDataName) : base(testDataName) { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, string[], string[]>)Solve);


        public string[] Solve(long bucketCount, string[] commands)
        {
            List<string> result = new List<string>();
            word_dict = new Dictionary<long, List<string>>();
            bucketcount = bucketCount;
            foreach (var cmd in commands)
            {
                var toks = cmd.Split();
                var cmdType = toks[0];
                var arg = toks[1];
                long compute_hash = 0;
                if (cmdType != "check")
                {
                    compute_hash = hash_func(arg);
                }

                switch (cmdType)
                {
                    case "add":
                        Add(arg, compute_hash);
                        break;
                    case "del":
                        Delete(arg, compute_hash);
                        break;
                    case "find":
                        result.Add(Find(arg, compute_hash));
                        break;
                    case "check":
                        result.Add(Check(int.Parse(arg)));
                        break;
                }
            }
            return result.ToArray();
        }
        private long hash_func(string s)
        {
            long hash = 0;
            foreach (var c in s.Reverse())
            {
                hash = (hash * ChosenX + (int)c) % BigPrimeNumber;
            }
            return hash % bucketcount;
        }
        private static long hash_func_differenct(string s ,int x , long prime)
        {
            long hash = 0;
            foreach (var c in s.Reverse())
            {
                hash = (hash * ChosenX + (int)c) % BigPrimeNumber;
            }
            return hash;
        }
        private long bucketcount;
        public const long BigPrimeNumber = 1000000007;
        public const long ChosenX = 263;

        Dictionary<long, List<string>> word_dict = new Dictionary<long, List<string>>();

        public static long PolyHash(
            string str, int start, int count,
            long p = BigPrimeNumber, long x = ChosenX)
        {
            long hash = 0;
            string make_Str = "";
            for (int i = start ; i <= start + count ; i++)
            {
                make_Str += str[i];
            }
            hash = hash_func_differenct(make_Str ,(int) x , BigPrimeNumber);
            return hash;
        }

        public void Add(string str, long computed_hash)
        {

            try
            {
                if (! this.word_dict[computed_hash].Contains(str))
                    this.word_dict[computed_hash].Add(str);
            }
            catch
            {
                this.word_dict[computed_hash] = new List<string>();
                this.word_dict[computed_hash].Add(str);
            }

        }

        public string Find(string str, long computed_hash)
        {
            string printed = "no";
            try
            {
                if (this.word_dict[computed_hash].Contains(str))
                {
                    printed = "yes";
                }
            }
            catch
            {

            }
            return printed;
        }

        public void Delete(string str, long computed_hash)
        {
            try
            {
                if (this.word_dict[computed_hash].Contains(str))
                {
                    this.word_dict[computed_hash].Remove(str);
                }
            }
            catch
            {

            }
        }

        public string Check(int i)
        {
            try
            {
                string[] reversed = new string[this.word_dict[i].Count];
                this.word_dict[i].CopyTo(reversed) ;
                reversed = reversed.Reverse().ToArray();
                if (this.word_dict[i].Count == 0)
                {
                    return "-";
                }
                return string.Join(" ", reversed);
            }
            catch
            {
                return "-";
            }
            
        }
    }
}
