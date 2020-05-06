using System;
using System.Collections.Generic;
using System.Text;

namespace DS_Graph.WeightedGraph
{
    public interface IWeightedGraph<Weight> where Weight : IComparable<Weight>
    {
        int V();
        int E();
        void AddEdge(Edge<Weight> edge);
        bool HasEdge(int v, int w);
        void Show();
        IEnumerable<Edge<Weight>> Adj(int v);

    }
}
