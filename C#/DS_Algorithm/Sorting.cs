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

            return watch.Elapsed.TotalSeconds;
        }

        public static double TestAlgo(int[] arr, Func<int[], int> sortingAction)
        {
            Stopwatch watch = new Stopwatch();
            watch.Start();

            sortingAction(arr);

            watch.Stop();

            if (!TestSortedArray(arr))
            {
                return -1;
            }

            return watch.Elapsed.TotalSeconds;
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

        public static int[] GenerateTestArray(int n, int range)
        {
            int[] result = new int[n];

            Random rand = new Random();

            for (int i = 0; i < n; i++)
            {
                result[i] = rand.Next(range);
            }
            return result;
        }

        public static int[] GeneratedNearlyArray(int n, int swapTimes)
        {
            int[] result = new int[n];
            for (int i = 0; i<n;i++)
            {

               result[i] = i;
            }

            Random rand = new Random();

            for (int j = 0; j< swapTimes; j++)
            {
                int a = rand.Next(0, n - 1);
                int b = rand.Next(0, n - 1);

                swap(result, a, b);
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

        public static void swap(int[] arr, int i, int j)
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
                for (int j = 0; j < arr.Length - 1 - i; j++)
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

        private static void InsertSort(int[] arr, int l, int r)
        {
            
            for (int i = l + 1; i <= r; i++  )
            {
                int key = arr[i];
                int j;
                for (j = i;  j > l && arr[j-1] > key; j-- )
                {
                    arr[j] = arr[j - 1];
                }
                arr[j] = key;
            }
        }
        #endregion

        #region "shell sort"
        public static void ShellSort(int[] arr)
        {
            int n = arr.Length;

            for (int gap = n / 2; gap > 0; gap /= 2)
            {
                /*注意：对各组进行插入排序时，并不是先对一个组排序完，再对下一个组进行排序， 而是轮流
                     对每个组进行排序。 理解下面的循环（轮流排序）， 插入排序从第二个元素开始*/
                for (int i = gap; i < n; i++)
                {
                    // 下面是插入排序的操作
                    int key = arr[i];
                    int j;
                    for (j = i;  j >= gap && arr[j - gap] > key; j -= gap)
                    {
                        arr[j] = arr[j - 1];
                    }
                    arr[j] = key;
                }
            }
        }
        #endregion


        #region "Merge Sort"

        public static void MergeSort(int[] arr)
        {
            mergeSort(arr, 0, arr.Length - 1);
        }

        private static void mergeSort(int[] arr, int l, int r)
        {
            if (l >= r)
            {
                return;
            }

            // 解决整数越界问题
            int mid = (l + r) / 2;
            
            // 分组
            // 递归调用
            // 这里怎么理解：  可以看作先执行左边的分组， 一直向下执行，知道把左边的分组全部排好顺序。
            // 再执行右边的分组，把右边也排好顺序，最后合并左右。
            mergeSort(arr, l, mid);
            mergeSort(arr, mid + 1, r);

            //merge
            merge(arr, l, mid, r);
        }

        // 优化写法
        public static void MergeSort1(int[] arr)
        {
            mergeSort1(arr, 0, arr.Length - 1);
        }
        private static void mergeSort1(int[] arr, int l, int r)
        {
            //优化2： 对于较小的子数组， 这里取有16个元素的， 采用插入排序。
            // 因为：对于较小的数组， 可以看作近似有序的数组， 对于近似有序的数组， 插入排序的效率更高。
            if (r - l >= 15)
            {
                InsertSort(arr, l, r);
            }

            // 解决整数越界问题
            int mid = (l + r) / 2;

            // 分组
            // 递归调用
            // 这里怎么理解：  可以看作先执行左边的分组， 一直向下执行，知道把左边的分组全部排好顺序。
            // 再执行右边的分组，把右边也排好顺序，最后合并左右。
            mergeSort1(arr, l, mid);
            mergeSort1(arr, mid + 1, r);

            // 优化1：
            // 只有当  左子数组的右边界 大于 右子数组的左边时， 进行merge操作
            // 因为我们在归并过程中保证了两个字数组的顺序
            if (arr[mid] > arr[mid + 1])
            {
                //merge
                merge(arr, l, mid, r);
            }
         
        }


        // 从底向上的合并排序
        public static void MergeSortBU(int[] arr)
        {
            // 从size为1的子数组（最下面的子数组开始）向上依次合并
            for (int size = 1; size <=arr.Length; size+=size )
            {
                // 循环依次合并两个子数组
                // 需要合并[i...i+size-1] 以及 [i+size....i+ 2 * size-1]
                // 注意子数组边界是否越界
                //i + size < arr.Length 保证了左子数组存在，不越界
                for (int i = 0; i + size < arr.Length; i+=size + size)
                {
                    //Math.Min(i + size + size - 1, arr.Length - 1) 保证了右子数组的右边界不越界
                    merge(arr, i, i + size - 1, Math.Min(i + size + size - 1, arr.Length - 1));
                }
            }
        }

        private static void merge(int[] arr, int l, int mid, int r)
        {
            int[] aux = new int[r - l + 1];
            for (int m = l;  m <= r; m++ )
            {
                aux[m - l] = arr[m];
            }

            int i = l, j = mid + 1;
            
            for (int k = l; k <= r; k++)
            {
                if (i > mid)
                {
                    arr[k] = aux[j - l];
                    j++;
                }
                else if (j > r)
                {
                    arr[k] = aux[i - l];
                    i++;
                }
                else if (aux[i-l] < aux[j-l] )
                {
                    arr[k] = aux[i - l];
                    i++;
                }
                else
                {
                    arr[k] = aux[j- l];
                    j++;
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
