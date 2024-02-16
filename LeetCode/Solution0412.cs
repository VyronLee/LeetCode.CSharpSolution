// ------------------------------------------------------------
//         File: Solution0412.cs
//        Brief: Solution0412.cs
//
//       Author: VyronLee, lwz_jz@hotmail.com
//
//      Created: 2024-2-16 11:49
//    Copyright: Copyright (c) 2024, VyronLee
// ============================================================

//给你一个整数 n ，找出从 1 到 n 各个整数的 Fizz Buzz 表示，并用字符串数组 answer（下标从 1 开始）返回结果，其中：
//
//
// answer[i] == "FizzBuzz" 如果 i 同时是 3 和 5 的倍数。
// answer[i] == "Fizz" 如果 i 是 3 的倍数。
// answer[i] == "Buzz" 如果 i 是 5 的倍数。
// answer[i] == i （以字符串形式）如果上述条件全不满足。
//
//
//
//
// 示例 1：
//
//
//输入：n = 3
//输出：["1","2","Fizz"]
//
//
// 示例 2：
//
//
//输入：n = 5
//输出：["1","2","Fizz","4","Buzz"]
//
//
// 示例 3：
//
//
//输入：n = 15
//输出：["1","2","Fizz","4","Buzz","Fizz","7","8","Fizz","Buzz","11","Fizz","13","1
//4","FizzBuzz"]
//
//
//
// 提示：
//
//
// 1 <= n <= 10⁴
//
//
// Related Topics 数学 字符串 模拟 👍 331 👎 0

using System.Collections.Generic;
using System.Text;

namespace LeetCode
{
    public class Solution0412
    {
        public IList<string> FizzBuzz(int n) {
            const string fizz = "Fizz";
            const string buzz = "Buzz";
            var ret = new List<string>();
            var sb = new StringBuilder();
            for (var i = 1; i <= n; i++) {
                sb.Clear();
                if (i % 3 == 0)
                    sb.Append(fizz);
                if (i % 5 == 0)
                    sb.Append(buzz);
                if (sb.Length <= 0)
                    sb.Append(i);
                ret.Add(sb.ToString());
            }
            return ret;
        }
    }
}