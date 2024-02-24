// ------------------------------------------------------------
//         File: Solution2476.cs
//        Brief: Solution2476.cs
//
//       Author: VyronLee, lwz_jz@hotmail.com
//
//      Created: 2024-2-24 20:22
//    Copyright: Copyright (c) 2024, VyronLee
// ============================================================

//给你一个 二叉搜索树 的根节点 root ，和一个由正整数组成、长度为 n 的数组 queries 。
//
// 请你找出一个长度为 n 的 二维 答案数组 answer ，其中 answer[i] = [mini, maxi] ：
//
//
// mini 是树中小于等于 queries[i] 的 最大值 。如果不存在这样的值，则使用 -1 代替。
// maxi 是树中大于等于 queries[i] 的 最小值 。如果不存在这样的值，则使用 -1 代替。
//
//
// 返回数组 answer 。
//
//
//
// 示例 1 ：
//
//
//
//
//输入：root = [6,2,13,1,4,9,15,null,null,null,null,null,null,14], queries = [2,5,1
//6]
//输出：[[2,2],[4,6],[15,-1]]
//解释：按下面的描述找出并返回查询的答案：
//- 树中小于等于 2 的最大值是 2 ，且大于等于 2 的最小值也是 2 。所以第一个查询的答案是 [2,2] 。
//- 树中小于等于 5 的最大值是 4 ，且大于等于 5 的最小值是 6 。所以第二个查询的答案是 [4,6] 。
//- 树中小于等于 16 的最大值是 15 ，且大于等于 16 的最小值不存在。所以第三个查询的答案是 [15,-1] 。
//
//
// 示例 2 ：
//
//
//
//
//输入：root = [4,null,9], queries = [3]
//输出：[[-1,4]]
//解释：树中不存在小于等于 3 的最大值，且大于等于 3 的最小值是 4 。所以查询的答案是 [-1,4] 。
//
//
//
//
// 提示：
//
//
// 树中节点的数目在范围 [2, 10⁵] 内
// 1 <= Node.val <= 10⁶
// n == queries.length
// 1 <= n <= 10⁵
// 1 <= queries[i] <= 10⁶
//
//
// Related Topics 树 深度优先搜索 二叉搜索树 数组 二分查找 二叉树 👍 59 👎 0

using System.Collections.Generic;

namespace LeetCode
{
    public class Solution2476
    {
        public IList<IList<int>> ClosestNodes(TreeNode root, IList<int> queries) {
            var orderedList = new List<int>();
            DepthFirstSearch(root, orderedList);

            var ans = new List<IList<int>>();
            foreach (var query in queries) {
                var pairs = new List<int>();
                ans.Add(pairs);

                var (min, max) = (int.MinValue, int.MaxValue);

                if (query < orderedList[0]) {
                    min = -1;
                    max = orderedList[0];
                }
                else if (query > orderedList[^1]) {
                    min = orderedList[^1];
                    max = -1;
                }
                else {
                    var l = 0;
                    var r = orderedList.Count - 1;
                    while (l <= r) {
                        var m = l + (r - l) / 2;
                        if (query < orderedList[m]) {
                            r = m - 1;
                        }
                        else if (query > orderedList[m]) {
                            l = m + 1;
                        }
                        else {
                            min = max = orderedList[m];
                            break;
                        }
                    }
                    if (l > r) {
                        min = orderedList[r];
                        max = orderedList[l];
                    }
                }
                pairs.Add(min);
                pairs.Add(max);
            }
            return ans;
        }

        private void DepthFirstSearch(TreeNode root, List<int> ret) {
            if (null == root) {
                return;
            }
            DepthFirstSearch(root.left, ret);
            ret.Add(root.val);
            DepthFirstSearch(root.right, ret);
        }
    }
}