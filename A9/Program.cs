using System;
using Priority_Queue;

namespace A9
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
             //First, we create the priority queue.
            //By default, priority-values are of type 'float'
            SimplePriorityQueue<int> spq = new SimplePriorityQueue<int>();
            spq.Enqueue(8,3);
            SimplePriorityQueue<string> priorityQueue = new SimplePriorityQueue<string>();
            var ans = Q3Froggie.Solve(35, 10, new long[]{30,20,32,33,10},new long[]{5,10,2,4,32});
            //Now, let's add them all to the queue (in some arbitrary order)!
            priorityQueue.Enqueue("4 - Joseph", 0);
            priorityQueue.Enqueue("2 - Tyler", 0); //Note: Priority = 0 right now!
            priorityQueue.Enqueue("1 - Jason", 0);
            priorityQueue.Enqueue("4 - Ryan", 0);
            priorityQueue.Enqueue("3 - Valerie", 0);
            
            //Change one of the string's priority to 2.  Since this string is already in the priority queue, we call UpdatePriority() to do this
            // priorityQueue.UpdatePriority("2 - Tyler", 2);

            //Finally, we'll dequeue all the strings and print them out
            while(priorityQueue.Count != 0)
            {
                string nextUser = priorityQueue.Dequeue();
                Console.WriteLine(nextUser);
            }

            //Output:
            //1 - Jason
            //2 - Tyler
            //3 - Valerie
            //4 - Joseph
            //4 - Ryan
        }
    }
}
