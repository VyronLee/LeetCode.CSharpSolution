// ------------------------------------------------------------
//         File: Solution1679.cs
//        Brief: Solution1679.cs
//
//       Author: VyronLee, lwz_jz@hotmail.com
//
//      Created: 2024-2-18 15:4
//    Copyright: Copyright (c) 2024, VyronLee
// ============================================================

//给你一个整数数组 nums 和一个整数 k 。
//
// 每一步操作中，你需要从数组中选出和为 k 的两个整数，并将它们移出数组。
//
// 返回你可以对数组执行的最大操作数。
//
//
//
// 示例 1：
//
//
//输入：nums = [1,2,3,4], k = 5
//输出：2
//解释：开始时 nums = [1,2,3,4]：
//- 移出 1 和 4 ，之后 nums = [2,3]
//- 移出 2 和 3 ，之后 nums = []
//不再有和为 5 的数对，因此最多执行 2 次操作。
//
// 示例 2：
//
//
//输入：nums = [3,1,3,4,3], k = 6
//输出：1
//解释：开始时 nums = [3,1,3,4,3]：
//- 移出前两个 3 ，之后nums = [1,4,3]
//不再有和为 6 的数对，因此最多执行 1 次操作。
//
//
//
// 提示：
//
//
// 1 <= nums.length <= 10⁵
// 1 <= nums[i] <= 10⁹
// 1 <= k <= 10⁹
//
//
// Related Topics 数组 哈希表 双指针 排序 👍 69 👎 0

using System;
using System.Collections.Generic;

namespace LeetCode
{
    public class Solution1679
    {
        public int MaxOperations(int[] nums, int k) {
            var counts = new Dictionary<int, int>();
            for (var i = 0; i < nums.Length; i++) {
                var n = nums[i];
                counts[n] = GetValueOrDefault(counts, n) + 1;
            }

            var result = 0;
            foreach (var kv in counts) {
                var n1 = kv.Key;
                var n2 = k - n1;
                var cnt1 = GetValueOrDefault(counts, n1);
                var cnt2 = GetValueOrDefault(counts, n2);
                if (n1 == n2) {
                    result += cnt1 / 2;
                    SetValueOrDefault(counts, n1, cnt1 - cnt1 / 2);
                }
                else {
                    var c = Math.Min(cnt1, cnt2);
                    result += c;
                    SetValueOrDefault(counts, n1, cnt1 - c);
                    SetValueOrDefault(counts, n2, cnt2 - c);
                }
            }
            return result;
        }

        private int GetValueOrDefault(Dictionary<int, int> dict, int key) {
            return dict.TryGetValue(key, out var value) ? value : 0;
        }

        private void SetValueOrDefault(Dictionary<int, int> dict, int key, int value) {
            if (!dict.ContainsKey(key)) {
                return;
            }
            dict[key] = value;
        }
    }
}