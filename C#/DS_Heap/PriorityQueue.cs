using System;
using System.Collections.Generic;
using System.Text;

namespace DS_Heap
{
    public class PriorityQueue<T> where T : IComparable<T>
    {

        private MaxHeap<T> maxHeap;


        public PriorityQueue()
        {
            maxHeap = new MaxHeap<T>();
        }

        public int GetSize()
        {
            return maxHeap.GetSize();
        }

        public bool IsEmpty()
        {
            return maxHeap.IsEmpty();
        }

        public void Enqueue(T e)
        {
            maxHeap.Add(e);
        }

        public T Dequeue()
        {
            return maxHeap.ExtractMax();
        }

        public T GetFront()
        {
            return maxHeap.FindMax();
        }
    }
}
