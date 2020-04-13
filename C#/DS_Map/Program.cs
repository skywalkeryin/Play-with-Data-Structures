using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace DS_Map
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("pride and prejudice");

            List<string> words = new List<string>();

            FileOperation.ReadFile("pride-and-prejudice.txt", words);

            Console.WriteLine("Total words: " + words.Count);

            LinkedListMap<string, int> map = new LinkedListMap<string, int>();

            foreach (var word in words)
            {
                if (map.Contains(word))
                {
                    map.Set(word, map.Get(word) + 1);
                }
                else
                {
                    map.Add(word, 1);
                }
            }

            Console.WriteLine("Total different words: " + map.GetSize());
            Console.WriteLine("Frequency of PRIDE: " + map.Get("pride"));


            Console.WriteLine("----------------------BST MAP---------------------");

            Console.WriteLine("pride and prejudice");

            List<string> words2 = new List<string>();

            FileOperation.ReadFile("pride-and-prejudice.txt", words2);

            Console.WriteLine("Total words: " + words2.Count);

           BSTMap<string, int> map2 = new BSTMap<string, int>();

            foreach (var word in words2)
            {
                if (map2.Contains(word))
                {
                    map2.Set(word, map2.Get(word) + 1);
                }
                else
                {
                    map2.Add(word, 1);
                }
            }

            Console.WriteLine("Total different words: " + map2.GetSize());
            Console.WriteLine("Frequency of PRIDE: " + map2.Get("pride"));


            Console.WriteLine("---------------------Test MAP---------------------");

            string fileName = "pride-and-prejudice.txt";
            LinkedListMap<string, int> map3 = new LinkedListMap<string, int>();
            double time1 = testMap(map3, fileName);
            Console.WriteLine("Total seconds of linkedlist map :" + time1 +"s");

            BSTMap<string, int> map4 = new BSTMap<string, int>();
            double time2 = testMap(map4, fileName);
            Console.WriteLine("Total seconds of bst map :" + time2 + "s");

        }

        public static double testMap(IMap<string,int> map, string filename)
        {
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();

            Console.WriteLine(filename);

            List<string> words = new List<string>();

            FileOperation.ReadFile(filename, words);

            Console.WriteLine("Total words: " + words.Count);

            foreach (var word in words)
            {
                if (map.Contains(word))
                {
                    map.Set(word, map.Get(word) + 1);
                }
                else
                {
                    map.Add(word, 1);
                }
            }
            Console.WriteLine("Total different words: " + map.GetSize());

            stopWatch.Stop();
            return (double)stopWatch.ElapsedMilliseconds / 1000.000;
        }
    }


}
