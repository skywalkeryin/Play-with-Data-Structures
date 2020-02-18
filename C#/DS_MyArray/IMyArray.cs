using System;
using System.Collections.Generic;
using System.Text;

namespace DS_MyArray
{
    interface IMyArray<T>
    {
        bool IsEmpty();
        int GetSize();
        void AddFirst(T e);
        void AddLast(T e);

        bool Contains(T e);

        int Find(T e);
        T RemoveFirst();
        T RemoveLast();

        string ToString();
    }
}
