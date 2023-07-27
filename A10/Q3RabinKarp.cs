using System;
using System.Collections.Generic;
using TestCommon;

namespace A10
{
    public class Q3RabinKarp : Processor
    {
        public Q3RabinKarp(string testDataName) : base(testDataName) { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<string, string, long[]>)Solve);

        public long[] Solve(string pattern, string text)
        {
            long p=1000000007;
            var rand= new Random();
            var x=rand.Next(1,(int)p-1);
            List<long> pos=new List<long>();
            long pHash=hashfunc(pattern,x,p);
            var thah=PrecomputeHashes(text,pattern,p,x);
            for(var i=0;i<text.Length-pattern.Length+1;i++)
            {
                if(thah[i]==pHash)pos.Add(i);
            }
            return pos.ToArray();
            // List<long> occurrences = new List<long>();
            // int startIdx = 0;
            // int foundIdx = 0;
            // while ((foundIdx = text.IndexOf(pattern, startIdx)) >= startIdx)
            // {
            //     startIdx = foundIdx + 1;
            //     occurrences.Add(foundIdx);
            // }
            // return occurrences.ToArray();
        }

        private List<long> PrecomputeHashes(string text, string pattern, long prime, int x)
        {
            var t = text.Length;
            var p = pattern.Length;
            var s=text.Substring(t-p,p);
            List<long> H=new List<long>();
            for(var i=0;i<t-p+1;i++)
            {
                H.Add(0);
            }
            H[t-p]=(hashfunc(s,x,prime));
            long y=1;
            for(var i=1;i<p+1;i++)
            {
                y=(y*x)%prime;
            }
            for(var i=t-p-1;i>-1;i--)
            {
                H[i]=(x*H[i+1]+Convert.ToInt32(text[i])-y*Convert.ToInt32(text[i+p]))%prime;
            }
            return H;
        }

        private long hashfunc(string pattern, int x, long p)
        {
            long ans =0;
            var ar=pattern.ToCharArray();
            Array.Reverse(ar);
            foreach(var c in ar )
            {
                ans=(ans*x+Convert.ToInt32(c))%p;
            }
            return ans;
        }
        private static long hashfunc_for_precompute(string pattern, int x, long p)
        {
            long ans =0;
            var ar=pattern.ToCharArray();
            Array.Reverse(ar);
            foreach(var c in ar )
            {
                ans=(ans*x+Convert.ToInt32(c))%p;
            }
            return ans;
        }

        public static long[] PreComputeHashes(
            string text, 
            int P, 
            long prime, 
            long x)
        {
            var t = text.Length;
            var p = P;
            var s=text.Substring(t-p,p);
            List<long> hashes=new List<long>();
            for(var i=0;i<t-p+1;i++)
            {
                hashes.Add(0);
            }
            hashes[t-p]=(hashfunc_for_precompute(s,(int)x,prime));
            long y=1;
            for(var i=1;i<p+1;i++)
            {
                y=(y*x)%prime;
            }
            for(var i=t-p-1;i>-1;i--)
            {
                hashes[i]=(x*hashes[i+1]+Convert.ToInt32(text[i])-y*Convert.ToInt32(text[i+p]))%prime;
            }
            return hashes.ToArray();
        }
    }
}
