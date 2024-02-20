// ------------------------------------------------------------
//         File: Solution0103.cs
//        Brief: Solution0103.cs
//
//       Author: VyronLee, lwz_jz@hotmail.com
//
//      Created: 2024-2-16 15:24
//    Copyright: Copyright (c) 2024, VyronLee
// ============================================================

//给你二叉树的根节点 root ，返回其节点值的 锯齿形层序遍历 。（即先从左往右，再从右往左进行下一层遍历，以此类推，层与层之间交替进行）。
//
//
//
// 示例 1：
//
//
//输入：root = [3,9,20,null,null,15,7]
//输出：[[3],[20,9],[15,7]]
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
// -100 <= Node.val <= 100
//
//
// Related Topics 树 广度优先搜索 二叉树 👍 853 👎 0

using System.Collections.Generic;

namespace LeetCode
{
    public class Solution0103
    {
        public IList<IList<int>> ZigzagLevelOrder(TreeNode root) {
            var record = new List<IList<int>>();
            if (null != root) {
                Traversal(root, record, 0);
            }
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

            if (depth % 2 != 0) {
                result[depth].Insert(0, root.val);
            }
            else {
                result[depth].Add(root.val);
            }
        }
    }
}