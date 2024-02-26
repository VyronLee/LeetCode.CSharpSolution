// ------------------------------------------------------------
//         File: Solution0938.cs
//        Brief: Solution0938.cs
//
//       Author: VyronLee, lwz_jz@hotmail.com
//
//      Created: 2024-2-26 16:38
//    Copyright: Copyright (c) 2024, VyronLee
// ============================================================

//给定二叉搜索树的根结点 root，返回值位于范围 [low, high] 之间的所有结点的值的和。
//
//
//
// 示例 1：
//
//
//输入：root = [10,5,15,3,7,null,18], low = 7, high = 15
//输出：32
//
//
// 示例 2：
//
//
//输入：root = [10,5,15,3,7,13,18,1,null,6], low = 6, high = 10
//输出：23
//
//
//
//
// 提示：
//
//
// 树中节点数目在范围 [1, 2 * 10⁴] 内
// 1 <= Node.val <= 10⁵
// 1 <= low <= high <= 10⁵
// 所有 Node.val 互不相同
//
//
// Related Topics 树 深度优先搜索 二叉搜索树 二叉树 👍 360 👎 0

namespace LeetCode
{
    public class Solution0938
    {
        public int RangeSumBST(TreeNode root, int low, int high) {
            var sum = 0;
            DepthFirstSearch(root, low, high, ref sum);
            return sum;
        }

        private void DepthFirstSearch(TreeNode root, int low, int high, ref int sum) {
            if (null == root) {
                return;
            }
            if (root.val < low) {
                DepthFirstSearch(root.right, low, high, ref sum);
            }
            else if (root.val > high) {
                DepthFirstSearch(root.left, low, high, ref sum);
            }
            else {
                sum += root.val;
                DepthFirstSearch(root.right, low, high, ref sum);
                DepthFirstSearch(root.left, low, high, ref sum);
            }
        }
    }
}