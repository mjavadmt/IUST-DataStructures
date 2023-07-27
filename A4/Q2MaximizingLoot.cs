using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TestCommon;

namespace A4
{
    public class Q2MaximizingLoot : Processor
    {
        public Q2MaximizingLoot(string testDataName) : base(testDataName)
        {}

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, long[], long[], long>) Solve);


        public virtual long Solve(long capacity, long[] weights, long[] values)
        {
            
            double value = 0;
            long picked_weight = 0;
            List<Tuple<double,long>> merge_vw = new List<Tuple<double,long>>();
            for (int i = 0 ; i<weights.Length ; i++)
            {
                double sth = (double)values[i]/weights[i];
                merge_vw.Add(Tuple.Create(Math.Round(sth , 9),weights[i]));
            }
            var merge_vw_sorted = merge_vw.OrderByDescending(x => x.Item1).ToList();
            int initializer = 0;
            while (picked_weight < capacity)
            {
                if (initializer == merge_vw_sorted.Count)
                {
                    return (long)value;
                }
                if (picked_weight + merge_vw_sorted[initializer].Item2 <= capacity)
                {
                    value += merge_vw_sorted[initializer].Item1 * merge_vw_sorted[initializer].Item2;
                    picked_weight += merge_vw_sorted[initializer].Item2;
                }
                else
                {
                    value += (((capacity - picked_weight)) * merge_vw_sorted[initializer].Item1);
                    picked_weight = capacity;
                }
                initializer ++ ;
            }
            return (long)value;


           
        }


        public override Action<string, string> Verifier { get; set; } =
            TestTools.ApproximateLongVerifier;

    }
}
