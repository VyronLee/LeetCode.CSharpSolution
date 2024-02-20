// ------------------------------------------------------------
//         File: Solution0107.cs
//        Brief: Solution0107.cs
//
//       Author: VyronLee, lwz_jz@hotmail.com
//
//      Created: 2024-2-15 21:55
//    Copyright: Copyright (c) 2024, VyronLee
// ============================================================

//给你二叉树的根节点 root ，返回其节点值 自底向上的层序遍历 。 （即按从叶子节点所在层到根节点所在的层，逐层从左向右遍历）
//
//
//
// 示例 1：
//
//
//输入：root = [3,9,20,null,null,15,7]
//输出：[[15,7],[9,20],[3]]
//
//
// 示例 2：
//
//
//输入：root = [1]
//输出：[[1]]
//
//
// 示例 3：
//
//
//输入：root = []
//输出：[]
//
//
//
//
// 提示：
//
//
// 树中节点数目在范围 [0, 2000] 内
// -1000 <= Node.val <= 1000
//
//
// Related Topics 树 广度优先搜索 二叉树 👍 777 👎 0

using System.Collections.Generic;

namespace LeetCode
{
    public class Solution0107
    {
        public IList<IList<int>> LevelOrderBottom(TreeNode root) {
            var record = new List<IList<int>>();
            if (null != root) {
                Traversal(root, record, 0);
            }
            record.Reverse();
            return record;
        }

        private void Traversal(TreeNode root, List<IList<int>> result, int depth) {
            if (null == root) {
                return;
            }
            VisitNode(root, result, depth);
            Traversal(root.left, result, depth + 1);
            Traversal(root.right, result, depth + 1);
        }

        private void VisitNode(TreeNode root, List<IList<int>> result, int depth) {
            if (null == root) {
                return;
            }
            if (result.Count <= depth) {
                result.Add(new List<int>());
            }
            result[depth].Add(root.val);
        }
    }
}