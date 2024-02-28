// ------------------------------------------------------------
//         File: Solution1161.cs
//        Brief: Solution1161.cs
//
//       Author: VyronLee, lwz_jz@hotmail.com
//
//      Created: 2024-2-28 22:2
//    Copyright: Copyright (c) 2024, VyronLee
// ============================================================

//给你一个二叉树的根节点 root。设根节点位于二叉树的第 1 层，而根节点的子节点位于第 2 层，依此类推。
//
// 请返回层内元素之和 最大 的那几层（可能只有一层）的层号，并返回其中 最小 的那个。
//
//
//
// 示例 1：
//
//
//
//
//输入：root = [1,7,0,7,-8,null,null]
//输出：2
//解释：
//第 1 层各元素之和为 1，
//第 2 层各元素之和为 7 + 0 = 7，
//第 3 层各元素之和为 7 + -8 = -1，
//所以我们返回第 2 层的层号，它的层内元素之和最大。
//
//
// 示例 2：
//
//
//输入：root = [989,null,10250,98693,-89388,null,null,null,-32127]
//输出：2
//
//
//
//
// 提示：
//
//
// 树中的节点数在
// [1, 10⁴]范围内
//
// -10⁵ <= Node.val <= 10⁵
//
//
// Related Topics 树 深度优先搜索 广度优先搜索 二叉树 👍 131 👎 0

using System.Collections.Generic;

namespace LeetCode
{
    public class Solution1161
    {
        public int MaxLevelSum(TreeNode root) {
            var (max, depth, maxDepth) = (int.MinValue, 1, 1);
            var queue1 = new List<TreeNode>(1000);
            var queue2 = new List<TreeNode>(1000);
            queue1.Add(root);
            while (queue1.Count > 0) {
                var sum = 0;
                for (var i = 0; i < queue1.Count; i++) {
                    sum += queue1[i].val;
                    queue2.Add(queue1[i]);
                }
                if (sum > max) {
                    max = sum;
                    maxDepth = depth;
                }

                queue1.Clear();
                for (var i = 0; i < queue2.Count; i++) {
                    var treeNode = queue2[i];
                    if (treeNode.left != null) {
                        queue1.Add(treeNode.left);
                    }
                    if (treeNode.right != null) {
                        queue1.Add(treeNode.right);
                    }
                }
                queue2.Clear();

                depth++;
            }
            return maxDepth;
        }
    }
}