using System;
using System.Collections.Generic;

namespace DS_BST
{
    class Program
    {
        static void Main(string[] args)
        {
            //BST<int> bst = new BST<int>();
            //int[] nums = new int[] { 5, 3, 6, 8, 4, 2, 7,20, 31, 21, 14, 12 };
            //foreach(int num in nums)
            //{
            //    bst.Add(num);
            //}

            //bst.PreOrder();
            //bst.InOrder();

            //Console.WriteLine();
            //bst.PreOrderNR();
            //Console.WriteLine(bst.GenerateBSTString());

            //bst.InOrder();
            //Console.WriteLine();
            //bst.InOrderNR();

            List<int> bstList = new List<int>();

            BST<int> bst2 = new BST<int>();
            Random random = new Random();
            //for (int i = 0; i < 100; i++)
            //{
            //    bst2.Add(random.Next(1000));
            //}
            //bst2.InOrder();
            //while (!bst2.IsEmpty())
            //{
            //    //Console.WriteLine(bst2.RemoveMin());
            //    bstList.Add((int)bst2.RemoveMin());
            //}

            //Console.WriteLine("------------------");
            //foreach (var a in bstList)
            //{
            //    Console.WriteLine(a);
            //}


            //for (int i =0; i < bstList.Count - 1; i++)
            //{
            //    if(bstList[i] > bstList[i + 1])
            //    {
            //        throw new Exception("error");
            //    }
            //}

            //BST<int> bst3 = new BST<int>();
            //List<int> testList = new List<int> { 1, 5, 7, 27, 40, 13, 29, 23, 65, 33 };
            //for (int i = 0; i < testList.Count; i++)
            //{
            //    bst3.Add                                                                                                                                                                                                                                                                      (testList[i]);
            //}

            //bst3.PreOrder();
            //bst3.PostOrder();

            //for (int i = 0; i < testList.Count - 1; i++)
            //{
            //    bst3.Remove(testList[i]);
            //}


            //bst3.InOrder();

            //Console.WriteLine(bst3.Floor(43));
            //Console.WriteLine(bst3.Floor(22));
            //Console.WriteLine(bst3.Floor(-1));


            BST2<int> bst4 = new BST2<int>();
            List<int> testList2 = new List<int> { 41, 22, 15, 13, 33, 37, 58, 50,  42, 53, 63 };
            for (int i = 0; i < testList2.Count; i++)
            {
                bst4.Add(testList2[i]);
            }

            //bst4.InOrder();

            Console.WriteLine(bst4.GenerateBSTString());
            //bst3.PreOrder();
            //bst3.PostOrder();

            //bst4.Remove(50);

            //for (int i = 0; i < testList2.Count - 1; i++)
            //{
            //    bst4.Remove(testList2[i]);
            //}

            //bst4.InOrder();

            Console.WriteLine("Rank 50: " + bst4.Rank(50));
            Console.WriteLine("Rank 63: " + bst4.Rank(63));
            Console.WriteLine("Rank 13: " + bst4.Rank(13));
            Console.WriteLine("Rank 33: " + bst4.Rank(33));
            Console.WriteLine("Rank 37: " + bst4.Rank(37));

            for (int i = 1; i <= testList2.Count; i++)
            {
                Console.WriteLine($"Index {i} : {bst4.Select(i)}");
            }
            //bst3.InOrder();

            //Console.WriteLine(bst3.Floor(43));
            //Console.WriteLine(bst3.Floor(22));
            //Console.WriteLine(bst3.Floor(-1));



                

        }

    }
}
