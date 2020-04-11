using DS_MyLinkedList;
using System;
using System.Collections.Generic;
using System.Text;

namespace DS_Set
{
    public class LinkedListSet<T> : ISet<T>
    {

        private MyLinkedList<T> list;


        public LinkedListSet()
        {
            list = new MyLinkedList<T>();
        }

        public void Add(T e)
        {
            if(!list.Contains(e)){
                list.AddFirst(e);
            }
        }

        public void Remove(T e)
        {
            list.RemoveElement(e);
        }

        public bool Contains(T e)
        {
            return list.Contains(e);
        }

        public int GetSize()
        {
            return list.GetSize();

        }
        public bool IsEmpty()
        {
            return list.IsEmpty();
        }

        
    }
}
