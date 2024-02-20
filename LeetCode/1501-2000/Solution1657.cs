// ------------------------------------------------------------
//         File: Solution1657.cs
//        Brief: Solution1657.cs
//
//       Author: VyronLee, lwz_jz@hotmail.com
//
//      Created: 2024-2-19 20:29
//    Copyright: Copyright (c) 2024, VyronLee
// ============================================================

//如果可以使用以下操作从一个字符串得到另一个字符串，则认为两个字符串 接近 ：
//
//
// 操作 1：交换任意两个 现有 字符。
//
//
//
// 例如，abcde -> aecdb
//
//
// 操作 2：将一个 现有 字符的每次出现转换为另一个 现有 字符，并对另一个字符执行相同的操作。
//
// 例如，aacabb -> bbcbaa（所有 a 转化为 b ，而所有的 b 转换为 a ）
//
//
//
//
// 你可以根据需要对任意一个字符串多次使用这两种操作。
//
// 给你两个字符串，word1 和 word2 。如果 word1 和 word2 接近 ，就返回 true ；否则，返回 false 。
//
//
//
// 示例 1：
//
//
//输入：word1 = "abc", word2 = "bca"
//输出：true
//解释：2 次操作从 word1 获得 word2 。
//执行操作 1："abc" -> "acb"
//执行操作 1："acb" -> "bca"
//
//
// 示例 2：
//
//
//输入：word1 = "a", word2 = "aa"
//输出：false
//解释：不管执行多少次操作，都无法从 word1 得到 word2 ，反之亦然。
//
// 示例 3：
//
//
//输入：word1 = "cabbba", word2 = "abbccc"
//输出：true
//解释：3 次操作从 word1 获得 word2 。
//执行操作 1："cabbba" -> "caabbb"
//执行操作 2："caabbb" -> "baaccc"
//执行操作 2："baaccc" -> "abbccc"
//
//
// 提示：
//
//
// 1 <= word1.length, word2.length <= 10⁵
// word1 和 word2 仅包含小写英文字母
//
//
// Related Topics 哈希表 字符串 计数 排序 👍 134 👎 0

using System.Collections.Generic;
using System.Linq;

namespace LeetCode
{
    public class Solution1657
    {
        public bool CloseStrings(string word1, string word2) {
            var dict1 = Parse(word1);
            var dict2 = Parse(word2);

            var keys1 = dict1.Keys;
            var keys2 = dict2.Keys;
            if (keys1.Except(keys2).Any() || keys2.Except(keys1).Any()) {
                return false;
            }

            var counts1 = dict1.Values.OrderBy(x => x);
            var counts2 = dict2.Values.OrderBy(x => x);
            return counts1.SequenceEqual(counts2);
        }

        private Dictionary<char, int> Parse(string word) {
            var dict = new Dictionary<char, int>();
            for (var i = 0; i < word.Length; i++) {
                if (!dict.TryAdd(word[i], 1)) {
                    dict[word[i]]++;
                }
            }
            return dict;
        }
    }
}