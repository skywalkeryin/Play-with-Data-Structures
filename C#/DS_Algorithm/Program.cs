using System;
using System.Collections.Generic;
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
            int[] arr = Sorting.GenerateTestArray(10000);

            Console.WriteLine("bubble sort seconds " + Sorting.TestSorting(arr, Sorting.BubbleSort));
            Console.WriteLine("bubble sort1 seconds " + Sorting.TestSorting(arr, Sorting.BubbleSort1));


            Console.WriteLine("insertion sort seconds " + Sorting.TestSorting(arr, Sorting.IsertionSort));
            Console.WriteLine("insertion sort1 seconds " + Sorting.TestSorting(arr, Sorting.IsertionSort2));
            Console.WriteLine("shell sort seconds " + Sorting.TestSorting(arr, Sorting.ShellSort));

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
