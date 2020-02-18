using DS_MyQueue;
using System;
using Xunit;

namespace DS_MyQueueTest
{
    public class MyQueueTest
    {
        [Fact]
        public void TestQueue()
        {
            IQueue<int> queue = new LoopQueue<int>();
            int[] excepted = new int[] { 0, 3, 4, 5, 6, 7, 8, 9, 0, 0, 0 };
            // task
            for (int i = 0; i < 10; i++)
            {
                queue.Enqueue(i);
                if (i % 3 == 2)
                {
                    queue.Dequeue();
                }
            }
            //
            Assert.Equal(excepted, queue.GetData()); ;
        }

        public void TestQueue2()
        {
            IQueue<int> queue = new LoopQueue2<int>();

            int[] excepted = new int[] { 0, 3, 4, 5, 6, 7, 8, 9, 0, 0, 0 };
            // task
            for (int i = 0; i < 10; i++)
            {
                queue.Enqueue(i);
                if (i % 3 == 2)
                {
                    queue.Dequeue();
                }
            }
            //
            Assert.Equal(excepted, queue.GetData()); ;
        }
    }
}
