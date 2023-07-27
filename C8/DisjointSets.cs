using System.Collections.Generic;

namespace C8
{
    class DisjointSets
    {
        public int[] parent;
        int n;
        public DisjointSets(int n)
        {
            this.n = n;
            makeSet();
        }

        public void makeSet()
        {
            this.parent = new int[this.n];
            for (int i = 0 ; i< this.n ; i++)
            {
                parent[i] = i;
            }
        }

        public int find(int x)
        {
            if (x != parent[x])
                parent[x] = find(parent[x]);
            return parent[x];
        }

        public void union(int x, int y)
        {
            var x_id = find(x);
            var y_id = find(y);
            // if (x_id == y_id)
            //     return;
            // if (rank[x_id] >= rank[y_id])
            // {
            //     parent[y_id] = x_id;
            //     if (rank[x_id] == rank[y_id])
            //         rank[y_id] += 1;   
            // }  
            // else
            // {
            //     parent[x_id] = y_id;
            // }
            if (x_id < y_id)
                parent[y_id] = x_id;
            else
                parent[x_id] = y_id;
        }
    }
}
