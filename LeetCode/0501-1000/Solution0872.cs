// ------------------------------------------------------------
//         File: Solution0872.cs
//        Brief: Solution0872.cs
//
//       Author: VyronLee, lwz_jz@hotmail.com
//
//      Created: 2024-2-25 19:54
//    Copyright: Copyright (c) 2024, VyronLee
// ============================================================

//请考虑一棵二叉树上所有的叶子，这些叶子的值按从左到右的顺序排列形成一个 叶值序列 。
//
//
//
// 举个例子，如上图所示，给定一棵叶值序列为 (6, 7, 4, 9, 8) 的树。
//
// 如果有两棵二叉树的叶值序列是相同，那么我们就认为它们是 叶相似 的。
//
// 如果给定的两个根结点分别为 root1 和 root2 的树是叶相似的，则返回 true；否则返回 false 。
//
//
//
// 示例 1：
//
//
//
//
//输入：root1 = [3,5,1,6,2,9,8,null,null,7,4], root2 = [3,5,1,6,7,4,2,null,null,
//null,null,null,null,9,8]
//输出：true
//
//
// 示例 2：
//
//
//
//
//输入：root1 = [1,2,3], root2 = [1,3,2]
//输出：false
//
//
//
//
// 提示：
//
//
// 给定的两棵树结点数在 [1, 200] 范围内
// 给定的两棵树上的值在 [0, 200] 范围内
//
//
// Related Topics 树 深度优先搜索 二叉树 👍 228 👎 0

using System.Collections.Generic;
using System.Linq;

namespace LeetCode
{
    public class Solution0872
    {
        public bool LeafSimilar(TreeNode root1, TreeNode root2) {
            var leafs1 = new List<int>();
            var leafs2 = new List<int>();
            GetLeafs(root1, leafs1);
            GetLeafs(root2, leafs2);
            return leafs1.SequenceEqual(leafs2);
        }

        private void GetLeafs(TreeNode root, List<int> result) {
            if (root == null) {
                return;
            }
            if (root.left == null && root.right == null) {
                result.Add(root.val);
                return;
            }
            GetLeafs(root.left, result);
            GetLeafs(root.right, result);
        }
    }
}