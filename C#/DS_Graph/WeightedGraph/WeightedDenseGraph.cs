using System;
using System.Collections.Generic;
using System.Text;

namespace DS_Graph.WeightedGraph
{
    // 稠密图 邻接表
    public class WeightedDenseGraph<Weight> : IWeightedGraph<Weight> where Weight : struct, IComparable<Weight>
    {
        private int n;
        private int m;
        private bool directed;
        private Weight[][] g;

        public WeightedDenseGraph(int n, bool directed)
        {
            this.n = n;
            this.m = 0;
            this.directed = directed;
            g = new Weight[n][];
            for (int i = 0; i < n; i++)
            {
                g[i] = new Weight[n];  //初始值为weight的初始值
            }
        }
        public void AddEdge(Edge<Weight> edge)
        {
            if (edge.V() < 0 || edge.V() >= n)
            {
                throw new Exception("Ilegal vertex.");
            }
            if (edge.W() < 0 || edge.W() >= n)
            {
                throw new Exception("Ilegal vertex.");
            }

            g[edge.V()][edge.W()] = edge.Wt();
            if (!directed)
            {
                g[edge.W()][edge.V()] = edge.Wt();
            }

        }

        public IEnumerable<Edge<Weight>> Adj(int v)
        {
            if (v < 0 || v >= n)
            {
                throw new Exception("Ilegal vertex.");
            }
            List<Edge<Weight>> result = new List<Edge<Weight>>();
            for (int i = 0; i < g[v].Length; i++)
            {
                result.Add(new Edge<Weight>(v, i, g[v][i]));
            }
            return result;
        }

        public int V()
        {
            return n;
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
            return g[v][w].CompareTo(default(Weight)) > 0;
        }

        public void Show()
        {
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write(g[i][j] + "\t");
                }
                Console.Write("\n");
            }
        }
    }
}
