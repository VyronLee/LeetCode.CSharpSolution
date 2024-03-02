// ------------------------------------------------------------
//         File: Solution0547.cs
//        Brief: Solution0547.cs
//
//       Author: VyronLee, lwz_jz@hotmail.com
//
//      Created: 2024-3-2 14:21
//    Copyright: Copyright (c) 2024, VyronLee
// ============================================================

//
//
// 有 n 个城市，其中一些彼此相连，另一些没有相连。如果城市 a 与城市 b 直接相连，且城市 b 与城市 c 直接相连，那么城市 a 与城市 c 间接相连
//。
//
//
//
// 省份 是一组直接或间接相连的城市，组内不含其他没有相连的城市。
//
// 给你一个 n x n 的矩阵 isConnected ，其中 isConnected[i][j] = 1 表示第 i 个城市和第 j 个城市直接相连，而
//isConnected[i][j] = 0 表示二者不直接相连。
//
// 返回矩阵中 省份 的数量。
//
//
//
// 示例 1：
//
//
//输入：isConnected = [[1,1,0],[1,1,0],[0,0,1]]
//输出：2
//
//
// 示例 2：
//
//
//输入：isConnected = [[1,0,0],[0,1,0],[0,0,1]]
//输出：3
//
//
//
//
// 提示：
//
//
// 1 <= n <= 200
// n == isConnected.length
// n == isConnected[i].length
// isConnected[i][j] 为 1 或 0
// isConnected[i][i] == 1
// isConnected[i][j] == isConnected[j][i]
//
//
// Related Topics 深度优先搜索 广度优先搜索 并查集 图 👍 1091 👎 0

using System.Linq;

namespace LeetCode
{
    public class Solution0547
    {
        public int FindCircleNum(int[][] isConnected) {
            var set = new DisjointSet(isConnected.Length);
            for (var i = 0; i < isConnected.Length; i++) {
                for (var j = 0; j < isConnected[i].Length; j++) {
                    if (isConnected[i][j] == 0) {
                        continue;
                    }
                    set.Union(i, j);
                }
            }
            return set.GetRootsCount();
        }

        private class DisjointSet
        {
            private readonly int[] _parent;
            private readonly int[] _rank;

            public DisjointSet(int size) {
                _parent = new int[size];
                _rank = new int[size];

                for (var i = 0; i < size; i++) {
                    _parent[i] = i; // Initially, every element is its own parent
                    _rank[i] = 0; // Initial rank of all elements is 0
                }
            }

            // Find the root of the set in which element 'i' belongs
            public int Find(int i) {
                if (_parent[i] != i) { // Path Compression
                    _parent[i] = Find(_parent[i]);
                }
                return _parent[i];
            }

            // Union by Rank
            public void Union(int x, int y) {
                var xRoot = Find(x);
                var yRoot = Find(y);

                if (xRoot == yRoot)
                    return; // Already in the same set

                // Merge the smaller rank tree into the larger rank tree
                if (_rank[xRoot] < _rank[yRoot]) {
                    _parent[xRoot] = yRoot;
                    _rank[xRoot] = 0;
                }
                else if (_rank[yRoot] < _rank[xRoot]) {
                    _parent[yRoot] = xRoot;
                    _rank[yRoot] = 0;
                }
                else { // If ranks are same, then make one as root and increment its rank by one
                    _parent[yRoot] = xRoot;
                    _rank[yRoot] = 0;
                    _rank[xRoot]++;
                }
            }

            public int GetRootsCount() {
                return _parent.Where((t, i) => t == i).Count();
            }
        }
    }
}