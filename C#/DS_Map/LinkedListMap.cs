using System;
using System.Collections.Generic;
using System.Text;

namespace DS_Map
{
    public class LinkedListMap<T, V> : IMap<T, V> 
    {

        private class Node
        {
            public T key;
            public V value;
            public Node next;

            public Node() :  this(default(T), default(V), null)
            {

            }

            public Node(T key, V value) :this(key, value, null)
            {

            }

            public Node(T key, V value, Node node)
            {
                this.key = key;
                this.value = value;
                this.next = node;
            }
        }


        private Node dummyHead;
        private int size;

        public LinkedListMap()
        {
            dummyHead = new Node();
            size = 0;
        }

        public void Add(T key, V value)
        {
            Node node = GetNode(key);

            if (node == null)
            {
                dummyHead.next = new Node(key, value, dummyHead.next);
                size++;
            }
            else
            {
                node.value = value;
            }

        }


        private Node GetNode(T k)
        {
            Node cur = dummyHead.next;
            while (cur != null)
            {
                if (k.Equals(cur.key))
                {
                    return cur;
                }
                cur = cur.next;
            }
            return null;
        }
        public bool Contains(T k)
        {
            return GetNode(k) != null;
        }

        public V Get(T k)
        {
            Node node = GetNode(k);
            return node == null ? default(V) : node.value;
        }

        public int GetSize()
        {
            return size;
        }

        public bool IsEmpty()
        {
            return size == 0;
        }

        public V Remove(T key)
        {
            Node prev = dummyHead;

            while (prev.next != null)
            {
                if (prev.next.key.Equals(key))
                {
                    break;
                }
                prev = prev.next;
            }

            if (prev.next != null) 
            {
                Node delNode = prev.next;
                prev.next = delNode.next;
                delNode.next = null;
                size--;

                return delNode.value;
            }
            return default(V);
        }

        public void Set(T k, V v)
        {
            Node node = GetNode(k);
            if (node == null)
            {
                throw new Exception("can not find this key");
            }
            else
            {
                node.value = v;
            }
        }
    }
}
