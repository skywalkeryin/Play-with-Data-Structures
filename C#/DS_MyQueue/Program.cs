using System;
using System.Diagnostics;

namespace DS_MyQueue
{
    class Program
    {

        static double TestQueue(IQueue<int> queue, int OptCount)
        {
            Random rnd = new Random();
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            for (int i = 0; i <OptCount; i++)
            {
                queue.Enqueue(rnd.Next(int.MaxValue));
            }
            for (int i = 0; i < OptCount; i++)
            {
                queue.Dequeue();
            }
            stopWatch.Stop();
            return (double)stopWatch.ElapsedMilliseconds / 1000.000;
        }
        static void Main(string[] args)
        {
            //IQueue<int> queue = new LoopQueue2<int>();

            //for (int i = 0; i < 10; i ++)
            //{
            //    queue.Enqueue(i);
            //    Console.WriteLine(queue);
            //    if(i % 3  == 2)
            //    { 
            //        queue.Dequeue();
            //        Console.WriteLine(queue);
            //    }
            //}

            // Test two queue implementation
            int optCount = 100000;
            IQueue<int> queue = new MyArrayQueue<int>();
            IQueue<int> queue2 = new LoopQueue<int>();

            double testTime1 = TestQueue(queue, optCount);
            Console.WriteLine($"Array Queue, Time: {testTime1}s");
            double testTime2 = TestQueue(queue2, optCount);
            Console.WriteLine($"Loop Queue, Time: {testTime2}s");

        }
    }
}
