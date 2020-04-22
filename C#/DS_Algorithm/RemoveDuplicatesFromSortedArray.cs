using System;
using System.Collections.Generic;
using System.Text;

namespace DS_LeetCode
{

    // 26. Remove Duplicates from Sorted Array
    public class RemoveDuplicatesFromSortedArray
    {
        public int RemoveDuplicates(int[] nums)
        {

            if (nums.Length == 0)
            {
                return 0;
            }

            int k = 0;

            for (int i = 0; i < nums.Length; i++)
            {

                if (nums[k] != nums[i])
                {
                    k++;
                    nums[k] = nums[i];
                    nums[i] = 0;
                }
                else
                {
                    nums[i] = 0;
                }
            }
            return k + 1;
        }

        //https://leetcode.com/problems/remove-duplicates-from-sorted-array-ii/
        /*
         * Given nums = [1,1,1,2,2,3],
         * Your function should return length = 5, with the first five elements of nums being 1, 1, 2, 2 and 3 respectively.
         * It doesn't matter what you leave beyond the returned length.
         */
        public int RemoveDuplicates2(int[] nums)
        {
                if (nums.Length == 0) return 0;
                int currIndex = 0, count = 1;
                for (int i = 1; i < nums.Length; i++)
                {
                    if (nums[i] != nums[currIndex])
                    {
                        nums[++currIndex] = nums[i];
                        count = 0; //reset counter
                    }
                    else if (count < 2)
                    {  //allow 2 duplicates or change this to allow any number
                        nums[++currIndex] = nums[i];
                    }
                    count++;
                }
                return currIndex + 1;
         
        }

    }
}
