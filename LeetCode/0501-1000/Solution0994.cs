﻿// ------------------------------------------------------------
//         File: Solution0994.cs
//        Brief: Solution0994.cs
//
//       Author: VyronLee, lwz_jz@hotmail.com
//
//      Created: 2024-3-8 19:4
//    Copyright: Copyright (c) 2024, VyronLee
// ============================================================

//在给定的 m x n 网格
// grid 中，每个单元格可以有以下三个值之一：
//
//
// 值 0 代表空单元格；
// 值 1 代表新鲜橘子；
// 值 2 代表腐烂的橘子。
//
//
// 每分钟，腐烂的橘子 周围 4 个方向上相邻 的新鲜橘子都会腐烂。
//
// 返回 直到单元格中没有新鲜橘子为止所必须经过的最小分钟数。如果不可能，返回 -1 。
//
//
//
// 示例 1：
//
//
//
//
//输入：grid = [[2,1,1],[1,1,0],[0,1,1]]
//输出：4
//
//
// 示例 2：
//
//
//输入：grid = [[2,1,1],[0,1,1],[1,0,1]]
//输出：-1
//解释：左下角的橘子（第 2 行， 第 0 列）永远不会腐烂，因为腐烂只会发生在 4 个方向上。
//
//
// 示例 3：
//
//
//输入：grid = [[0,2]]
//输出：0
//解释：因为 0 分钟时已经没有新鲜橘子了，所以答案就是 0 。
//
//
//
//
// 提示：
//
//
// m == grid.length
// n == grid[i].length
// 1 <= m, n <= 10
// grid[i][j] 仅为 0、1 或 2
//
//
// Related Topics 广度优先搜索 数组 矩阵 👍 818 👎 0

using System.Collections.Generic;

namespace LeetCode
{
    public class Solution0994
    {
        public int OrangesRotting(int[][] grid) {
            var rowCount = grid.Length;
            var colCount = grid[0].Length;

            var freshCount = 0;
            var curr = new List<(int, int)>();
            var next = new List<(int, int)>();
            for (var i = 0; i < rowCount; i++) {
                for (var j = 0; j < colCount; j++) {
                    if (grid[i][j] == 2) {
                        curr.Add((i, j));
                    }
                    else if (grid[i][j] == 1) {
                        freshCount++;
                    }
                }
            }

            if (curr.Count <= 0) {
                if (freshCount > 0) {
                    return -1;
                }
                return 0;
            }

            var min = -1;
            while (curr.Count > 0) {
                min++;
                for (var i = 0; i < curr.Count; i++) {
                    var (row, col) = curr[i];
                    TryRotte(row-1, col);
                    TryRotte(row, col-1);
                    TryRotte(row+1, col);
                    TryRotte(row, col+1);
                }
                (curr, next) = (next, curr);
                next.Clear();
            }
            return freshCount > 0 ? -1 : min;

            void TryRotte(int i, int j) {
                if (i < 0 || i >= rowCount || j < 0 || j >= colCount) {
                    return;
                }
                if (grid[i][j] != 1) {
                    return;
                }
                Rotte(i, j);
            }

            void Rotte(int i, int j) {
                next.Add((i, j));
                grid[i][j] = 2;
                freshCount--;
            }
        }
    }
}