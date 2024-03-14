// ------------------------------------------------------------
//         File: Solution2300.cs
//        Brief: Solution2300.cs
//
//       Author: VyronLee, lwz_jz@hotmail.com
//
//      Created: 2024-3-14 16:19
//    Copyright: Copyright (c) 2024, VyronLee
// ============================================================

//
//
// 示例 1：
//
// 输入：spells = [5,1,3], potions = [1,2,3,4,5], success = 7
//输出：[4,0,3]
//解释：
//- 第 0 个咒语：5 * [1,2,3,4,5] = [5,10,15,20,25] 。总共 4 个成功组合。
//- 第 1 个咒语：1 * [1,2,3,4,5] = [1,2,3,4,5] 。总共 0 个成功组合。
//- 第 2 个咒语：3 * [1,2,3,4,5] = [3,6,9,12,15] 。总共 3 个成功组合。
//所以返回 [4,0,3] 。
//
//
// 示例 2：
//
// 输入：spells = [3,1,2], potions = [8,5,8], success = 16
//输出：[2,0,2]
//解释：
//- 第 0 个咒语：3 * [8,5,8] = [24,15,24] 。总共 2 个成功组合。
//- 第 1 个咒语：1 * [8,5,8] = [8,5,8] 。总共 0 个成功组合。
//- 第 2 个咒语：2 * [8,5,8] = [16,10,16] 。总共 2 个成功组合。
//所以返回 [2,0,2] 。
//
//
//
//
// 提示：
//
//
// n == spells.length
// m == potions.length
// 1 <= n, m <= 10⁵
// 1 <= spells[i], potions[i] <= 10⁵
// 1 <= success <= 10¹⁰
//
//
// Related Topics 数组 双指针 二分查找 排序 👍 95 👎 0

using System;

namespace LeetCode;

public class Solution2300
{
    public int[] SuccessfulPairs(int[] spells, int[] potions, long success) {
        Array.Sort(potions);

        var ret = new int[spells.Length];
        for (var i = 0; i < spells.Length; i++) {
            var l = 0;
            var r = potions.Length - 1;
            while (true) {
                if (l > r) {
                    ret[i] = 0;
                    break;
                }
                var m = (l + r) / 2;
                if ((long)spells[i] * potions[m] >= success) {
                    if (m - 1 < 0 || (long)spells[i] * potions[m - 1] < success) {
                        ret[i] = potions.Length - m;
                        break;
                    }
                    if (m - 1 >= 0 && (long)spells[i] * potions[m - 1] >= success) {
                        r = m - 1;
                    }
                }
                else {
                    l = m + 1;
                }
            }
        }
        return ret;
    }
}