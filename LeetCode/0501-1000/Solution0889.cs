// ------------------------------------------------------------
//         File: Solution0889.cs
//        Brief: Solution0889.cs
//
//       Author: VyronLee, lwz_jz@hotmail.com
//
//      Created: 2024-2-22 22:59
//    Copyright: Copyright (c) 2024, VyronLee
// ============================================================

//给定两个整数数组，preorder 和 postorder ，其中 preorder 是一个具有 无重复 值的二叉树的前序遍历，postorder 是同一棵
//树的后序遍历，重构并返回二叉树。
//
// 如果存在多个答案，您可以返回其中 任何 一个。
//
//
//
// 示例 1：
//
//
//
//
//输入：preorder = [1,2,4,5,3,6,7], postorder = [4,5,2,6,7,3,1]
//输出：[1,2,3,4,5,6,7]
//
//
// 示例 2:
//
//
//输入: preorder = [1], postorder = [1]
//输出: [1]
//
//
//
//
// 提示：
//
//
// 1 <= preorder.length <= 30
// 1 <= preorder[i] <= preorder.length
// preorder 中所有值都 不同
// postorder.length == preorder.length
// 1 <= postorder[i] <= postorder.length
// postorder 中所有值都 不同
// 保证 preorder 和 postorder 是同一棵二叉树的前序遍历和后序遍历
//
//
// Related Topics 树 数组 哈希表 分治 二叉树 👍 370 👎 0

using System.Collections.Generic;

namespace LeetCode
{
    public class Solution0889
    {
        public TreeNode ConstructFromPrePost(int[] preorder, int[] postorder) {
            var postorderElements = new Dictionary<int, int>(postorder.Length);
            for (var i = 0; i < postorder.Length; i++) {
                postorderElements.Add(postorder[i], i);
            }

            var root = new TreeNode(preorder[0]);
            var curr = root;
            var stack = new Stack<TreeNode>(preorder.Length);
            stack.Push(curr);
            for (var i = 1; i < preorder.Length && stack.Count > 0; ) {
                var val = preorder[i];
                curr = stack.Peek();
                if (IsChildOf(curr.val, val)) {
                    var child = new TreeNode(val);
                    if (curr.left == null) {
                        curr.left = child;
                    }
                    else if (curr.right == null) {
                        curr.right = child;
                    }
                    stack.Push(child);
                    i++;
                }
                else {
                    stack.Pop();
                }
            }
            return root;

            bool IsChildOf(int rootVal, int childVal) {
                var rootIdx = postorderElements[rootVal];
                var childIdx = postorderElements[childVal];
                return childIdx < rootIdx;
            }
        }
    }
}