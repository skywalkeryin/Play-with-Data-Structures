using System;
using System.Collections.Generic;
using System.Text;

namespace DS_MyStack
{
    interface IStack<T>
    {
        void Push(T e);
        T Pop();
        T Peek();
        int GetSize();
        bool IsEmpty();
    }
}
