using System;

namespace DS_MyStack
{
    class Program
    {
        static void Main(string[] args)
        {
            MyArrayStack<int> stack = new MyArrayStack<int>();
            LinkedListStack<int> stack2 = new LinkedListStack<int>();

            for (int i = 0; i < 5; i++)
            {
                stack2.Push(i);
                Console.WriteLine(stack2);
            }

        }

        
    }
}
