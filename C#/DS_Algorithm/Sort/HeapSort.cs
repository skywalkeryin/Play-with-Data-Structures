using System;
using System.Collections.Generic;
using System.Text;

namespace DS_LeetCode.Sort
{
    public class HeapSortClass
    {

        public static void HeapSort(int[] arr)
        {
            // heapfiy to bulid a heap
            for (int i = (arr.Length-2)/2; i >= 0; i-- )
            {
                SiftDown(arr, arr.Length, i);
            }

            //
            for (int i = arr.Length - 1; i > 0; i-- )
            {
                Sorting.swap(arr, i, 0);

                SiftDown(arr, i, 0);
            }
        }

        private static void ShiftUp(int[] arr, int i)
        {
            for (int k = i; k > 0;)
            {
                int parentInx = parent(k);
                if (parentInx >= 0 && arr[k] > arr[parentInx])
                {
                    Sorting.swap(arr, arr[k], arr[parentInx]);
                }
                k = parentInx;
            }
        }

        // n 为数组元素个数从0开始
        private static void SiftDown(int[] arr, int n, int i)
        {    
            int rightInx = i;
            int downVal = arr[i];

            for (int k = i; leftChild(k) < n; )
            {
                int j = leftChild(k);

                // 判断是否有右孩子， 如果有，看那个孩子比较大
                if (j + 1 < n && arr[j] < arr[j + 1])
                {
                    j = j + 1;
                }

                if (downVal < arr[j])
                {

                    //优化：把交换改成一步步赋值，提高效率
                    arr[k] = arr[j]; 
                    rightInx = j;
                    //Sorting.swap(arr, k, j);
                    k = j;
                }
                else
                {
                    break;
                }
            }

            arr[rightInx] = downVal;
        }

        // 0 based heap
        private static int parent(int i)
        {
            if (i <= 0)
            {
                throw new Exception("illegal index.");
            }
            return (i - 1) / 2;
        }

        private static int leftChild(int i)
        {
            return i * 2 + 1;
        }

        private static int rightChild(int i)
        {
            return i * 2 + 2;
        }
    }
}
