using DS_MyArray;
using System;
using System.Collections.Generic;
using System.Text;

namespace DS_MyQueue
{
    public class MyArrayQueue<T> : IQueue<T>
    {
        private MyArray2<T> data;

        public MyArrayQueue()
        {
            data = new MyArray2<T>();
        }
        public MyArrayQueue(int capacity)
        {
            data = new MyArray2<T>(capacity);
        }
        public T Dequeue()
        {
            return data.RemoveFirst();
        }
        public void Enqueue(T e)
        {
            data.AddLast(e);
        }

        public T[] GetData()
        {
            return data.GetData();
        }

        public T GetFront()
        {
            return data.GetFirst();
        }

        public int GetSize()
        {
            return data.GetSize();
        }
        public bool IsEmpty()
        {
            return data.IsEmpty();
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Queue: front [");
            for (int i = 0; i < data.GetSize(); i++)
            {
                sb.Append(data.Get(i));
                if(i != data.GetSize() - 1)
                {
                    sb.Append(", ");
                }
            }
            sb.Append(" ] tail");
            return sb.ToString();
        }
    }
}
