using DS_LeetCode;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Xunit;

namespace DS_LeetCodeTest
{
    public class TwoPointerTest
    {
        [Fact]
        public void TestPalindrome()
        {

            string s = "0P";

            bool excepted = true;

            Assert.Equal(excepted, TwoPointers.ValidPalindrome(s));
        }

        [Fact]

        public void TestReverseVowels()
        {
            string s = "hello";

            string excepted = "holle";

            Assert.Equal(excepted, TwoPointers.ReverseVowels(s));
        }

        [Fact]
        public void TestMinSubArrayLen()
        {
            int[] nums = { 2, 3, 1, 2, 4, 3 };

            int excepted = 2;

            Assert.Equal(excepted, TwoPointers.MinSubArrayLen(7, nums));
        }

        [Fact]
        public void TestLengthOfLongestSubstring()
        {
            string s = "abcabcbb";
            int excepted = 3;
            Assert.Equal(excepted, TwoPointers.LengthOfLongestSubstring(s));

        }

        [Fact]
        public void TestFindAnagrams()
        {
            String s = "cbaebabacd";
            string p = "abc";

            Assert.Equal(new List<int>() { 0, 6 }, TwoPointers.FindAnagrams(s, p));

        }
        [Fact]
        public void TestMinWindow()
        {
            string s = "cabwefgewcwaefgcf";
            string t = "cae";
            Assert.Equal("cwae", TwoPointers.MinWindow(s, t));
        }

        [Fact]
        public void TwoSortedArrayInterset()
        {
            Random rand = new Random();
            int n1 = 3;
            int n2 = 5;
            //int[] nums1 = new int[n1];
            //int[] nums2 = new int[n2];
            //for (int i = 0; i < n1; i++)
            //{
            //    nums1[i] = rand.Next(n1);
            //}
            //for (int i = 0; i < n2; i++)
            //{
            //    nums2[i] = rand.Next(n2);
            //}
            //Array.Sort(nums1);
            //Array.Sort(nums2);

            int[] nums1 = { 2, 4, 5, 5, 7, 8, };
            int[] nums2 = { 3, 5, 5, 8,10, };

            int[] Interset = nums1.Intersect(nums2).ToArray();

            Assert.Equal(Interset, TwoPointers.TwoSortedArrayInterset(nums1, nums2));

        }

        [Fact]
        public void TestIsHappy()
        {
            Assert.True(TwoPointers.IsHappy(2));
        }

        [Fact]
        public void TestWordPattern()
        {
            Assert.True(TwoPointers.WordPattern("abba", "dog cat cat dog"));
        }

        [Fact]
        public void TestFrequencySort()
        {
            Assert.Equal("", TwoPointers.FrequencySort("tree"));

        }


        [Fact]
        public void TestThreeSum()
        {
            int[] nums = { -1, 0, 1, 2, -1, -4 };
            Assert.Equal(null, TwoPointers.ThreeSum(nums));
        }

        [Fact]
        public void TestFourSum()
        {
            int[] nums = { -3, -1, 0, 2, 4, 5};
            Assert.Equal(null, TwoPointers.FourSum(nums, 0));
        }

        [Fact]
        public void TestContainsNearbyDuplicate()
        {
            int[] nums = { 1,2,3,1};
            Assert.Equal(true, TwoPointers.ContainsNearbyDuplicate(nums, 3));
        }
    }
}
