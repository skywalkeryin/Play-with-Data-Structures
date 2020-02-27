using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace DS_BST
{
    public class BST<T> where T : IComparable<T>
    {
        private class Node {
            public T e;
            public Node left;
            public Node right;

            public Node()
            {

            }
            public Node(T e)
            {
                this.e = e;
                this.left = null;
                this.right = null;
            }
        }

        private Node root;
        private int size;


        public BST()
        {
            this.size = 0;
            this.root = new Node();
        }

        public bool IsEmpty()
        {
            return size == 0;
        }
        public int GetSize()
        {
            return size;
        }
    }
}
