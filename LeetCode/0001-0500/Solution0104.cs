// ------------------------------------------------------------
//         File: Solution0104.cs
//        Brief: Solution0104.cs
//
//       Author: VyronLee, lwz_jz@hotmail.com
//
//      Created: 2024-2-25 19:44
//    Copyright: Copyright (c) 2024, VyronLee
// ============================================================

//给定一个二叉树 root ，返回其最大深度。
//
// 二叉树的 最大深度 是指从根节点到最远叶子节点的最长路径上的节点数。
//
//
//
// 示例 1：
//
//
//
//
//
//
//输入：root = [3,9,20,null,null,15,7]
//输出：3
//
//
// 示例 2：
//
//
//输入：root = [1,null,2]
//输出：2
//
//
//
//
// 提示：
//
//
// 树中节点的数量在 [0, 10⁴] 区间内。
// -100 <= Node.val <= 100
//
//
// Related Topics 树 深度优先搜索 广度优先搜索 二叉树 👍 1782 👎 0

using System;

namespace LeetCode
{
    public class Solution0104
    {
        public int MaxDepth(TreeNode root) {
            var max = 0;
            DepthFirstSearch(root, 1, ref max);
            return max;
        }

        private void DepthFirstSearch(TreeNode root, int depth, ref int max) {
            if (null == root) {
                return;
            }
            max = Math.Max(max, depth);
            DepthFirstSearch(root.left, depth + 1, ref max);
            DepthFirstSearch(root.right, depth + 1, ref max);
        }
    }
}