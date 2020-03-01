using System;
using System.Collections.Generic;
using System.Text;

namespace DS_MyLinkedList
{
    public class MyLinkedList<T>
    {
        private class Node 
        {
            public T e;
            public Node next;

            public Node(T e, Node node)
            {
                this.e = e;
                this.next = node;
            }

            public Node(T e) :this(e, null)
            {
                
            }
            public Node() :this(default(T), null)
            {

            }
            public override string ToString()
            {
                return e.ToString();
            }
        }

        private Node dummyHead;
        private int size;

        public MyLinkedList()
        {
            dummyHead = new Node();
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

        // 列表中的不常用操作，练习用。。
        public void Add(int index, T e)
        {
            if (index < 0 && index > size )
            {
                throw new Exception("Add failed. Illegal index");
            }
            Node prev = dummyHead;
            for (int i = 0; i < index; i++)
            {
                prev = prev.next;
            }
            prev.next = new Node(e, prev.next);

            //if (index == 0)
            //{
            //    AddFirst(e);
            //}
            //else
            //{
            //    Node prev = head;
            //    for (int i = 0; i < index - 1; i++)
            //    {
            //        prev = prev.next;
            //    }
            //    prev.next = new Node(e, prev.next);
            //}
            size++;
        }
        public void AddFirst(T e)
        {
            //Node node = new Node(e);
            //node.next = head;
            //head = node;

            //head = new Node(e, head.next);
            Add(0, e);
        }
        public void AddLast(T e)
        {
            Add(size, e);
        }

        public void AddRecursive(T e)
        {
            dummyHead.next = AddRecursive(dummyHead.next, e);
        }

        private Node AddRecursive(Node node, T e)
        {
            if (node == null)
            {
                size++;
                return new Node(e);
            }

            node.next = AddRecursive(node.next, e);
            return node;
        }
        public T Get(int index)
        {
            if (index < 0 && index >= size)
            {
                throw new Exception("Get Failed. Illegal index.");
            }
            Node cur = dummyHead.next;
            for (int i = 0; i <index; i++)
            {
                cur = cur.next;
            }
            return cur.e;
        }

        public T GetFirst()
        {
            return Get(0);
        }

        public T GetLast()
        {
            return Get(size - 1);
        }
        public bool Contains(T e)
        {
            Node cur = dummyHead.next;
            while (cur != null)
            {
                if(cur.e.Equals(e))
                {
                    return true;
                }
            }
            return false;
        }
        public T Remove(int index)
        {
            if (index < 0 || index >= size)
            {
                throw new Exception("Remove failed. Illegal index.");
            }
            Node prev = dummyHead;
            for (int i = 0; i < index; i++)
            {
                prev = prev.next;
            }
            Node delNode = prev.next;
            prev.next = delNode.next;
            delNode.next = null;
            size--;
            return delNode.e;
        }

        public T RemoveFirst()
        {
            return Remove(0);
        }
        public T RemoveLast()
        {
            return Remove(size - 1);
        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            Node cur = dummyHead.next;
            while (cur != null)
            {
                sb.Append(cur.e);
                sb.Append("=>");
                cur = cur.next;
            }
            sb.Append("null");
            return sb.ToString();
        }
    }
}
