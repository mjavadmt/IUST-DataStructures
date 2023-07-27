using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using TestCommon;

namespace E2
{
    public class Q2ThreeChildrenMinHeap : Processor
    {
        public Q2ThreeChildrenMinHeap(string testDataName) : base(testDataName) { }
        public override string Process(string inStr)
        {
            long n;
            long changeIndex, changeValue;
            long[] heap;
            using (StringReader reader = new StringReader(inStr))
            {
                n = long.Parse(reader.ReadLine());

                string line = null;
                line = reader.ReadLine();

                TestTools.ParseTwoNumbers(line, out changeIndex, out changeValue);

                line = reader.ReadLine();
                heap = line.Split(TestTools.IgnoreChars, StringSplitOptions.RemoveEmptyEntries)
                    .Select(x => long.Parse(x)).ToArray();
            }

            return string.Join("\n", Solve(n, changeIndex, changeValue, heap));

        }
        public long[] Solve(
            long n, 
            long changeIndex, 
            long changeValue, 
            long[] heap)
        {
             var oldp=heap[changeIndex];
            heap[changeIndex]+=changeValue;
            if(heap[changeIndex]<oldp)
            {
                siftup(changeIndex,heap);
            }
            else{
                siftdown(changeIndex,heap);
            }
            return heap;
        }   
        public long parent(long i)
        {
            return (long)((i-1)/3);
        }
        public long leftchild(long i)
        {
            return (long)((3*i)+1);
        }
        public long rightchild(long i)
        {
            return (long)((3*i)+3);
        }
        public long middlechild(long i)
        {
            return (long)((3*i)+2);
        }
 
        public void siftdown(long i,long[] tree)
        {
            long left_min = int.MaxValue ;
            long right_min = int.MaxValue ;
            long middle_min = int.MaxValue ;
            if (leftchild(i) < tree.Length)
            {
                left_min = tree[leftchild(i)];
            }
            if (rightchild(i) < tree.Length )
            {
                right_min = tree[rightchild(i)];
            }
            if (middlechild(i) < tree.Length)
            {
                middle_min = tree[middlechild(i)];
            }
            var min=new long[]{left_min,middle_min,right_min}.Min();
            while(tree[i]>min)
            {
 
                if(min==tree[leftchild(i)])
                {
                    (tree[i],tree[leftchild(i)])=(tree[leftchild(i)],tree[i]);
                    i=leftchild(i);
                }
                else if(min==tree[middlechild(i)])
                {
                    
                    (tree[i],tree[middlechild(i)])=(tree[middlechild(i)],tree[i]);
                    i=middlechild(i);
                }
                else if(min==tree[rightchild(i)])
                {
                    (tree[i],tree[rightchild(i)])=(tree[rightchild(i)],tree[i]);
                    i=rightchild(i);
                }
                long min_for_middle = int.MaxValue ;
                long min_for_right = int.MaxValue;
                if (leftchild(i) >= tree.Length)
                {
                    break ;
                }
                if(middlechild(i)< tree.Length )
                    min_for_middle = tree[middlechild(i)];
                if (rightchild(i) < tree.Length)
                    min_for_right = tree[rightchild(i)];
                min=new long[]{tree[leftchild(i)],min_for_middle,min_for_right}.Min();
                
            }
        }
        public void siftup(long i,long[] tree)
        {
            while(i>0 && tree[parent(i)]>tree[i])
            {
                (tree[parent(i)],tree[i])=(tree[i],tree[parent(i)]);
                i=parent(i);
            }
        }   
    }
}
