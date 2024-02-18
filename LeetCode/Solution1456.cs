// ------------------------------------------------------------
//         File: Solution1456.cs
//        Brief: Solution1456.cs
//
//       Author: VyronLee, lwz_jz@hotmail.com
//
//      Created: 2024-2-18 20:33
//    Copyright: Copyright (c) 2024, VyronLee
// ============================================================

//给你字符串 s 和整数 k 。
//
// 请返回字符串 s 中长度为 k 的单个子字符串中可能包含的最大元音字母数。
//
// 英文中的 元音字母 为（a, e, i, o, u）。
//
//
//
// 示例 1：
//
// 输入：s = "abciiidef", k = 3
//输出：3
//解释：子字符串 "iii" 包含 3 个元音字母。
//
//
// 示例 2：
//
// 输入：s = "aeiou", k = 2
//输出：2
//解释：任意长度为 2 的子字符串都包含 2 个元音字母。
//
//
// 示例 3：
//
// 输入：s = "leetcode", k = 3
//输出：2
//解释："lee"、"eet" 和 "ode" 都包含 2 个元音字母。
//
//
// 示例 4：
//
// 输入：s = "rhythms", k = 4
//输出：0
//解释：字符串 s 中不含任何元音字母。
//
//
// 示例 5：
//
// 输入：s = "tryhard", k = 4
//输出：1
//
//
//
//
// 提示：
//
//
// 1 <= s.length <= 10^5
// s 由小写英文字母组成
// 1 <= k <= s.length
//
//
// Related Topics 字符串 滑动窗口 👍 91 👎

using System;

namespace LeetCode
{
    public class Solution1456
    {
        public int MaxVowels(string s, int k) {
            var max = 0;
            for (var i = 0; i < k; i++) {
                if (IsVowel(s[i])) {
                    max++;
                }
            }
            if (max >= k) {
                return max;
            }

            var sum = max;
            for (int i = 1, j = k; j < s.Length; i++, j++) {
                if (IsVowel(s[i - 1])) {
                    sum--;
                }
                if (IsVowel(s[j])) {
                    sum++;
                }
                max = Math.Max(max, sum);
                if (max >= k) {
                    break;
                }
            }
            return max;
        }

        private bool IsVowel(char c) {
            return c == 'a' || c == 'e' || c == 'i' || c == 'o' || c == 'u';
        }
    }
}