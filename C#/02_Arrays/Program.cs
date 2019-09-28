using System;

namespace _02_Arrays
{
    class Program
    {
        static void Main(string[] args)
        {
            // MyArray<int> array = new MyArray<int>(10);

            // for(int i = 0; i < 10; i++){
            //     array.AddLast(i);
            // }

            // array.AddLast(3);

            // Console.WriteLine(array);

            // array.AddFirst(4);
            // array.AddFirst(4);
            // array.AddFirst(4);
            // array.AddFirst(4);
            // Console.WriteLine(array);
            // array.RemoveFirst();
            // array.RemoveFirst();
            // array.RemoveFirst();
            // array.RemoveFirst();
            // Console.WriteLine(array);

           


            MyArray<int> array1 = new MyArray<int>(1);

            array1.AddFirst(1);
            array1.RemoveFirst();
            array1.RemoveFirst();
            Console.WriteLine(array1);



        }
    }
}
