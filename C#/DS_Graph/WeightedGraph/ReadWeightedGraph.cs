using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace DS_Graph.WeightedGraph
{
    public class ReadWeightedGraph
    {

        public  ReadWeightedGraph(IWeightedGraph<double> graph, string filename)
        {
            string[] lines = File.ReadAllLines(@"G:\Project\Play-with-Data-Structures\C#\DS_Graph\WeightedGraph\" + filename);

            int V = graph.V();

            int E = graph.E();

            for (int i = 1; i < lines.Length; i++)
            {
                int v = Convert.ToInt32(lines[i].Split(' ')[0]);
                int w = Convert.ToInt32(lines[i].Split(' ')[1]);
                double wt = Convert.ToDouble(lines[i].Split(' ')[2]);
                graph.AddEdge(new Edge<double>(v, w, wt));
            }

        }      

    }
}
