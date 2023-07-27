using System;
using System.Collections.Generic;
using System.Text;
using TestCommon;

namespace A11
{
    public class Q3IsItBSTHard : Processor
    {
        public Q3IsItBSTHard(string testDataName) : base(testDataName) { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long[][], bool>)Solve);

        public bool Solve(long[][] nodes)
        {
            int nodes_length=nodes.Length;
            Node[] NodeArray=new Node[nodes_length];
            for(int i=0;i<nodes_length;i++)
            {
                NodeArray[i]=new Node(nodes[i][0],nodes[i][1],nodes[i][2]);
            }
            if(nodes_length == 0 || IsBinarySearchTree(NodeArray))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool IsBinarySearchTree(Node[] tree)
        {
            Stack<(Node , Node , Node)> PreInNext = new Stack<(Node , Node , Node)>(); 
            Node ln=new Node(int.MinValue,-1,-1);
            Node rn=new Node(int.MaxValue,-1,-1);
            PreInNext.Push((ln , tree[0] , rn));
            while (PreInNext.Count!=0)
            {
                var n= PreInNext.Pop();
                Node root=n.Item2;
                Node left=n.Item1;
                Node right=n.Item3;
                if (root.key < left.key || root.key >= right.key)
                {
                    return false;
                }
                if (root.left != -1)
                {
                    PreInNext.Push((left , tree[root.left] , root));
                }
                if (root.right != -1)
                {
                    PreInNext.Push((root , tree[root.right] , right));
                }
            }
            return true;
        }
    
        
    }
    

}