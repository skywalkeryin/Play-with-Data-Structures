using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DS_LeetCode
{
    public class TwoPointers
    {
        public static bool ValidPalindrome(string s)
        {
            //Time Complexity; o(n)

            int i = 0;
            int j = s.Length - 1;

            while (true)
            {
                while (i < s.Length - 1 && !Char.IsLetter(s[i]))
                {
                    i++;
                }

                while (j > 0 && !Char.IsLetter(s[j]))
                {
                    j--;
                }

                if (i >= j)
                {
                    break;
                }

                if (Char.ToLowerInvariant(s[i]) != Char.ToLowerInvariant(s[j]))
                {
                    return false;
                }

                i++;
                j--;
            }
            return true;


        }


        // 345. Reverse Vowels of a String
        public static string ReverseVowels(string s)
        {

            char[] s1 = s.ToArray();
            // Two pointer
            int l = 0;
            int r = s1.Length - 1;

            while (true)
            {

                while (l < s.Length && !IsVowel(s1[l]))
                {
                    l++;
                }

                while (r >= 0 && !IsVowel(s1[r]))
                {
                    r--;
                }

                if (l >= r) break;

                swap(s1, l, r);

                l++;
                r--;


            }
            return new String(s1);


        }

        private static bool IsVowel(char c)
        {

            char[] s = new char[] { 'a', 'e', 'i', 'o', 'u' };
            return s.Contains(char.ToLowerInvariant(c));
        }

        private static void swap(char[] s, int i, int j)
        {
            char temp = s[i];
            s[i] = s[j];
            s[j] = temp;
        }


        //209. Minimum Size Subarray Sum
        public static int MinSubArrayLen(int s, int[] nums)
        {

            // 滑动窗口 ij 解法
            //time-complexity: o(n)

            int res = nums.Length + 1;

            int sum = 0;
            int l = 0;   //nums[l...r] 为我们的滑动窗口
            int r = -1;

            while (r < nums.Length && l <= r)
            {

                if (sum < s)
                {

                    sum += nums[++r];
                }
                else
                {
                    sum -= nums[l++];
                }

                if (sum >= s)
                {
                    if (r - l + 1 < res)
                    {
                        res = r - l + 1;
                    }
                }

            }

            if (res == nums.Length + 1)
            {
                return 0;
            }

            return res;
        }


        // 3. Longest Substring Without Repeating Characters
        public static int LengthOfLongestSubstring(string s)
        {

            // sliding window
            // TimeComplexity: o(n)

            int[] ascii = new int[256]; // store the assii char freq
            int res = 0;

            int l = 0, r = -1; // [l, r] 存储substring

            while (l < s.Length)
            {
                if (r + 1 < s.Length && ascii[s[r + 1]] == 0)
                {

                    ascii[s[++r]]++;
                }
                else
                {
                    ascii[s[l++]]--;
                }

                if (r - l + 1 > res)
                {
                    res = r - l + 1;
                }
            }

            return res;

        }


        // 438. Find All Anagrams in a String
        public static IList<int> FindAnagrams(string s, string p)
        {
            // sliding windows
            // Time complexity: o(n)

            int[] sFreq = new int[26];
            int[] pFreq = new int[26];

            int sl = s.Length;
            int pl = p.Length;

            List<int> res = new List<int>();
            for (int i = 0; i < sl; i++)
            {

                sFreq[(int)(s[i] - 'a')]++;

                if (i >= pl)
                {
                    sFreq[(int)(s[i - pl] - 'a')]--;
                }

                if (IsEqual(sFreq, pFreq))
                {
                    res.Add(i - pl + 1);
                }

            }
            return res;

        }


        private static  bool IsEqual(int[] a, int[] b)
        {

            if (a.Length != b.Length)
            {
                return false;
            }

            for (int i = 0; i < a.Length; i++)
            {
                if (a[i] != b[i])
                {
                    return false;
                }
            }
            return true;
        }


        //76. Minimum Window Substring
        public static string MinWindow(string s, string t)
        {
            // Time complexity : o(n)

            int[] tFreq = new int[256];
            for (int i = 0; i < t.Length; i++)
            {
                tFreq[t[i]]++;
            }

            int left = 0; // 左指针
            int right = 0; // 右指针
            int count = 0; // 计数器，  s字符串中 子区间[left, right]中t字符的个数
            int minLength = int.MaxValue;
            int minLeft = -1;  // 记录每次的left指针, 优化，不用每次计算substring
            string res = "";

            for (right = 0; right < s.Length; right++)
            {
                // 寻找s中符合t的字符， 然后count加一
                if (--tFreq[s[right]] >= 0)
                {
                    count++;
                }
                // 当count等于t的长度时， 说明在s的[left, right]区间找到了所有的t字符
                while (count == t.Length)
                {

                    // 记录此时 区间长度 以及 substring
                    if (minLength > (right - left + 1))
                    {
                        minLength = right - left + 1;
                        minLeft = left;
                        //res = s.Substring(left, minLength);
                    }


                    // 然后移动做指针，缩小window
                    // 移动左指针的时候， 相应的字符频率加上1， 如果该字符的频率大于1的话， 说明该字符的频率初始值是大于               // 1的，因此该字符是属于t字符串的， 要就是说移动左指针减掉了一个符合t的字符，依次count需要减一
                    if (++tFreq[s[left]] > 0)
                    {
                        count--;
                    }
                    left++;
                }
            }
            // 只计算一次substring
            return minLeft == -1 ? "" : s.Substring(minLeft, minLength);
        }

        //Find interset of two sorted array 
        public static int[] TwoSortedArrayInterset(int[] nums1, int[] nums2)
        {
            List<int> result = new List<int>();

            int i = 0;
            int j = 0;

            for (i =0;  i < nums1.Length; i++)
            {             
                while (nums2[j] < nums1[i] && j < nums2.Length -1)
                {
                    j++;    
                }
                if (nums2[j] == nums1[i])
                {
                    result.Add(nums2[j]);
                    j++;    
                }
            }

            return result.ToArray();

        }

        // 202 happy number
        public static bool IsHappy(int n)
        {
            HashSet<int> set = new HashSet<int>();
            return isHappy(n, set);


        }
        private static bool isHappy(int n, HashSet<int> set)
        {
            if (n == 1)
            {
                return true;
            }


            int sum = 0;
            while (n > 0)
            {
                int d = n % 10;
                sum += d * d;
                n = n / 10;
            }
            // contain in hashset time complexity o(1)
            if (set.Contains(n))
            {
                return false;
            }
            set.Add(sum);
            // 递归调用
            return isHappy(sum, set);
        }

        // 290 word pattern
        public static bool WordPattern(string pattern, string str)
        {
            string[] strArray = str.Split(' ');
            if (pattern.Length != strArray.Length)
            {
                return false;
            }

            Dictionary<char, List<int>> dict = new Dictionary<char, List<int>>();

            Dictionary<string, List<int>> dict2 = new Dictionary<string, List<int>>();

            for (int i = 0; i < pattern.Length; i++)
            {
                if (!dict.ContainsKey(pattern[i]))
                {
                    dict.Add(pattern[i], new List<int>() { i });
                }
                else
                {
                    dict[pattern[i]].Add(i);
                }
            }

            for (int i = 0; i < strArray.Length; i++)
            {
                if (!dict2.ContainsKey(strArray[i]))
                {
                    dict2.Add(strArray[i], new List<int>() { i });
                }
                else
                {
                    dict2[strArray[i]].Add(i);
                }
            }

            for (int i = 0; i < dict.Keys.Count; i++)
            {
                if (!ComapareTwoList(dict[dict.Keys.ElementAt(i)], dict2[dict2.Keys.ElementAt(i)]))
                {
                    return false;
                }
            }
            return true;

        }
        private static bool ComapareTwoList(List<int> list1, List<int> list2)
        {
            if (list1 != list2)
            {
                return false;
            }

            for (int i = 0; i < list1.Count; i++)
            {
                if (list1[i] != list2[i])
                {
                    return false;
                }
            }
            return true;
        }


        #region "451. Sort Characters By Frequency"
        public static string FrequencySort(string s)
        {

            char[] chars = new char[128];

            int[] freq = new int[128];
            for (int i = 0; i < 128; i++)
            {
                freq[i] = 0;
                chars[i] = default(char);
            }

            for (int i = 0; i < s.Length; i++)
            {

                freq[(int)(s[i])]++;
                chars[(int)(s[i])] = s[i];
            }

            // sort
            quickSort(freq, chars);

            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < chars.Length; i++)
            {
                if (chars[i] != default(char))
                {
                    for (int j = 0; i < freq[i]; j++)
                    {
                        sb.Append(chars[i]);
                    }
                }
            }
            return sb.ToString();


        }

        // Time Complexity:O(logn)
        private static void quickSort(int[] freq, char[] chars)
        {
            quickSort(0, freq.Length - 1, freq, chars);

        }

        // 在 [l,  r] 闭区间排序
        private static void quickSort(int l, int r, int[] freq, char[] chars)
        {

            if (l > r)
            {
                return;
            }

            int pInx = Partition(l, r, freq, chars);
            // [l, pInx] < pivot
            quickSort(l, pInx - 1, freq, chars);
            quickSort(pInx + 1, r, freq, chars);

        }

        private static int Partition(int l, int r, int[] freq, char[] chars)
        {

            int i = 0;
            int j = l; //[l, j) > pivot 
            int pivot = freq[l];

            for (i = l + 1; i <= r; i++)
            {

                if (freq[i] > pivot)
                {
                    swap(i, ++j, freq, chars);
                }
            }
            swap(l, j, freq, chars);
            return j;
        }

        private static void swap(int i, int j, int[] freq, char[] chars)
        {

            int temp = freq[i];
            freq[i] = freq[j];
            freq[j] = temp;

            char temp1 = chars[i];
            chars[i] = chars[j];
            chars[j] = temp1;

        }
        #endregion



        #region "15 3 sum"
        public static IList<IList<int>> ThreeSum(int[] nums)
        {
            // Time Complexity: o(n2)
            // Space Complexity: o(n2)

            IList<IList<int>> result = new List<IList<int>>();

            Dictionary<int, int> counter = new Dictionary<int, int>();
            for (int i = 0; i < nums.Length; i++)
            {

                if (!counter.ContainsKey(nums[i]))
                {
                    counter.Add(nums[i], 1);
                }
                else
                {
                    counter[nums[i]]++;
                }
            }

            // sort Array
            Array.Sort(nums);
            nums = nums.Distinct().ToArray();

            for (int i = 0; i < nums.Length; i++)
            {
                for (int j = i + 1; j < nums.Length; j++)
                {

                    if (nums[i] * 2 + nums[j] == 0 && counter[nums[i]] >= 2)
                    {

                        result.Add(new List<int>() { nums[i], nums[i], nums[j] });
                    }
                    else if (nums[i] + nums[j] * 2 == 0 && counter[nums[j]] >= 2)
                    {
                        result.Add(new List<int>() { nums[i], nums[j], nums[j] });
                    }

                    int complement = 0 - nums[i] - nums[j];
                    if (complement > nums[j] && counter.ContainsKey(complement) && counter[complement] >= 1)
                        result.Add(new List<int>() { nums[i], nums[j], complement });
                }
            }


            return result;


        }
        #endregion


        #region "18 4sum"
        public static IList<IList<int>> FourSum(int[] nums, int target)
        {

            // Time complexity : o(n^3)
            IList<IList<int>> result = new List<IList<int>>();

            if (nums.Length < 4)
            {
                return result;
            }

            Array.Sort(nums);
            int aindex = 0;

            while (aindex < nums.Length)
            {
                int bindex = aindex + 1;

                while (bindex < nums.Length)
                {

                    int cindex = bindex + 1;
                    int dindex = nums.Length - 1;

                    while (cindex < dindex)
                    {
                        int complement = target - nums[aindex] - nums[bindex];

                        if (nums[cindex] + nums[dindex] == complement)
                        {
                            result.Add(new List<int>() { nums[aindex], nums[bindex], nums[cindex], nums[dindex] });
                        }
                        else if (nums[cindex] + nums[dindex] < complement)
                        {
                            cindex = nextIndex(nums, cindex);
                        }
                        else
                        {
                            dindex = prevIndex(nums, dindex);
                        }

                    }
                    bindex = nextIndex(nums, bindex);
                }
                aindex = nextIndex(nums, aindex);
            }
            return result;
        }

        private static int nextIndex(int[] nums, int curInx)
        {

            for (int i = curInx + 1; i < nums.Length; i++)
            {
                if (nums[i] != nums[curInx])
                {
                    return i;
                }
            }
            return nums.Length;
        }

        private static int prevIndex(int[] nums, int curInx)
        {
            for (int i = curInx - 1; i >= 0; i--)
            {
                if (nums[i] != nums[curInx])
                {
                    return i;
                }
            }
            return -1;
        }
        #endregion

        #region "219 "
        //Time complexity: o(n)
        // space complexity: o(k)
        public static bool ContainsNearbyDuplicate(int[] nums, int k)
        {

            // 存储k区间的所有 nums 值
            HashSet<int> set = new HashSet<int>();

            int l = 0;
            int r = 0;

            while (l < r && r < nums.Length)
            {
                if (!set.Contains(nums[r]))
                {
                    set.Add(nums[r]);
                }
                else
                {
                    return true;
                }
                if (r < k)
                {
                    r++;
                }
                else
                {
                    set.Remove(nums[l]);
                    l++;
                    r++;
                }
            }
            return false;
        }
        #endregion
    }

}
