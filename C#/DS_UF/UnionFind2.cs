using System;
using System.Collections.Generic;
using System.Text;

namespace DS_UF
{
    // 第二版并查集， 虽然仍然使用数组， 但是形成了一个树的结构。
    public class UnionFind2 : IUnionFind
    {
        // parent数组， 用来存放第i元素所指向的元素索引
        private int[] parent;

        public UnionFind2(int size)
        {
            parent = new int[size];
            for (int i = 0; i < parent.Length; i++)
            {
                parent[i] = i;
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

            // 把q的根节点指向p 的根节点来连接
            parent[qroot] = proot;
        }
    }
}
