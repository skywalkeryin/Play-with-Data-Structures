using System;
using System.Collections.Generic;
using System.Text;

namespace DS_MyLinkedList
{
    public class LoopLinkedList<T>
    {
        private class Node
        {
            public T e;
            public Node next, prev;

            public Node()
            {
                    
            }
            public Node(T val)
            {
                this.e = val;
            }
            public Node(T val , Node prev, Node next)
            {
                this.e = val;
                this.prev = prev;
                this.next = next;
            }

            public override string ToString()
            {
                return this.e.ToString();
            }
        }

        private Node dummyHead, tail;
        private int size;

        public LoopLinkedList()
        {
            this.size = 0;
            this.dummyHead = new Node();
            //this.tail = new Node();
            //dummyHead.prev = tail;
            //dummyHead.next = tail;
            //tail.next = dummyHead;
            //tail.prev = dummyHead;
        }
        public int GetSize()
        {
            return size;
        }
        public bool IsEmpty()
        {
            return size == 0;
        }
        public void Add(int index, T val)
        {
            if (index < 0 || index > size)
            {
                throw new Exception("Illeagel Argument");
            }
            Node temp = new Node(val, null, null);
            Node prev = dummyHead;
            
            for (int i = 0; i < index; i++)
            {
                prev = prev.next;
            }

            if (prev.next == null || prev.next == dummyHead)
            {
                dummyHead.prev = temp;
                temp.next = dummyHead;
                temp.prev = prev;
                prev.next = temp;
                tail = temp;
            }
            else
            {
                prev.next.prev = temp;
                temp.next = prev.next;
                temp.prev = prev;
                prev.next = temp;
            }

            ////添加元素
            //int dummyHeadCode = dummyHead.GetHashCode();
            //int prevCode = prev.GetHashCode();
            //prev.next.prev = temp;
            //temp.next = prev.next;
            //temp.prev = prev;
            //prev.next = temp;

            ////链表尾
            //if (temp.next == null || temp.next == dummyHead)
            //{
            //    temp.next = dummyHead;
            //    dummyHead.prev = temp;
            //    tail = temp;
            //}

            //if (prev.next == dummyHead)  //链表尾
            //{
            //    dummyHead.prev = temp;
            //    temp.next = dummyHead;
            //    prev.next = temp;
            //    temp.prev = prev;
            //    tail = temp;
            //}
            //else
            //{
            //    prev.next.prev = temp;
            //    temp.next = prev.next;
            //    temp.prev = prev;
            //    prev.next = temp;
            //}
            size++;
        }


        public void AddFirst(T val)
        {
            Add(0, val);
        }

        public void AddLast(T val)
        {
            Add(size, val);
        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("LoopLinkedList: ");
            Node cur = dummyHead.next;

            // 不是链表尾
            while (cur != null && cur != dummyHead)
            {
                sb.Append(cur + "->");
                cur = cur.next;
            }
            //if (cur != null)   // null looplinkedlist
            //{
            //    while (true)
            //    {
            //        if (cur == dummyHead)
            //        {
            //            break;
            //        }
            //        sb.Append(cur + "->");
            //        cur = cur.next;
            //    }
            //}
            sb.Append("null");
            return sb.ToString();
        }
    }
}
