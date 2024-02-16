// ------------------------------------------------------------
//         File: ListNode.cs
//        Brief: ListNode.cs
//
//       Author: VyronLee, lwz_jz@hotmail.com
//
//      Created: 2024-2-16 18:51
//    Copyright: Copyright (c) 2024, VyronLee
// ============================================================

namespace LeetCode
{
    public class ListNode
    {
        public int val;
        public ListNode next;

        public ListNode(int val = 0, ListNode next = null) {
            this.val = val;
            this.next = next;
        }
    }
}