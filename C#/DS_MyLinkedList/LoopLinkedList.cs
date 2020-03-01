using System;
using System.Collections.Generic;
using System.Text;

namespace DS_MyLinkedList
{
    /// <summary>
    /// 循环链表 和 双向链表
    /// </summary>
    /// <typeparam name="T"></typeparam>
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

        private Node dummyHead;
        //private Node  tail;
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

            //空链表 和 链表尾情况
            if (prev.next == null || prev.next == dummyHead)
            {
                dummyHead.prev = temp;
                temp.next = dummyHead;
                temp.prev = prev;
                prev.next = temp;
               // tail = temp;
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
        // O(1) 复杂度
        public void AddLast2(T val)
        {
            Node temp = new Node(val, null, null);

            if (dummyHead.prev == null) //空链表
            {
                dummyHead.prev = temp;
                temp.next = dummyHead;
                temp.prev = dummyHead;
                dummyHead.next = temp;
            }
            else
            {
                Node tail = dummyHead.prev;
                temp.next = dummyHead;
                temp.prev = tail;

                tail.next = temp;
                dummyHead.prev = temp;
            }
            size++;

        }
        public T Get(int index)
        {
            if (index < 0 || index >= size )
            {
                throw new Exception("Get Failed. Illegal index.");
            }
            Node cur = dummyHead.next;
            for (int i = 0; i< index; i++)
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

        public T Remove(int index)
        {
            if (index < 0 || index >= size)
            {
                throw new Exception("Remove Failed. Illegal index.");
            }
            Node prev = dummyHead;
            for (int i = 0; i < index; i++)
            {
                prev = prev.next;
            }

            Node delNode = prev.next;
            T ret = delNode.e;

            if (delNode.next == dummyHead) // 链表尾
            {
                prev.next = dummyHead;
                dummyHead.prev = prev;
            }
            else
            {
                prev.next = prev.next.next;
                prev.next.next.prev = prev;
            }
            // delete node
            delNode.next = null;
            delNode.prev = null;
            size--;
            return ret;
        }
        public T RemoveFirst()
        {
            return Remove(0);
        }
        public T RemoveLast()
        {
            return Remove(size - 1);
        }
        public T RemoveLast2()
        {
            if (IsEmpty())
            {
                throw new Exception("Remove Failed. LoopLinkedlist is empty.");
            }

            Node prev = dummyHead.prev.prev;
            Node tail = dummyHead.prev;
            Node ret = prev.next;

            prev.next = dummyHead;
            dummyHead.prev = prev;

            tail.next = null;
            tail.prev = null;
            size--;

            return ret.e;
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
