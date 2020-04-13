using System;
using System.Collections.Generic;
using System.Text;

namespace DS_Map
{
    public interface IMap<T, V>
    {
        void Add(T k, V v);
        V Remove(T k);
        bool Contains(T k);
        void Set(T k, V v);
        V Get(T k);
        int GetSize();
        bool IsEmpty();
    }
}
