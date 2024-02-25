// ------------------------------------------------------------
//         File: Solution0437.cs
//        Brief: Solution0437.cs
//
//       Author: VyronLee, lwz_jz@hotmail.com
//
//      Created: 2024-2-25 20:24
//    Copyright: Copyright (c) 2024, VyronLee
// ============================================================

//给定一个二叉树的根节点 root ，和一个整数 targetSum ，求该二叉树里节点值之和等于 targetSum 的 路径 的数目。
//
// 路径 不需要从根节点开始，也不需要在叶子节点结束，但是路径方向必须是向下的（只能从父节点到子节点）。
//
//
//
// 示例 1：
//
//
//
//
//输入：root = [10,5,-3,3,2,null,11,3,-2,null,1], targetSum = 8
//输出：3
//解释：和等于 8 的路径有 3 条，如图所示。
//
//
// 示例 2：
//
//
//输入：root = [5,4,8,11,null,13,4,7,2,null,null,5,1], targetSum = 22
//输出：3
//
//
//
//
// 提示:
//
//
// 二叉树的节点个数的范围是 [0,1000]
//
// -10⁹ <= Node.val <= 10⁹
// -1000 <= targetSum <= 1000
//
//
// Related Topics 树 深度优先搜索 二叉树 👍 1807 👎 0

namespace LeetCode
{
    public class Solution0437
    {
        public int PathSum(TreeNode root, int targetSum) {
            if (root == null) {
                return 0;
            }
            return PathSum(root, targetSum, 0L)
                 + PathSum(root.left, targetSum)
                 + PathSum(root.right, targetSum);
        }

        private int PathSum(TreeNode root, int targetSum, long depthSum) {
            if (root == null) {
                return 0;
            }
            depthSum += root.val;

            return (depthSum == targetSum ? 1 : 0)
                   + PathSum(root.left, targetSum, depthSum)
                   + PathSum(root.right, targetSum, depthSum);
        }
    }
}