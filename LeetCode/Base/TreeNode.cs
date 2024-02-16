// ------------------------------------------------------------
//         File: TreeNode.cs
//        Brief: TreeNode.cs
//
//       Author: VyronLee, lwz_jz@hotmail.com
//
//      Created: 2024-2-16 15:26
//    Copyright: Copyright (c) 2024, VyronLee
// ============================================================

namespace LeetCode
{
    public class TreeNode
    {
        public int val;
        public TreeNode left;
        public TreeNode right;

        public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null) {
            this.val = val;
            this.left = left;
            this.right = right;
        }
    }

}