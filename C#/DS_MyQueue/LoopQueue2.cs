using System;
using System.Collections.Generic;
using System.Text;

namespace DS_MyQueue
{
    public class LoopQueue2<T> : IQueue<T>
    {
        private T[] data;
        private int front;
        private int tail;

        public LoopQueue2(int capacity)
        {
            data = new T[capacity + 1];
        }
        public LoopQueue2() : this(10)
        {

        }

        public void Enqueue(T e)
        {
            if ((tail + 1) % data.Length  == front)
            {
                resize(GetCapacity() * 2);
            }
            data[tail] = e;
            tail =(tail + 1) % data.Length;
        }

        public T Dequeue()
        {
            if (IsEmpty())
            {
                throw new Exception("Dequeue failed. The queue is empty");
            }

            T result = data[front];
            data[front] = default(T);
            front = (front + 1) % data.Length;

            if (GetSize() == GetCapacity() / 4 && GetCapacity() / 2 != 0)
            {
                resize(GetCapacity() / 2);
            }
            return result;
        }

        public T GetFront()
        {
            if (IsEmpty())
            {
                throw new Exception("GetFront failed. The queue is empty");
            }
            return data[front];
        }

        public int GetSize()
        {
            return (tail - front) >= 0 ? tail - front : data.Length - (front - tail);
        }
        public bool IsEmpty()
        {
            return front == tail;
        }
        public int GetCapacity()
        {
            return data.Length - 1;
        }

        private void resize(int newCapacity)
        {
            T[] newData = new T[newCapacity + 1];
            int size = GetSize();
            for (int i = 0; i < size; i++)
            {
                newData[i] = data[(i + front) % data.Length];
            }
            data = newData;
            tail = size;
            front = 0;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append($"Queue: size is {GetSize()}, capacity is {GetCapacity()} \n");
            sb.Append("front [ ");
            for (int i = front; i != tail; i = (i + 1) % data.Length)
            {
                sb.Append(data[i]);
                if (i != tail - 1)
                {
                    sb.Append(", ");
                }
            }
            sb.Append(" ] tail");
            return sb.ToString();
        }

        public T[] GetData()
        {
            return data;
        }
    }
}
