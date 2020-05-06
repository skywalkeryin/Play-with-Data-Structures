using System;
using System.Collections.Generic;
using System.Text;

namespace DS_Graph
{
    public class Path
    {
        private IGraph G;
        private int s; // 起始点
        private bool[] visited;
        private int[] from;  // 记录节点的来源 int[i] 表示i点来自哪个点

        
        // 从s点开始遍历所有的邻边
        public Path(IGraph graph, int s)
        {
            // 算法初始化
            G = graph;
            if (s < 0 && s >= G.V())
            {
                throw new Exception("s is illegal");
            }

            visited = new bool[G.V()];
            from = new int[G.V()];

            for (int i = 0; i < G.V(); i++)
            {
                visited[i] = false;
                from[i] = -1;
            }
            this.s = s;

            //寻路算法
            dfs(s);
        }

        // 判断从s到w点有没有路相连
        public bool HasPath(int w)
        {
            if (w < 0 && w >= G.V())
            {
                throw new Exception("w is illegal");
            }

            return visited[w];
        }

        List<int> path(int w)
        {
            if (!HasPath(w))
            {
                throw new Exception("There is no path between s and w.");
            }

            List<int> path = new List<int>();

            Stack<int> stack = new Stack<int>();
            int p = w;

            // 一直到p等于-1， 此时p为s， 因为s点没from放进数组
            while (p != -1)
            {
                stack.Push(p);
                p = from[p];
            }

            while(stack.Count > 0){
                path.Add(stack.Pop());
            }

            return path;
        }

        public void ShowPath(int w)
        {
            if (!HasPath(w))
            {
                throw new Exception("There is no path between s and w.");
            }

            List<int> list = path(w);
            for (int i = 0; i <list.Count; i++)
            {
                Console.Write(list[i]);
                if (i != list.Count -1)
                {
                    Console.Write("->");
                }
                else
                {
                    Console.Write("\n");
                }
            }

        }

        private void dfs(int v)
        {
            visited[v] = true;
            foreach (int  i  in G.Adj(v))
            {
                if (!visited[i])
                {
                    from[i] = v; // 表示i点从v点来
                    dfs(i);
                }
            }
        }
    }
}
