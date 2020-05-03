using System;
using System.Collections.Generic;
using System.Text;

namespace DS_UF
{
    public class UnionFind1 : IUnionFind
    {
        private int[] id;

        public UnionFind1(int size)
        {
            id = new int[size];
            for (int i = 0; i < id.Length; i++)
            {
                id[i] = i;
            }
        }

        public int Find(int p)
        {
            return id[p];
        }


        // 判断两个元素是否在同一集合
        public bool IsConnected(int p, int q)
        {
            return Find(p) == Find(q);
        }

        // 合并连个元素, o（n）
        public void UnitElement(int p, int q)
        {
            int pid = Find(p);
            int qid = Find(q);

            if (pid == qid) return;

            for (int i = 0; i < id.Length; i++)
            {
                if (id[i] == pid)
                {
                    id[i] = qid;
                }
            }
        }
    }
}
