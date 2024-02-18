// ------------------------------------------------------------
//         File: Solution0643.cs
//        Brief: Solution0643.cs
//
//       Author: VyronLee, lwz_jz@hotmail.com
//
//      Created: 2024-2-18 17:33
//    Copyright: Copyright (c) 2024, VyronLee
// ============================================================

//给你一个由 n 个元素组成的整数数组 nums 和一个整数 k 。
//
// 请你找出平均数最大且 长度为 k 的连续子数组，并输出该最大平均数。
//
// 任何误差小于 10⁻⁵ 的答案都将被视为正确答案。
//
//
//
// 示例 1：
//
//
//输入：nums = [1,12,-5,-6,50,3], k = 4
//输出：12.75
//解释：最大平均数 (12-5-6+50)/4 = 51/4 = 12.75
//
//
// 示例 2：
//
//
//输入：nums = [5], k = 1
//输出：5.00000
//
//
//
//
// 提示：
//
//
// n == nums.length
// 1 <= k <= n <= 10⁵
// -10⁴ <= nums[i] <= 10⁴
//
//
// Related Topics 数组 滑动窗口 👍 330 👎 0

using System;

namespace LeetCode
{
    public class Solution0643
    {
        public double FindMaxAverage(int[] nums, int k) {
            var sum = 0d;
            for (var i = 0; i < k && i < nums.Length; i++) {
                sum += nums[i];
            }

            var max = sum;
            for (int i = 1, j = k; j < nums.Length; i++, j++) {
                sum = sum - nums[i - 1] + nums[j];
                max = Math.Max(max, sum);
            }
            return max / Math.Min(nums.Length, k);
        }
    }
}