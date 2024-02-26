// ------------------------------------------------------------
//         File: Solution0236.cs
//        Brief: Solution0236.cs
//
//       Author: VyronLee, lwz_jz@hotmail.com
//
//      Created: 2024-2-26 23:40
//    Copyright: Copyright (c) 2024, VyronLee
// ============================================================

//给定一个二叉树, 找到该树中两个指定节点的最近公共祖先。
//
// 百度百科中最近公共祖先的定义为：“对于有根树 T 的两个节点 p、q，最近公共祖先表示为一个节点 x，满足 x 是 p、q 的祖先且 x 的深度尽可能大（
//一个节点也可以是它自己的祖先）。”
//
//
//
// 示例 1：
//
//
//输入：root = [3,5,1,6,2,0,8,null,null,7,4], p = 5, q = 1
//输出：3
//解释：节点 5 和节点 1 的最近公共祖先是节点 3 。
//
//
// 示例 2：
//
//
//输入：root = [3,5,1,6,2,0,8,null,null,7,4], p = 5, q = 4
//输出：5
//解释：节点 5 和节点 4 的最近公共祖先是节点 5 。因为根据定义最近公共祖先节点可以为节点本身。
//
//
// 示例 3：
//
//
//输入：root = [1,2], p = 1, q = 2
//输出：1
//
//
//
//
// 提示：
//
//
// 树中节点数目在范围 [2, 10⁵] 内。
// -10⁹ <= Node.val <= 10⁹
// 所有 Node.val 互不相同 。
// p != q
// p 和 q 均存在于给定的二叉树中。
//
//
// Related Topics 树 深度优先搜索 二叉树 👍 2617 👎 0

using System.Collections.Generic;

namespace LeetCode
{
    public class Solution0236
    {
        public TreeNode LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q) {
            List<TreeNode> parentsP = new(), parentsQ = new();
            bool foundP = false, foundQ = false;
            GetAncestors(root, p, parentsP, ref foundP);
            GetAncestors(root, q, parentsQ, ref foundQ);
            return GetLowestCommonAncestor(parentsP, parentsQ);
        }

        private TreeNode GetLowestCommonAncestor(List<TreeNode> parentsP, List<TreeNode> parentsQ) {
            TreeNode ans = null;
            for (var i = 0; i < parentsP.Count && i < parentsQ.Count; i++) {
                if (parentsP[i] == parentsQ[i]) {
                    ans = parentsP[i];
                    continue;
                }
                break;
            }
            return ans;
        }

        private void GetAncestors(TreeNode root, TreeNode child, List<TreeNode> parents, ref bool found) {
            if (null == root || found) {
                return;
            }

            parents.Add(root);
            if (root == child) {
                found = true;
                return;
            }

            GetAncestors(root.left, child, parents, ref found);
            GetAncestors(root.right, child, parents, ref found);

            if (found) {
                return;
            }
            parents.RemoveAt(parents.Count-1);
        }
    }
}