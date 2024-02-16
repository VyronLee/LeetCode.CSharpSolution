﻿// ------------------------------------------------------------
//         File: Solution1480.cs
//        Brief: Solution1480.cs
//
//       Author: VyronLee, lwz_jz@hotmail.com
//
//      Created: 2024-2-16 11:21
//    Copyright: Copyright (c) 2024, VyronLee
// ============================================================

//给你一个数组 nums 。数组「动态和」的计算公式为：runningSum[i] = sum(nums[0]…nums[i]) 。
//
// 请返回 nums 的动态和。
//
//
//
// 示例 1：
//
// 输入：nums = [1,2,3,4]
//输出：[1,3,6,10]
//解释：动态和计算过程为 [1, 1+2, 1+2+3, 1+2+3+4] 。
//
// 示例 2：
//
// 输入：nums = [1,1,1,1,1]
//输出：[1,2,3,4,5]
//解释：动态和计算过程为 [1, 1+1, 1+1+1, 1+1+1+1, 1+1+1+1+1] 。
//
// 示例 3：
//
// 输入：nums = [3,1,2,10,1]
//输出：[3,4,6,16,17]
//
//
//
//
// 提示：
//
//
// 1 <= nums.length <= 1000
// -10^6 <= nums[i] <= 10^6
//
//
// Related Topics 数组 前缀和 👍 446 👎 0

namespace LeetCode
{
    public class Solution1480
    {
        public int[] RunningSum(int[] nums) {
            var sums = new int[nums.Length];
            sums[0] = nums[0];
            for (var i = 1; i < nums.Length; i++) {
                sums[i] = sums[i - 1] + nums[i];
            }
            return sums;
        }
    }
}