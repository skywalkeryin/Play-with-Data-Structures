using System;
using System.Collections.Generic;
using System.Text;

namespace DS_LeetCode
{
    public class Sorting
    {
        #region "Insertion Sort"
        public void IsertionSort(int[] arr)
       {
            int n = arr.Length;
            for (int i = 1; i < n; ++i)
            {
                int key = arr[i];
                int j = i - 1;

                // Move elements of arr[0..i-1], 
                // that are greater than key, 
                // to one position ahead of 
                // their current position 
                while (j >= 0 && arr[j] > key)
                {
                    arr[j + 1] = arr[j];
                    j = j - 1;
                }
                arr[j + 1] = key;
            }
       }
        #endregion

        #region "Quick Sort"

        public void QuickSort(int[] arr)
        {
            quickSort(arr, 0, arr.Length - 1);
        }

        /* The main function that implements QuickSort() 
            arr[] --> Array to be sorted, 
             low --> Starting index, 
            high --> Ending index */
        private void quickSort(int[] arr, int low, int high)
        {

            if(low <high){

                int pivotIndex = partition(arr, low, high);

                quickSort(arr, low, pivotIndex - 1);
                quickSort(arr,  pivotIndex + 1, high);

            }
        }
        /// <summary>
        /// The partition process for the quick sort, return new oivot index
        /// </summary>
        /// <param name="subArr"></param>
        /// <param name="low">subarray starting index</param>
        /// <param name="higt">subarray endding index</param>
        /// <returns></returns>
        private int partition(int[] subArr, int low, int higt)
        {
            // pick the last element as the pivot
            int pivot = subArr[higt];
            int i = low - 1;
            //int j = low;

            for (int j = low;  j < higt; j++)
            {
                if (subArr[j] < pivot)
                {
                    i++;
                    swap(subArr, i, j);
                }
            }
            swap(subArr, i +  1, higt);  //swap  i + 1 and pivot

            return i + 1;
        }

        private void swap(int[] arr, int i, int j)
        {
            int temp = arr[i];
            arr[i] = arr[j];
            arr[j] = temp;
        }
        #endregion
    }
}
