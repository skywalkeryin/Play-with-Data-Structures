using System;
using System.Collections.Generic;
using System.Text;

namespace DS_BST
{
    public  class BST2<T> where T : IComparable<T>
    {

        public class Node 
        {

            public T e;
            public Node left;
            public Node right;
            public int size;
            public int depth;

            public Node()
            {
                e = default(T);
                left = null;
                right = null;
                size = 0;
                depth = 0;
            }

            public Node(T e)
            {
                this.e = e;
                left = null;
                right = null;
                size = 1;
                depth = 0;
            }

            public override string ToString()
            {
                return $"[E is {e}, size is {size}, depth is {depth}]";
            }

        }

        private Node root;
        private int size;

        public BST2()
        {
            this.root = null;
            this.size = 0;
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
            root = Add(root, e, 0);
        }

        // 添加新元素到以node为根的二叉树
        // 返回新的二叉树
        private Node Add(Node node, T e, int depth)
        {
            //int depth = 0;

            if (node == null)
            {
                node = new Node(e);
                node.depth = depth;

                size++;
                return node;
            }

            if (e.CompareTo(node.e) > 0)
            {
                //depth++;
                node.right = Add(node.right, e, depth+1);
                node.size++;
            }
            else
            {
                //depth++;
                node.left = Add(node.left, e, depth + 1);
                node.size++;
            }

            return node;
        }

        public bool Contains(T e)
        {
            return Contains(root, e);
        }


        private bool Contains(Node node, T e)
        {
            //if (IsEmpty())
            //{
            //    throw new Exception("The bst is empty");
            //}

            if (node == null)
            {
                return false;
            }

            if (e.CompareTo(node.e) == 0)
            {
                return true;
            }

            else if(e.CompareTo(node.e) > 0){
                return Contains(node.right, e);
            }
            else  //  (node.e.CompareTo(e) > 0)
            {
                return Contains(node.left, e);
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

        public T RemoveMax()
        {
             T e = maximum(root);

            root = RemoveMax(root);
             
            return e;
        }

        private Node RemoveMax(Node node)
        {
            //if (node == null)
            //{
            //    return node;
            //}
            node.size--;

            if (node.right == null)
            {
                Node leftNode = node.left;

                if (leftNode != null)
                {
                    leftNode.depth--;
                }

                node.left = null;              
                size--;

                return leftNode;
            }
            node.right = RemoveMax(node.right);
            return node;
        }

        private T maximum(Node node)
        {
            if (IsEmpty())
            {
                throw new Exception("BST is empty.");
            }
            if(node.right ==null)
            {
                return node.e;
            }
            return maximum(node.left);
        }

        public T RemoveMin()
        {
            Node retNode = minimum(root);
            root = RemoveMin(root);
            return retNode.e;
        }

        private Node minimum(Node node)
        {
            if (IsEmpty())
            {
                throw new Exception("The BST is empty.");
            }

            if (node.left == null)
            {
                return node;
            }

            return minimum(node.left);
        }

        private Node RemoveMin(Node node)
        {
            if (node == null)
            {
                return node;
            }

            node.size--; // 每一个在这一路径上的node， size都要减一
            if (node.left == null)
            {
                Node rightNode = node.right;
                if (rightNode != null)
                {
                    rightNode.depth--;
                }

                node.right = null;
                size--;

                return rightNode;
            }

            node.left = RemoveMin(node.left);
            return node;
        }

        public void Remove(T e)
        {
            root = Remove(root, e);
        }


        // 删除以node为根的二叉树的元素e
        // 返回删除后二叉树的根
        public Node Remove(Node node, T e)
        {
            if (node == null)
            {
                return node;
            }

            // 没有元素e的话，什么也不做。 
            // 避免执行 node.size--，导致每个节点的size错误
            if (!Contains(e))
            {
                return node;
            }

            node.size--; // 每一个在这一路径上的node， size都要减一

            if (e.CompareTo(node.e) > 0)
            {
                node.right = Remove(node.right, e);
                return node;
            }
            else if (e.CompareTo(node.e) < 0)
            {
                node.left = Remove(node.left, e);
                return node;
            }
            else // e.CompareTo(node.e) == 0
            {
                if (node.left == null)
                {
                    Node rightNode = node.right;

                    if (rightNode != null)
                    {
                        rightNode.depth--;
                    }
                    node.right = null;
                    size--;
                    return rightNode;
                }
                else if (node.right == null)
                {
                    Node leftNode = node.left;
                    if (leftNode != null)
                    {
                        leftNode.depth--;
                    }
                    node.left = null;
                    size--;
                    return leftNode;
                }
                else  // node.left != null && node.right != null
                {
                    Node successor = minimum(node.right);
                    successor.depth = node.depth;

                    successor.right =  RemoveMin(node.right);
                    successor.left = node.left;

                    node.right = null;
                    node.left = null;

                    return successor;
                }
            }
        }

        // 看这个数据是当前所有数据的第几名
        public int Rank(T e)
        {
            if (IsEmpty())
            {
                throw new Exception("The BST is empty");
            }
            if (!Contains(e))
            {
                throw new Exception("There is no this element.");
            }

            return Rank(root, e);
        }

        private int Rank(Node node, T e)
        {
            if (e.CompareTo(node.e) == 0)
            {
                return getNodeLeftSize(node) + 1; //加上自己
            }
            else if (e.CompareTo(node.e) > 0)
            {
                return getNodeLeftSize(node) + 1 + Rank(node.right, e);
            }
            else //if (e.CompareTo(node.e) < 0)
            {
                return Rank(node.left, e);
            }
        }

        // 选择特定名次 的数据
        public T Select(int index)
        {
            if (IsEmpty())
            {
                throw new Exception("The BST is empty");
            }

            if (index < 0 || index > size)
            {
                throw new Exception("Illegal Index.");
            }

            Node retNode = Select(root, getNodeLeftSize(root) + 1, index);
            return retNode.e;
        }

       
        private Node Select(Node node, int number, int index)
        {
            if (index == number)
            {
                return node;
            }

            else if (index > number)
            {
                return Select(node.right, number + getNodeLeftSize(node.right) + 1, index);
            }
            else  // index < number
            {
                return Select(node.left, number - 1 - getNodeRightSize(node.left), index);
            }
        }

        private int getNodeLeftSize(Node node)
        {
            if (node == null)
            {
                return 0;
            }
            return (node.left != null ? node.left.size : 0);
        }

        private int getNodeRightSize(Node node)
        {
            if(node == null)
            {
                return 0;
            }
            return (node.right != null ? node.right.size : 0); 
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
                sb.Append(GenerateDepthString(depth) + "null" + "\n");
                return;
            }

            sb.Append(GenerateDepthString(depth) + node.ToString() + "\n");
            GenerateBSTString(node.left, depth + 1, sb);
            GenerateBSTString(node.right, depth + 1, sb);
            
        }

        private string GenerateDepthString(int depth)
        {
            string result = "";
            for (int i = 0; i <= depth; i++)
            {
                result += "--";
            }
            return result;
        }
    }
}
