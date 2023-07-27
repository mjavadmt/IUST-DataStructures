using System;
using System.Collections.Generic;
using System.Text;
using TestCommon;
using System.Linq;

namespace A5
{
    public class Q6ClosestPoints : Processor
    {
        public Q6ClosestPoints(string testDataName) : base(testDataName)
        { }
        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long , long[], long[], double>)Solve);


        public static double Solve(long n, long[] starts, long[] ends)
        {
            Tuple<long,long>[] points = new Tuple<long, long>[starts.Length];
            for (int i = 0 ; i<starts.Length ;i++)
                points[i] = Tuple.Create(starts[i],ends[i]);
            points = points.OrderBy(x => x.Item1).ToArray();
            return FindMinDistance(points);
        }
        private static double FindDistance(Tuple<long,long> p1 , Tuple<long,long> p2)
        {
            return Math.Round(Math.Sqrt((p1.Item1 - p2.Item1)*(p1.Item1 - p2.Item1) + (p2.Item2 - p1.Item2)*(p2.Item2 - p1.Item2)),4);
        }
        private static double FindMinDistance(Tuple<long,long>[] points)
        {
            if (points.Length == 3)
            {
                var first_d = FindDistance(points[0],points[1]);
                var second_d = FindDistance(points[0],points[2]);
                var third_d = FindDistance(points[1],points[2]);
                return new double[]{first_d,second_d,third_d}.Min(); 
            }
            if (points.Length == 2)
            {
                return FindDistance(points[0],points[1]);
            }
            var first_half =Q4NumberOfInversions.SubArray(points , 0 , (int)(points.Length/2)) ;
            var second_half=Q4NumberOfInversions.SubArray(points , (int)(points.Length/2), points.Length - (int)(points.Length/2)); 
            var x_middle = (double)(first_half[first_half.Length-1].Item1 + second_half[0].Item1)/2;
            var a = FindMinDistance(first_half);
            var b = FindMinDistance(second_half);
            var min_ab = Math.Min(a,b);
            List<Tuple<long,long>> check_between = new List<Tuple<long, long>>();
            for (int i = first_half.Length - 1 ; i >= 0 ; i--)
            {
                if (x_middle - first_half[i].Item1 > min_ab)
                    break;
                check_between.Add(first_half[i]);
            }
            for ( int i = 0 ; i<second_half.Length ; i++)
            {
                if (second_half[i].Item1 - x_middle > min_ab)
                    break;
                check_between.Add(second_half[i]);
            }
            check_between = check_between.OrderBy(x => x.Item2).ToList();
            min_ab = FindBetween(check_between,min_ab);
            return min_ab;
        }
        private static double FindBetween(List<Tuple<long,long>> between , double min_so_far)
        {
            for (int i = 0 ; i<between.Count ; i++)
            {
                var move = i+7;
                if (move > between.Count)
                    move = between.Count;
                for (int j = i+1 ; j<move ; j++)
                {
                    var check_distance = FindDistance(between[i],between[j]);
                    if (check_distance < min_so_far)
                        min_so_far = check_distance;
                }
            }
            return min_so_far;
        }
        // public override Action<string, string> Verifier { get; set; } =
        //     TestTools.ApproximateLongVerifier;
    }
}