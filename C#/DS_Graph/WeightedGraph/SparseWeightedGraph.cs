using System;
using System.Collections.Generic;
using System.Text;

namespace DS_Graph.WeightedGraph
{
    // 稀松图， 邻接表
    public class SparseWeightedGraph<Weight> : IWeightedGraph<Weight> where Weight : struct, IComparable<Weight>
    {
        private int n; //节点个数
        private int m; //边的个数
        private bool directed;
        private List<Edge<Weight>>[] g;

        public SparseWeightedGraph(int n, bool directed)
        {
            this.n = n;
            this.m = 0;
            this.directed = directed;
            g = new List<Edge<Weight>>[n];
            for (int i = 0; i< n; i++)
            {
                g[i] = new List<Edge<Weight>>();
            }
        }

        public void AddEdge(Edge<Weight> edge)
        {
            if (edge.V() < 0 || edge.V() >= n )
            {
                throw new Exception("Ilegal vertex.");
            }
            if (edge.W() < 0 || edge.W() >= n)
            {
                throw new Exception("Ilegal vertex.");
            }

            g[edge.V()].Add(edge);
            if (edge.V() != edge.W() && !directed) // 去掉自环边
            {
                g[edge.W()].Add(new Edge<Weight>(edge.V(), edge.W(), edge.Wt()));
            }
            m++;

        }

        public IEnumerable<Edge<Weight>> Adj(int v)
        {
            if (v < 0 || v >= n)
            {
                throw new Exception("Ilegal vertex.");
            }

            return g[v];
        }

        public int E()
        {
            return m;
        }

        public bool HasEdge(int v, int w)
        {
            if (v < 0 || v >= n)
            {
                throw new Exception("Ilegal vertex.");
            }
            if (w < 0 || w >= n)
            {
                throw new Exception("Ilegal vertex.");
            }

            for (int i = 0; i < g[v].Count; i++)
            {
                if (g[v][i].Other(v) == w)
                {
                    return true;
                }
            }
            return false;
        }

        public void Show()
        {
            for (int i = 0; i < n; i++)
            {
                Console.Write("Vertex:" + i);
                foreach (var a in g[i])
                {
                    Console.Write($"{a}" + '\t');
                }
                Console.Write("\n");
            }
        }

        public int V()
        {
            return n;
        }
    }
}
