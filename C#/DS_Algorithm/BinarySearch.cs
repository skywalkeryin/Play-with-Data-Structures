using System;
using System.Collections.Generic;
using System.Text;

namespace DS_LeetCode
{
    public class BinarySearch
    {


        public int BinarySearch1(int[] nums, int target)
        {
            int l = 0;
            int r = nums.Length - 1;   // 闭区间
            while (l <= r)
            {
                int mid = l + (r - l) / 2;
                if (nums[mid] == target)
                {
                    return mid;
                }
                else if (nums[mid] < target)
                {
                    l = mid + 1;
                }
                else
                {
                    r = mid - 1;
                }
            }
            return -1;
        }

        public int BinarySearch2(int[] nums, int target)
        {
            int l = 0;
            int r = nums.Length;   // 开区间 [l, r)
            while (l < r)
            {
                int mid = l + (r - l) / 2;
                if (nums[mid] == target)
                {
                    return mid;
                }
                else if (nums[mid] < target)
                {
                    l = mid + 1;
                }
                else
                {
                    r = mid;
                }
            }
            return -1;
        }

        // 返回 第一个 i, 满足nums[i] >== target, 如果 全部nums小于target则返回 nums的长度
        // 闭区间的写法
        public int lowerBound(int[] nums, int target)
        {
            int l = 0;
            int r = nums.Length - 1;
            while (l <= r)
            {
                int mid = l + (r - l) / 2;
                if (nums[mid] >= target)
                {
                    r = mid - 1;
                }
                else
                {
                    l = mid + 1;
                }
            }
            return l;

        }

        // 开区间的写法
        public int lowerBoundOpen(int[] nums, int target)
        {
            int l = 0;
            int r = nums.Length;
            while (l < r)
            {
                int mid = l + (r - l) / 2;
                if (nums[mid] >= target)
                {
                    r = mid;
                }
                else
                {
                    l = mid + 1;
                }
            }
            return l;

        }

        // 返回函数可以找到v在数组中第一次出现的位置, 如果没有发现v，则返回比v小的最大元素的索引
        public int floor(int[] nums, int target)
        {
            int l = 0;
            int r = nums.Length - 1;
            while (l <= r)
            {
                int mid = l + (r - l) / 2;
                if (nums[mid] >= target)
                {
                    r = mid - 1;
                }
                else
                {
                    l = mid + 1;
                }
            }

            // 结束条件 l > r

            return l == 0 ? -1 : l;
        }
    }
}
