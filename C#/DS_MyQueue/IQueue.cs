using System;
using System.Collections.Generic;
using System.Text;

namespace DS_MyQueue
{
    public interface IQueue<T>
    {
        void Enqueue(T e);
        T Dequeue();
        T GetFront();
        int GetSize();
        bool IsEmpty();
        T[] GetData();
    }
}
