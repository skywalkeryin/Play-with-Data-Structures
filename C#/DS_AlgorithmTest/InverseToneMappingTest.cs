using DS_LeetCode;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace DS_LeetCodeTest
{
    public class InverseToneMappingTest
    {

        [Fact]
        public  void TestInverseToneMapping()
        {
            int n = 100000;
            int[] arr = new int[n];

            for (int i =0; i<n;i++)
            {
                arr[i] = i;
            }
            int excepted = 0;

            //Assert.Equal(excepted, 0);

            Assert.Equal(excepted, InverseToneMapping.FindInverseToneMapping(arr));

        }

        [Fact]
        public void TestFindNElement()
        {
            int n = 10000;
            int[] arr = new int[n];

            for (int i = 0; i < n; i++)
            {
                arr[i] = i;
            }

            int nElement = 1243;

            int excepted = n - nElement;

           // Assert.Equal(excepted, InverseToneMapping.FindNElement(arr, nElement));
        }
    }
}
