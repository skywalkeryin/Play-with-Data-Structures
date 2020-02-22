using System;
using System.Collections.Generic;
using System.Text;

namespace DS_MyLinkedList
{

    public class ListNode
    {
      public int val;
      public ListNode next;

        public ListNode()
        {
            
        }

        public ListNode(int x) { val = x; }
        public ListNode(int[] arr)
        {
            if (arr == null || arr.Length == 0)
            {
                throw new ArgumentNullException();
            }
            this.val = arr[0];
            ListNode cur = this;
            for (int i = 1; i < arr.Length; i++)
            {
                cur.next = new ListNode(arr[i]);
                cur = cur.next;
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            ListNode cur = this;
            while (cur != null)
            {
                sb.Append(cur.val + "->");
                cur = cur.next;
            }
            sb.Append("NULL");
            return sb.ToString();
        }

    }
 
    public class Remove_Linked_List_Elements
    {
        public static ListNode RemoveElements(ListNode head, int val, int depth)
        {
            string depthString = GenerateDepthStr(depth);
            Console.WriteLine(depthString +"call: remove " + val + " in " + head);

            if (head == null)
            {
                Console.WriteLine(depthString + "Return: " + "null");
                return head;
            }
            ListNode res = RemoveElements(head.next, val, depth + 1);
            Console.WriteLine(depthString + "After Remove: " + val + " : " + res);

            ListNode ret;
            if (head.val == val)
            {
                ret = res;
            }
            else
            {
                head.next = res;
                ret = head;
            }

            Console.WriteLine(depthString + "Return: " + ret);

            return ret;
  
        }

        public static string GenerateDepthStr(int depth)
        {
            string res = "";
            for (int i = 0; i <= depth; i++)
            {
                res += "--";
            }
            return res;
        }
    }
}
