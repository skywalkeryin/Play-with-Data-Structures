using System;
using System.Collections.Generic;
using System.Text;

namespace DS_LinkedList_Leetcode
{
    public class TreeNode
    {
      public int val;
      public TreeNode left;
      public TreeNode right;
      public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
        {
            this.val = val;
            this.left = left;
            this.right = right;
        }
        public static TreeNode GenerateTreeNode(int?[] nums)
        {
           
            TreeNode root = new TreeNode();

            root = insertLevelOrder(root, nums, 0);
            return root;
        }

        private static TreeNode insertLevelOrder(TreeNode root, int?[] nums, int i)
        {
            if (i >= nums.Length || nums[i] == null)
            {
                return null;
            }

             root = new TreeNode(nums[i].Value);
             root.left = insertLevelOrder(root.left, nums, i * 2 + 1);
             root.right = insertLevelOrder(root.right, nums, i * 2 + 2);
            return root;
        }
        
     }
    public  class BstLeetCode
    {
        #region "257. Binary Tree Paths"
        public static List<string> BinaryTreePaths(TreeNode root)
        {
            List<string> res = new List<string>();
            if (root == null)
            {
                return res;
            }
            if (root.left == null && root.right == null)
            {
                res.Add(root.val.ToString());
            }
            List<string> lefts = BinaryTreePaths(root.left);
            for (int i = 0; i < lefts.Count; i++)
            {
                res.Add(root.val.ToString() + "->" + lefts[i]);
            }

            List<string> rights = BinaryTreePaths(root.right);
            for (int i = 0; i < rights.Count; i++)
            {
                res.Add(root.val.ToString() + "->" + rights[i]);
            }

            return res;
        }
        #endregion

    }
}
