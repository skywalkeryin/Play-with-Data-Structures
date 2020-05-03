using DS_LeetCode;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace DS_LeetCodeTest
{
    public class BinartSearchClassTest
    {
        [Fact]
        public void BinarySearchTest()
        {
            int n = 10000;
            int[] arr = new int[n];
            for (int i =0; i < n; i++)
            {
                arr[i] = i;
            }
            int excepted = 9;
            int excepted1 = -1;

            int index = BinartSearchClass.BinarySearchNR(arr, 9);
            int index1 = BinartSearchClass.BinarySearchRE(arr, 9);

            int index2 = BinartSearchClass.BinarySearchNR(arr, 111111);
            int index3 = BinartSearchClass.BinarySearchRE(arr, 10000);

            Assert.Equal(excepted, index);
            Assert.Equal(excepted, index1);
            Assert.Equal(excepted1, index2);
            Assert.Equal(excepted1, index3);
        }


        [Fact]
        public void FloorTest()
        {
            int n = 10;
            int m = 5;
            int[] arr = new int[] { 1, 4, 6, 8, 8, 15, 21 };
    

            Assert.Equal(-1, BinartSearchClass.Floor1(arr, 0));
            Assert.Equal(0, BinartSearchClass.Floor1(arr, 1));
            Assert.Equal(3, BinartSearchClass.Floor1(arr, 8));
            Assert.Equal(4, BinartSearchClass.Floor1(arr, 10));
            Assert.Equal(6, BinartSearchClass.Floor1(arr, 25));




        }

        [Fact]
        public void CeilTest()
        {
            int[] arr = new int[] { 1, 4, 6, 8, 8, 15, 21 };


            Assert.Equal(0, BinartSearchClass.Ceil(arr, -10000));
            Assert.Equal(0, BinartSearchClass.Ceil(arr, 1));
            Assert.Equal(4, BinartSearchClass.Ceil(arr, 8));
            Assert.Equal(5, BinartSearchClass.Ceil(arr, 10));
            Assert.Equal(-1, BinartSearchClass.Ceil(arr, 25));

        }
    }
}
