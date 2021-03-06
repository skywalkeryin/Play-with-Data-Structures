﻿using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace DS_BST
{
    public class BST<T> where T : IComparable<T>
    {
        public class Node {
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
            this.root = null;
        }

        public bool IsEmpty()
        {
            return size == 0;
        }
        public int GetSize()
        {
            return size;
        }

        public void Add(T e)
        {
           root = Add(root, e);
        }

        // 向以node为根的二分搜索树中插入元素e， 递归算法
        // 返回插入新节点后二分搜索树的根
        private Node Add(Node node , T e)
        {
            if (node == null)
            {
                node = new Node(e);
                size++;
                return node;
            }

            if (node.e.CompareTo(e) > 0)
            {
                node.left = Add(node.left, e);
            }
            else if(node.e.CompareTo(e) < 0)
            {
                node.right = Add(node.right, e);
            }

            return node;
        }

        public bool Contains(T e)
        {
            return Contains(root, e);
        }

        private bool Contains(Node node, T e)
        {
            if (node == null)
            {
                return false;
            }
            if (node.e.CompareTo(e) == 0)
            {
                return true;
            }
            else if (node.e.CompareTo(e) < 0)
            {
                return Contains(node.left, e);
            }
            else //  (node.e.CompareTo(e) > 0)
            {
                return Contains(node.right, e);
            }
        }

        public void PreOrder()
        {
            PreOrder(root);
        }
        private void PreOrder(Node node)
        {
            if (node == null)
            {
                return;
            }
            Console.WriteLine(node.e);
            PreOrder(node.left); 

            PreOrder(node.right);
        }
        public void PreOrderNR()
        {
            Stack<Node> stack = new Stack<Node>();
            stack.Push(root);
            while (stack.Count != 0)
            {
                Node cur = stack.Pop();

                Console.WriteLine(cur.e);
                if (cur.right != null)
                {
                    stack.Push(cur.right);
                }
                if (cur.left != null)
                {
                    stack.Push(cur.left);
                }
            }
        }

        // 中序遍历
        public void InOrder()
        {
            InOrder(root);
        }
        private void InOrder(Node node)
        {
            if (node == null)
            {
                return;
            }
            InOrder(node.left);
            Console.WriteLine(node.e);

            InOrder(node.right);
        }

        public void InOrderNR()
        {
            if (IsEmpty())
            {
                return;
            }
            Stack<Node> stack = new Stack<Node>();

            // 把所有的左子树推入栈中
            PushLeftNode(stack, root);
            ////stack.Push(cur);
            //while (cur != null)
            //{
            //    stack.Push(cur);
            //    cur = cur.left;
            //}

            Node cur = stack.Pop();
            Console.WriteLine(cur.e);

            while (stack.Count != 0)
            {
                cur = stack.Pop();
                Console.WriteLine(cur.e);
                if (cur.right != null)
                {
                    PushLeftNode(stack, cur.right);
                }
            }
        }
        // 把这个节点所有的左子树推入栈中
        private void PushLeftNode(Stack<Node> stack, Node cur)
        {
            while (cur != null)
            {
                stack.Push(cur);
                cur = cur.left;
            }
        }

        // 后序遍历
        public void PostOrder()
        {
            PostOrder(root);
        }
        private void PostOrder(Node node)
        {
            if (node == null)
            {
                return;
            }
            PostOrder(node.left);
            PostOrder(node.right);

            Console.WriteLine(node.e);

        }

        public T minimum()
        {
            if(size == 0)
            {
                throw new Exception("BST is empty");
            }

            return minimum(root).e;
        }

        public Node minimum(Node node)
        {
            if (node.left == null)
            {
                return node;
            }
            return minimum(node.left);
        }

        public T maximum()
        {
            if (size == 0)
            {
                throw new Exception("BST is empty");
            }

            return maximum(root).e;
        }
        private Node maximum(Node node) {
            if (node.right == null)
            {
                return node;
            }
            return maximum(node.right);
                          
        }

        public T RemoveMin()
        {
            T ret = minimum();
            root = RemoveMin(root);
            return ret;
        }

        // 
        private Node RemoveMin(Node node)
        {
            if (node.left == null)
            {
                Node rightNode = node.right;
                node.right = null;
                size--;
                return rightNode;
            }
            node.left = RemoveMin(node.left);
            return node;
        }

        public T RemoveMax()
        {
            T ret = maximum();
            root = RemoveMax(root);
            return ret;
        }


        // 删除以node为根的二分搜索树的最大值
        // 返回删除节点后的二分搜索树的根
        private Node RemoveMax(Node node)
        {
            if(node.right == null)
            {
                Node leftNode = node.left;
                node.left = null;
                size--;
                return leftNode;
            }
            node.right = RemoveMax(node.right);
            return node;
        }


        public void Remove(T e)
        {
            root = Remove(root, e);
        }

        private Node Remove(Node node, T e)
        {
            if(node == null)
            {
                return null;
            }
            if (node.e.CompareTo(e) < 0)
            {
                 node.right = Remove(node.right, e);
                return node;
            }
            else if (node.e.CompareTo(e) > 0)
            {
                node.left = Remove(node.left, e);
                return node;
            }
            else
            {
                if (node.left == null)  // 待删除节点左子树为空的情况
                {
                    Node retNode = node.right;
                    node.right = null;
                    size--;
                    return retNode;
                }
                else if (node.right == null) // 待删除节点右子树为空的情况
                {
                    Node retNode = node.left;
                    node.left = null;
                    size--;
                    return retNode;
                }
                else
                {
                    // 待删除节点左右子树均不为空
                    // 找到比待删除节点大的最小节点， 即待删除节点右子树的最小节点
                    // 用该节点来代替待删除节点
                    //Node successor = minimum(node.right);

                    //successor.right = RemoveMin(node.right);
                    //successor.left = node.left;
                    //node.left = node.right = null;

                    //return successor;

                    Node predecessor = maximum(node.left);
                    
                    predecessor.left =  RemoveMax(node.left);
                    predecessor.right = node.right;
                    node.right = node.left = null;
                    
                    return predecessor;
                }

                
            }
        }

        public T Floor(T e)
        {
            Node retNode = floor(root, e);
            if (retNode != null)
            {
                return retNode.e;
            }
            else
            {
                return default(T);
            }
        }

        private Node floor(Node node, T e)
        {    
            if (node == null)
            {
                return null;
            }

            if (node.e.CompareTo(e) == 0)
            {
                return node;
            }
            else if (node.e.CompareTo(e) > 0 )  
            {
               return floor(node.left, e);
            }

            Node right = floor(node.right, e);

            if (right == null)
            {
                return node;
            }
            else
            {
                return right;
            }

        }

        public T Ceil(T e)
        {
            Node retNode = ceil(root, e);
            if (retNode != null)
            {
                return retNode.e;
            }
            return default(T);
        }

        private Node ceil(Node node, T e)
        {
            if (node == null)
            {
                return node;
            }
            if (node.e.CompareTo(e) > 0)
            {
                return ceil(node.right, e);
            }

            Node left = ceil(node.left, e);
            if (left == null)
            {
                return node;
            }
            else
            {
                return left;
            }

        }
        

        public string GenerateBSTString()
        {
            StringBuilder sb = new StringBuilder();
            GenerateBSTString(root, 0, sb);
            return sb.ToString();
        }

        private void GenerateBSTString(Node node, int depth, StringBuilder sb)
        {         
            if (node == null)
            {
                sb.Append(GenerateDepthString(depth) + "NUll\n");
                return;
            }

            sb.Append(GenerateDepthString(depth) + node.e + "\n");
            GenerateBSTString(node.right, depth + 1,sb);
            GenerateBSTString(node.left, depth + 1, sb);
        }

        private string GenerateDepthString(int depth)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i<depth; i++)
            {
                sb.Append("--");
            }
            return sb.ToString();
        }
    }
}
