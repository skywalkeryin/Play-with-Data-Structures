using System;
using System.Collections.Generic;
using System.Text;

namespace DS_LeetCode
{
    public class MoveZeros
    {
        public void MoveZeroes(int[] nums)
        {
            // Time Complexity: O(n)
            // Space Complexity: O(1)


            int k = 0;  // 记录最后非0元素的索引, nums中， [0...k)的元素均为非0元素

            // 遍历到第i个元素后， 保证[0...i]中的所有非0元素
            // 都按照顺序排列在[0...k) 中
            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] != 0)
                {
                    if (i != k)
                    {
                        Swap(nums, i, k);
                        k++;
                    }
                    else
                    {
                        k++;
                    }

                }
            }

        }

        public void Swap(int[] nums, int i, int j)
        {
            int temp = nums[i];
            nums[i] = nums[j];
            nums[j] = temp;
        }
    }
}
