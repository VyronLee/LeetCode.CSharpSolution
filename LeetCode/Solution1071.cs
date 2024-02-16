// ------------------------------------------------------------
//         File: Solution1071.cs
//        Brief: Solution1071.cs
//
//       Author: VyronLee, lwz_jz@hotmail.com
//
//      Created: 2024-2-16 14:12
//    Copyright: Copyright (c) 2024, VyronLee
// ============================================================

//对于字符串 s 和 t，只有在 s = t + ... + t（t 自身连接 1 次或多次）时，我们才认定 “t 能除尽 s”。
//
// 给定两个字符串 str1 和 str2 。返回 最长字符串 x，要求满足 x 能除尽 str1 且 x 能除尽 str2 。
//
//
//
// 示例 1：
//
//
//输入：str1 = "ABCABC", str2 = "ABC"
//输出："ABC"
//
//
// 示例 2：
//
//
//输入：str1 = "ABABAB", str2 = "ABAB"
//输出："AB"
//
//
// 示例 3：
//
//
//输入：str1 = "LEET", str2 = "CODE"
//输出：""
//
//
//
//
// 提示：
//
//
// 1 <= str1.length, str2.length <= 1000
// str1 和 str2 由大写英文字母组成
//
//
// Related Topics 数学 字符串 👍 386 👎 0

namespace LeetCode
{
    public class Solution1071
    {
        public string GcdOfStrings(string str1, string str2) {
            var ret = "";
            var divisor = "";
            for (var i = 0; i < str1.Length && i < str2.Length; i++) {
                if (str1[i] != str2[i]) {
                    break;
                }
                divisor += str1[i];
                if (!CanDivide(str1, divisor) || !CanDivide(str2, divisor))
                    continue;
                if (ret.Length < divisor.Length)
                    ret = divisor;
            }
            return ret;
        }

        bool CanDivide(string devidend, string divisor) {
            var len1 = devidend.Length;
            var len2 = divisor.Length;
            if (len1 % len2 != 0) {
                return false;
            }
            var times = len1 / len2;
            var ret = true;
            for (var i = 0; i < times; i++) {
                if (devidend.Substring(i * len2, len2) == divisor)
                    continue;
                ret = false;
                break;
            }
            return ret;
        }
    }
}