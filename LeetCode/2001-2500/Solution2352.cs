// ------------------------------------------------------------
//         File: Solution2352.cs
//        Brief: Solution2352.cs
//
//       Author: VyronLee, lwz_jz@hotmail.com
//
//      Created: 2024-2-20 20:21
//    Copyright: Copyright (c) 2024, VyronLee
// ============================================================

//给你一个下标从 0 开始、大小为 n x n 的整数矩阵 grid ，返回满足 Ri 行和 Cj 列相等的行列对 (Ri, Cj) 的数目。
//
// 如果行和列以相同的顺序包含相同的元素（即相等的数组），则认为二者是相等的。
//
//
//
// 示例 1：
//
//
//
//
//输入：grid = [[3,2,1],[1,7,6],[2,7,7]]
//输出：1
//解释：存在一对相等行列对：
//- (第 2 行，第 1 列)：[2,7,7]
//
//
// 示例 2：
//
//
//
//
//输入：grid = [[3,1,2,2],[1,4,4,5],[2,4,2,2],[2,4,2,2]]
//输出：3
//解释：存在三对相等行列对：
//- (第 0 行，第 0 列)：[3,1,2,2]
//- (第 2 行, 第 2 列)：[2,4,2,2]
//- (第 3 行, 第 2 列)：[2,4,2,2]
//
//
//
//
// 提示：
//
//
// n == grid.length == grid[i].length
// 1 <= n <= 200
// 1 <= grid[i][j] <= 10⁵
//
//
// Related Topics 数组 哈希表 矩阵 模拟 👍 91 👎 0

namespace LeetCode
{
    public class Solution2352
    {
        public int EqualPairs(int[][] grid) {
            var cnt = 0;
            for (var row = 0; row < grid.Length; row++) {
                for (var col = 0; col < grid.Length; col++) {
                    if (ArrayEquals(grid, row, col)) {
                        cnt++;
                    }
                }
            }
            return cnt;
        }

        private bool ArrayEquals(int[][] grid, int row, int col) {
            for (var i = 0; i < grid.Length; i++) {
                if (grid[row][i] != grid[i][col]) {
                    return false;
                }
            }
            return true;
        }
    }
}