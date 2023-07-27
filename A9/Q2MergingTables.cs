using System;
using System.Linq;
using TestCommon;
using System.Collections.Generic;
namespace A9
{
    public class Q2MergingTables : Processor
    {

        public Q2MergingTables(string testDataName) : base(testDataName) { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long[], long[], long[], long[]>)Solve);

        public long[] Solve(long[] tableSizes, long[] targetTables, long[] sourceTables)
        {
            List<long> a = new List<long>();
            Database db = new Database(tableSizes);
            for (var i = 0; i < targetTables.Length; i++)
            {
                db.merge(sourceTables[i] - 1, targetTables[i] - 1);
                a.Add(db.get_max());
            }
            return a.ToArray();
        }

    }
    public class Database
    {
        long[] row_count;
        long max_row;
        long[] rank;
        long[] parents;

        public Database(long[] row_count)
        {
            this.row_count = row_count;
            this.max_row = row_count.Max();
            this.rank = new long[row_count.Length];
            for (var i = 0; i < rank.Length; i++)
            {
                rank[i] = 1;
            }
            this.parents = new long[row_count.Length];
            for (var i = 0; i < parents.Length; i++)
            {
                parents[i] = i;
            }
        }
        public long get_max()
        {
            return this.max_row;
        }
        public void merge(long src, long dst)
        {
            long src_root = this.get_parent(src);
            long dest_root = this.get_parent(dst);
            if (src_root == dest_root) return;
            if (this.rank[src_root] >= this.rank[dest_root])
                this.parents[src_root] = dest_root;
            else
            {
                this.parents[dest_root] = src_root;
                if (this.rank[src_root] == this.rank[dest_root])
                {
                    this.rank[src_root] += 1;
                }
            }
            this.row_count[dest_root] += this.row_count[src_root];
            this.row_count[src_root] = 0;
            if (this.max_row < this.row_count[dest_root])
                this.max_row = this.row_count[dest_root];
        }

        private long get_parent(long table)
        {
            List<long> for_update = new List<long>();
            var root = table;
            while (this.parents[root] != root)
            {
                for_update.Add(this.parents[root]);
                root = this.parents[root];
            }
            foreach (var i in for_update)
            {
                this.parents[i] = root;
            }
            return root;
        }
    }
}