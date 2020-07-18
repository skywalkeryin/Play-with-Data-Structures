using System;
using System.Collections.Generic;
using System.Text;

namespace DS_LeetCode
{
   public class GenerateParentheses
    {
        static void Main(string[] args)
        {
            Solution s = new Solution();
            s.GenerateParenthesis(3);
        }

        public class Solution
        {
            public IList<string> GenerateParenthesis(int n)
            {

                IList<string> result = new List<string>();
                GenerateParenthesis(result, n, n, "");
                return result;
            }

            public void GenerateParenthesis(IList<string> result, int openCounter, int closeCounter, string str)
            {

                if (openCounter == 0 && closeCounter == 0)
                {
                    result.Add(str);
                    return;
                }

                //Conditions
                if (openCounter == closeCounter)
                {
                    GenerateParenthesis(result, openCounter - 1, closeCounter, str + "(");
                }
                else if (openCounter > 0 && openCounter < closeCounter)
                {
                    GenerateParenthesis(result, openCounter - 1, closeCounter, str + "(");
                    GenerateParenthesis(result, openCounter, closeCounter + 1, str + ")");
                }
                else if (openCounter == 0)
                {
                    GenerateParenthesis(result, openCounter, closeCounter + 1, str + ")");
                }
            }
        }
    }
}
