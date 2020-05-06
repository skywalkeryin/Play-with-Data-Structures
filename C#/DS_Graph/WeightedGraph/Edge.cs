﻿using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace DS_Graph.WeightedGraph
{
    public class Edge<Weight> : IComparable<Edge<Weight>> where Weight :IComparable<Weight> 
    {
        private int a, b;  //边的两点
        private Weight weight; // 边的权重

        public Edge(int v, int w, Weight weight)
        {
            this.a = v;
            this.b = w;
            this.weight = weight;
        }

        public Edge(Edge<Weight> edge)
        {
            this.a = edge.a;
            this.b = edge.b;
            this.weight = edge.weight;
        }

        public int V() { return a; }
        public int W() { return b; }
        public Weight Wt() { return weight; }  // 返回权重

        public int Other(int x)
        {
            if (x != a && x != b)
            {
                throw new Exception("Ilegal x");
            }
            return x == a ? a : b;
        }

        public override string ToString()
        {
            return $" {a} - {b}, wight:{weight}";
        }

        public int CompareTo(Edge<Weight> other)
        {
            if (other.Wt().CompareTo(this.weight) > 0)
            {
                return 1;
            }
            else if (other.Wt().CompareTo(this.weight) < 0)
            {
                return -1;
            }
            else
            {
                return 0;
            }
        }
    }
}