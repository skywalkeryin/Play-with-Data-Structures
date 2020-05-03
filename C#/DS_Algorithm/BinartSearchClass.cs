using System;
using System.Collections.Generic;
using System.Text;

namespace DS_LeetCode
{
    //二分搜索法 应用于已排好序的数组
    public class BinartSearchClass
    {

        // 非递归版本
        public static int BinarySearchNR(int[] arr, int target)
        {
            // l 和 r 是闭区间 [l, r]中寻找target
            int l = 0;  
            int r = arr.Length-1;
            while (l <= r)
            {
                int mid = l + (r - l) / 2;

                if (arr[mid] == target)
                {
                    return mid;
                }
                else if (arr[mid] > target)
                {
                    r = mid - 1;                   
                }
                else
                {
                    l = mid + 1;
                }
            }
            return -1;
        }

        public static int BinarySearchRE(int[] arr, int target)
        {
            return binarySearch(arr, target, 0, arr.Length - 1);
        }

        // 在[l...r]中寻找target
        private static int binarySearch(int[] arr, int target, int l, int r)
        {
            if (l > r)
            {
                return -1;
            }

            int mid = l + (r - l) / 2;
            if (arr[mid] == target)
            {
                return mid;
            }
            else if (arr[mid] < target)
            {
                return binarySearch(arr, target, mid + 1, r);
            }
            else
            {
                return binarySearch(arr, target, l, mid - 1);
            }
        }


        // floor  函数可以找到v在数组中第一次出现的位置
        public static int Floor(int[] arr, int target)
        {
            int rel = -1;

            int l = 0;
            int r = arr.Length - 1;

            int resultInx = 0;  // target 其中一个索引
            while (l <= r)
            {
                int mid = l + (r - l) / 2;

                if (l == r)
                {
                    resultInx = mid;
                    break;
                }
                if (target == arr[mid])
                {
                    resultInx = mid;
                    break;
                }
                else if (target > arr[mid])
                {
                    l = mid + 1;
                }
                else
                {
                    r = mid - 1;
                }
            }
            rel = resultInx;
            if (arr[rel] == target)
            {
                // 向下循环，去找最后一个target的索引
                
                while (true)
                {
                    rel--;
                    if (arr[rel] != target)
                    {
                        break;
                    }
                }
                rel++;  //floor找第一个target元素
            }
            else if (arr[rel] < target) //如果不存在 目标元素
            {
                while (true)
                {
                    rel++;
                    if (rel >= arr.Length)
                    {
                        return arr.Length -1;  // 返回最后一个元素 
                    }
                    if (arr[rel] > target)
                    {
                        break;
                    }
                }
                rel--; // floor 找前一个元素比target小的元素
            }
            else  // arr[rel] > target 如果不存在 目标元素
            {
                while (true)
                {
                    rel--;
                    if (rel < 0)  // 比目标元素小的元素在 数组中不存在
                    {
                        return -1;
                    }
                    if (arr[rel] < target)
                    {
                        break;
                    }
                }

            }

            return rel;
        }


        // 找到 target 元素的最左侧索引
        public static int LeftIndex(int[] arr, int target)
        {
            int l = 0;
            int r = arr.Length;

            //结束条件   l > r
            while (l <= r)
            {
                int mid = l + (r - l) / 2;
                if (arr[mid] == target )
                {
                    r = mid - 1;
                }
                else if (target > arr[mid])
                {
                    l = mid + 1;
                }
                else  // target < arr[mid]
                {
                    r = mid - 1;
                }
            }

            //结束条件   l > r, 看一下l是否超出索引， 因为l 是大于r的
            if (l >= arr.Length || arr[l] != target)
            {
                return -1;
            }
            return l;
        }

        // 寻找target的最左侧, 或者比target小的最大的索引
        public static int Floor1 (int[] arr, int target)
        {
            int l = 0;
            int r = arr.Length -1;

            while (l <= r)
            {
                int mid = l + (r - l) / 2;
                if (arr[mid] == target) 
                {
                    r = mid - 1;
                }
                else if (target < arr[mid])
                {
                    r = mid - 1;
                }
                else  // target > arr[mid]
                {
                    l = mid + 1;
                }
            }

            // 结束条件 l > r
            // 所有的元素都比target 大
            if (r < 0 )
            {
                if ( arr[r + 1] == target) { return r + 1; }
                return r;
            }

            if (l == arr.Length)
            {
                return l-1;
            }

            //如果数组存在target的话，l就是最左侧的索引，
            //如果不存在的话， 最后一个mid元素小于target， 此时 l =  mid + 1, 因此需要 l -1 去得到比target小的最大元素
            return arr[l] == target ? l : l - 1;
        }


        public static int RightIndex(int[] arr, int target)
        {
            int l = 0;
            int r = arr.Length - 1;
            while (l <= r)
            {
                int mid = l + (r - l) / 2;

                if (arr[mid] == target)
                {
                    l = mid + 1;
                }
                else if (arr[mid] < target)
                {
                    l = mid + 1;
                }
                else  // arr[mid] > target
                {
                    r = mid - 1;
                }
            }
            // l > r 结束循环
            // 检查左索引的边界问题
            if (l >= arr.Length)  // 说明数组中的元素都都小于target
            {
                return -1;
            }
            return l - 1;
        }

        // 寻找
        public static int Ceil(int[] arr, int target)
        {
            int l = 0;
            int r = arr.Length - 1;

            while (l <= r)
            {
                int mid = l + (r - l) / 2;

                if (arr[mid] == target)
                {
                    l = mid + 1;
                }
                else if (arr[mid] < target)
                {
                    l = mid + 1;
                }
                else // arr[mid] > target
                {
                    r = mid - 1;
                }
            }
            if (r < 0)  //所有的数组都比target大
            {
                return 0;
            }

            if (l >= arr.Length) // 所有的数组元素都比target小
            {
                if (arr[l-1] == target)  //如果在最后一个元素是 target
                {
                    return l - 1;
                }
                return -1;
            }

            return arr[r] == target ? r : r + 1; 
        }
    }
}
