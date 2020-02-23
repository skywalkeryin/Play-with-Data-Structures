using System;

namespace DS_MyLinkedList
{
    class Program
    {
        static void Main(string[] args)
        {
            //MyLinkedList<int> linkedList = new MyLinkedList<int>();
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
            LoopLinkedList<int> list2 = new LoopLinkedList<int>();

            for (int i =0; i < 5; i++)
            {
                list2.AddLast(i);
            }
            Console.WriteLine(list2);


        }
    }
}
