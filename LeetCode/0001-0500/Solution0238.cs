// ------------------------------------------------------------
//         File: Solution0238.cs
//        Brief: Solution0238.cs
//
//       Author: VyronLee, lwz_jz@hotmail.com
//
//      Created: 2024-2-17 15:33
//    Copyright: Copyright (c) 2024, VyronLee
// ============================================================

//给你一个整数数组 nums，返回 数组 answer ，其中 answer[i] 等于 nums 中除 nums[i] 之外其余各元素的乘积 。
//
// 题目数据 保证 数组 nums之中任意元素的全部前缀元素和后缀的乘积都在 32 位 整数范围内。
//
// 请 不要使用除法，且在 O(n) 时间复杂度内完成此题。
//
//
//
// 示例 1:
//
//
//输入: nums = [1,2,3,4]
//输出: [24,12,8,6]
//
//
// 示例 2:
//
//
//输入: nums = [-1,1,0,-3,3]
//输出: [0,0,9,0,0]
//
//
//
//
// 提示：
//
//
// 2 <= nums.length <= 10⁵
// -30 <= nums[i] <= 30
// 保证 数组 nums之中任意元素的全部前缀元素和后缀的乘积都在 32 位 整数范围内
//
//
//
//
// 进阶：你可以在 O(1) 的额外空间复杂度内完成这个题目吗？（ 出于对空间复杂度分析的目的，输出数组 不被视为 额外空间。）
//
// Related Topics 数组 前缀和 👍 1707 👎 0

namespace LeetCode
{
    public class Solution0238
    {
        public int[] ProductExceptSelf(int[] nums) {
            var ret = new int[nums.Length];
            for (var i = 0; i < nums.Length; i++) {
                ret[i] = 1;
            }

            var left = 1;
            var right = 1;
            for (int i = 0, j = nums.Length - 1; i < nums.Length; i++, j--) {
                ret[i] *= left;
                ret[j] *= right;
                left *= nums[i];
                right *= nums[j];
            }
            return ret;
        }
    }
}