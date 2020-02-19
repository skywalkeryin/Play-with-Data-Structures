using System;
using System.Collections.Generic;
using System.Text;
using DS_MyLinkedList;

namespace DS_MyStack
{
    public class LinkedListStack<T> : IStack<T>
    {
        private MyLinkedList<T> data;

        public LinkedListStack()
        {
            data = new MyLinkedList<T>();
        }
        public int GetSize()
        {
            return data.GetSize();
        }
      
        public bool IsEmpty()
        {
            return data.IsEmpty();
        }

        public void Push(T e)
        {
            data.AddFirst(e);
        }

        public T Peek()
        {
            return data.GetFirst();
        }

        public T Pop()
        {
            return data.RemoveFirst();
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Stack:");
            sb.Append(" [ ");
            for (int i = data.GetSize() - 1; i >= 0; i--)
            {
                sb.Append(data.Get(i));
                if (i != 0)
                {
                    sb.Append(", ");
                }
            }
            sb.Append(" ] TOP");
            return sb.ToString();
        }


    }
}
