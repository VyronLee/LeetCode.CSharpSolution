// ------------------------------------------------------------
//         File: Solution0700.cs
//        Brief: Solution0700.cs
//
//       Author: VyronLee, lwz_jz@hotmail.com
//
//      Created: 2024-2-28 23:36
//    Copyright: Copyright (c) 2024, VyronLee
// ============================================================

//给定二叉搜索树（BST）的根节点
// root 和一个整数值
// val。
//
// 你需要在 BST 中找到节点值等于 val 的节点。 返回以该节点为根的子树。 如果节点不存在，则返回
// null 。
//
//
//
// 示例 1:
//
//
//
//
//
//输入：root = [4,2,7,1,3], val = 2
//输出：[2,1,3]
//
//
// 示例 2:
//
//
//输入：root = [4,2,7,1,3], val = 5
//输出：[]
//
//
//
//
// 提示：
//
//
// 树中节点数在 [1, 5000] 范围内
// 1 <= Node.val <= 10⁷
// root 是二叉搜索树
// 1 <= val <= 10⁷
//
//
// Related Topics 树 二叉搜索树 二叉树 👍 461 👎 0

namespace LeetCode
{
    public class Solution0700
    {
        public TreeNode SearchBST(TreeNode root, int val) {
            if (null == root) {
                return null;
            }
            if (root.val == val) {
                return root;
            }
            if (root.val < val) {
                return SearchBST(root.right, val);
            }
            return SearchBST(root.left, val);
        }
    }
}