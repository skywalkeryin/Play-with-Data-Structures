using System;
using System.Collections.Generic;
using System.Text;

namespace DS_Graph
{
    public class SparseGraph : IGraph
    {
        private int n; //节点
        private int m; // 边数
        private bool directed;
        private List<int>[] g;

        public SparseGraph(int n, bool directed)
        {
            this.n = n;
            this.m = 0;
            this.directed = directed;

            g = new List<int>[n];
            for (int i =0; i < n; i++)
            {
                g[i] = new List<int>();
            }

        }
        public int V() //返回节点个数
        {
            return n;
        }

        public int E() //返回边的个数
        {
            return m;
        }

        //向图中添加一个边
        public void AddEdge(int v, int w)
        {
            if (v < 0 || v >= n)
            {
                throw new Exception("v is illegal.");
            }
            if (w < 0 || w >= n)
            {
                throw new Exception("w is illegal.");
            }

            g[v].Add(w);
            // 无向图， 去掉自环边， 没法去掉平行边， 因为hasEdge的时间复杂度是o(n)的， 成本比较高
            // 通常情况下， 在加完所有的边后，一次性去除平行边
            if (v != w && !directed)  
            {
                g[w].Add(v);
            }
            m++;
        }

        // o（n）的时间复杂度
        // 验证图中是否有从v到w的边
        private bool hasEdge(int v, int w)
        {
            if (v < 0 || v >= n)
            {
                throw new Exception("v is illegal.");
            }
            if (w < 0 || w >= n)
            {
                throw new Exception("w is illegal.");
            }

            for (int i = 0; i < g[v].Count; i++)
            {
                if (g[v][i] == w)
                {
                    return true;
                }
            }
            return false;
        }

        //返回定点v的所有邻边
        public IEnumerable<int> Adj(int v)
        {
            if (v < 0 || v >= n)
            {
                throw new Exception("v is illegal.");
            }
            return g[v];
        }

        public void Show()
        {
            for (int i = 0; i < n; i++)
            {
                Console.Out.Write("vertex " + i + ":\t");
                for (int j = 0; j < g[i].Count; j++)
                {
                    Console.Out.Write($"{g[i][j]} \t");
                }
                Console.Out.Write('\n');
            }
        }

    }
}
