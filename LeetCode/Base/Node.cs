// ------------------------------------------------------------
//         File: Node.cs
//        Brief: Node.cs
//
//       Author: VyronLee, lwz_jz@hotmail.com
//
//      Created: 2024-2-17 13:26
//    Copyright: Copyright (c) 2024, VyronLee
// ============================================================

using System.Collections.Generic;

namespace LeetCode
{
    public class Node {
        public int val;
        public IList<Node> children;

        public Node() {}

        public Node(int _val) {
            val = _val;
        }

        public Node(int _val, IList<Node> _children) {
            val = _val;
            children = _children;
        }
    }
}