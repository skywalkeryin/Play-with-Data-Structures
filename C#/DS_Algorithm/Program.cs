using DS_LeetCode.Sort;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DS_LeetCode
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine(IntToString(1234));
            //Console.WriteLine(IntToString(-1234));
            //Console.WriteLine(IntToString(0));

            //List<int> PrimeList = new List<int>();
            //for (int i = -100; i <= 0; i++)
            //{
            //    if (IsPrime(i))
            //    {
            //        PrimeList.Add(i);
            //    }
            //}

            //StringBuilder sb = new StringBuilder();

            //sb.Append("[ ");
            //foreach (var prime in PrimeList)
            //{
            //    sb.Append(prime.ToString() + ", ");
            //}
            //sb.Append("]");

            //Console.WriteLine(sb);

           

            //Console.WriteLine(Pow(2, -5));
            //Console.WriteLine(Pow(2, 10));

            //int[] nums = new int[] { 1, 2, 3 };
            //Console.WriteLine(nums.Length);
            //nums[2] = 0;
            
            //Console.WriteLine(nums.Length);


            // test time
            int[] arr = Sorting.GenerateTestArray(100000);

            int[] arr1 = arr.Select(a => a).ToArray();
            int[] arr2 = arr.Select(a => a).ToArray(); // deep copy
            int[] arr3 = arr.Select(a => a).ToArray(); // deep copy
            int[] arr4 = arr.Select(a => a).ToArray(); // deep copy
            int[] arr5 = arr.Select(a => a).ToArray(); // deep copy
            int[] arr6 = arr.Select(a => a).ToArray(); // deep copy
            int[] arr7 = arr.Select(a => a).ToArray(); // deep copy
            int[] arr8 = arr.Select(a => a).ToArray(); // deep copy

            int[] testArray = Sorting.GenerateTestArray(100000);
            int[] testArray1 = testArray.Select(a => a).ToArray();

            int[] nearlySortedarr = Sorting.GeneratedNearlyArray(1000000, 100);
            int[] nearlySortedarr1 = nearlySortedarr.Select(a => a).ToArray();

            int[] testArraySmallRange = Sorting.GenerateTestArray(200000, 20);
            int[] testArraySmallRange1 = testArraySmallRange.Select(a => a).ToArray();
            int[] testArraySmallRange2 = testArraySmallRange.Select(a => a).ToArray();
            int[] testArraySmallRange3 = testArraySmallRange.Select(a => a).ToArray();

            int n = 100000;
            int[] arrInversion = new int[n];

            for (int i = 0; i < n; i++)
            {
                arrInversion[i] = i;
            }

            int[] arrInversion1 = arrInversion.Select(a => a).ToArray();
            int[] arrInversion2 = arrInversion.Select(a => a).ToArray();
            //Console.WriteLine("bubble sort seconds " + Sorting.TestSorting(arr, Sorting.BubbleSort));


            //Console.WriteLine("bubble sort1 seconds " + Sorting.TestSorting(arr2, Sorting.BubbleSort1));

            //Console.WriteLine("insertion sort seconds " + Sorting.TestSorting(arr3, Sorting.IsertionSort));

            //Console.WriteLine("insertion sort1 seconds " + Sorting.TestSorting(arr4, Sorting.IsertionSort2));

            //Console.WriteLine("shell sort seconds " + Sorting.TestSorting(arr5, Sorting.ShellSort));

            //Console.WriteLine("merge sort seconds " + Sorting.TestSorting(arr1, Sorting.MergeSort));

            Console.WriteLine("merge sort1 seconds " + Sorting.TestSorting(arrInversion1, Sorting.MergeSort));

            Console.WriteLine("merge sort bu seconds " + Sorting.TestSorting(arrInversion2, Sorting.MergeSortBU));

            //Console.WriteLine("quick sort bu seconds " + Sorting.TestSorting(nearlySortedarr, QuickSortClass.QuickSort));

            //Console.WriteLine("quick sort bu seconds neraly sorted " + Sorting.TestSorting(nearlySortedarr1, QuickSortClass.QuickSort1));



            //Console.WriteLine("quick sort 1" + Sorting.TestSorting(testArraySmallRange, QuickSortClass.QuickSort1));

            //Console.WriteLine("quick sort two ways " + Sorting.TestSorting(testArraySmallRange1, QuickSortClass.QuickSortTwoWay));

            Console.WriteLine("quick sort three ways " + Sorting.TestSorting(testArraySmallRange2, QuickSortClass.QucikSortThreeWay));

            int[] arrHeap = new int[] { 62, 41,  30, 28, 16, 22, 13, 19, 17, 15 };
            Console.WriteLine("heap sort " + Sorting.TestSorting(arr8, HeapSortClass.HeapSort));




            //Console.WriteLine("Inversion Mapping algo " + Sorting.TestAlgo(arrInversion, InverseToneMapping.FindInverseToneMapping));


        }

        public static string Reverse(string s)
        {
            char[] charArray = s.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }

        //整数转为字符串
        //时间复杂度为：O(logn) 以10为底
        static string IntToString(int num)
        {
            string s= "";

            int absNum = Math.Abs(num);

            if (num == 0)
            {
                return "0";
            }

            while (absNum > 0)
            {       
                s +=  (absNum % 10).ToString();
                absNum /= 10;      
            }

            if (num < 0)
            {
                s += "-";
            }
            return Reverse(s);
        }


        // 判断一个数是否为素数
        // 时间复杂度为 O(sqrt(n))
        static bool IsPrime(int n)
        {
            int AbsN = Math.Abs(n);

            if (AbsN == 0 || AbsN == 1)
            {
                return false;
            }

            for (int i = 2; i * i <= AbsN; i++ )
            {
                if (AbsN % i == 0)
                {
                    return false;
                }
            }
            return true;
        }


        static decimal Pow(decimal x, int n)
        {
            // int absn = Math.Abs(n);
            if (n == 0)
            {
                return 1;
            }

            decimal t = Pow(x, n / 2);

            if (n % 2 != 0)
            {
                if (n < 0)
                {
                    return t * t * 1 / x; 
                }
                else
                {
                    return t * t * x;
                }
            }
            return t * t;                              

        }
    }
}
