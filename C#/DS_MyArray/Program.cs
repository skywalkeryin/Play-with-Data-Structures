using System;
using System.Linq;

namespace DS_MyArray
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

            //MyArray<int> array1 = new MyArray<int>(1);

            //array1.AddFirst(1);
            //array1.RemoveFirst();
            //array1.RemoveFirst();
            //Console.WriteLine(array1);

            //--------------------------- Array 2  --------------------------------------
            int[] arr = new int[4];
            MyArray2<int> array2 = new MyArray2<int>(arr);

            Console.WriteLine(array2);


            arr[1] = 4;
            Console.WriteLine("---------------New Array2-------------");

            MyArray2<int> array21 = new MyArray2<int>();

            foreach(int i in Enumerable.Range(1, 12))
            {
                array21.AddFirst(i);
            }

            Console.WriteLine(array21);
            Console.WriteLine(array21.Get(3));
            array21.Set(4, 6);
            array21.Set(1, 6);
            array21.RemoveLast();
            array21.RemoveLast();
            array21.RemoveLast();
            array21.RemoveLast();
            array21.RemoveFirst();
            array21.RemoveFirst();
            array21.RemoveFirst();
            Console.WriteLine(array21);
            Console.WriteLine($"The result of removing 1 is " + array21.RemoveAllElement(1));
            Console.WriteLine(array21);
            Console.WriteLine($"The result of removing 6 is " + array21.RemoveAllElement(6));

            Console.WriteLine(array21);



            //Console.WriteLine(array2);

            //object a = 0;
            //object b = 0;

            //int a = 0;
            //int b = 0;


            //object ab = "tete ss";
            //object cd = new string("tete ss");
            //Console.WriteLine(ab == cd);
            //Console.WriteLine(ab.Equals(cd));



        }
    }
}
