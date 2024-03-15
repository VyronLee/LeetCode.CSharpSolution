// ------------------------------------------------------------
//         File: Solution0017.cs
//        Brief: Solution0017.cs
//
//       Author: VyronLee, lwz_jz@hotmail.com
//
//      Created: 2024-3-15 14:52
//    Copyright: Copyright (c) 2024, VyronLee
// ============================================================

//给定一个仅包含数字 2-9 的字符串，返回所有它能表示的字母组合。答案可以按 任意顺序 返回。
//
// 给出数字到字母的映射如下（与电话按键相同）。注意 1 不对应任何字母。
//
//
//
//
//
// 示例 1：
//
//
//输入：digits = "23"
//输出：["ad","ae","af","bd","be","bf","cd","ce","cf"]
//
//
// 示例 2：
//
//
//输入：digits = ""
//输出：[]
//
//
// 示例 3：
//
//
//输入：digits = "2"
//输出：["a","b","c"]
//
//
//
//
// 提示：
//
//
// 0 <= digits.length <= 4
// digits[i] 是范围 ['2', '9'] 的一个数字。
//
//
// Related Topics 哈希表 字符串 回溯 👍 2778 👎 0

namespace LeetCode;

public class Solution0017
{
    private Dictionary<char, char[]> Mapping = new Dictionary<char, char[]> {
        { '2', new []{ 'a', 'b', 'c'}},
        { '3', new []{ 'd', 'e', 'f'}},
        { '4', new []{ 'g', 'h', 'i'}},
        { '5', new []{ 'j', 'k', 'l'}},
        { '6', new []{ 'm', 'n', 'o'}},
        { '7', new []{ 'p', 'q', 'r', 's'}},
        { '8', new []{ 't', 'u', 'v'}},
        { '9', new []{ 'w', 'x', 'y', 'z'}}

    };

    public IList<string> LetterCombinations(string digits) {
        if (digits.Length <= 0) {
            return new List<string>();
        }

        var list1 = new List<char[]>();
        var list2 = new List<char[]>();

        var first = Mapping[digits[0]];
        for (var i = 0; i < first.Length; i++) {
            list1.Add(new[] { first[i] });
        }

        for (var i = 1; i < digits.Length; i++) {
            var n = digits[i];
            var mapping = Mapping[n];
            for (var j = 0; j < mapping.Length; j++) {
                for (var k = 0; k < list1.Count; k++) {
                    var charArr = new char[list1[k].Length + 1];
                    Array.Copy(list1[k], charArr, list1[k].Length);
                    charArr[^1] = mapping[j];
                    list2.Add(charArr);
                }
            }
            (list1, list2) = (list2, list1);
            list2.Clear();
        }
        return list1.Select(v => new string(v)).ToList();
    }
}