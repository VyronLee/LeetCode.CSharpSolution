// ------------------------------------------------------------
//         File: Solution0735.cs
//        Brief: Solution0735.cs
//
//       Author: VyronLee, lwz_jz@hotmail.com
//
//      Created: 2024-2-20 22:42
//    Copyright: Copyright (c) 2024, VyronLee
// ============================================================

//给定一个整数数组 asteroids，表示在同一行的小行星。
//
// 对于数组中的每一个元素，其绝对值表示小行星的大小，正负表示小行星的移动方向（正表示向右移动，负表示向左移动）。每一颗小行星以相同的速度移动。
//
// 找出碰撞后剩下的所有小行星。碰撞规则：两个小行星相互碰撞，较小的小行星会爆炸。如果两颗小行星大小相同，则两颗小行星都会爆炸。两颗移动方向相同的小行星，永远
//不会发生碰撞。
//
//
//
// 示例 1：
//
//
//输入：asteroids = [5,10,-5]
//输出：[5,10]
//解释：10 和 -5 碰撞后只剩下 10 。 5 和 10 永远不会发生碰撞。
//
// 示例 2：
//
//
//输入：asteroids = [8,-8]
//输出：[]
//解释：8 和 -8 碰撞后，两者都发生爆炸。
//
// 示例 3：
//
//
//输入：asteroids = [10,2,-5]
//输出：[10]
//解释：2 和 -5 发生碰撞后剩下 -5 。10 和 -5 发生碰撞后剩下 10 。
//
//
//
// 提示：
//
//
// 2 <= asteroids.length <= 10⁴
// -1000 <= asteroids[i] <= 1000
// asteroids[i] != 0
//
//
// Related Topics 栈 数组 模拟 👍 478 👎 0

using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCode
{
    public class Solution0735
    {
        public int[] AsteroidCollision(int[] asteroids) {
            if (asteroids.Length <= 0) {
                return Array.Empty<int>();
            }

            var stack = new Stack<int>(asteroids.Length);
            for (var i = 0; i < asteroids.Length; i++) {
                while (true) {
                    if (!stack.TryPeek(out var top)) {
                        stack.Push(asteroids[i]);
                        break;
                    }

                    var signT = Math.Sign(top);
                    var signN = Math.Sign(asteroids[i]);
                    if (signT == signN || signT < 0 && signN > 0) {
                        stack.Push(asteroids[i]);
                        break;
                    }

                    var sizeT = Math.Abs(top);
                    var sizeN = Math.Abs(asteroids[i]);
                    if (sizeT == sizeN) {
                        stack.Pop();
                        break;
                    }

                    if (sizeT < sizeN) {
                        stack.Pop();
                        continue;
                    }
                    break;
                }
            }
            return stack.Reverse().ToArray();
        }
    }
}