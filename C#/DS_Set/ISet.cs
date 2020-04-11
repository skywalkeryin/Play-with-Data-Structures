﻿using System;
using System.Collections.Generic;
using System.Text;

namespace DS_Set
{
    public interface ISet<T>
    {
        void Add(T e);
        void Remove(T e);
        bool Contains(T e);
        int GetSize();
        bool IsEmpty();

    }
}
