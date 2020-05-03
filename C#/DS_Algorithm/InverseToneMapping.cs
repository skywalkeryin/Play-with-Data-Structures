using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DS_LeetCode
{
    public class InverseToneMapping
    {
        public static int FindInverseToneMapping(int[] arr)
        {
            int result = 0;

            for (int size = 1; size <= arr.Length; size += size)
            {

                for (int i = 0;  i + size < arr.Length; i += size + size )
                {
                    result += findInverseToneMapping(arr, i, i + size - 1, Math.Min(i + size + size - 1, arr.Length - 1));
                }
            }

            return result;
        }
         

        private static int findInverseToneMapping(int[] arr, int l, int mid, int r)
        {
            int counter = 0;

            int[] arrCopy = new int[r - l + 1];
            for (int m = l; m <= r; m++)
            {
                arrCopy[m - l] = arr[m];
            }

            int i = l;
            int j = mid + 1;

            for (int k = l; k <= r; k++)
            {

                if (i > mid) //左边元素处理完毕
                {
                    arr[k] = arrCopy[j-l];
                    j++;
                }
                if (j > r) // 右边元素处理完毕
                {
                    arr[k] = arrCopy[i-l];
                    i++;
                }
                else if (arrCopy[i-l] <= arrCopy[j-l])
                {
                    arr[k] = arrCopy[i-l];
                    i++;
                }
                else 
                {
                    arr[k] = arrCopy[j-l];
                    j++;
                    counter += mid - i + 1;            
                }
            }
            return counter;
        }


   

    }
}
