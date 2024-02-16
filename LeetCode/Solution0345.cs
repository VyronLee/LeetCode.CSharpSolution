// ------------------------------------------------------------
//         File: Solution0345.cs
//        Brief: Solution0345.cs
//
//       Author: VyronLee, lwz_jz@hotmail.com
//
//      Created: 2024-2-16 21:17
//    Copyright: Copyright (c) 2024, VyronLee
// ============================================================

//给你一个字符串 s ，仅反转字符串中的所有元音字母，并返回结果字符串。
//
// 元音字母包括 'a'、'e'、'i'、'o'、'u'，且可能以大小写两种形式出现不止一次。
//
//
//
// 示例 1：
//
//
//输入：s = "hello"
//输出："holle"
//
//
// 示例 2：
//
//
//输入：s = "leetcode"
//输出："leotcede"
//
//
//
// 提示：
//
//
// 1 <= s.length <= 3 * 10⁵
// s 由 可打印的 ASCII 字符组成
//
//
// Related Topics 双指针 字符串 👍 343 👎 0

namespace LeetCode
{
    public class Solution0345
    {
        public string ReverseVowels(string s) {
            var ret = s.ToCharArray();
            for (int i = 0, j = ret.Length - 1; i < j; ) {
                var head = ret[i];
                if (!IsVowel(head)) {
                    i++;
                    continue;
                }

                var tail = ret[j];
                if (!IsVowel(tail)) {
                    j--;
                    continue;
                }

                (ret[i++], ret[j--]) = (tail, head);
            }

            return new string(ret);

            bool IsVowel(char c) {
                return c is 'a' or 'e' or 'i' or 'o' or 'u' or 'A' or 'E' or 'I' or 'O' or 'U';
            }
        }
    }
}