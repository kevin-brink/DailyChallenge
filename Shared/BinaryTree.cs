using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Shared
{
    public class BinaryTree<T> where T : IComparable
    {
        public Node<T>? Root;

        public BinaryTree() => Root = null;
        public BinaryTree(T value) => Root = new Node<T>(value);
        public BinaryTree(Node<T>? root) => Root = root;
        public BinaryTree(List<T> values)
        {
            foreach (var value in values)
                Insert(value);
        }

        public void Insert(Node<T> node)
        {
            if (Root is null)
                Root = node;
            else
                Root.Insert(node);
        }

        public void Insert(T value)
        {
            if (Root is null)
                Root = new Node<T>(value);
            else
                Root.Insert(value);
        }

        public List<T> Traverse_PreOrder() => Root?.Traverse_PreOrder() ?? new();
        public List<T> Traverse_InOrder() => Root?.Traverse_InOrder() ?? new();
        public List<T> Traverse_PostOrder() => Root?.Traverse_PostOrder() ?? new();

        public static bool IsEqual<U>(BinaryTree<U> tree1, BinaryTree<U> tree2) where U : IComparable
        {
            return Node<U>.IsEqual(tree1.Root, tree2.Root);
        }
    }

    public class Node<T> where T : IComparable
    {
        public T Value;
        public Node<T>? Left;
        public Node<T>? Right;

        public Node(T value, Node<T>? left = null, Node<T>? right = null)
        {
            Value = value;
            Left = left;
            Right = right;
        }

        public void Insert(Node<T> node)
        {
            if (node.Value.CompareTo(Value) < 0)
            {
                if (Left is null)
                    Left = node;
                else
                    Left.Insert(node);
            }
            else
            {
                if (Right is null)
                    Right = node;
                else
                    Right.Insert(node);
            }
        }

        public void Insert(T value)
        {
            if (value.CompareTo(Value) < 0)
            {
                if (Left is null)
                    Left = new Node<T>(value);
                else
                    Left.Insert(value);
            }
            else
            {
                if (Right is null)
                    Right = new Node<T>(value);
                else
                    Right.Insert(value);
            }
        }

        public List<T> Traverse_PreOrder()
        {
            var output = new List<T>();

            output.Add(Value);
            if (Left is not null)
                output.AddRange(Left.Traverse_PreOrder());
            if (Right is not null)
                output.AddRange(Right.Traverse_PreOrder());

            return output;
        }

        public List<T> Traverse_InOrder()
        {
            var output = new List<T>();

            if (Left is not null)
                output.AddRange(Left.Traverse_InOrder());
            output.Add(Value);
            if (Right is not null)
                output.AddRange(Right.Traverse_InOrder());

            return output;
        }

        public List<T> Traverse_PostOrder()
        {
            var output = new List<T>();

            if (Left is not null)
                output.AddRange(Left.Traverse_PostOrder());
            if (Right is not null)
                output.AddRange(Right.Traverse_PostOrder());
            output.Add(Value);

            return output;
        }

        public static bool IsEqual<U>(Node<U>? node1, Node<U>? node2) where U : IComparable
        {
            if (node1 is null && node2 is not null) return false;
            if (node1 is not null && node2 is null) return false;
            if (node1 is null && node2 is null) return true;

            // Null-forgiving is acceptable because the above checks gurantee nothing is null
            if (node1?.Value.CompareTo(node2!.Value) != 0) return false;

            return Node<U>.IsEqual(node1.Left, node2.Left)
                && Node<U>.IsEqual(node1.Right, node2.Right);
        }
    }
}
