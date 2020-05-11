using DS_Graph.WeightedGraph;
using DS_Graph.WeightedGraph.Optimization;
using System;
using System.Collections.Generic;

namespace DS_Graph
{
    class Program
    {
        static void Main(string[] args)
        {
            // 使用两种图的储存方式来读取文件
            string fileName = "TextG1.txt";
            SparseGraph graph = new SparseGraph(13, false);
            ReadGraph readGraph = new ReadGraph(graph, fileName);
            Console.WriteLine( "test g1 in sparse graph ");
            graph.Show();

            Console.WriteLine();

            DenseGraph graph1 = new DenseGraph(13, false);
            ReadGraph readGraph1 = new ReadGraph(graph1, fileName);
            Console.WriteLine("test g1 in dense graph ");

            graph1.Show();


            Console.WriteLine("===========================================");

            DenseGraph graph2 = new DenseGraph(13, false);
            ReadGraph readGraph2 = new ReadGraph(graph2, fileName);
            Path path = new Path(graph2, 0);

            Console.WriteLine("test path g1 in dense graph ");

            path.ShowPath(4);


            Console.WriteLine("===========================================");

            WeightedDenseGraph<double> wgraph3 = new WeightedDenseGraph<double>(8, false);
            ReadWeightedGraph readGraph3 = new ReadWeightedGraph(wgraph3, "testG1.txt");

            Console.WriteLine("test  in weighted dense graph ");

            wgraph3.Show();

            Console.WriteLine("===========================================");

            SparseWeightedGraph<double> wgraph4 = new SparseWeightedGraph<double>(8, false);
            ReadWeightedGraph readGraph4 = new ReadWeightedGraph(wgraph4, "testG1.txt");

            Console.WriteLine("test  in weighted sparse graph ");

            wgraph4.Show();

            Console.WriteLine("Test MinHeap");
            int n = 100000;
            MinHeap<int> heap = new MinHeap<int>(n);
            Random rand = new Random();
            for (int i = 0; i < n; i++)
            {
                heap.Add(rand.Next(n));
            }
            List<int> list = new List<int>();
            for (int i = 0; i < n; i++)
            {
                list.Add(heap.ExtractMin());
            }
            for (int i = 0; i < n-1; i++)
            {
                if(list[i] > list[i + 1]){
                    throw new Exception("MinHeap error");
                }
            }


            Console.WriteLine("===========================================");
            Console.WriteLine("Test MST");

            SparseWeightedGraph<double> wgraph5 = new SparseWeightedGraph<double>(8, false);
            ReadWeightedGraph readGraph5 = new ReadWeightedGraph(wgraph5, "testG1.txt");
            LazyPrimeMST<double> mst = new LazyPrimeMST<double>(wgraph5);
            List<Edge<double>> mstPath = mst.MstEdges();

            for (int i =0; i < mstPath.Count; i++)
            {
                Console.WriteLine(mstPath[i]);
            }

            Console.WriteLine("Test Index MinHeap");

            IndexMinHeap<int> heap1 = new IndexMinHeap<int>(n);
            for (int i = 0; i < n; i++)
            {
                heap1.Add(i, rand.Next(n));
            }

            for (int i = 0; i < n / 2; i++)
            {
                heap1.Update(i, rand.Next(n));
            }

            List<int> list1 = new List<int>();
            for (int i = 0; i < n; i++)
            {
                list1.Add(heap1.ExtractMin());
            }

            for (int i = 0; i < n - 1; i++)
            {
                if (list1[i] > list1[i + 1])
                {
                    throw new Exception("IndexMinHeap error");
                }
            }


            Console.WriteLine("===========================================");
            Console.WriteLine("Test MST Optimization");

            SparseWeightedGraph<double> wgraph6 = new SparseWeightedGraph<double>(8, false);
            ReadWeightedGraph readGraph6 = new ReadWeightedGraph(wgraph6, "testG1.txt");
            PrimMST<double> mst1 = new PrimMST<double>(wgraph6);
            List<Edge<double>> mstPath1 = mst1.MstEdges();

            for (int i = 0; i < mstPath1.Count; i++)
            {
                Console.WriteLine(mstPath1[i]);
            }



        }
    }
}
