// ------------------------------------------------------------
//         File: Solution003.cs
//        Brief: Solution003.cs
//
//       Author: VyronLee, lwz_jz@hotmail.com
//
//      Created: 2024-2-15 22:44
//    Copyright: Copyright (c) 2024, VyronLee
// ============================================================

//给定一个字符串 s ，请你找出其中不含有重复字符的 最长子串 的长度。
//
//
//
// 示例 1:
//
//
//输入: s = "abcabcbb"
//输出: 3
//解释: 因为无重复字符的最长子串是 "abc"，所以其长度为 3。
//
//
// 示例 2:
//
//
//输入: s = "bbbbb"
//输出: 1
//解释: 因为无重复字符的最长子串是 "b"，所以其长度为 1。
//
//
// 示例 3:
//
//
//输入: s = "pwwkew"
//输出: 3
//解释: 因为无重复字符的最长子串是 "wke"，所以其长度为 3。
//     请注意，你的答案必须是 子串 的长度，"pwke" 是一个子序列，不是子串。
//
//
//
//
// 提示：
//
//
// 0 <= s.length <= 5 * 10⁴
// s 由英文字母、数字、符号和空格组成
//
//
// Related Topics 哈希表 字符串 滑动窗口 👍 9969 👎 0

using System;

namespace LeetCode
{
    public class Solution003
    {
        public int LengthOfLongestSubstring(string s) {
            var chars = new int[char.MaxValue];
            var max = 0;
            for (int l = 0, r = -1; l < s.Length && r < s.Length; ) {
                if (r + 1 < s.Length && chars[s[r + 1]] == 0) {
                    chars[s[r + 1]] = 1;
                    r++;
                }
                else {
                    chars[s[l]] = 0;
                    l++;
                }
                max = Math.Max(max, r - l + 1);
            }
            return max;
        }
    }
}