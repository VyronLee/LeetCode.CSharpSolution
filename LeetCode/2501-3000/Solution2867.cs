// ------------------------------------------------------------
//         File: Solution2867.cs
//        Brief: Solution2867.cs
//
//       Author: VyronLee, lwz_jz@hotmail.com
//
//      Created: 2024-2-27 17:15
//    Copyright: Copyright (c) 2024, VyronLee
// ============================================================

//给你一棵 n 个节点的无向树，节点编号为 1 到 n 。给你一个整数 n 和一个长度为 n - 1 的二维整数数组 edges ，其中 edges[i] =
// [ui, vi] 表示节点 ui 和 vi 在树中有一条边。
//
// 请你返回树中的 合法路径数目 。
//
// 如果在节点 a 到节点 b 之间 恰好有一个 节点的编号是质数，那么我们称路径 (a, b) 是 合法的 。
//
// 注意：
//
//
// 路径 (a, b) 指的是一条从节点 a 开始到节点 b 结束的一个节点序列，序列中的节点 互不相同 ，且相邻节点之间在树上有一条边。
// 路径 (a, b) 和路径 (b, a) 视为 同一条 路径，且只计入答案 一次 。
//
//
//
//
// 示例 1：
//
//
//
//
//输入：n = 5, edges = [[1,2],[1,3],[2,4],[2,5]]
//输出：4
//解释：恰好有一个质数编号的节点路径有：
//- (1, 2) 因为路径 1 到 2 只包含一个质数 2 。
//- (1, 3) 因为路径 1 到 3 只包含一个质数 3 。
//- (1, 4) 因为路径 1 到 4 只包含一个质数 2 。
//- (2, 4) 因为路径 2 到 4 只包含一个质数 2 。
//只有 4 条合法路径。
//
//
// 示例 2：
//
//
//
//
//输入：n = 6, edges = [[1,2],[1,3],[2,4],[3,5],[3,6]]
//输出：6
//解释：恰好有一个质数编号的节点路径有：
//- (1, 2) 因为路径 1 到 2 只包含一个质数 2 。
//- (1, 3) 因为路径 1 到 3 只包含一个质数 3 。
//- (1, 4) 因为路径 1 到 4 只包含一个质数 2 。
//- (1, 6) 因为路径 1 到 6 只包含一个质数 3 。
//- (2, 4) 因为路径 2 到 4 只包含一个质数 2 。
//- (3, 6) 因为路径 3 到 6 只包含一个质数 3 。
//只有 6 条合法路径。
//
//
//
//
// 提示：
//
//
// 1 <= n <= 10⁵
// edges.length == n - 1
// edges[i].length == 2
// 1 <= ui, vi <= n
// 输入保证 edges 形成一棵合法的树。
//
//
// Related Topics 树 深度优先搜索 数学 动态规划 数论 👍 54 👎 0

using System.Collections.Generic;

namespace LeetCode
{
    public class Solution2867
    {
        private bool[] SieveOfEratosthenes(int n) {
            var isPrime = new bool[n + 1];
            for (var i = 2; i <= n; i++)
                isPrime[i] = true;

            for (var p = 2; p * p <= n; p++) {
                if (!isPrime[p])
                    continue;
                for (var i = p * p; i <= n; i += p)
                    isPrime[i] = false;
            }
            return isPrime;
        }

        public long CountPaths(int n, int[][] edges) {
            var primes = SieveOfEratosthenes(n);
            var dict = BuildTree(n, edges, primes);
            var cnt = 0L;
            foreach (var kv in dict) {
                cnt += InternalCountPaths(kv.Value, null, 0L, 0L);
            }
            return cnt/2;
        }

        private long InternalCountPaths(TreeNode root, TreeNode parent, long nodes, long primes) {
            if (null == root || primes >= 2) {
                return 0;
            }

            primes += root.Prime ? 1 : 0;
            if (primes >= 2) {
                return 0;
            }

            nodes++;
            var cnt = 0L;
            if (primes == 1 && nodes > 1) {
                cnt = 1;
            }
            root.Neighbors.ForEach(v => {
                if (v == parent) {
                    return;
                }
                cnt += InternalCountPaths(v, root, nodes, primes);
            });

            return cnt;
        }

        private Dictionary<int, TreeNode> BuildTree(int n, int[][] edges, bool[] primes) {
            var dict = new Dictionary<int, TreeNode>();
            foreach (var edge in edges) {
                var (parent, child) = (edge[0], edge[1]);
                if (!dict.TryGetValue(parent, out var parentNode)) {
                    parentNode = dict[parent] = new TreeNode(parent);
                    parentNode.Prime = primes[parent];
                }
                if (!dict.TryGetValue(child, out var childNode)) {
                    childNode = dict[child] = new TreeNode(child);
                    childNode.Prime = primes[child];
                }
                childNode.Neighbors.Add(parentNode);
                parentNode.Neighbors.Add(childNode);
            }
            return dict;
        }

        private class TreeNode
        {
            public int Val { get; }
            public List<TreeNode> Neighbors { get; } = new();
            public bool Prime { get; set; }

            public TreeNode(int val) {
                Val = val;
            }
        }
    }
}