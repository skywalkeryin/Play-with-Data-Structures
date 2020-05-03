using System;
using System.Collections.Generic;
using System.Text;

namespace DS_LeetCode.Sort
{
    public class QuickSortClass
    {

        public static Random rand = new Random();

        private static void swap(int[] arr, int i, int j)
        {
            int temp = arr[i];
            arr[i] = arr[j];
            arr[j] = temp;
        }

        public static void QuickSort(int[] arr)
        {
            quickSort(arr, 0, arr.Length - 1);
        }

        private static void quickSort(int[] arr, int l, int r)
        {
            if (l >= r)
            {
                return;
            }

            int p = partition(arr, l, r);

            quickSort(arr, l, p - 1);
            quickSort(arr, p + 1, r);
        } 

        private static int partition(int[] arr, int l, int r)
        {
            int pivot = arr[l];
            int i = l;
            
            // [l+1...i] 为 < pivot
            for (int j = l + 1; j <= r; j++ )
            {
                if (arr[j] < pivot)
                {
                    swap(arr, j, ++i);
                }
            }
            swap(arr, l, i);

            return i;
        }


        public static void QuickSort1(int[] arr)
        {
            quickSort1(arr, 0, arr.Length - 1);
        }

        private static void quickSort1(int[] arr, int l, int r)
        {
            if (l >= r)
            {
                return;
            }

            int p = partition1(arr, l, r);

            quickSort1(arr, l, p);
            quickSort1(arr, p + 1, r);
        }

        private static int partition1(int[] arr, int l, int r)
        {
            // 优化方案： 不在使用固定的元素作为pivot， 而是选择随机元素作为pivot
            //Random rand = new Random();
            //int rnd = ;
            swap(arr, rand.Next(l, r), l);

            int pivot = arr[l];
            int i = l;

            // [1...i] 为 < pivot
            for (int j = l + 1; j <= r; j++)
            {
                if (arr[j] < pivot)
                {
                    swap(arr, j, ++i);
                }
            }
            swap(arr, l, i);

            return i;
        }


        #region "two way quick sort"
        public static void QuickSortTwoWay(int[] arr)
        {
            quickSortTwoWay(arr, 0, arr.Length - 1);
        }

        private static void quickSortTwoWay(int[] arr, int l, int r)
        {
            if (l >= r)
            {
                return;
            }

            int p = partitionTwoWay(arr, l, r);

            quickSortTwoWay(arr, l, p - 1);
            quickSortTwoWay(arr, p + 1, r);
        }

        private static int partitionTwoWay(int[] arr, int l, int r)
        {
            //swap(arr, l, rand.Next(l, r));
            int pivot = arr[l];

            // int[l+1... i-1] 为<= pivot  int[]
            // int[j+1... r] 为>= pivot  int[]
            int i = l + 1;
            int j = r;

            while (true)
            {   
                while(i <= r && arr[i] < pivot) { i++; }
                while (j >= l+1 && arr[j] > pivot) { j-- ; }

                if (i > j)
                {
                    break;
                }
                else
                {
                    swap(arr, i, j);
                    i++;
                }   j--;         
            }
            swap(arr, l, j);

            return j;
        }
        #endregion

        #region "Quick  sort three ways"
        public static void QucikSortThreeWay(int[] arr)
        {
            quickSortThreeWay(arr, 0, arr.Length - 1);
        }
        public static void quickSortThreeWay(int[] arr, int l, int r)
        {
            if (l >= r)
            {
                return;
            }
            //partition
            swap(arr, l, rand.Next(l, r));
            int pivot = arr[l];

            int lt = l;  //[l+1, lt] < pivot
            int gt = r + 1;  //[gt, r] >  pivot

            //[gt+1...i]
            // int i = l + 1;
            for (int i = l + 1; i < gt;)
            {
                if (arr[i] == pivot)
                {
                    i++;
                }
                else if (arr[i] < pivot)
                {
                    swap(arr, i, ++lt);
                    i++;
                }
                else // arr[i] > pivot
                {
                    swap(arr, i, --gt);
                }
            }
            swap(arr, l, lt);

            //注意lt需要减1， 因为交换往后 [0, lt-1] < pivot
            quickSortThreeWay(arr, l, lt - 1);
            quickSortThreeWay(arr, gt, r);

        }
        #endregion


        //利用快排思想， 去查找数组的第n大元素， 时间复杂度o(n)
        public static int FindNElement(int[] arr, int n)
        {
            if (n > arr.Length)
            {
                throw new Exception("errot");
            }

            return findNElement(arr, n, 0, arr.Length - 1);

        }

        public static int findNElement(int[] arr, int n, int l, int r)
        {

            int p = partiton(arr, n, l, r);

            if (n == r - p + 1)
            {
                return arr[p];
            }
            else if (n > r - p + 1)
            {
                return findNElement(arr, n - (r - p + 1), l, p - 1);
            }
            else //n <r - p +1
            {
                return findNElement(arr, n, p + 1, r);
            }

        }

        private static int partiton(int[] arr, int n, int l, int r)
        {

            if (n == 0)
            {
                return n;
            }

            int pivot = arr[l];

            int i = l;
            for (int j = l + 1; j <= r; j++)
            {
                if (arr[j] < pivot)
                {
                    Sorting.swap(arr, j, ++i);
                }
            }

            Sorting.swap(arr, l, i);

            return i;
        }
    }
}
