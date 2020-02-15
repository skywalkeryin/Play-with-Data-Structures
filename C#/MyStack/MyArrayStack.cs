using DS_MyArray;
using System;
using System.Collections.Generic;
using System.Text;

namespace DS_MyStack
{
    public class MyArrayStack<T> : IStack<T>
    {
        private MyArray2<T> array;

        public MyArrayStack()
        {
            array = new MyArray2<T>();
        }

        public MyArrayStack(int Capacity)
        {
            array = new MyArray2<T>(Capacity);
        }

        public int GetSize()
        {
            return array.GetSize();
        }

        public int GetCapacity()
        {
            return array.GetCapacity();
        }

        public bool IsEmpty()
        {
            return array.IsEmpty();
        }

        public void Push(T e)
        {
            array.AddLast(e);
        }

        public T Pop()
        {
            return array.RemoveLast();
        }

        public T Peek()
        {
            return array.GetLast();
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Stack:");
            sb.Append(" [ ");
            for (int i = 0; i < array.GetSize(); i++)
            {
                sb.Append(array.Get(i));
                if(i != array.GetSize() - 1)
                {
                    sb.Append(", ");
                }
            }
            sb.Append(" ] TOP");
            return sb.ToString();
        }
    }
}
