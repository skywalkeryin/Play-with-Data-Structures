using System;
using System.Collections.Generic;
using System.Text;

namespace DS_Map
{
    public class FileOperation
    {
        public static bool ReadFile(string fileName, List<string> words)
        {

            if (fileName == null || words == null)
            {
                Console.WriteLine("file name is null or words is null");
                return false;
            }
            string path = @"G:\Project\Play-with-Data-Structures\C#\DS_Set\";
            string[] lines = System.IO.File.ReadAllLines(@path+fileName);
            foreach (string line in lines)
            {
                int start = firstCharacterIndex(line, 0);

                for (int i = start + 1; i  <= line.Length;)
                {
                    if (i == line.Length ||  !char.IsLetter(line[i]))
                    {
                        string word = line.Substring(start, i - start).ToLower();
                        words.Add(word);
                        start = firstCharacterIndex(line, i);
                        i = start + 1;
                    }
                    else
                    {
                        i++;
                    }
                }
            }
            return true;

        }

        private static int firstCharacterIndex(String s, int start)
        {

            for (int i = start; i < s.Length; i++)
                if (char.IsLetter(s[i]))
                    return i;
            return s.Length;
        }
    }
}
