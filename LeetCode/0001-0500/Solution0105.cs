// ------------------------------------------------------------
//         File: Solution0105.cs
//        Brief: Solution0105.cs
//
//       Author: VyronLee, lwz_jz@hotmail.com
//
//      Created: 2024-2-20 12:13
//    Copyright: Copyright (c) 2024, VyronLee
// ============================================================

//给定两个整数数组 preorder 和 inorder ，其中 preorder 是二叉树的先序遍历， inorder 是同一棵树的中序遍历，请构造二叉树并
//返回其根节点。
//
//
//
// 示例 1:
//
//
//输入: preorder = [3,9,20,15,7], inorder = [9,3,15,20,7]
//输出: [3,9,20,null,null,15,7]
//
//
// 示例 2:
//
//
//输入: preorder = [-1], inorder = [-1]
//输出: [-1]
//
//
//
//
// 提示:
//
//
// 1 <= preorder.length <= 3000
// inorder.length == preorder.length
// -3000 <= preorder[i], inorder[i] <= 3000
// preorder 和 inorder 均 无重复 元素
// inorder 均出现在 preorder
// preorder 保证 为二叉树的前序遍历序列
// inorder 保证 为二叉树的中序遍历序列
//
//
// Related Topics 树 数组 哈希表 分治 二叉树 👍 2226 👎 0

using System.Collections.Generic;

namespace LeetCode
{
    public class Solution0105
    {
        public TreeNode BuildTree(int[] preorder, int[] inorder) {
            var inorderElements = new Dictionary<int, int>(inorder.Length);
            for (var i = 0; i < inorder.Length; i++) {
                inorderElements.Add(inorder[i], i);
            }
            return BuildTree(preorder, 0, preorder.Length - 1, inorderElements, 0, inorder.Length - 1);
        }

        private TreeNode BuildTree(int[] preorder, int preLeft, int preRight, Dictionary<int, int> inorderElements, int inLeft, int inRight) {
            if (preLeft > preRight) {
                return null;
            }
            var root = new TreeNode(preorder[preLeft]);
            var inorderIndex = inorderElements[preorder[preLeft]];
            root.left = BuildTree(preorder, preLeft + 1, preLeft + inorderIndex - inLeft, inorderElements, inLeft, inorderIndex - 1);
            root.right = BuildTree(preorder, preLeft + inorderIndex - inLeft + 1, preRight, inorderElements, inorderIndex + 1, inRight);
            return root;
        }
    }
}