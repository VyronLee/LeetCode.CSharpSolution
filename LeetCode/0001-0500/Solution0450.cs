// ------------------------------------------------------------
//         File: Solution0450.cs
//        Brief: Solution0450.cs
//
//       Author: VyronLee, lwz_jz@hotmail.com
//
//      Created: 2024-2-28 23:44
//    Copyright: Copyright (c) 2024, VyronLee
// ============================================================

//给定一个二叉搜索树的根节点 root 和一个值 key，删除二叉搜索树中的 key 对应的节点，并保证二叉搜索树的性质不变。返回二叉搜索树（有可能被更新）的
//根节点的引用。
//
// 一般来说，删除节点可分为两个步骤：
//
//
// 首先找到需要删除的节点；
// 如果找到了，删除它。
//
//
//
//
// 示例 1:
//
//
//
//
//输入：root = [5,3,6,2,4,null,7], key = 3
//输出：[5,4,6,2,null,null,7]
//解释：给定需要删除的节点值是 3，所以我们首先找到 3 这个节点，然后删除它。
//一个正确的答案是 [5,4,6,2,null,null,7], 如下图所示。
//另一个正确答案是 [5,2,6,null,4,null,7]。
//
//
//
//
// 示例 2:
//
//
//输入: root = [5,3,6,2,4,null,7], key = 0
//输出: [5,3,6,2,4,null,7]
//解释: 二叉树不包含值为 0 的节点
//
//
// 示例 3:
//
//
//输入: root = [], key = 0
//输出: []
//
//
//
// 提示:
//
//
// 节点数的范围 [0, 10⁴].
// -10⁵ <= Node.val <= 10⁵
// 节点值唯一
// root 是合法的二叉搜索树
// -10⁵ <= key <= 10⁵
//
//
//
//
// 进阶： 要求算法时间复杂度为 O(h)，h 为树的高度。
//
// Related Topics 树 二叉搜索树 二叉树 👍 1315 👎 0

namespace LeetCode
{
    public class Solution0450
    {
        public TreeNode DeleteNode(TreeNode root, int key) {
            if (root == null) {
                return null;
            }

            var prev = new TreeNode(int.MaxValue) {
                left = root
            };
            var prevOrigin = prev;

            var curr = root;
            while (curr != null) {
                if (curr.val == key) {
                    break;
                }
                if (curr.val > key) {
                    (prev, curr) = (curr, curr.left);
                }
                else {
                    (prev, curr) = (curr, curr.right);
                }
            }

            if (null == curr) {
                return root;
            }

            TreeNode replace;
            if (curr.left == null && curr.right == null) {
                replace = null;
            }
            else if (curr.left == null) {
                replace = curr.right;
            }
            else if (curr.right == null) {
                replace = curr.left;
            }
            else {
                var (parent, node) = ((TreeNode) null, curr.right);
                while (node.left != null) {
                    parent = node;
                    node = node.left;
                }
                if (parent != null) {
                    parent.left = node.right;
                }
                if (curr.right != node) {
                    node.right = curr.right;
                }
                node.left = curr.left;
                replace = node;
            }

            if (prev.val > key) {
                prev.left = replace;
            }
            else {
                prev.right = replace;
            }
            return prevOrigin.left;
        }
    }
}