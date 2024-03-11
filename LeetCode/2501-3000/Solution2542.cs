﻿// ------------------------------------------------------------
//         File: Solution2542.cs
//        Brief: Solution2542.cs
//
//       Author: VyronLee, lwz_jz@hotmail.com
//
//      Created: 2024-3-11 16:28
//    Copyright: Copyright (c) 2024, VyronLee
// ============================================================

//给你两个下标从 0 开始的整数数组 nums1 和 nums2 ，两者长度都是 n ，再给你一个正整数 k 。你必须从 nums1 中选一个长度为 k 的
//子序列 对应的下标。
//
// 对于选择的下标 i0 ，i1 ，...， ik - 1 ，你的 分数 定义如下：
//
//
// nums1 中下标对应元素求和，乘以 nums2 中下标对应元素的 最小值 。
// 用公式表示： (nums1[i0] + nums1[i1] +...+ nums1[ik - 1]) * min(nums2[i0] , nums2[i1
//], ... ,nums2[ik - 1]) 。
//
//
// 请你返回 最大 可能的分数。
//
// 一个数组的 子序列 下标是集合 {0, 1, ..., n-1} 中删除若干元素得到的剩余集合，也可以不删除任何元素。
//
//
//
// 示例 1：
//
//
//输入：nums1 = [1,3,3,2], nums2 = [2,1,3,4], k = 3
//输出：12
//解释：
//四个可能的子序列分数为：
//- 选择下标 0 ，1 和 2 ，得到分数 (1+3+3) * min(2,1,3) = 7 。
//- 选择下标 0 ，1 和 3 ，得到分数 (1+3+2) * min(2,1,4) = 6 。
//- 选择下标 0 ，2 和 3 ，得到分数 (1+3+2) * min(2,3,4) = 12 。
//- 选择下标 1 ，2 和 3 ，得到分数 (3+3+2) * min(1,3,4) = 8 。
//所以最大分数为 12 。
//
//
// 示例 2：
//
//
//输入：nums1 = [4,2,3,1,1], nums2 = [7,5,10,9,6], k = 1
//输出：30
//解释：
//选择下标 2 最优：nums1[2] * nums2[2] = 3 * 10 = 30 是最大可能分数。
//
//
//
//
// 提示：
//
//
// n == nums1.length == nums2.length
// 1 <= n <= 10⁵
// 0 <= nums1[i], nums2[j] <= 10⁵
// 1 <= k <= n
//
//
// Related Topics 贪心 数组 排序 堆（优先队列） 👍 82 👎 0

using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCode
{
    public class Solution2542
    {
        public long MaxScore(int[] nums1, int[] nums2, int k) {
            if (nums1.Length <= k) {
                return nums1.Sum(v => (long)v) * nums2.Min();
            }

            var multiples = new List<(int, int)>();
            for (var i = 0; i < nums1.Length; i++) {
                multiples.Add((nums2[i], i));
            }
            multiples.Sort((a, b) => -a.Item1.CompareTo(b.Item1));

            var max = 0L;
            var sum = 0L;
            var queue = new PriorityQueue<int, int>();
            for (var i = 0; i < multiples.Count; i++) {
                var (n2, idx) = multiples[i];
                if (i >= k) {
                    if (nums1[idx] > queue.Peek()) {
                        var removed = queue.EnqueueDequeue(nums1[idx], nums1[idx]);
                        sum += nums1[idx];
                        sum -= removed;
                    }
                    max = Math.Max(max, sum * n2);
                }
                else if (i < k){
                    queue.Enqueue(nums1[idx], nums1[idx]);
                    sum += nums1[idx];
                    if (i == k - 1) {
                        max = Math.Max(max, sum * n2);
                    }
                }
            }
            return max;
        }
    }
}