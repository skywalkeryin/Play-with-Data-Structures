using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace DS_LeetCode
{
    public class Sorting
    {

        #region "Helper"
        public static double TestSorting(int[] arr, Action<int[]> sortingAction)
        {
            Stopwatch watch = new Stopwatch();
            watch.Start();

            sortingAction(arr);

            watch.Stop();

            if (!TestSortedArray(arr))
            {
                return -1;
            }

            return watch.ElapsedMilliseconds / 1000.000000000000;


        }

        public static int[] GenerateTestArray(int n)
        {
            int[] result = new int[n];

            Random rand = new Random();

            for (int i = 0; i < n; i++)
            {
                result[i] = rand.Next(int.MaxValue);
            }
            return result;
        }

        public static bool TestSortedArray(int[] arr)
        {
            for (int i = 0; i < arr.Length-1; i++)
            {
                if (arr[i] > arr[i + 1])
                {
                    return false;
                }
            }
            return true;
        }

        private static void swap(int[] arr, int i, int j)
        {
            int temp = arr[i];
            arr[i] = arr[j];
            arr[j] = temp;
        }
        #endregion

        #region "bubble sort"
        public static void BubbleSort(int[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                for (int j = 0; j < arr.Length - 1; j++)
                {
                    if (arr[j] > arr[j + 1])
                    {
                        swap(arr, j, j + 1);
                    }
                }
            }
        }

        // 改进写法1
        // 在第二次循环减去后面已经排好顺序的元素
        // 根据计算循环次数为（n-2 +1）^ 2 / 2, 比n^2快了两倍
        public static void BubbleSort1(int[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                for (int j = 0; j < arr.Length - 1 - (i + 1); j++)
                {
                    if (arr[j] > arr[j + 1])
                    {
                        swap(arr, j, j + 1);
                    }
                }
            }
        }
        #endregion

        #region "Selection Sort"
        /*
         * Time Complexity O(n2)
         * 每次选取区间的最小值， 然后再和第一个元素交换位置
         */
        public static  void SelectionSort(int[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                // 选取剩下数列的最小值， 寻找[i....n)区间里的最小元素
                int minIndex = i;
                for (int j = i + 1; j < arr.Length; j++)
                {           
                    if (arr[j] < arr[minIndex] )
                    {
                        minIndex = j;
                    }
                }
                // 然后和第一个元素交换位置
                swap(arr, i, minIndex);
            }
        }
        #endregion

        #region "Insertion Sort"
        public static void IsertionSort(int[] arr)
       {
            int n = arr.Length;
            // 为什么从1开始而不是0呢， 因为对于插入排序， 第0
            // 元素可以看作已经排好序的
            for (int i = 1; i < n; ++i)
            {
                int key = arr[i];
                
                // 寻找当前arr[i]合适的插入位置
                // 写法1：
                /*
                 从i开始， 依次和前一个元素比较，如果比前一个元素小， 则交换位置。 否则的话， 就是已经排好序的数组。
                 */
                for (int j = i;  j > 0 && arr[j] < arr[j - 1]; j-- )
                {
                    swap(arr, j, j - 1);
                }

                // 写法2： 
                // 保证[0...i-1]为顺序数组
                // 从 i-1 开始， 把i索引处的元素拿出来依次和前面的元素进行比较， 如果元素比i 处元素大
                // 则元素向后移动一位， 直到i处元素比此处元素大， 则把i处元素插入到此处元素的后一位。
                //int k = i - 1;
                //while (k >= 0 && arr[k] > key)
                //{
                //    arr[k + 1] = arr[k];
                //    k = k - 1;
                //}
                //arr[k + 1] = key;

                for (int j = i - 1; j >= 0; j--)
                {
                    if (arr[j] > arr[i])
                    {
                        arr[j+1] = arr[j];
                    }
                    else
                    {
                        arr[j] = arr[i];
                    }
                }
               
            }
       }

        public static void IsertionSort2(int[] arr)
        {
            int n = arr.Length;
            // 为什么从1开始而不是0呢， 因为对于插入排序， 第0
            // 元素可以看作已经排好序的
            for (int i = 1; i < n; ++i)
            {

                // 寻找当前arr[i]合适的插入位置

                // 写法2： 
                // 保证[0...i-1]为顺序数组
                // 从 i-1 开始， 把i索引处的元素拿出来依次和前面的元素进行比较， 如果元素比i 处元素大
                // 则元素向后移动一位， 直到i处元素比此处元素大， 则把i处元素插入到此处元素的后一位。
                //int k = i - 1;
                //while (k >= 0 && arr[k] > key)
                //{
                //    arr[k + 1] = arr[k];
                //    k = k - 1;
                //}
                //arr[k + 1] = key;

                //for (int j = i - 1; j >= 0; j--)
                //{
                //    if (arr[j] > arr[i])
                //    {
                //        arr[j + 1] = arr[j];
                //    }
                //    else
                //    {
                //        arr[j] = arr[i];
                //    }
                //}

                // 更优的写法
                int e = arr[i];
                int j;
                for (j = i;  j > 0 && arr[j - 1] > e; j--)
                {
                    arr[i] = arr[i - 1];
                }
                arr[j] = e;
            }
        }
        #endregion

        #region "shell sort"
        public static void ShellSort(int[] arr)
        {
            int n = arr.Length;

            for (int gap = n / 2; gap > 0; gap /= 2)
            {
                for (int i = gap; i < n; i++)
                {
                    // 下面是插入排序的操作
                    int key = arr[i];
                    int j;
                    for (j = i;  j > 0 && arr[j - 1] > key; j -= gap)
                    {
                        arr[j] = arr[j - 1];
                    }
                    arr[j] = key;
                }
            }
        }
        #endregion


        #region "Quick Sort"
        public static void QuickSort(int[] arr)
        {
            quickSort(arr, 0, arr.Length - 1);
        }

        /* The main function that implements QuickSort() 
            arr[] --> Array to be sorted, 
             low --> Starting index, 
            high --> Ending index */
        private static void quickSort(int[] arr, int low, int high)
        {

            if(low <high){

                int pivotIndex = partition(arr, low, high);

                quickSort(arr, low, pivotIndex - 1);
                quickSort(arr,  pivotIndex + 1, high);

            }
        }
        /// <summary>
        /// The partition process for the quick sort, return new oivot index
        /// </summary>
        /// <param name="subArr"></param>
        /// <param name="low">subarray starting index</param>
        /// <param name="higt">subarray endding index</param>
        /// <returns></returns>
        private static int partition(int[] subArr, int low, int higt)
        {
            // pick the last element as the pivot
            int pivot = subArr[higt];
            int i = low - 1;
            //int j = low;

            for (int j = low;  j < higt; j++)
            {
                if (subArr[j] < pivot)
                {
                    i++;
                    swap(subArr, i, j);
                }
            }
            swap(subArr, i +  1, higt);  //swap  i + 1 and pivot

            return i + 1;
        }

        #endregion
    }
}
