/*
 
This problem was asked by Google.

Given the root to a binary tree, implement serialize(root), which serializes the tree into a string, 
and deserialize(s), which deserializes the string back into the tree.

For example, given the following Node class

class Node:
    def __init__(self, val, left=None, right=None):
        self.val = val
        self.left = left
        self.right = right
The following test should pass:

node = Node('root', Node('left', Node('left.left')), Node('right'))
assert deserialize(serialize(node)).left.left.val == 'left.left'

 */

using Shared;
using System.Diagnostics;

namespace Daily_0003
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var tree = new BinaryTree<int>(new List<int>() { 5, 4, 6, 3, 5, 7, 1, 10 });
            var newTree = BinaryTreeExtender.Deserialize<int>(tree.Serialize());

            var isEqual = BinaryTree<int>.IsEqual(tree, newTree);     
            Debug.Assert(isEqual);
        }
    }
}