/******************************************************************
* 命名空间名称: LeetCodeOJ154
* 文件名: BinaryTree
* CLR版本: 4.0.30319.17929
* 创建者: H92774
* 创建时间: 2015/7/3 14:42:06
******************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCodeOJ154
{
    partial class Solution
    {
        /*
       Given two binary trees, write a function to check if they are equal or not.
       Two binary trees are considered equal if they are structurally identical and the nodes have the same value.
       */
        public Boolean IsSameTree(TreeNode p, TreeNode q)
        {
            if (p == null && q == null)
            {
                return true;
            }

            if (p == null || q == null)
            {
                return false;
            }

            if (p.val == q.val)
            {
                return IsSameTree(p.left, q.left) && IsSameTree(p.right, q.right);
            }

            return false;
        }


        /*
        Given a binary tree, check whether it is a mirror of itself (ie, symmetric around its center).

        For example, this binary tree is symmetric:

            1
            / \
            2   2
            / \ / \
        3  4 4  3
        But the following is not:
            1
            / \
            2   2
            \   \
            3    3
        Note:
        Bonus points if you could solve it both recursively and iteratively.

        confused what "{1,#,2,3}" means? > read more on how binary tree is serialized on OJ.


        OJ's Binary Tree Serialization:
        The serialization of a binary tree follows a level order traversal, where '#' signifies a path terminator where no node exists below.

        Here's an example:
            1
            / \
            2   3
            /
            4
            \
                5
        The above binary tree is serialized as "{1,2,3,#,#,4,#,#,5}".
        */
        public Boolean IsSymmetric(TreeNode root)
        {
            if (root == null)
            {
                return true;
            }

            return IsSymmetric2(root.left, root.right);
        }
        private Boolean IsSymmetric2(TreeNode p, TreeNode q)
        {
            if (p == null && q == null)
            {
                return true;
            }

            if (p == null || q == null)
            {
                return false;
            }

            if (p.val == q.val)
            {
                return IsSymmetric2(p.left, q.right) && IsSymmetric2(p.right, q.left);
            }

            return false;
        }


        /*
        Given a binary tree, return the level order traversal of its nodes' values. (ie, from left to right, level by level).

        For example:
        Given binary tree {3,9,20,#,#,15,7},
            3
            / \
            9  20
            /  \
            15   7
        return its level order traversal as:
        [
            [3],
            [9,20],
            [15,7]
        ]
        */
        public IList<IList<int>> LevelOrder(TreeNode root)
        {
            var result = new List<IList<int>>();

            if (root == null)
            {
                return result;
            }

            var queue = new Queue<KeyValuePair<TreeNode, int>>();
            queue.Enqueue(new KeyValuePair<TreeNode, int>(root, 0));

            while (queue.Count > 0)
            {
                var kvp = queue.Dequeue();
                var node = kvp.Key;
                var level = kvp.Value;

                if (level >= result.Count)
                {
                    result.Add(new List<int>());
                }
                result[level].Add(node.val);

                if (node.left != null) queue.Enqueue(new KeyValuePair<TreeNode, int>(node.left, level + 1));
                if (node.right != null) queue.Enqueue(new KeyValuePair<TreeNode, int>(node.right, level + 1));
            }

            return result;
        }

        public IList<IList<int>> LevelOrder2(TreeNode root)
        {
            IList<IList<int>> result = new List<IList<int>>();
            if (root == null)
            {
                return result;
            }

            return result;
        }

    }
    public class TreeNode
    {
        public int val;
        public TreeNode left;
        public TreeNode right;
        public TreeNode(int x) { val = x; }
    }

}
