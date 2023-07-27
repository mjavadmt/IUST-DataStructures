using Priority_Queue;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TestCommon;

namespace A9
{
    public class Q3Froggie : Processor
    {
        public Q3Froggie(string testDataName) : base(testDataName)
        { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, long, long[], long[], long>)Solve);

        public static long Solve(long initialDistance, long initialEnergy, long[] distance, long[] food)
        {
            long Count = 0;
            long CanBeMoved = initialDistance - initialEnergy;
            List<long> NotCheckedIndex = new List<long>();
            SimplePriorityQueue<long> pq = new SimplePriorityQueue<long>();
            for (int i = 0; i < distance.Length; i++)
            {
                if (CanBeMoved > distance[i])
                {
                    pq.Enqueue(distance[i], 0);
                    NotCheckedIndex.Add(i);
                }
                else
                {
                    pq.Enqueue(distance[i], -food[i]);
                }
            }
            while (CanBeMoved != 0)
            {
                if (CanBeMoved < 0)
                {
                    break;
                }
                for (int j = 0; j < NotCheckedIndex.Count; j++)
                {
                    long n = NotCheckedIndex[j];
                    if (CanBeMoved <= distance[n])
                    {
                        pq.UpdatePriority(distance[n], -food[n]);
                        NotCheckedIndex.Remove(n);
                        j -= 1;
                    }
                }
                long GetMax = pq.Dequeue();
                if (GetMax < CanBeMoved)
                {
                    return -1;
                }
                int index = Array.IndexOf(distance, GetMax);
                CanBeMoved -= food[index];
                Count += 1;
            }

            if (Count == 0)
                return -1;

            return Count;
        }

        private static long NewMethod1(long initialDistance, long initialEnergy, long[] distance, long[] food)
        {
            long CanBeMoved = initialDistance - initialEnergy;
            SimplePriorityQueue<long> StoreMaxes = new SimplePriorityQueue<long>();
            foreach (var d in distance)
                StoreMaxes.Enqueue(d, 0);
            List<int> NotChecked = Enumerable.Range(0, distance.Length).ToList();
            long Count = 0;
            while (CanBeMoved > 0)
            {
                List<int> ToBeRemoved = new List<int>();
                foreach (var nc in NotChecked)
                {
                    if (distance[nc] >= CanBeMoved)
                    {
                        StoreMaxes.UpdatePriority(distance[nc], -food[nc]);
                        ToBeRemoved.Add(nc);
                    }
                }
                NotChecked.RemoveAll(x => ToBeRemoved.Contains(x));
                long GetMax = 0;
                if (!StoreMaxes.Any())
                {
                    return -1;
                }
                GetMax = StoreMaxes.Dequeue();
                if (GetMax < CanBeMoved)
                {
                    return -1;
                }
                CanBeMoved -= food[Array.IndexOf(distance, GetMax)];
                Count++;
            }
            if (Count == 0)
                return -1;
            return Count;
        }

        private static long NewMethod(long initialDistance, ref long initialEnergy, long[] distance, long[] food)
        {
            List<(long, long)> DistanceWithEnergy = new List<(long, long)>();
            for (long i = 0; i < food.Length; i++)
            {
                DistanceWithEnergy.Add((initialDistance - distance[i], food[i]));
            }
            DistanceWithEnergy = DistanceWithEnergy.OrderBy(x => x.Item1).ToList();
            long MovedSoFar = 0;
            int start = 0;
            long count = 0;

            while (MovedSoFar != initialDistance)
            {
                (long, int) max = (0, 0);
                if (start == food.Length)
                    return -1;
                var start_copy = start;
                if (MovedSoFar + initialEnergy >= initialDistance)
                    break;
                long subtract = 0;
                if (start > 0)
                    subtract = DistanceWithEnergy[start - 1].Item1;
                while (initialEnergy >= DistanceWithEnergy[(int)start].Item1 - subtract)
                {
                    if (DistanceWithEnergy[start].Item2 > max.Item1)
                        max = (DistanceWithEnergy[start].Item2, start);
                    start++;
                    if (start == food.Length)
                        break;
                }
                initialEnergy += max.Item1 - (DistanceWithEnergy[max.Item2].Item1 - MovedSoFar);
                MovedSoFar = DistanceWithEnergy[max.Item2].Item1;
                count++;
                if (MovedSoFar + initialEnergy >= initialDistance)
                    break;
                if (start_copy == start)
                    return -1;
                start = max.Item2 + 1;
            }
            return count;
        }
    }

}
