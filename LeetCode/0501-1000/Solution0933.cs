// ------------------------------------------------------------
//         File: Solution0933.cs
//        Brief: Solution0933.cs
//
//       Author: VyronLee, lwz_jz@hotmail.com
//
//      Created: 2024-2-23 21:44
//    Copyright: Copyright (c) 2024, VyronLee
// ============================================================

//写一个 RecentCounter 类来计算特定时间范围内最近的请求。
//
// 请你实现 RecentCounter 类：
//
//
// RecentCounter() 初始化计数器，请求数为 0 。
// int ping(int t) 在时间 t 添加一个新请求，其中 t 表示以毫秒为单位的某个时间，并返回过去 3000 毫秒内发生的所有请求数（包括新请求
//）。确切地说，返回在 [t-3000, t] 内发生的请求数。
//
//
// 保证 每次对 ping 的调用都使用比之前更大的 t 值。
//
//
//
// 示例 1：
//
//
//输入：
//["RecentCounter", "ping", "ping", "ping", "ping"]
//[[], [1], [100], [3001], [3002]]
//输出：
//[null, 1, 2, 3, 3]
//
//解释：
//RecentCounter recentCounter = new RecentCounter();
//recentCounter.ping(1);     // requests = [1]，范围是 [-2999,1]，返回 1
//recentCounter.ping(100);   // requests = [1, 100]，范围是 [-2900,100]，返回 2
//recentCounter.ping(3001);  // requests = [1, 100, 3001]，范围是 [1,3001]，返回 3
//recentCounter.ping(3002);  // requests = [1, 100, 3001, 3002]，范围是 [2,3002]，返回
//3
//
//
//
//
// 提示：
//
//
// 1 <= t <= 10⁹
// 保证每次对 ping 调用所使用的 t 值都 严格递增
// 至多调用 ping 方法 10⁴ 次
//
//
// Related Topics 设计 队列 数据流 👍 247 👎 0

using System.Collections.Generic;

namespace LeetCode
{
    public class Solution0933
    {
        public class RecentCounter {

            private readonly List<int> _list = new List<int>();
            private int _left = -1;

            public RecentCounter() {

            }

            public int Ping(int t) {
                _list.Add(t);
                if (_left < 0) {
                    _left = 0;
                    return 1;
                }
                while (_left < _list.Count && t - _list[_left] > 3000) {
                    _left++;
                }
                return _list.Count - _left;
            }
        }
    }
}