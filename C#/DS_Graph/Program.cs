using DS_Graph.WeightedGraph;
using System;

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

        }
    }
}
