using DS_LinkedList_Leetcode;
using System;
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
    }
}
