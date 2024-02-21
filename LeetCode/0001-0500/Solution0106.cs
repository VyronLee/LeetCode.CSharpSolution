// ------------------------------------------------------------
//         File: Solution0106.cs
//        Brief: Solution0106.cs
//
//       Author: VyronLee, lwz_jz@hotmail.com
//
//      Created: 2024-2-21 16:29
//    Copyright: Copyright (c) 2024, VyronLee
// ============================================================

//给定两个整数数组 inorder 和 postorder ，其中 inorder 是二叉树的中序遍历， postorder 是同一棵树的后序遍历，请你构造并
//返回这颗 二叉树 。
//
//
//
// 示例 1:
//
//
//输入：inorder = [9,3,15,20,7], postorder = [9,15,7,20,3]
//输出：[3,9,20,null,null,15,7]
//
//
// 示例 2:
//
//
//输入：inorder = [-1], postorder = [-1]
//输出：[-1]
//
//
//
//
// 提示:
//
//
// 1 <= inorder.length <= 3000
// postorder.length == inorder.length
// -3000 <= inorder[i], postorder[i] <= 3000
// inorder 和 postorder 都由 不同 的值组成
// postorder 中每一个值都在 inorder 中
// inorder 保证是树的中序遍历
// postorder 保证是树的后序遍历
//
//
// Related Topics 树 数组 哈希表 分治 二叉树 👍 1186 👎 0

using System.Collections.Generic;

namespace LeetCode
{
    public class Solution0106
    {
        public TreeNode BuildTree(int[] inorder, int[] postorder) {
            var inorderElements = new Dictionary<int, int>(inorder.Length);
            for (var i = 0; i < inorder.Length; i++) {
                inorderElements.Add(inorder[i], i);
            }
            return BuildTree(postorder, 0, postorder.Length - 1, inorderElements, 0, inorder.Length - 1);
        }

        private TreeNode BuildTree(int[] postorder, int postL, int postR, Dictionary<int, int> inorderElements, int inL, int inR) {
            if (postL > postR) {
                return null;
            }

            var inorderIndex = inorderElements[postorder[postR]];
            var node = new TreeNode(postorder[postR]) {
                left = BuildTree(postorder, postL, postR - inR + inorderIndex - 1, inorderElements, inL, inorderIndex - 1),
                right = BuildTree(postorder, postR - inR + inorderIndex, postR - 1, inorderElements, inorderIndex + 1, inR)
            };
            return node;
        }
    }
}