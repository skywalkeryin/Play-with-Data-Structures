using System;
using System.Collections.Generic;
using System.Text;

namespace DS_Map
{
    public class BSTMap<T, V> : IMap<T, V> where T : IComparable<T>
    {

        private class Node
        {
            public T key;
            public V value;

            public Node left;
            public Node right;

            public Node(T key, V value, Node left, Node right)
            {
                this.key = key;
                this.value = value;
                this.left = left;
                this.right = right;
            }

            public Node(T key, V value) : this(key, value, null, null)
            {

            }

            public Node() : this(default(T), default(V), null, null)
            {

            }

            public override string ToString()
            {
                return $"The key is {this.key}, the value is {this.value}";
            }

        }

        private Node root;
        private int size;
        public BSTMap()
        {
            root = null;
            size = 0;
        }
        public int GetSize()
        {
            return size;
        }
        public bool IsEmpty()
        {
            return size == 0;
        }
        


        private Node GetNode(T key)
        {
            return GetNode(root, key);
        }

        private Node GetNode(Node node, T key)
        {
            if (node == null)
            {
                return node;
            }

            if (key.CompareTo(node.key) == 0)
            {
                return node;
            }
            else if (key.CompareTo(node.key) > 0)
            {
                return GetNode(node.right, key);
            }
            else  // key.CompareTo(node.key) < 0
            {
                return GetNode(node.left, key);
            }
        }

        public void Add(T k, V v)
        {
            root = Add(root, k, v);
        }

        private Node Add(Node node, T key, V value)
        {
            if (node == null)
            {
                size++;
                return new Node(key, value);
            }

            if (key.CompareTo(node.key) > 0)
            {
                node.right = Add(node.right, key, value);         
            }
            else if (key.CompareTo(node.key) < 0)
            {
                node.left = Add(node.left, key, value);
            }
            else
            {
                node.value = value;           
            }
            return node;
        }

        public bool Contains(T k)
        {
            Node node = GetNode(k);
            return node != null;
        }

        public V Get(T k)
        {
            Node node = GetNode(k);
            if (node != null)
            {
                return node.value;
            }
            return default(V);
        }
    
        public V Remove(T k)
        {
            Node node = GetNode(k);
            if (node == null)
            {
                throw new Exception("cannot find the key");
            }
            else
            {
                root = Remove(root, k);
            }
            
            return node.value;
        }

        private Node Remove(Node node, T k)
        {
            if (node == null)
            {
                return node;
            }

            if (k.CompareTo(node.key) > 0)
            {
                node.right = Remove(node.right, k);
                return node;
            }
            else if (k.CompareTo(node.key) < 0)
            {
                node.left = Remove(node.left, k);
                return node;
            }
            else
            {
                if (node.left == null)
                {
                    Node rightNode = node.right;
                    node.right = null;
                    size--;
                    return rightNode;
                }
                if (node.right == null)
                {
                    Node leftNode = node.left;
                    node.left = null;
                    size--;
                    return leftNode;
                }
                else // (node.right != null && node.left != null)
                {
                    Node successor = minimum(node.right);
                    
                    successor.right = RemoveMin(node.right); ;
                    successor.left = node.left;

                    node.left = null;
                    node.right = null;


                    return successor;
                }
            }
        }

        private V RemonveMin()
        {
            Node node = minimum(root);

            root = RemoveMin(root);

            if (node== null)
            {
                return node.value;
            }
            else
            {
                return default(V);
            }
        }
        private Node RemoveMin(Node node)
        {
            if (node == null)
            {
                return node;
            }

            if (node.left != null && node.left.left == null)
            {
                size--;
                return null;
            }

            node.left = RemoveMin(node);
            return node;
        }

        private Node minimum(Node node)
        {
            if (node == null)
            {
                return node;
            }

            if (node.left == null)
            {
                return node;
            }
            return minimum(node.left);
        }

        public void Set(T k, V v)
        {
            Node node = GetNode(k);
            if (node == null)
            {
                throw new Exception("cannot find this key in the map.");
            }
            else
            {
                node.value = v;
            }
        }


       
     
    }
}
