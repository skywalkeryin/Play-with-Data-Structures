using System;
using System.Collections.Generic;
using System.Text;

namespace DS_Graph
{
    // dfs, 求出图的的联通量
    public class Components
    {
        private IGraph G;
        private bool[] visted; // 存储节点i是否访问过 
        private int count;  // 图的联通量
        private int[] id; // 把相互连通的点设置相同的id

        public Components(IGraph graph)
        {
            // 算法初始化
            G = graph;
            visted = new bool[G.V()];
            count = 0;
            for (int i = 0; i < G.V(); i++)
            {
                visted[i] = false;
                id[i] = -1;
            }

            //  求图的联通量
            for (int i = 0; i < G.V(); i++)
            {
                if (!visted[i])
                {               
                    dfs(i);
                    count++;
                }
                
            }
        }

        public int Count()
        {
            return count;
        }
        // 两个点是否相连
        public bool IsConnected(int v, int w)
        {
            if(v < 0 || v >= G.V()){
                throw new Exception("illegal v");
            }

            if (w < 0 || w >= G.V())
            {
                throw new Exception("illegal v");
            }
            return id[v] == id[w];
        }
        // 深度遍历v的所有邻边
        private void dfs(int v)
        {
            visted[v] = true;
            id[v] = count;

            IEnumerable<int> iterator = G.Adj(v);
            foreach (int i in iterator)
            {
                if (!visted[i])
                {                 
                    dfs(i);
                }
            }
        }


    }
}
