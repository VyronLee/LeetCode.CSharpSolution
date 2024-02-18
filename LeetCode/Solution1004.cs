// ------------------------------------------------------------
//         File: Solution1004.cs
//        Brief: Solution1004.cs
//
//       Author: VyronLee, lwz_jz@hotmail.com
//
//      Created: 2024-2-18 20:43
//    Copyright: Copyright (c) 2024, VyronLee
// ============================================================

//给定一个二进制数组 nums 和一个整数 k，如果可以翻转最多 k 个 0 ，则返回 数组中连续 1 的最大个数 。
//
//
//
// 示例 1：
//
//
//输入：nums = [1,1,1,0,0,0,1,1,1,1,0], K = 2
//输出：6
//解释：[1,1,1,0,0,1,1,1,1,1,1]
//粗体数字从 0 翻转到 1，最长的子数组长度为 6。
//
// 示例 2：
//
//
//输入：nums = [0,0,1,1,0,0,1,1,1,0,1,1,0,0,0,1,1,1,1], K = 3
//输出：10
//解释：[0,0,1,1,1,1,1,1,1,1,1,1,0,0,0,1,1,1,1]
//粗体数字从 0 翻转到 1，最长的子数组长度为 10。
//
//
//
// 提示：
//
//
// 1 <= nums.length <= 10⁵
// nums[i] 不是 0 就是 1
// 0 <= k <= nums.length
//
//
// Related Topics 数组 二分查找 前缀和 滑动窗口 👍 679 👎 0

using System;

namespace LeetCode
{
    public class Solution1004
    {
        public int LongestOnes(int[] nums, int k) {
            var max = 0;
            var cnt = 0; // 窗口内0的个数
            for (int i = 0, j = 0; j < nums.Length; j++) {
                // 移动窗口右边界
                if (nums[j] == 0) {
                    cnt++;
                }
                // 移动窗口左边界
                while (cnt > k) {
                    if (nums[i] == 0) {
                        cnt--;
                    }
                    i++;
                }
                max = Math.Max(max, j - i + 1);
            }
            return max;
        }
    }
}