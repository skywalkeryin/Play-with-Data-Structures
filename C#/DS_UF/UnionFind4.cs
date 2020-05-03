using System;
using System.Collections.Generic;
using System.Text;

namespace DS_UF
{
    // 第四版并查集， 虽然仍然使用数组， 但是形成了一个树的结构。rank优化
    public class UnionFind4 : IUnionFind
    {
        // parent数组， 用来存放第i元素所指向的元素索引
        private int[] parent;
        private int[] rank;  // 用来存储一i为根的树的高度

        public UnionFind4(int size)
        {
            parent = new int[size];
            for (int i = 0; i < parent.Length; i++)
            {
                parent[i] = i;
            }

            rank = new int[size];
            for (int i = 0; i < rank.Length; i++)
            {
                rank[i] = 1;
            }
        }


        public int GetSize()
        {
            return parent.Length;
        }

        public int Find(int p)
        {
            if (p < 0 && p >= parent.Length)
            {
                throw new Exception("p is out of the bound.");
            }
            while (p != parent[p])
            {
                p = parent[p];
            }

            return p;
        }

        public bool IsConnected(int p, int q)
        {
            int proot = Find(p);
            int qroot = Find(q);
            return proot == qroot;
        }

        public void UnitElement(int p, int q)
        {
            int proot = Find(p);
            int qroot = Find(q);
            if (proot == qroot)
            {
                return;
            }

            if (rank[proot] < rank[qroot])
            {
                parent[proot] = qroot;

            }
            else if(rank[proot] > rank[qroot])
            {
                parent[qroot] = proot;
            }
            else // rank[qroot] == rank[proot], 此时要维护rank值， 加1
            {
                parent[qroot] = proot;
                rank[proot] += 1;
            }
        }
    }
}
