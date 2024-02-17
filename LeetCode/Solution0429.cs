// ------------------------------------------------------------
//         File: Solution0429.cs
//        Brief: Solution0429.cs
//
//       Author: VyronLee, lwz_jz@hotmail.com
//
//      Created: 2024-2-17 13:35
//    Copyright: Copyright (c) 2024, VyronLee
// ============================================================

//给定一个 N 叉树，返回其节点值的层序遍历。（即从左到右，逐层遍历）。
//
// 树的序列化输入是用层序遍历，每组子节点都由 null 值分隔（参见示例）。
//
//
//
// 示例 1：
//
//
//
//
//输入：root = [1,null,3,2,4,null,5,6]
//输出：[[1],[3,2,4],[5,6]]
//
//
// 示例 2：
//
//
//
//
//输入：root = [1,null,2,3,4,5,null,null,6,7,null,8,null,9,10,null,null,11,null,12,
//null,13,null,null,14]
//输出：[[1],[2,3,4,5],[6,7,8,9,10],[11,12,13],[14]]
//
//
//
//
// 提示：
//
//
// 树的高度不会超过 1000
// 树的节点总数在 [0, 10^4] 之间
//
//
// Related Topics 树 广度优先搜索 👍 440 👎 0

using System.Collections.Generic;

namespace LeetCode
{
    public class Solution0429
    {
        public IList<IList<int>> LevelOrder(Node root) {
            var record = new List<IList<int>>();
            if (null != root) {
                Traversal(root, record, 0);
            }
            return record;
        }

        private void Traversal(Node root, List<IList<int>> result, int depth) {
            if (null == root) {
                return;
            }
            VisitNode(root, result, depth);

            foreach (var child in root.children) {
                Traversal(child, result, depth + 1);
            }
        }

        private void VisitNode(Node root, List<IList<int>> result, int depth) {
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