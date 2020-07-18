using DS_LinkedList_Leetcode;
using System;
using System.Collections.Generic;
using Xunit;

namespace DS_LinkedList_LeetcodeTest
{
    public class UnitTest1
    {
        [Fact]
        public void TestReverseBetween()
        {
            ListNode head = new ListNode(1, new ListNode(2, new ListNode(3, new ListNode(4, new ListNode(5, null)))));


            ReverseLinkedList.ReverseBetween(head, 2, 4);
        }

        [Fact]
        public void TestDeleteDuplicates()
        {
            int[] nums = {1, 1, 2 };

            ListNode head = ListNode.CreateListNode(nums);

            ReverseLinkedList.DeleteDuplicates(head);
        }

        [Fact]
        public void TestAddTwoNumbers()
        {

            int[] nums = { 7, 2, 4, 3 };
            int[] nums2 = { 5, 6, 4 };

            ListNode l1 = ListNode.CreateListNode(nums);
            ListNode l2 = ListNode.CreateListNode(nums2);

            ReverseLinkedList.AddTwoNumbers(l1, l2);

        }


        [Fact]
        public void TestDeleteDuplicates2()
        {

            int[] nums = { 1, 1, 1, 2, 3 };

            ListNode l1 = ListNode.CreateListNode(nums);

            ReverseLinkedList.DeleteDuplicates2(l1);

        }

        [Fact]
        public void TestReverseKGroup()
        {
            int[] nums = { 1, 2, 3, 4, 5 };

            ListNode l1 = ListNode.CreateListNode(nums);
            ReverseLinkedList.ReverseKGroup(l1, 3);
        }

        [Fact]
        public void TestInsertionSortList()
        {
            int[] nums = { 4,2, 1, 3};

            ListNode l1 = ListNode.CreateListNode(nums);
            ReverseLinkedList.InsertionSortList(l1);
        }

        [Fact]
        public void TestSortList()
        {
            int[] nums = { 4, 2, 1, 3 };

            ListNode l1 = ListNode.CreateListNode(nums);
            ReverseLinkedList.SortList(l1);
        }

        [Fact]
        public void TestEvalRPN()
        {
            string[] nums = { "4","13","5","/","+"};
            ReverseLinkedList.EvalRPN(nums);
        }

        [Fact]
        public void TestSimplifyPath()
        {
            string str = "/home/a";
            ReverseLinkedList.SimplifyPath(str);
        }

        [Fact]
        public void TestBinaryTreePaths()
        {
            int?[]  nums =  { 1, 2, 3, null, 5 };
            TreeNode node = TreeNode.GenerateTreeNode(nums);

            List<string> LIST = BstLeetCode.BinaryTreePaths(node);
        }

        [Fact]
        public void TestLetterCombinations()
        {
            BackTracking.LetterCombinations("23");
        }

        [Fact]
        public void TestPermute()
        {
            BackTracking.Permute(new int[] { 1,2,3 });
        }

        [Fact]
        public void TestExist()
        {
            //char[][] board = new char[3][]
            //{
            //    new char[] { 'A','B','C','E' },
            //    new char[] { 'S','F','C','S' },
            //    new char[] { 'A','D','E','E' },
            //};
            char[][] board = new char[][]
            {
                new char[]{ 'a', 'a'}
            };
            BackTracking.Exist(board, "aa");
        }
        [Fact]
        public void TestNumberOfIslands()
        {
            char[][] board = new char[4][]
            {
                new char[] { '1','1','1','1','0' },
                new char[] { '1','1','0', '1','0' },
                new char[] { '1','1','1','0', '0' },
                new char[] { '0','0','0','0', '0' },
            };

            BackTracking.NoofIslands.NumIslands(board);
        }

        [Fact]
        public void TestNQueens()
        {
            BackTracking.Nqueens.SolveNQueens(4);
        }

        [Fact]
        public void TestSodudoSolver()
        {
            char[][] board = new char[9][] {
            new char[]{ '5', '3', '.', '.', '7', '.', '.', '.', '.' }, 
            new char[]{ '6','.','.','1','9','5','.','.','.' }, 
            new char[]{ '.','9','8','.','.','.','.','6','.' }, 
            new char[]{ '8','.','.','.','6','.','.','.','3' }, 
            new char[]{ '4','.','.','8','.','3','.','.','1' }, 
            new char[]{ '7','.','.','.','2','.','.','.','6'}, 
            new char[]{ '.','6','.','.','.','.','2','8','.' }, 
            new char[]{ '.','.','.','4','1','9','.','.','5' }, 
            new char[]{ '.','.','.','.','8','.','.','7','9' },
            };

            BackTracking.SudokuSolver.SolveSudoku(board);
        }

        [Fact]
        public void TestUniquePaths()
        {
            BackTracking.UniquePaths.UniquePaths1(3, 2);
        }

        [Fact]
        public void TestLevelOrderBottom()
        {
            int?[] nums = { 3, 9, 20, null, null, 15, 7 };
            TreeNode treeNode = TreeNode.GenerateTreeNode(nums);

            BstLeetCode.LevelOrderBottom(treeNode);
        }
    }
}
