using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DS_Graph.WeightedGraph
{
    public class LazyPrimeMST<Weight> where Weight :struct, IComparable<Weight>
    {
        private IWeightedGraph<Weight> g;
        private bool[] marked;

        private MinHeap<Edge<Weight>> ipq;
        private List<Edge<Weight>> path;
        private Weight wt;

        public LazyPrimeMST(IWeightedGraph<Weight> graph)
        {
            this.g = graph;
            this.marked = new bool[graph.V()];
            this.ipq = new MinHeap<Edge<Weight>>(graph.E()); // 边的个数
            this.path = new List<Edge<Weight>>();

            //Lazy prime算法
            visit(0); //从0开始遍历

            while (!ipq.IsEmpty()) 
            {
                Edge<Weight> minEdge = ipq.ExtractMin();

                // 如果两个点在同一分区， 则边不符合跨区
                if (marked[minEdge.V()] == marked[minEdge.W()])
                {
                    continue;
                }
                // 把符合的边加入到最小生成树MST
                path.Add(minEdge);

                if (!marked[minEdge.V()])
                {
                    visit(minEdge.V());
                }
                else
                {
                    visit(minEdge.W());
                }
            }

            dynamic wt = default(Weight);
            for (int i =0; i < path.Count; i++ )
            {
                wt += path[i].Wt();
            }
            this.wt = (Weight)wt;

        }
        public List<Edge<Weight>> MstEdges()
        {
            return path;
        }

        private void visit(int i)
        {
            if (i<0 || i> g.V())
            {
                throw new Exception("Illegal i.");
            }
            if (marked[i])
            {
                return;
            }

            marked[i] = true;

            // 将和节点i相连接的所有未访问的边放入最小堆中
            foreach (var edge in g.Adj(i))
            {
                if (!marked[edge.Other(i)])
                {
                    ipq.Add(edge);
                }
            }
        }

        
    }
}
