using System;

namespace DS_MyStack
{
    class Program
    {
        static void Main(string[] args)
        {
            MyArrayStack<int> stack = new MyArrayStack<int>();
            
            for(int i = 0; i < 5; i++)
            {
                stack.Push(i);
                Console.WriteLine(stack);
            }

        }

        
    }
}
