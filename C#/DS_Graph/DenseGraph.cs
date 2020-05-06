using System;
using System.Collections.Generic;
using System.Text;

namespace DS_Graph
{
    // 用邻接矩阵来表示 稠密图
    // 优点： 将平行边给去掉了， 可以采用o(1) 复杂度查询是否有边
    public class DenseGraph : IGraph
    {

        private int n; // 节点数
        private int m; //边数
        private bool directed;
        private bool[][] g;

          public DenseGraph( int n, bool directed)
           {
            this.n = n;
            this.m = 0;
            this.directed = directed;

             g = new bool[n][];
             for (int i = 0; i < n; i++)
             {
                g[i] = new bool[n];
             }
           } 
        public int V() //返回节点个数
        {
            return n;
        } 
        public int E()// 返回边的个数
        {
            return m; 
        }
        
        public  void AddEdge(int v, int w)
        {

            if (v < 0 || v >= n)
            {
                throw new Exception("v is illegal.");
            }

            if (w < 0 || w >= n)
            {
                throw new Exception("v is illegal.");
            }

            if (HasEdge(v, w))
            {
                return;
            }

            g[v][w] = true;
            if (!directed) //如果无向图时，两侧都要赋值
            {
                g[w][v] = true;
            }
            m++;



        }
        public bool HasEdge(int v, int w)
        {
            return g[v][w];
        }


        //返回定点v的所有邻边, 遍历所有的邻边
        public IEnumerable<int> Adj(int v)
        {
            if (v < 0 || v >= n)
            {
                throw new Exception("v is illegal.");
            }

            List<int> adj = new List<int>();
            for (int i = 0; i < n; i++)
            {
                if (g[v][i])
                {
                    adj.Add(i);
                }
            }
            return adj;
        }


        //显示图
        public void Show()
        {
            for (int i =0; i< n; i++)
            {
               // Console.Out.Write("vertex " + i +":\t");
                for (int j = 0; j < g[i].Length; j++)
                {
                    Console.Write($"{Convert.ToInt32(g[i][j])}\t");
                }
                Console.Write('\n');
            }
        }
    }                                      
}    