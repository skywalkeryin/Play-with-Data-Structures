using DS_MyArray;
using System;
using System.Collections.Generic;
using System.Text;

namespace DS_Heap
{
    public class MaxIndexHeap<T>  where T : IComparable<T>
    {
        private MyArray2<T> data;  // 用来存储数据
        private MyArray2<int> indexs; // 用来存储数据的索引
        private MyArray2<int> revs; // 用来存储索引在indexs堆中的位置
        private int size;

        public MaxIndexHeap()
        {
            data = new MyArray2<T>();
            indexs = new MyArray2<int>();
            revs = new MyArray2<int>();
            size = 0;

            for (int i = 0; i < data.GetCapacity(); i++)
            {
                revs.Add(i, -1);
            }
        }

        public MaxIndexHeap(T[] arr)
        {
            data = new MyArray2<T>();
            indexs = new MyArray2<int>();
            revs = new MyArray2<int>();
            size = 0;


            for (int i = 0; i < arr.Length; i++)
            {
                data.Add(i, arr[i]);
                indexs.Add(i, i);
                revs.Add(i, i);
            }
            for (int i = parent(arr.Length-1); i >= 0; i--)
            {
                shiftDown(i);
            }
        }

        public int GetSize()
        {
            return size;
        }

        public bool IsEmpty()
        {
            return size == 0;
        }

        //看下索引是否在反向堆里有位置
        //因为， 我们们不删除反向堆， 只是把删除的所以赋值为-1
        public bool Contains(int i)
        {
            if (i < 0 )
            {
                throw new Exception("Illegal index");
            }
            return  i < revs.GetSize() && revs.Get(i) != -1;
           
        }

        //向索引堆添加一个元素。
        public void Add(int  i, T e)
        {
            if (Contains(i))
            {
                return;
            }

            //添加数据
            data.AddLast(e);
            size++;

            //添加新数据的索引
            indexs.AddLast(i);

            // 添加新数据索引的位置到反向堆
            if (i < revs.GetSize())
            {
                revs.Set(i, size - 1);
            }
            else
            {
                revs.AddLast(size - 1);
            }
            

            shiftUp(size - 1);
        }

        public T FindMax()
        {
            if (data.GetSize() == 0)
            {
                throw new Exception("The heap is empty. Cannot find the max.");
            }

            T rel = data.Get(indexs.Get(0));
            return rel;
        }

        public T ExtractMax()
        {
            T rel = FindMax();

            //data.Set()
            //data.Remove(indexs.Get(0));

            indexs.Swap(0, size - 1); // 交换index堆的第一个和最后一个元素
         
            //int lastInx = indexs.Remove(indexs.GetSize() - 1);

            revs.Set(indexs.Get(size-1),  -1); // 删除index堆最后一个索引
            revs.Set(indexs.Get(0), 0);

            size--; // 删除元素

            shiftDown(0);
        
            return rel;
        }




        private void shiftUp(int i)
        {
            int resultInx = i; // indexs 的索引
            int dataInx = indexs.Get(i);
            T upValue = data.Get(indexs.Get(i));
            while (i > 0  && data.Get(indexs.Get(parent(i))).CompareTo(upValue) < 0)
            {
                    // 优化：不用每次交换索引
                    indexs.Set(i, indexs.Get(parent(i))); // 把父亲节点赋值给当前节点
                    revs.Set(indexs.Get(parent(i)), i);  //更新parentinx 的位置

                    resultInx = parent(i);
                    i = parent(i);
            }

            indexs.Set(resultInx, dataInx);
            revs.Set(dataInx, resultInx);
        }

        private void shiftDown(int i)
        {
            int resultInx = i;
            int dataInx = indexs.Get(i);
            T downValue = data.Get(dataInx);

            while (leftChild(i) < size)
            {
                int j = leftChild(i);
                // 有右子节点并且右子节点更大
                if (j + 1 < size && data.Get(indexs.Get(j + 1)).CompareTo(data.Get(indexs.Get(j))) > 0)
                {
                    j = j + 1;
                }

                // 如果 value 比最大的字节点的value小
                if (downValue.CompareTo(data.Get(indexs.Get(j))) < 0 )
                {
                    indexs.Set(i, indexs.Get(j));   // 把子节点赋值给父亲节点
                    revs.Set(indexs.Get(j), i);
                    
                    resultInx = j;
                    i = j;
                }
                else
                {
                    break;
                }
            }
            indexs.Set(resultInx, dataInx);
            revs.Set(dataInx, resultInx);
        }

        private int parent(int i )
        {
            return (i - 1) / 2;
        }
        private int leftChild(int i)
        {
            return i * 2 + 1;
        }
        private int rightChild(int i)
        {
            return i * 2 + 2;
        }
    }
}
