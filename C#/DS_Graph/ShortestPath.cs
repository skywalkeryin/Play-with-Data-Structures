using System;
using System.Collections.Generic;
using System.Text;

namespace DS_Graph
{
    // 广度优先遍历
    // 求无向图最短的路径
    public class ShortestPath
    {
        private IGraph g;
        private int s; // 起始点
        bool[] visted; //标记定点是否被访问过
        int[] from; // 记录路径, from[i]表示查找的路径上i的上一个节点
        int[] ord; // 记录路径节点的次序


        public ShortestPath(IGraph g, int s)
        {
            this.g = g;
            this.s = s;

            if (s < 0 && s >= g.V())
            {
                throw new Exception("s is illegal");
            }

            this.visted = new bool[g.V()];

            this.from = new int[g.V()];
            this.ord = new int[g.V()];
            for (int i = 0; i < g.V(); i++)
            {
                from[i] = -1;
                ord[i] = -1;
            }

            // 无向图的最短路径算法
            Queue<int> queue = new Queue<int>();

            queue.Enqueue(s);
            visted[s] = true;
            ord[s] = 0;

            while (queue.Count > 0)
            {
                int i = queue.Dequeue();

                foreach (var j in g.Adj(i))
                {
                    if (!visted[j])
                    {
                        queue.Enqueue(j);
                        visted[j] = true;
                        from[j] = i;
                        ord[j] = ord[i] + 1;
                    }
                    
                }
            }
        }

        // 查询s与w之间是否有路径
        public bool HasPath(int w)
        {
            if (w < 0 || w >= g.V())
            {
                throw new Exception("Ilegal vertex");
            }
            return visted[w];
        }

        // 返回s与顶点w之间的路径
        public List<int> Path(int w)
        {
            if (!HasPath(w))
            {
                throw new Exception("There is no path.");
            }

            Stack<int> stack = new Stack<int>();

            int p = w;
            while (p != -1) //from[s] = -1;
            {
                stack.Push(p);
                p = from[p];
            }

            // 从栈中依次取出顶点
            List<int> path = new List<int>();
            while (stack.Count > 0)
            {
                path.Add(stack.Pop());
            }
            return path;
        }


        public void ShowPath(int w)
        {
            if (w < 0 || w >= g.V())
            {
                throw new Exception("Ilegal vertex");
            }

            List<int> path = Path(w);
            for (int i = 0; i < path.Count; i++)
            {
                Console.Write(path[i]);
                if (i != path.Count)
                {
                    Console.Write(" -> ");
                }
                else
                {
                    Console.Write("\n");
                }
            }
        }

        // 从 s到w 的长度
        public int Length(int w)
        {
            return ord[w];
        }

    }
}
