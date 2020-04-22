using DS_LeetCode;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace DS_LeetCodeTest
{
    public class RemoveDuplicatesFromSortedArrayTest
    {
        [Fact]
        public void TestRemoveDuplicates()
        {

            int[] nums = new int[] { 0, 0, 1, 1, 1, 2, 2, 3, 3, 4 };
            int[] excepted = new int[] { 0, 1, 2, 3, 4 };

            //act
            RemoveDuplicatesFromSortedArray mz = new RemoveDuplicatesFromSortedArray();
            mz.RemoveDuplicates(nums);

            //
            Assert.Equal(excepted, nums);
        }

        [Fact]
        public void TestRemoveDuplicates2()
        {

            int[] nums = new int[] { 0, 0, 1, 1, 1, 1, 2, 3, 3 };
            int[] excepted = new int[] { 0, 0, 1, 1, 2, 3, 3 };

            //act
            RemoveDuplicatesFromSortedArray mz = new RemoveDuplicatesFromSortedArray();
            mz.RemoveDuplicates2(nums);

            //
            Assert.Equal(excepted, nums);
        }
    }
}
