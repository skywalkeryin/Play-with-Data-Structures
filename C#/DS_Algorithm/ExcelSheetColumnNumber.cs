using System;
using System.Collections.Generic;
using System.Text;

namespace DS_LeetCode
{
    class ExcelSheetColumnNumber
    {

        static void Main(string[] args)
        {
            double power = Math.Log(14348906, 3);
            //int b = int.Parse(power);
            int c = Convert.ToInt32(power);
            var diff = Math.Abs(Convert.ToInt32(power) - power);
            if (diff < 0.0000001) // need some min threshold to compare floating points
            {
                //return true;
            }
            else
            {
                //return false;
            }
            bool a = power.Equals(5.0);
            Solution s = new Solution();
            s.TitleToNumber("A");
        }

        public class Solution
        {
            public int TitleToNumber(string s)
            {

                int res = 0;

                int digit = 0;
                for (int i = s.Length - 1; i >= 0; i++)
                {
                    int number = (int)(s[i] - 'A') + 1;
                    res += number * (26 ^ digit);
                    digit++;
                }
                return res;
            }
        }
    }
}
