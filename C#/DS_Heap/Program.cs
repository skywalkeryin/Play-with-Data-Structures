using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace DS_Heap
{

    public class Freq : IComparable<Freq>
    {

        public Freq(int num, int freq)
        {
            this.Num = num;
            this.Fre = freq;
        }

        public int Num { get; set; }
        public int Fre { get; set; }


        public int CompareTo(Freq other)
        {

            if (this.Fre < other.Fre)
            {
                return 1;
            }
            else if (this.Fre > other.Fre)
            {
                return -1;
            }
            else
            {
                return 0;
            }
        }


    }
    class Program
    {
        static void Main(string[] args)
        {
            int[] nums = new int[] { 1, 1, 1, 2, 2, 3 };
            int[] arrs = new int[] { 15, 17, 19, 13, 22, 16, 28, 30, 41, 62 };
            //TopKFrequent(nums, 2);

            int n = 100000;//arrs.Length;

            MaxHeap<int> heap = new MaxHeap<int>();
            Random rand = new Random();
            MaxIndexHeap<int> inxHeap = new MaxIndexHeap<int>();

            for (int i = 0; i < n; i++)
            {
                int a = rand.Next(int.MaxValue);
                heap.Add(a);
                inxHeap.Add(i, a);
            }

            List<int> list = new List<int>();
            List<int> list2 = new List<int>();

            for (int i = 0; i < n; i++)
            {
                list.Add(heap.ExtractMax());
                list2.Add(inxHeap.ExtractMax());
            }

            for (int i = 0; i < n-1; i++)
            {
                if (list[i] < list[i+1])
                {
                    throw new Exception("Error");
                }
                if (list2[i] < list2[i + 1])
                {
                    throw new Exception("Error");
                }
            }

            Console.WriteLine("Success.");

            int[] arr = new int[n];
            for (int i = 0; i < n; i++)
            {
                arr[i] = rand.Next(int.MaxValue);
            }

            double time1 = TestHeap(arr, true);
            double time2 = TestHeap(arr, false);

            Console.WriteLine("with heapify: " + time1 +"s");
            Console.WriteLine("without heapify: " + time2 +"s");

        }

        static double TestHeap(int[]  arr, bool IsHeapify)
        {
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();


            MaxHeap<int> heap;
            if (IsHeapify)
            {
                heap = new MaxHeap<int>(arr);
            }
            else
            {
                heap = new MaxHeap<int>();
                for (int i =0; i <arr.Length; i++)
                {
                    heap.Add(arr[i]);
                }
            }

            //sort 
            List<int> list = new List<int>();

            for (int i = 0; i < heap.GetSize(); i++)
            {
                list.Add(heap.ExtractMax());
            }

            for (int i = 0; i < list.Count-1; i++)
            {
                if (list[i] < list[i + 1])
                {
                    throw new Exception("Error");
                }
            }

            Console.WriteLine("Success.");

            stopWatch.Stop();
            return (double)stopWatch.ElapsedMilliseconds / 1000.000;
        }


        // leet code
        //public static IList<int> TopKFrequent(int[] nums, int k)
        //{

        //    Dictionary<int, int> dict = new Dictionary<int, int>();

        //    for (int i = 0; i < nums.Length; i++)
        //    {

        //        if (dict.ContainsKey(nums[i]))
        //        {
        //            dict[nums[i]]++;
        //        }
        //        else
        //        {
        //            dict.Add(nums[i], 1);
        //        }
        //    }

        //    PriorityQueue<Freq> pq = new PriorityQueue<Freq>();


        //    foreach (int key in dict.Keys)
        //    {

        //        if (pq.GetSize() < k)
        //        {
        //            pq.Enqueue(new Freq(key, dict[key]));
        //        }
        //        else if (dict[key] > pq.GetFront().Fre)
        //        {
        //            pq.Dequeue();
        //            pq.Enqueue(new Freq(key, dict[key]));
        //        }
        //    }

        //    List<int> result = new List<int>();
        //    for (int i = 0; i < k; i++)
        //    {
        //        result.Add(heap.Dequeue().Num);
        //    }
        //    return result;


        //}
    }
}
