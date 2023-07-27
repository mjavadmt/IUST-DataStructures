using System;
using System.Collections.Generic;
using System.Text;
using TestCommon;
using System.Linq;

namespace A5
{
    public class Q2MajorityElement:Processor
    {

        public Q2MajorityElement(string testDataName) : base(testDataName)
        { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, long[], long>)Solve);


        public static long Solve(long n, long[] a)
        {
            if (MyMajorityElement(a) != -1)
                return 1;
            else
                return 0;            
        }
        private static long MyMajorityElement(long[] a)
        {
            if (a.Length == 1)
                return a[0];
            long FirstMajor = MyMajorityElement(SubArray(a,0,(int)(a.Length)/2));
            long SeconMajor = MyMajorityElement(SubArray(a,(int)(a.Length)/2,a.Length - (int)(a.Length)/2));
            long FirstCount = 0;
            long SeconCount = 0;
            if (FirstMajor != -1)
            {
                foreach (var i in a)
                {
                    if (i == FirstMajor)
                        FirstCount += 1;
                    if (FirstCount > a.Length/2)
                        return FirstMajor;
                }    
            }
            if (SeconMajor != -1)
            {
                foreach(var i in a)
                {
                    if (i == SeconMajor)
                        SeconCount += 1;
                    if (SeconCount > a.Length/2)
                        return SeconMajor;
                } 
            }
            return -1;
        }
        public static long[] SubArray(long[] data, int index, int length)
        {
            long[] result = new long[length];
            Array.Copy(data, index, result, 0, length);
            return result;
        }
    }
}
