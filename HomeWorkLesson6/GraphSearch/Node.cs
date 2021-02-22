using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphSearch
{
    public class Node
    {
        public bool Visited;
        public int Value { get; }
        public List<Node> Children;

        public Node(int value)
        {
            Visited = false;
            Value = value;
            Children = new List<Node>();
        }

        public Node AddChild(Node node, bool bidirect = true)
        {
            Children.Add(node);
            if (bidirect)
            {
                node.Children.Add(this);
            }
            return this;
        }
    }
}
