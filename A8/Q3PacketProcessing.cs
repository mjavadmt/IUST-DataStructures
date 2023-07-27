using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TestCommon;

namespace A8
{
    public class Q3PacketProcessing : Processor
    {
        public Q3PacketProcessing(string testDataName) : base(testDataName)
        {}

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, long[], long[], long[]>)Solve);

        public long[] Solve(long bufferSize, 
            long[] arrivalTimes, 
            long[] processingTimes)
        {
            List<long[]> requests = new List<long[]>();
            Buffer buffer = new Buffer();
            buffer.size = bufferSize;
            List<long> responses = new List<long>();
            for (int i = 0 ; i< arrivalTimes.Length ; i++)
            {
                responses.Add(buffer.PacketProcess(new long[]{arrivalTimes[i], processingTimes[i]}));
            }

            return responses.ToArray();
        }
    }
    class Buffer
    {
        public List<long> finish_time = new List<long>();
        public long size ;
        public long PacketProcess(long[] request)
        {
            while (this.finish_time.Count > 0 && this.finish_time[0] <= request[0])
            {
                this.finish_time.Remove(this.finish_time[0]);
            }
            if (this.finish_time.Count == 0)
            {
                this.finish_time.Add(request[1] + request[0]);
                return request[0];
            }
            else if (this.finish_time.Count < this.size)
            {
                this.finish_time.Add(request[1] + this.finish_time.Last());
                return this.finish_time[this.finish_time.Count - 2];
            }
            else 
                return -1;
        }
    }
}