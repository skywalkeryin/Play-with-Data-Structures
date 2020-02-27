using System;
using System.Diagnostics;

namespace DS_MyLinkedList
{
    class Program
    {
        static double TestLoopLinkedList1(LoopLinkedList<int> list, int OptCount)
        {
            Random rnd = new Random();
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            for (int i = 0; i < OptCount; i++)
            {
                list.AddLast(rnd.Next(int.MaxValue));
            }
            for (int i = 0; i < OptCount; i++)
            {
                list.RemoveLast2();
            }
            stopWatch.Stop();
            return (double)stopWatch.ElapsedMilliseconds / 1000.000;
        }

        static double TestLoopLinkedList2(LoopLinkedList<int> list, int OptCount)
        {
            Random rnd = new Random();
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            for (int i = 0; i < OptCount; i++)
            {
                list.AddLast2(rnd.Next(int.MaxValue));
            }
            for (int i = 0; i < OptCount; i++)
            {
                list.RemoveLast2();
            }
            stopWatch.Stop();
            return (double)stopWatch.ElapsedMilliseconds / 1000.000;
        }

        static void Main(string[] args)
        {
            MyLinkedList<int> linkedList = new MyLinkedList<int>();
            linkedList.RemoveFirst();
            //for(int i = 0; i < 5; i++)
            //{
            //    linkedList.AddFirst(i);
            //    Console.WriteLine(linkedList);
            //}
            //linkedList.Add(2, 666);
            //Console.WriteLine(linkedList);

            //linkedList.Remove(2);
            //Console.WriteLine(linkedList);
            //linkedList.RemoveFirst();
            //linkedList.RemoveFirst();
            //linkedList.RemoveFirst();
            //Console.WriteLine(linkedList);

            // recusive
            //int[] nums = new int[]{ 1, 2, 6, 3, 4, 5, 6 };
            //ListNode head = new ListNode(nums);
            //Console.WriteLine(head);
            //head = Remove_Linked_List_Elements.RemoveElements(head, 6, 0);

            // LoopLinkedList
            //LoopLinkedList<int> list3 = new LoopLinkedList<int>();
            //Console.WriteLine(list3);


            //LoopLinkedList<int> list2 = new LoopLinkedList<int>();

            //for (int i = 0; i < 15; i++)
            //{
            //    list2.AddLast2(i);
            //}
            //Console.WriteLine(list2);

            //list2.RemoveLast2();
            //list2.RemoveLast2();
            //Console.WriteLine(list2);

            //test addlast 时间复杂度
            //LoopLinkedList<int> list3 = new LoopLinkedList<int>();
            //LoopLinkedList<int> list4 = new LoopLinkedList<int>();
            //int optCount = 100000;


            //double testTime3 = TestLoopLinkedList1(list3, optCount);
            //Console.WriteLine($"Linkedlist 3, Time: {testTime3}s");
            //double testTime4 = TestLoopLinkedList2(list4, optCount);
            //Console.WriteLine($"Linkedlist 4, Time: {testTime4}s");

        }
    }
}
