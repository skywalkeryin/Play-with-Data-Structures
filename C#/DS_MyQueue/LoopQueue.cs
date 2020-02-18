using DS_MyArray;
using System;
using System.Collections.Generic;
using System.Text;

namespace DS_MyQueue
{
    public class LoopQueue<T> : IQueue<T>
    {
        private T[] data;
        private int front;
        private int tail;
        private int size;

        public LoopQueue(int capacity)
        {
            data = new T[capacity + 1];
            tail = 0;
            front = 0;
            size = 0;
        }

        public LoopQueue() : this(10)
        {

        }
        public void Enqueue(T e)
        {
            if ((tail + 1) % data.Length == front) // data is full
            {
                Resize(GetCapacity() * 2);
            }
            data[tail] = e;
            tail = (tail + 1) % data.Length; 
            size++;
        }

        public T Dequeue()
        {
            if (IsEmpty())  // data is empty
            {
                throw new Exception("Dequeue failed. The queue is empty.");
            }
            T e = data[front];
            data[front] = default(T);
            front = (front + 1) % data.Length;
            size--;
            if (size == GetCapacity() / 4 && GetCapacity() / 2 != 0)
            {
                Resize(GetCapacity() / 2);
            }
            return e;
        }

        public T GetFront()
        {
            if (IsEmpty())  // data is empty
            {
                throw new Exception("The queue is empty.");
            }
            return data[front];
        }

        public int GetSize()
        {
            return size;
        }

        public int GetCapacity()
        {
            return data.Length - 1;
        }

        public bool IsEmpty()
        {
            return tail == front;
        }
        private void Resize(int newCapacity)
        {
            T[] newData = new T[newCapacity + 1];
            for (int i = 0;  i < size; i++)
            {
                newData[i] = data[(i + front) % data.Length];
            }
            data = newData;
            front = 0;
            tail = size;
        }

        public T[] GetData()
        {
            return data;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append($"Queue: size is {size}, capacity is {GetCapacity()} \n");
            sb.Append("front [");
            for (int i = front; i != tail;  i= (i + 1)% data.Length)
            {
                sb.Append(data[i]);
                if ((i + 1) % data.Length != tail)
                {
                    sb.Append(", ");
                }
            }
            sb.Append(" ] tail");
            return sb.ToString();
        }
    }
}
