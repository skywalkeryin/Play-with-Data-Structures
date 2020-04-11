using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace DS_Set
{
    class Program
    {
        static void Main(string[] args)
        {

            // BST Set 
            Console.WriteLine("pride and prejudice");

            List<string> words = new List<string>();

            FileOperation.ReadFile("pride-and-prejudice.txt", words);

            Console.WriteLine("Total words: " + words.Count);

            BSTSet<string> set1 = new BSTSet<string>();
            foreach (string word in words)
            {
                set1.Add(word);
            }
            Console.WriteLine("Total different words: " + set1.GetSize());


            //Linked list set
            Console.WriteLine("--------------Linked list set------------------");

            Console.WriteLine("pride and prejudice");

            List<string> words2 = new List<string>();

            FileOperation.ReadFile("pride-and-prejudice.txt", words2);

            Console.WriteLine("Total words: " + words2.Count);

            LinkedListSet<string> set2 = new LinkedListSet<string>();
            foreach (string word in words2)
            {
                set2.Add(word);
            }
            Console.WriteLine("Total different words: " + set2.GetSize());


            Console.WriteLine("--------------test seting------------------");
            string fileName = "pride-and-prejudice.txt";

            BSTSet<string> set3 = new BSTSet<string>();
            double time1 = testSet(set3, fileName);
            Console.WriteLine("BST Set: " + time1 + "s");

            LinkedListSet<string> set4 = new LinkedListSet<string>();
            double time2 = testSet(set4, fileName);
            Console.WriteLine("BST Set: " + time2 + "s");


        }


        public static double testSet(ISet<string> set, string filename)
        {
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();

            Console.WriteLine(filename);

            List<string> words = new List<string>();

            FileOperation.ReadFile(filename, words);

            Console.WriteLine("Total words: " + words.Count);

            foreach (string word in words)
            {
                set.Add(word);
            }
            Console.WriteLine("Total different words: " + set.GetSize());

            stopWatch.Stop();
            return (double)stopWatch.ElapsedMilliseconds / 1000.000;
        } 
    }
}
