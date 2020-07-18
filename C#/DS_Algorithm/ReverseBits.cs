using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DS_LeetCode
{
    class ReverseBits
    {
        static void Main(string[] args)
        {
            Solution s = new Solution();
            uint n = Convert.ToUInt32("00000010100101000001111010011100", 2);
            s.reverseBits(n);
        }
        public class Solution
        {
            public uint reverseBits(uint n)
            {

                uint result = 0;
                uint a = 1;


                for (int i = 0; i < 32; i++)
                {
                    // 判断最左位是否为1
                    if ( (n & 1) == 1 )
                    {
                        // 如果为1的话， result向左移动一位，然后在加1
                        result <<= 1;
                        result += 1;

                    }
                    else
                    {
                        // 如果为0话， result只向左移动一位
                        result <<= 1;
                    }
                }
                return result;
            }

            public string reverse(char[] str)
            {
                int i = 0;
                int j = str.Length - 1;
                while (i < j)
                {
                    char temp = str[i];
                    str[i] = str[j];
                    str[j] = temp;
                    i++;
                    j--;
                }
                return new String(str);
            }
        }
    }
}
