using DS_LeetCode;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace DS_LeetCodeTest
{
    public class SortingTest
    {
        [Fact]
        public void TestInsertionSort()
        {
            int[] arrs = new int[] { 12, 11, 13, 5, 6 };
            int[] excepted = { 5, 6, 11, 12, 13 };

            Sorting sort = new Sorting();

            sort.IsertionSort(arrs);

            Assert.Equal(excepted, arrs);
        }


        [Fact]
        public void TestQuickSort()
        {
            int[] arrs = new int[] { 12, 11, 13, 5, 6 };
            int[] excepted = { 5, 6, 11, 12, 13 };

            Sorting sort = new Sorting();

            sort.QuickSort(arrs);

            Assert.Equal(excepted, arrs);
        }

    }
}
