using System;

namespace DS_MyLinkedList
{
    class Program
    {
        static void Main(string[] args)
        {
            MyLinkedList<int> linkedList = new MyLinkedList<int>();
            for(int i = 0; i < 5; i++)
            {
                linkedList.AddFirst(i);
                Console.WriteLine(linkedList);
            }
            linkedList.Add(2, 666);
            Console.WriteLine(linkedList);

            linkedList.Remove(2);
            Console.WriteLine(linkedList);
            linkedList.RemoveFirst();
            linkedList.RemoveFirst();
            linkedList.RemoveFirst();
            Console.WriteLine(linkedList);
        }
    }
}
