using System;
using System.Collections.Generic;
using System.Text;

namespace DS_LeetCode
{
    class Kth_Smallest_ElementinaSortedMatrix
    {
        static void Main(string[] args)
        {
            int[][] matrix = new int[][] { 
              new int[]{ 1,  5,  9},
              new int[]{10, 11, 13},
              new int[]{12, 13, 15},
            };

            Solution s = new Solution();
            s.KthSmallest(matrix, 8);
        }

        public class Solution
        {
            public int KthSmallest(int[][] matrix, int k)
            {

                int n = matrix.Length;
                int m = matrix[0].Length;

                int left = matrix[0][0];
                int right = matrix[n - 1][m - 1];

                while (left <= right)
                {

                    int mid = left + (right - left) / 2;
                    int counter = 0;
                    for (int i = 0; i < n; i++)
                    {
                        counter += lowerBound(matrix[i], mid);
                    }
                    if (counter == k)
                    {
                        return mid;
                    }
                    else if (counter < k)
                    {
                        left = mid + 1;
                    }
                    else
                    {
                        right = mid - 1;
                    }
                }
                return -1;

            }

            // retrun first index of i, which is row[i] >= target, if all item of rows less than targer, then return the length of     // row
            public int lowerBound(int[] row, int target)
            {
                int left = 0;
                int right = row.Length;
                while (left < right)
                {
                    int mid = left + (right - left) / 2;
                    if (row[mid] >= target)
                    {
                        right = mid;
                    }
                    else
                    {
                        left = mid + 1;
                    }
                }                                                                                                                                                   
                return left;
            }
        }
    }
}
