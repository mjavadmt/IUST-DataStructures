using System;
using System.Diagnostics.CodeAnalysis;

namespace C11
{
    class Node: IComparable<Node>
    {
        public long Num;
        public long Cost;
        public Node Parent;
        public Node(long Num, long Cost)
        {
            this.Num = Num;
            this.Cost = Cost;
        }

        public int CompareTo([AllowNull] Node other)
        {
            return this.Cost.CompareTo(other.Cost);
        }

        public override string ToString()
        {
            return this.Num.ToString();
        }
    }
}
