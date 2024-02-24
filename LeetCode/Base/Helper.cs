// ------------------------------------------------------------
//         File: Helper.cs
//        Brief: Helper.cs
//
//       Author: VyronLee, lwz_jz@hotmail.com
//
//      Created: 2024-2-18 20:59
//    Copyright: Copyright (c) 2024, VyronLee
// ============================================================

using System.Collections.Generic;
using System.Linq;

namespace LeetCode
{
    public class Helper
    {
        public static string ArrayToString<T>(IEnumerable<T> array) {
            return $"[{string.Join(", ", array)}]";
        }

        public static string DictToString<T, U>(Dictionary<T, U> dict) {
            return $"{string.Join(", ", dict.Select(kv => $"{kv.Key}: {kv.Value}"))}";
        }

        public static string LinkedListToString(ListNode root) {
            var list = new List<int>();
            while (root != null) {
                list.Add(root.val);
                root = root.next;
            }
            return $"[{string.Join(", ", list)}]";
        }
    }
}