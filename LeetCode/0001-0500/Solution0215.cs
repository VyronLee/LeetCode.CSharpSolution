// ------------------------------------------------------------
//         File: Solution0215.cs
//        Brief: Solution0215.cs
//
//       Author: VyronLee, lwz_jz@hotmail.com
//
//      Created: 2024-3-9 0:35
//    Copyright: Copyright (c) 2024, VyronLee
// ============================================================

//给定整数数组 nums 和整数 k，请返回数组中第 k 个最大的元素。
//
// 请注意，你需要找的是数组排序后的第 k 个最大的元素，而不是第 k 个不同的元素。
//
// 你必须设计并实现时间复杂度为 O(n) 的算法解决此问题。
//
//
//
// 示例 1:
//
//
//输入: [3,2,1,5,6,4], k = 2
//输出: 5
//
//
// 示例 2:
//
//
//输入: [3,2,3,1,2,4,5,5,6], k = 4
//输出: 4
//
//
//
// 提示：
//
//
// 1 <= k <= nums.length <= 10⁵
// -10⁴ <= nums[i] <= 10⁴
//
//
// Related Topics 数组 分治 快速选择 排序 堆（优先队列） 👍 2419 👎 0

using System;
using System.Collections.Generic;

namespace LeetCode
{
    public class Solution0215
    {
        public int FindKthLargest(int[] nums, int k) {
            return QuickSelect(nums, 0, nums.Length - 1, nums.Length - k);
        }

        private int QuickSelect(int[] nums, int l, int r, int k) {
            if (l == r) {
                return nums[k];
            }

            var m = nums[l];
            var i = l;
            var j = r;

            while (true) {
                while (i < j && nums[j] >= m) {
                    j--;
                }
                while (i < j && nums[i] <= m) {
                    i++;
                }
                if (i >= j) {
                    break;
                }
                (nums[j], nums[i]) = (nums[i], nums[j]);
            }
            (nums[l], nums[j]) = (nums[j], nums[l]);

            if (j == k) {
                return nums[k];
            }
            if (j < k) {
                return QuickSelect(nums, j + 1, r, k);
            }
            return QuickSelect(nums, l, j - 1, k);
        }
    }
}