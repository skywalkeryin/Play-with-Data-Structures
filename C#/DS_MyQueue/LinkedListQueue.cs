using System;
using System.Collections.Generic;
using System.Text;

namespace DS_MyQueue
{
    public class LinkedListQueue<T> : IQueue<T>
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

            public Node(T e) : this(e, null)
            {

            }
            public Node() : this(default(T), null)
            {

            }
            public override string ToString()
            {
                return e.ToString();
            }
        }

        private Node head, tail;
        private int size;

        public LinkedListQueue()
        {
            head = null;
            tail = null;
            size = 0;
        }
        public T Dequeue()
        {
            if (IsEmpty())
            {
                throw new Exception("Dequeue failed. The queue is empty.");
            }
            Node retNode = head;
            head = head.next;
            retNode.next = null;
            if (head == null)
            {
                tail = null;
            }
            size--;
            return retNode.e;
        }

        public void Enqueue(T e)
        {
            if (IsEmpty()) //  equals to tail == null
            {
                tail = new Node(e);
                head = tail;
            }
            else
            {
                tail.next = new Node(e);
                tail = tail.next;
            }
            size++;
        }

        public T[] GetData()
        {
            throw new NotImplementedException();
        }

        public T GetFront()
        {
            if (IsEmpty())
            {
                throw new Exception("Dequeue failed. The queue is empty.");
            }
            return head.e;
        }

        public int GetSize()
        {
            return size;
        }

        public bool IsEmpty()
        {
            return size == 0;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Queue: ");
            sb.Append("front");
            Node cur = head;
            while (cur != null)
            {
                sb.Append(cur.e);
                sb.Append("->");
                cur = cur.next;
            }
            sb.Append("null tail");
            return sb.ToString();
        }
    }
}
