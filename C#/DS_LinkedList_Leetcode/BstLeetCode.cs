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

        #region "107. Binary Tree Level Order Traversal II"

        public static IList<IList<int>> LevelOrderBottom(TreeNode root)
        {

            IList<IList<int>> result = new List<IList<int>>();
            if (root == null)
            {
                return result;
            }

            Queue<Tuple<TreeNode, int>> queue = new Queue<Tuple<TreeNode, int>>();
            queue.Enqueue(new Tuple<TreeNode, int>(root, 0));

            while (queue.Count > 0)
            {
                (TreeNode node, int level) = queue.Dequeue();

                if (level == result.Count)
                {
                    result.Add(new List<int>());
                }

                if (node != null)
                {
                    result[level].Add(node.val);
                }
                if (node.left != null)
                {
                    queue.Enqueue(new Tuple<TreeNode, int>(node.left, level + 1));
                }
                if (node.right != null)
                {
                    queue.Enqueue(new Tuple<TreeNode, int>(node.right, level + 1));
                }
            }
            reverse(result);

            return result;
        }

        private static void reverse(IList<IList<int>> data)
        {

            int i = 0;
            int j = data.Count - 1;

            while (j > i)
            {
                swap(data, i, j);
            }
        }
        private static void swap(IList<IList<int>> data, int i, int j)
        {
            IList<int> temp = data[i];

            data[i] = data[j];
            data[j] = temp;
        }
        #endregion

    }
}
