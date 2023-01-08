using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Xml.Linq;
using Shared;

namespace Daily_0003
{
    public static class BinaryTreeExtender
    {
        public static string Serialize<T>(this BinaryTree<T> tree) where T : IComparable
        {
            string type = typeof(T).Name;

            string serial = $"{type},({tree.Root?.Serialize() ?? ""})";

            return serial;
        }

        public static BinaryTree<T> Deserialize<T>(string serialTree) where T : IComparable
        {
            int split = serialTree.IndexOf(',');

            string typeString = serialTree.Substring(0, split);
            if (typeof(T).Name != typeString)
                throw new ArgumentException("The type given for 'T' is the original type of this serial tree");

            string serialNodes = serialTree.Substring(split + 1);
            if (serialNodes.First() != '(' && serialNodes.Last() != ')')
                throw new ArgumentException("This isnt a serial tree");

            return new BinaryTree<T>(NodeExtender.Deserialize<T>(serialNodes));
        }
    }

    public static class NodeExtender
    {
        public static string Serialize<T>(this Node<T> node) where T : IComparable
        {
            return $"{JsonSerializer.Serialize(node.Value)},({node.Left?.Serialize() ?? ""}),({node.Right?.Serialize() ?? ""})";
        }

        public static Node<T>? Deserialize<T>(string serialNode) where T : IComparable
        {
            if (serialNode.First() != '(' || serialNode.Last() != ')')
                throw new ArgumentException($"Something is wrong with node: '{serialNode}'");

            if (serialNode == "()")
                return null;

            serialNode = serialNode.Substring(1, serialNode.Length - 2);
                
            int split = serialNode.IndexOf(',');
            string serialValue = serialNode.Substring(0, split);
            T value = JsonSerializer.Deserialize<T>(serialValue)!;

            string serialNodes = serialNode.Substring(split + 1);
            string serialLeft = serialNodes.Substring(0, LeftParenthesisMatch(0, serialNodes));
            string serialRight = serialNodes.Substring(RightParenthesisMatch(serialNodes.Length-1, serialNodes));

            if (serialNodes != $"{serialLeft},{serialRight}")
                throw new Exception();

            Node<T>? left = Deserialize<T>(serialLeft);
            Node<T>? right = Deserialize<T>(serialRight);

            return new(value, left, right);
        }

        private static int LeftParenthesisMatch(int left, string serial)
        {
            int current = 0;

            for (int index = left + 1; index < serial.Length; index++)
            {
                if (serial[index] == '(')
                    ++current;
                if (serial[index] == ')')
                {
                    --current;

                    if (current == -1)
                        return index + 1;
                }
            }

            throw new Exception("There was no matching parenthesis");
        }

        private static int RightParenthesisMatch(int right, string serial)
        {
            int current = 0;

            for (int index = right - 1; index > 0; index--)
            {
                if (serial[index] == '(')
                {
                    --current;

                    if (current == -1)
                        return index;
                }
                if (serial[index] == ')')
                    ++current;
            }

            throw new Exception("There was no matching parenthesis");
        }
    }
}
