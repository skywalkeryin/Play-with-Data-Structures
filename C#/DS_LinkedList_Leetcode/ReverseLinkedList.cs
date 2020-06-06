using System;
using System.Collections.Generic;
using System.Text;

namespace DS_LinkedList_Leetcode
{


    // Definition for singly-linked list.
    public class ListNode
    {
        public int val;
        public ListNode next;
        public ListNode(int val = 0, ListNode next = null)
        {
            this.val = val;
            this.next = next;
        }

        public static ListNode CreateListNode(int[] nums)
        {
            ListNode head = new ListNode(nums[0]);

            ListNode cur = head;
            for (int i = 1; i< nums.Length; i++)
            {
                cur.next = new ListNode(nums[i]);
                cur = cur.next;
            }
            return head;
        }


    }
    public class ReverseLinkedList
    {
        //Time complexity: o(n )
        public static ListNode ReverseBetween(ListNode head, int m, int n)
        {

            ListNode node = head;
            int i = 1;
            ListNode pre = null;

            if (m == 1)
            {
                head = Reverse(head, n - m + 1);
                return head;
            }
            else
            {  //n > 1
                while (node != null)
                {
                    if (i == m - 1)
                    {
                        pre = node;
                        pre.next = Reverse(pre.next, n - m + 1);
                        break;
                    }
                    node = node.next;
                    i++;
                }
                return head;
            }
        }
        // reverse 传入的listnode， 然后返回新的根
        private static ListNode Reverse(ListNode head, int length)
        {

            int counter = 0;

            ListNode curOriginal = head;
            ListNode pre = null;
            ListNode cur = head;

            while (cur != null && length > 0)
            {
                ListNode next = cur.next;

                cur.next = pre;

                pre = cur;
                cur = cur.next;

                length--;
            }

            curOriginal.next = cur;

            return pre;

        }


        #region "83. Remove Duplicates from Sorted List"
        // Time complexity: o(n)
        public static ListNode DeleteDuplicates(ListNode head)
        {

            ListNode cur = head;
            while (cur != null)
            {
                cur = deleteNodes(cur);
                cur = cur.next;
            }
            return head;
        }
        // 删除和head 的val 相同的节点， 并且返回新的head
        private static ListNode deleteNodes(ListNode head)
        {                                                              
            int deleteValue = head.val;
            ListNode cur = head;
            while (cur != null && cur.next != null)
            {
                ListNode next = cur.next;
                if (cur.val == next.val  && cur.val == deleteValue)
                {
                    cur.next = next.next;
                }
                else
                {
                    break;
                }
                
            }
            return head;
        }
        #endregion


        #region "Add Two Numbers II"
        public static ListNode AddTwoNumbers(ListNode l1, ListNode l2)
        {
            l1 = reverse(l1);
            l2 = reverse(l2);

            ListNode pre = new ListNode(-1);
            int carry = 0;

            while (l1 != null || l2 != null || carry > 0)
            {
                int sum = 0;
                sum += l1 != null ? l1.val : 0;
                sum += l2 != null ? l2.val : 0;
                sum += carry;

                if (l1 != null)
                {
                    l1 = l1.next;
                }
                if (l2 != null)
                {
                    l2 = l2.next;
                }

                carry = sum / 10;
                sum = sum % 10;

                pre.next = new ListNode(sum);
                pre = pre.next;
            }

            return pre.next;
        }

        private static ListNode reverse(ListNode l1)
        {
            ListNode pre = null;
            ListNode cur = l1;

            while (cur != null)
            {
                ListNode next = cur.next;

                cur.next = pre;

                pre = cur;
                cur = next;
            }
            return pre;
        }
        #endregion

        #region "82. Remove Duplicates from Sorted List II"
        public static ListNode DeleteDuplicates2(ListNode head)
        {
            ListNode dummyHead = new ListNode(0);
            ListNode pre = dummyHead;
            dummyHead.next = head;

            ListNode cur = head;
            int dupVal = 0;
            while (cur != null)
            {

                if ((cur.next != null && cur.val == cur.next.val) || cur.val == dupVal)
                {
                    dupVal = cur.val;
                    pre.next = cur.next;
                    cur = cur.next;
                }
                else
                {
                    pre = cur;
                    cur = cur.next;
                }
            }

            return head;
        }
        #endregion

        #region ""
        public static ListNode ReverseKGroup(ListNode head, int k)
        {

            if (k == 1)
            {
                return head;
            }

            ListNode cur = head;
            ListNode ret = getKGroupHead(head, k);

            while (cur != null)
            {
                // 判断cur是否符合k group， 是的话进行reverse操作
                if (valiaKGroupNodes(cur, k))
                {
                    ListNode lastNode = Reverse2(cur, k);
                    // 下一个kgroup 没排序的第一个节点
                    cur = lastNode.next;
                    // 连接两个kgroup
                    ListNode firstNode = getKGroupHead(cur, k);
                    lastNode.next = firstNode;
                }
                else
                {
                    break;
                }
            }
            return ret;
        }
        private static ListNode getKGroupHead(ListNode node, int k)
        {
            ListNode ret = node;
            int n = k;
            // 寻找第一个反序后的第一个节点
            while (n > 1 && ret != null)
            {              
                ret = ret.next;
                n--;
            }
            // 如果不够k个node， 返回原始结点
            return ret == null ? node : ret;
        }
        private static bool valiaKGroupNodes(ListNode node, int k)
        {
            //  判断结点数是否大于等于k
            ListNode p = node;
            int n = k;
            while (p != null && n > 1)
            {
                p = p.next;
                n--;
            }
            if (p == null)
            {
                return false;
            }
            return true;
        }
        // Return the last node of kGroup after reversed
        private static ListNode Reverse2(ListNode head, int k)
        {         
            ListNode pre = head;
            ListNode cur = head.next;

            // reverse的过程， 执行k-1次
            while (cur != null && k > 1)
            {
                ListNode next = cur.next;
                cur.next = pre;
                k--;
                pre = cur;
                cur = next;
            }
            // pre为新的头结点
            // cur 为拍完knode 顺序后的第一个元素
            // head 为 the last node of kGroup after reversed
            head.next = cur;
            return head;
        }
        #endregion


        #region ""
        public static ListNode InsertionSortList(ListNode head)
        {

            ListNode dummyHead = new ListNode(-1);
            dummyHead.next = head;

            ListNode pre = dummyHead.next;
            while (pre.next != null)
            {
                // 当前的value
                int val = pre.next.val;
                ListNode next = pre.next.next;
                //
                ListNode pre1;
                for (pre1 = dummyHead; pre1 != pre; pre1 = pre1.next)
                {

                    if (pre1.next.val > val)
                    {

                        ListNode swapNode = pre.next;
                        ListNode pj = pre1.next;

                        pre1.next = swapNode;
                        swapNode.next = pj;
                        pre.next = next;

                        break;
                    }
                }
              
                    pre = pre.next;
                
            }
            return dummyHead.next;

        }
        #endregion
    }
}
