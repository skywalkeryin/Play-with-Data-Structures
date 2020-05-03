using System;
using System.Collections.Generic;
using System.Text;

namespace DS_UF
{
    // 第三版并查集， 虽然仍然使用数组， 但是形成了一个树的结构。优化了union操作
    public class UnionFind3 : IUnionFind
    {
        // parent数组， 用来存放第i元素所指向的元素索引
        private int[] parent;
        private int[] sz; //  sz数组 用来存储根为i 的树的节点个数

        public UnionFind3(int size)
        {
            parent = new int[size];
            for (int i = 0; i < parent.Length; i++)
            {
                parent[i] = i;
            }
            sz = new int[size];
            for (int i = 0; i < size; i++)
            {
                sz[i] = 1;
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

            // 优化：合并时， size大的指向size大的树
            if (sz[proot] < sz[qroot])
            {
                parent[proot] = qroot;
                sz[qroot] += sz[proot];
            }
            else
            {
                parent[qroot] = proot;
                sz[proot] += sz[qroot];
            }
        }
    }
}
