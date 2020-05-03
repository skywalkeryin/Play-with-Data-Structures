using System;
using System.Collections.Generic;
using System.Text;

namespace DS_UF
{
    public interface IUnionFind
    {
       void UnitElement(int p, int q);

       bool IsConnected(int p, int q);

        int Find(int p);

    }
}
