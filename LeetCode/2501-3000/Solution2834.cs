// ------------------------------------------------------------
//         File: Solution2834.cs
//        Brief: Solution2834.cs
//
//       Author: VyronLee, lwz_jz@hotmail.com
//
//      Created: 2024-3-8 15:34
//    Copyright: Copyright (c) 2024, VyronLee
// ============================================================

//给你两个正整数：n 和 target 。
//
// 如果数组 nums 满足下述条件，则称其为 美丽数组 。
//
//
// nums.length == n.
// nums 由两两互不相同的正整数组成。
// 在范围 [0, n-1] 内，不存在 两个 不同 下标 i 和 j ，使得 nums[i] + nums[j] == target 。
//
//
// 返回符合条件的美丽数组所可能具备的 最小 和，并对结果进行取模 10⁹ + 7。
//
//
//
// 示例 1：
//
//
//输入：n = 2, target = 3
//输出：4
//解释：nums = [1,3] 是美丽数组。
//- nums 的长度为 n = 2 。
//- nums 由两两互不相同的正整数组成。
//- 不存在两个不同下标 i 和 j ，使得 nums[i] + nums[j] == 3 。
//可以证明 4 是符合条件的美丽数组所可能具备的最小和。
//
// 示例 2：
//
//
//输入：n = 3, target = 3
//输出：8
//解释：
//nums = [1,3,4] 是美丽数组。
//- nums 的长度为 n = 3 。
//- nums 由两两互不相同的正整数组成。
//- 不存在两个不同下标 i 和 j ，使得 nums[i] + nums[j] == 3 。
//可以证明 8 是符合条件的美丽数组所可能具备的最小和。
//
// 示例 3：
//
//
//输入：n = 1, target = 1
//输出：1
//解释：nums = [1] 是美丽数组。
//
//
//
//
// 提示：
//
//
// 1 <= n <= 10⁹
// 1 <= target <= 10⁹
//
//
// Related Topics 贪心 数学 👍 41 👎 0

using System;

namespace LeetCode
{
    public class Solution2834
    {
        private const int Mod = 1000000007;

        public int MinimumPossibleSum(int n, int target) {
            // 拆分成两个等差数列求和
            // 1. [1, .., target/2]
            // 2. [target, ..., target + (n - (target/2+1))]
            var halfT = target / 2;
            var begin = 0L;
            var end = Math.Min(halfT, n);
            var sum1 = (int)(ModSum(begin, end) % Mod);
            if (n <= halfT) {
                return sum1;
            }

            begin = target;
            end = target + n - (halfT + 1);
            var sum2 = (int)(ModSum(begin, end) % Mod);
            return (sum1 + sum2) % Mod;
        }

        private long ModSum(long begin, long end) {
            return (end + begin) * (end - begin + 1) / 2;
        }
    }
}