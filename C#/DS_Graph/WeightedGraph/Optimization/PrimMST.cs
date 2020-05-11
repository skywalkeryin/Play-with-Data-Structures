using System;
using System.Collections.Generic;
using System.Text;

namespace DS_Graph.WeightedGraph.Optimization
{
    // lazy prim 算法的优化
    public class PrimMST<Weight> where Weight : struct, IComparable<Weight>
    {
        private IWeightedGraph<Weight> g;

        private bool[] marked;  //标记顶点是否被访问过
        private IndexMinHeap<Weight> ipq; // 记录对应每个顶点的最小weight
        List<Edge<Weight>> edgeTo; // 用来记录对应每个顶点的最小边（采用list记录是因为， 一些操作indexminheap没办法完成， 如取某一个顶点的边， 如果该顶点还未加入到堆中， 则不能取， 而list可以返回default值)

        private List<Edge<Weight>> mst;
        private Weight mstWeight;

        public PrimMST(IWeightedGraph<Weight> g)
        {
            this.g = g;
            marked = new bool[g.V()];
            ipq = new IndexMinHeap<Weight>(g.V());

            edgeTo = new List<Edge<Weight>>(g.V());
            for (int i = 0; i < g.V(); i++) 
            {
                edgeTo.Insert(i, null);
            }
            mst = new List<Edge<Weight>>();

            // Prim 算法
            visit(0);
            while (!ipq.IsEmpty())
            {
                // 去除最小的边
                int minV = ipq.GetMinIndex();
                ipq.ExtractMin();

                Edge<Weight> minEdge = edgeTo[minV];

                if (minEdge != null)
                {
                    mst.Add(minEdge);

                    visit(minV);
                }
            }

            dynamic weight = mst[0].Wt();
            for (int i = 1; i < mst.Count; i++ )
            {
                weight += mst[i].Wt();
            }
            this.mstWeight = (Weight)weight;

        }

        public List<Edge<Weight>> MstEdges()
        {
            return mst;
        }

        private void visit(int v)
        {
            if(marked[v])
            {
                return;
            }
            marked[v] = true;

            foreach (var edge in g.Adj(v))
            {
                int w = edge.Other(v);
                //如果另一个断点没有被访问
                if (!marked[w])
                {
                    // 如果没有考虑过这个断点， 则把和这个断点的相连接的边加入索引堆
                    if (edgeTo[w] == null)
                    {
                        edgeTo[w] = edge;
                        ipq.Add(w, edge.Wt());
                    }
                    // 如果曾经考虑这个端点, 但现在的边比之前考虑的边更短, 则进行替换
                    else if (edgeTo[w].Wt().CompareTo(edge.Wt()) > 0)
                    {
                        edgeTo[w] = edge;
                        ipq.Update(w, edge.Wt());
                    }

                }
            }
        }

    }
}
