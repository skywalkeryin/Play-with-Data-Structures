using System;
using System.Collections.Generic;
using System.Text;

namespace DS_Graph
{
    public interface IGraph
    {
        int V();
        int E();

        void AddEdge(int v,int w);
        IEnumerable<int> Adj(int v);

    }
}
