using System;

namespace DS_BST
{
    class Program
    {
        static void Main(string[] args)
        {
            BST<int> bst = new BST<int>();
            int[] nums = new int[] { 5, 3, 6, 8, 4, 2, 7,20, 31, 21, 14, 12 };
            foreach(int num in nums)
            {
                bst.Add(num);
            }

            //bst.PreOrder();
            //bst.InOrder();

            //Console.WriteLine();
            //bst.PreOrderNR();
            //Console.WriteLine(bst.GenerateBSTString());

            bst.InOrder();
            Console.WriteLine();
            bst.InOrderNR();
        }
    }
}
