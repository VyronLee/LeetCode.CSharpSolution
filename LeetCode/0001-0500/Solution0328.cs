// ------------------------------------------------------------
//         File: Solution0328.cs
//        Brief: Solution0328.cs
//
//       Author: VyronLee, lwz_jz@hotmail.com
//
//      Created: 2024-2-24 23:47
//    Copyright: Copyright (c) 2024, VyronLee
// ============================================================

//给定单链表的头节点 head ，将所有索引为奇数的节点和索引为偶数的节点分别组合在一起，然后返回重新排序的列表。
//
// 第一个节点的索引被认为是 奇数 ， 第二个节点的索引为 偶数 ，以此类推。
//
// 请注意，偶数组和奇数组内部的相对顺序应该与输入时保持一致。
//
// 你必须在 O(1) 的额外空间复杂度和 O(n) 的时间复杂度下解决这个问题。
//
//
//
// 示例 1:
//
//
//
//
//输入: head = [1,2,3,4,5]
//输出: [1,3,5,2,4]
//
// 示例 2:
//
//
//
//
//输入: head = [2,1,3,5,6,4,7]
//输出: [2,3,6,7,1,5,4]
//
//
//
// 提示:
//
//
// n == 链表中的节点数
// 0 <= n <= 10⁴
// -10⁶ <= Node.val <= 10⁶
//
//
// Related Topics 链表 👍 770 👎 0

namespace LeetCode
{
    public class Solution0328
    {
        public ListNode OddEvenList(ListNode head) {
            if (head == null || head.next == null || head.next.next == null) {
                return head;
            }

            bool flag;
            ListNode odd = head, oddHead = head;
            ListNode even = head.next, evenHead = head.next;

            for (flag = true, (head, even.next) = (even.next, null); head != null; flag = !flag, (head, head.next) = (head.next, null)) {
                if (flag) {
                    odd = odd.next = head;
                }
                else {
                    even = even.next = head;
                }
            }
            odd.next = evenHead;
            return oddHead;
        }
    }
}