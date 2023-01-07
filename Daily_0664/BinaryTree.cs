using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Daily_664
{
    internal class BinaryTree
    {
        private Node Root { get; set; } = null;

        private BinaryTree() { }

        public BinaryTree(int value)
        {
            Root = new Node(value);
        }

        public BinaryTree(List<int> values)
        {
            foreach (var value in values)
                Insert(value);
        }

        public void Insert(int value)
        {
            if (Root is null)
                Root = new Node(value);
            else
                Root.Insert(value);
        }

        public List<int> Traverse_PreOrder() => Root.Traverse_PreOrder();
        public List<int> Traverse_InOrder() => Root.Traverse_InOrder(); 
        public List<int> Traverse_PostOrder() => Root.Traverse_PostOrder();

        public int MaxDepth() => Root.MaxDepth();

        public class Node
        {
            public int Value { get; private set; }
            public Node Left { get; set; }
            public Node Right { get; set; }

            public Node(int value)
            {
                Value = value;
            }

            public void Insert(int value)
            {
                if (value < Value)
                {
                    if (Left is null)
                        Left = new Node(value);
                    else
                        Left.Insert(value);
                }
                else
                {
                    if (Right is null)
                        Right = new Node(value);
                    else
                        Right.Insert(value);
                }                
            }

            public List<int> Traverse_PreOrder()
            {
                var output = new List<int>();

                output.Add(Value);
                if (Left is not null)
                    output.AddRange(Left.Traverse_PreOrder());
                if (Right is not null)
                    output.AddRange(Right.Traverse_PreOrder());

                return output;
            }

            public List<int> Traverse_InOrder()
            {
                var output = new List<int>();

                if (Left is not null)
                    output.AddRange(Left.Traverse_InOrder());
                output.Add(Value);
                if (Right is not null)
                    output.AddRange(Right.Traverse_InOrder());

                return output;
            }

            public List<int> Traverse_PostOrder()
            {
                var output = new List<int>();

                if (Left is not null)
                    output.AddRange(Left.Traverse_PostOrder());
                if (Right is not null)
                    output.AddRange(Right.Traverse_PostOrder());
                output.Add(Value);

                return output;
            }

            public int MaxDepth()
            {
                var leftDepth = Left?.MaxDepth() ?? 0;
                var rightDepth = Right?.MaxDepth() ?? 0;

                if (leftDepth > rightDepth)
                    return leftDepth + 1;
                else
                    return rightDepth + 1;
            }
        }

    }
}
