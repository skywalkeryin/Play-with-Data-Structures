using DS_MyArray;
using System;
using System.Collections.Generic;
using System.Text;

namespace DS_Heap
{
    public class MaxHeap<T> where  T : IComparable<T>
    {
        private MyArray2<T> data;

        public MaxHeap(int capacity)
        {
            data = new MyArray2<T>(capacity);
        }

        public MaxHeap(T[] arr)
        {
            data = new MyArray2<T>(arr);

            //heapify
            for (int i = parent(data.GetSize() - 1); i >= 0; i--)
            {
                siftDown(i);
            }
        }


        public MaxHeap() : this(20)
        {
                
        }


        public int GetSize()
        {
            return data.GetSize();
        }

        public bool IsEmpty()
        {
            return data.IsEmpty();
        }

        // 返回完全二叉树的数组中， 一个索引所表示的元素的父亲节点的索引
        private int parent(int index)
        {
            if (index <= 0)
            {
                throw new Exception("Illegal index");
            }

            return (index - 1) / 2;
        }

        private int leftChild(int index)
        {
            return index * 2 + 1;
        }
        
        private int rightChild(int index)
        {
            return index * 2 + 2;
        }


        public void Add(T e)
        {
            data.AddLast(e);
            siftUp(data.GetSize() - 1);
        }
        // siftUp 操作
        private void siftUp(int index)
        {
            while (index>0 &&  data.Get(index).CompareTo(data.Get(parent(index))) > 0)
            {
                data.Swap(index, parent(index));
                index = parent(index);
            }
        }


        public T FindMax()
        {
            if (data.GetSize() == 0)
            {
                throw new Exception("The heap is empty. Cannot find the max.");
            }
            return data.Get(0);
        }
        
        public T ExtractMax()
        {
            T ret = FindMax();

            data.Swap(0, data.GetSize() - 1);
            data.RemoveLast();  // remove
            siftDown(0);

            return ret;
        }


        private void siftDown(int index)
        {
            while (leftChild(index)  < data.GetSize())
            {
                int k = leftChild(index);

                // k+1 表示右孩子的index 等同于rightChild
                // 下面表示右孩子存在， 并且比左孩子要大
                if (k + 1 < data.GetSize() && data.Get(k).CompareTo(data.Get(rightChild(index))) < 0)
                {
                    k = rightChild(index);
                }
                // 此时， k为子孩子中的最大值

                if (data.Get(k).CompareTo(data.Get(index)) > 0)
                {
                    data.Swap(k, index);
                }
                else
                {
                    break;
                }
                index = k;
            }
        }
    }
}
