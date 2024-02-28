// ------------------------------------------------------------
//         File: Solution0199.cs
//        Brief: Solution0199.cs
//
//       Author: VyronLee, lwz_jz@hotmail.com
//
//      Created: 2024-2-28 21:32
//    Copyright: Copyright (c) 2024, VyronLee
// ============================================================

//给定一个二叉树的 根节点 root，想象自己站在它的右侧，按照从顶部到底部的顺序，返回从右侧所能看到的节点值。
//
//
//
// 示例 1:
//
//
//
//
//输入: [1,2,3,null,5,null,4]
//输出: [1,3,4]
//
//
// 示例 2:
//
//
//输入: [1,null,3]
//输出: [1,3]
//
//
// 示例 3:
//
//
//输入: []
//输出: []
//
//
//
//
// 提示:
//
//
// 二叉树的节点个数的范围是 [0,100]
//
// -100 <= Node.val <= 100
//
//
// Related Topics 树 深度优先搜索 广度优先搜索 二叉树 👍 1036 👎 0

using System.Collections.Generic;

namespace LeetCode
{
    public class Solution0199
    {
        public IList<int> RightSideView(TreeNode root) {
            var ans = new List<int>();
            DFS(root, ans, 0);
            return ans;
        }

        private void DFS(TreeNode root, List<int> ans, int depth) {
            if (null == root) {
                return;
            }
            if (depth >= ans.Count) {
                ans.Add(root.val);
            }
            DFS(root.right, ans, depth+1);
            DFS(root.left, ans, depth+1);
        }
    }
}