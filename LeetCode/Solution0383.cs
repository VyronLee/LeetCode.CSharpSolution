// ------------------------------------------------------------
//         File: Solution0383.cs
//        Brief: Solution0383.cs
//
//       Author: VyronLee, lwz_jz@hotmail.com
//
//      Created: 2024-2-16 13:26
//    Copyright: Copyright (c) 2024, VyronLee
// ============================================================

//给你两个字符串：ransomNote 和 magazine ，判断 ransomNote 能不能由 magazine 里面的字符构成。
//
// 如果可以，返回 true ；否则返回 false 。
//
// magazine 中的每个字符只能在 ransomNote 中使用一次。
//
//
//
// 示例 1：
//
//
//输入：ransomNote = "a", magazine = "b"
//输出：false
//
//
// 示例 2：
//
//
//输入：ransomNote = "aa", magazine = "ab"
//输出：false
//
//
// 示例 3：
//
//
//输入：ransomNote = "aa", magazine = "aab"
//输出：true
//
//
//
//
// 提示：
//
//
// 1 <= ransomNote.length, magazine.length <= 10⁵
// ransomNote 和 magazine 由小写英文字母组成
//
//
// Related Topics 哈希表 字符串 计数 👍 865 👎 0

namespace LeetCode
{
    public class Solution0383
    {
        public bool CanConstruct(string ransomNote, string magazine) {
            var charCounts = new int[26];
            for (var i = 0; i < magazine.Length; i++) {
                var c = magazine[i];
                charCounts[c - 'a']++;
            }
            for (var i = 0; i < ransomNote.Length; i++) {
                var c = ransomNote[i];
                if (charCounts[c - 'a'] == 0) {
                    return false;
                }
                charCounts[c - 'a']--;
            }
            return true;
        }
    }
}