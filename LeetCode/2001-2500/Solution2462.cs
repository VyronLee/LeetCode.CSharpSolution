// ------------------------------------------------------------
//         File: Solution2462.cs
//        Brief: Solution2462.cs
//
//       Author: VyronLee, lwz_jz@hotmail.com
//
//      Created: 2024-3-12 18:23
//    Copyright: Copyright (c) 2024, VyronLee
// ============================================================

//给你一个下标从 0 开始的整数数组 costs ，其中 costs[i] 是雇佣第 i 位工人的代价。
//
// 同时给你两个整数 k 和 candidates 。我们想根据以下规则恰好雇佣 k 位工人：
//
//
// 总共进行 k 轮雇佣，且每一轮恰好雇佣一位工人。
// 在每一轮雇佣中，从最前面 candidates 和最后面 candidates 人中选出代价最小的一位工人，如果有多位代价相同且最小的工人，选择下标更小的
//一位工人。
//
// 比方说，costs = [3,2,7,7,1,2] 且 candidates = 2 ，第一轮雇佣中，我们选择第 4 位工人，因为他的代价最小 [3,2,
//7,7,1,2] 。
// 第二轮雇佣，我们选择第 1 位工人，因为他们的代价与第 4 位工人一样都是最小代价，而且下标更小，[3,2,7,7,2] 。注意每一轮雇佣后，剩余工人的下
//标可能会发生变化。
//
// 如果剩余员工数目不足 candidates 人，那么下一轮雇佣他们中代价最小的一人，如果有多位代价相同且最小的工人，选择下标更小的一位工人。
// 一位工人只能被选择一次。
//
//
// 返回雇佣恰好 k 位工人的总代价。
//
//
//
// 示例 1：
//
// 输入：costs = [17,12,10,2,7,2,11,20,8], k = 3, candidates = 4
//输出：11
//解释：我们总共雇佣 3 位工人。总代价一开始为 0 。
//- 第一轮雇佣，我们从 [17,12,10,2,7,2,11,20,8] 中选择。最小代价是 2 ，有两位工人，我们选择下标更小的一位工人，即第 3 位工人
//。总代价是 0 + 2 = 2 。
//- 第二轮雇佣，我们从 [17,12,10,7,2,11,20,8] 中选择。最小代价是 2 ，下标为 4 ，总代价是 2 + 2 = 4 。
//- 第三轮雇佣，我们从 [17,12,10,7,11,20,8] 中选择，最小代价是 7 ，下标为 3 ，总代价是 4 + 7 = 11 。注意下标为 3
//的工人同时在最前面和最后面 4 位工人中。
//总雇佣代价是 11 。
//
//
// 示例 2：
//
// 输入：costs = [1,2,4,1], k = 3, candidates = 3
//输出：4
//解释：我们总共雇佣 3 位工人。总代价一开始为 0 。
//- 第一轮雇佣，我们从 [1,2,4,1] 中选择。最小代价为 1 ，有两位工人，我们选择下标更小的一位工人，即第 0 位工人，总代价是 0 + 1 = 1
// 。注意，下标为 1 和 2 的工人同时在最前面和最后面 3 位工人中。
//- 第二轮雇佣，我们从 [2,4,1] 中选择。最小代价为 1 ，下标为 2 ，总代价是 1 + 1 = 2 。
//- 第三轮雇佣，少于 3 位工人，我们从剩余工人 [2,4] 中选择。最小代价是 2 ，下标为 0 。总代价为 2 + 2 = 4 。
//总雇佣代价是 4 。
//
//
//
//
// 提示：
//
//
// 1 <= costs.length <= 105
// 1 <= costs[i] <= 10⁵
// 1 <= k, candidates <= costs.length
//
//
// Related Topics 数组 双指针 模拟 堆（优先队列） 👍 59 👎 0

using System.Collections.Generic;

namespace LeetCode;

public class Solution2462
{
    public long TotalCost(int[] costs, int k, int candidates) {
        var len = costs.Length;
        var i = 0;
        var j = len - 1;
        var queue = new PriorityQueue<int, (int, int)>();
        while (i < candidates && i < costs.Length) {
            queue.Enqueue(costs[i], (costs[i], i));
            i++;
        }
        while (len - j - 1 < candidates && j > 0 && j >= i) {
            queue.Enqueue(costs[j], (costs[j], j));
            j--;
        }

        var total = 0L;
        while (k-- > 0) {
            if (!queue.TryPeek(out var min, out var priority)) {
                break;
            }
            total += min;
            queue.Dequeue();

            if (priority.Item2 < i) {
                if (i < costs.Length && i <= j) {
                    queue.Enqueue(costs[i], (costs[i], i));
                    i++;
                }
            }
            else {
                if (j >= 0 && j >= i) {
                    queue.Enqueue(costs[j], (costs[j], j));
                    j--;
                }
            }
        }

        return total;
    }
}