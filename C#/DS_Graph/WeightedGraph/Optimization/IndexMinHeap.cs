using System;
using System.Collections.Generic;
using System.Text;

namespace DS_Graph.WeightedGraph.Optimization
{
    public class IndexMinHeap<T> where T : IComparable<T>
    {
        private T[] data;  // 最小索引堆中的数据
        private int[] inxs;  // 最小索引堆中的索引, indexes[x] = i 表示索引i在x的位置
        private int[] revs;  // 最小索引堆中的反向索引, reverse[i] = x 表示索引i在x的位置
        private int count;
        private int capacity;

        public IndexMinHeap(int capacity)
        {
            this.count = 0;
            this.capacity = capacity;
            data = new T[capacity];
            inxs = new int[capacity];
            revs = new int[capacity];

            for (int i = 0; i < capacity; i++)
            {
                revs[i] = -1;
            }
        }

        public bool IsEmpty()
        {
            return count == 0;
        }

        // 获取索引为i的数据
        public T Get(int i)
        {
            if (!contaionIndex(i))
            {
                throw new Exception("Ilegal Index");
            }
            return data[i];
        }
        // 向最小索引堆插入一个元素， 索引为i， 元素为e
        public void Add(int i, T e)
        {
            if (count + 1 > this.capacity)
            {
                throw new Exception("Not enough space.");
            }

            if (contaionIndex(i))
            {
                return;
            }

            data[i] = e;

            inxs[count] = i;
            revs[i] = count;

            count++;

            shiftUp(count-1);
        }

        //更新 index i位置的数据
        public void Update(int i, T e)
        {
            if (!contaionIndex(i))
            {
                return;
            }

            data[i] = e;

            int heapInx = revs[i];

            shiftUp(heapInx);
            shiftDown(heapInx);
        }

        public int GetMinIndex()
        {
            if (!IsEmpty())
            {
                return inxs[0];
            }
            return -1;
        }

        public  T FindMin()
        {
            if (IsEmpty())
            {
                throw new Exception("The heap is empty.");
            }

            T rel = data[inxs[0]];
            return rel;
        }

        public T ExtractMin()
        {
            T rel = FindMin();

            swapIndexs(0, count-1);

            data[inxs[count-1]] = default(T);
            revs[inxs[count-1]] = -1;

            count--;

            shiftDown(0);

            return rel;
        }

        // 辅助函数
        private void shiftUp(int i)
        {
            while (i > 0 && data[inxs[(i-1) / 2]].CompareTo(data[inxs[i]]) > 0 )
            {

                swapIndexs((i - 1) / 2, i);

                i = (i - 1) / 2;
            }
        }

        private void shiftDown(int i)
        {
            while (i * 2 + 1 < count)
            {
                int j = i * 2 + 1;
                if(j + 1 < count && data[inxs[j+ 1]].CompareTo(data[inxs[j]]) < 0 )
                {
                    j = j + 1;
                }
                if (data[inxs[j]].CompareTo(data[inxs[i]]) < 0)
                {
                    swapIndexs(i, j);

                    i = j;
                }
                else
                {
                    break;
                }
            }
        }

        // 交换索引堆中 位置i和j
        // 改变了索引堆，相应的也要改变反向堆
        private void swapIndexs(int i, int j)
        {
            int temp = inxs[i];
            inxs[i] = inxs[j];
            inxs[j] = temp;

            revs[inxs[i]] = i;
            revs[inxs[j]] = j;
        }

        // check data of this index if exist
        private bool contaionIndex(int i)
        {
            if (i < 0  || i >= capacity)
            {
                throw new Exception("Illegal index.");
            }
            return revs[i] != -1;
        }


            
    }
}
