// ------------------------------------------------------------
//         File: Solution0002.cs
//        Brief: Solution0002.cs
//
//       Author: VyronLee, lwz_jz@hotmail.com
//
//      Created: 2024-2-15 21:55
//    Copyright: Copyright (c) 2024, VyronLee
// ============================================================

//给你两个 非空 的链表，表示两个非负的整数。它们每位数字都是按照 逆序 的方式存储的，并且每个节点只能存储 一位 数字。
//
// 请你将两个数相加，并以相同形式返回一个表示和的链表。
//
// 你可以假设除了数字 0 之外，这两个数都不会以 0 开头。
//
//
//
// 示例 1：
//
//
//输入：l1 = [2,4,3], l2 = [5,6,4]
//输出：[7,0,8]
//解释：342 + 465 = 807.
//
//
// 示例 2：
//
//
//输入：l1 = [0], l2 = [0]
//输出：[0]
//
//
// 示例 3：
//
//
//输入：l1 = [9,9,9,9,9,9,9], l2 = [9,9,9,9]
//输出：[8,9,9,9,0,0,0,1]
//
//
//
//
// 提示：
//
//
// 每个链表中的节点数在范围 [1, 100] 内
// 0 <= Node.val <= 9
// 题目数据保证列表表示的数字不含前导零
//
//
// Related Topics 递归 链表 数学 👍 10382 👎 0


public class ListNode
{
    public int val;
    public ListNode next;
    public ListNode(int val=0, ListNode next=null) {
        this.val = val;
        this.next = next;
    }
}

namespace LeetCode
{
    public class Solution0002
    {
        public ListNode AddTwoNumbers(ListNode l1, ListNode l2) {
            var root = new ListNode();
            var curr = root;
            var carry = 0;
            do {
                var val = 0;
                val += carry;
                val += l1?.val ?? 0;
                val += l2?.val ?? 0;

                curr.val = val % 10;
                carry = val >= 10 ? 1 : 0;

                l1 = l1?.next;
                l2 = l2?.next;

                if (null == l1 && null == l2) {
                    break;
                }
                var prev = curr;
                curr = prev.next = new ListNode();
            }
            while (true);

            if (carry > 0) {
                curr.next = new ListNode { val = 1 };
            }
            return root;
        }
    }
}