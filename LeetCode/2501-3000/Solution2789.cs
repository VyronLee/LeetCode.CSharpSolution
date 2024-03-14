// ------------------------------------------------------------
//         File: Solution2789.cs
//        Brief: Solution2789.cs
//
//       Author: VyronLee, lwz_jz@hotmail.com
//
//      Created: 2024-3-14 11:49
//    Copyright: Copyright (c) 2024, VyronLee
// ============================================================

//给你一个下标从 0 开始、由正整数组成的数组 nums 。
//
// 你可以在数组上执行下述操作 任意 次：
//
//
// 选中一个同时满足 0 <= i < nums.length - 1 和 nums[i] <= nums[i + 1] 的整数 i 。将元素 nums[i
//+ 1] 替换为 nums[i] + nums[i + 1] ，并从数组中删除元素 nums[i] 。
//
//
// 返回你可以从最终数组中获得的 最大 元素的值。
//
//
//
// 示例 1：
//
// 输入：nums = [2,3,7,9,3]
//输出：21
//解释：我们可以在数组上执行下述操作：
//- 选中 i = 0 ，得到数组 nums = [5,7,9,3] 。
//- 选中 i = 1 ，得到数组 nums = [5,16,3] 。
//- 选中 i = 0 ，得到数组 nums = [21,3] 。
//最终数组中的最大元素是 21 。可以证明我们无法获得更大的元素。
//
//
// 示例 2：
//
// 输入：nums = [5,3,3]
//输出：11
//解释：我们可以在数组上执行下述操作：
//- 选中 i = 1 ，得到数组 nums = [5,6] 。
//- 选中 i = 0 ，得到数组 nums = [11] 。
//最终数组中只有一个元素，即 11 。
//
//
//
//
// 提示：
//
//
// 1 <= nums.length <= 10⁵
// 1 <= nums[i] <= 10⁶
//
//
// Related Topics 贪心 数组 👍 47 👎 0

namespace LeetCode;

public class Solution2789
{
    public long MaxArrayValue(int[] nums) {
        var pre = (long) nums[^1];
        if (nums.Length <= 1) {
            return pre;
        }

        for (var i = nums.Length - 2; i >= 0; i--) {
            var cur = nums[i];
            if (cur <= pre) {
                pre = cur + pre;
            }
            else {
                pre = cur;
            }
        }
        return pre;
    }
}