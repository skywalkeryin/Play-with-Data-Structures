using System;
using System.Collections.Generic;
using System.Text;

namespace DS_Graph.WeightedGraph
{
    public class MinHeap<T> where T : IComparable<T>
    {
        private T[] data;
        private int count;
        private int capacity;

        public MinHeap(int capacity)
        {
            this.data = new T[capacity];
            this.count = 0;
            this.capacity = capacity;
        }

        //heapify
        public MinHeap(T[] arr)
        {
            data = new T[arr.Length];
            this.count = arr.Length;
            this.capacity = arr.Length;
            for (int i =0; i < arr.Length; i++)
            {
                data[i] = arr[i];    
            }

            for (int i = (count-1-1)/2; i>=0; i--)
            {
                shiftDown(i);
            }
        }

        public bool IsEmpty()
        {
            return count == 0;
        }

        public void Add(T e)
        {
            if (count + 1 > capacity)
            {
                throw new Exception("Not enough space.");
            }
            // addLast

            data[count] = e;
            count++;

            shiftUp(count-1);
        }

        public T ExtractMin()
        {
            T rel = findMax();

            swap(data, 0, count - 1);
            data[count - 1] = default(T);
            count--;

            shiftDown(0);
            

            return rel;
        }

        private T findMax()
        {
            return data[0];
        }

        private void shiftUp(int i)
        {
            while(i > 0  && data[(i - 1) / 2].CompareTo(data[i]) > 0)
            {
                swap(data, (i - 1) / 2, i);
                i = (i - 1) / 2;
            }
        }
        private void shiftDown(int i)
        {
            while (i * 2 + 1 < count)
            {
                int j = i * 2 + 1;
                if (j + 1 < count && data[j + 1].CompareTo(data[j]) < 0)
                {
                    j = j + 1;
                }

                if (data[i].CompareTo(data[j]) > 0)
                {
                    swap(data, i, j);
                    i = j;
                }
                else
                {
                    break;
                }

            }
        }

        private void swap(T[] arr, int i, int j)
        {
            T temp = arr[i];
            arr[i] = arr[j];
            arr[j] = temp;
        }
    }
}
