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
        public void TestSelectionSort()
        {

            int[] arrs = Sorting.GenerateTestArray(10);

            Sorting.SelectionSort(arrs);

            Assert.True(Sorting.TestSortedArray(arrs));
        }


        [Fact]
        public void TestInsertionSort()
        {
            int[] arrs = new int[] { 12, 11, 13, 5, 6 };
            int[] excepted = { 5, 6, 11, 12, 13 };


            Sorting.IsertionSort(arrs);

            Assert.Equal(excepted, arrs);
        }

        [Fact]
        public void TestBubbldSort()
        {
            int[] arrs = Sorting.GenerateTestArray(10);

            Sorting.BubbleSort(arrs);

            Assert.True(Sorting.TestSortedArray(arrs));
        }


        [Fact]
        public void TestQuickSort()
        {
            int[] arrs = new int[] { 12, 11, 13, 5, 6 };
            int[] excepted = { 5, 6, 11, 12, 13 };


            Sorting.QuickSort(arrs);

            Assert.Equal(excepted, arrs);
        }

    }
}
