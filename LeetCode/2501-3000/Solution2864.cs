// ------------------------------------------------------------
//         File: Solution2864.cs
//        Brief: Solution2864.cs
//
//       Author: VyronLee, lwz_jz@hotmail.com
//
//      Created: 2024-3-13 23:19
//    Copyright: Copyright (c) 2024, VyronLee
// ============================================================

//给你一个 二进制 字符串 s ，其中至少包含一个 '1' 。
//
// 你必须按某种方式 重新排列 字符串中的位，使得到的二进制数字是可以由该组合生成的 最大二进制奇数 。
//
// 以字符串形式，表示并返回可以由给定组合生成的最大二进制奇数。
//
// 注意 返回的结果字符串 可以 含前导零。
//
//
//
// 示例 1：
//
//
//输入：s = "010"
//输出："001"
//解释：因为字符串 s 中仅有一个 '1' ，其必须出现在最后一位上。所以答案是 "001" 。
//
//
// 示例 2：
//
//
//输入：s = "0101"
//输出："1001"
//解释：其中一个 '1' 必须出现在最后一位上。而由剩下的数字可以生产的最大数字是 "100" 。所以答案是 "1001" 。
//
//
//
//
// 提示：
//
//
// 1 <= s.length <= 100
// s 仅由 '0' 和 '1' 组成
// s 中至少包含一个 '1'
//
//
// Related Topics 贪心 数学 字符串 👍 25 👎 0

namespace LeetCode;

public class Solution2864
{
    public string MaximumOddBinaryNumber(string s) {
        var chars = s.ToCharArray();
        var i = -1;
        var j = -1;
        while (++i < chars.Length) {
            if (chars[i] != '1') {
                continue;
            }
            ++j;
            (chars[j], chars[i]) = (chars[i], chars[j]);
        }
        (chars[j], chars[i-1]) = (chars[i-1], chars[j]);
        return new string(chars);
    }
}