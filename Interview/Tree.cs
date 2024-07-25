using System;
using System.Collections.Generic;
using System.Text;

namespace Interview
{
    public static class Tree
    {
        public static void TreeDriver()
        {
            string data = "[1,2,3,4,5,null,null]";
            var root = deserialize(data);
            var level = GetLevelOfTree(root);
            //var s = serialize(root);
        }
        private static int[] ConvertStringToIntArray(string data)
        {
            if (String.IsNullOrEmpty(data))
            {
                // Error
                return new int[0];
            }

            data = data.Substring(1, data.Length - 2);
            string[] contents = data.Split(',');

            int[] ret = new int[contents.Length];
            int index = 0;
            foreach (string s in contents)
            {
                int i;
                bool success = Int32.TryParse(s, out i);
                if (success)
                {
                    ret[index] = i;
                }
                else
                {
                    if (s == "null")
                    {
                        ret[index] = Int32.MaxValue;
                    }
                }
                index++;
            }

            return ret;
        }

        public static string serialize(TreeNode root)
        {
            Queue<TreeNode> q = new Queue<TreeNode>();
            q.Enqueue(root);
            StringBuilder sb = new StringBuilder();
            sb.Append("[");
            bool isFirstVal = true;
            TreeNode nullNode = new TreeNode(Int32.MaxValue);
            int level = 1;
            double size = Math.Pow(2, level);
            while (q.Count != 0)
            {
                var currNode = q.Dequeue();
                if (currNode.left == null && size > 0)
                {
                    q.Enqueue(nullNode);
                }
                else
                {
                    q.Enqueue(currNode.left);
                }
                size--;
                if (currNode.right == null && size > 0)
                {
                    q.Enqueue(nullNode);
                }
                else
                {
                    q.Enqueue(currNode.right);
                }
                size--;

                if (isFirstVal)
                {
                    sb.Append(currNode.val);
                    isFirstVal = false;
                }
                else
                {
                    sb.Append(",");
                    if (currNode.val == Int32.MaxValue)
                    {
                        sb.Append("null");
                    }
                    else
                    {
                        sb.Append(currNode.val);
                    }
                }


            }
            sb.Append("]");

            return sb.ToString();

        }

        public static int GetLevelOfTree(TreeNode root)
        {
            if (root != null)
            {
                return GetLevelOfSubTree(root, -1);
            }
            else
            {
                return -1;
            }
        }

        private static int GetLevelOfSubTree(TreeNode node, int currLevel)
        { 
            if (node == null)
            {
                return 0;
            }

            currLevel++;
            int leftHeight = GetLevelOfSubTree(node.left, currLevel);
            int rightHeight = GetLevelOfSubTree(node.right, currLevel);

            return Math.Max(leftHeight, rightHeight);
        }

        public static TreeNode deserialize(string data)
        {
            var treeData = ConvertStringToIntArray(data);
            Queue<TreeNode> currentQ = new Queue<TreeNode>();
            Queue<TreeNode> parentQ = new Queue<TreeNode>();

            int level = 0;
            double size = Math.Pow(2, level) - 1;
            int index = 1;

            TreeNode dummy = new TreeNode(0);
            TreeNode root = new TreeNode(treeData[0]);
            dummy.left = root;

            parentQ.Enqueue(dummy);
            currentQ.Enqueue(root);

            while (currentQ.Count != 0)
            {
                if (size == 0)
                {
                    level++;
                    size = Math.Pow(2, level);
                    if (level == 1)
                    {
                        var currentNode = currentQ.Dequeue();
                        var parentNode = parentQ.Dequeue();
                        parentNode.left = currentNode;
                        parentQ.Enqueue(currentNode);
                    }
                    else
                    {
                        while (currentQ.Count != 0)
                        {
                            var parentNode = parentQ.Dequeue();
                            if (parentNode.val != Int32.MaxValue)
                            {
                                var leftNode = currentQ.Dequeue();
                                var rightNode = currentQ.Dequeue();
                                if (leftNode.val != Int32.MaxValue)
                                {
                                    parentNode.left = leftNode;
                                }

                                parentQ.Enqueue(leftNode);

                                if (rightNode.val != Int32.MaxValue)
                                {
                                    parentNode.right = rightNode;
                                }

                                parentQ.Enqueue(rightNode);
                            }
                        }
                    }
                }

                if (index < treeData.Length - 1)
                {
                    var leftVal = treeData[index];
                    currentQ.Enqueue(new TreeNode(leftVal));
                    index++;
                    var rightVal = treeData[index];
                    currentQ.Enqueue(new TreeNode(rightVal));
                    index++;
                }
                size -= 2;
            }

            return dummy.left;
        }

        public static TreeNode SortedListToBST(ListNode head)
        {
            if (head == null)
            {
                return null;
            }

            TreeNode root = BuildSubtree(head);
            return root;
        }

        private static TreeNode BuildSubtree(ListNode head)
        {
            ListNode end = head;
            ListNode mid = head;
            ListNode dummy = new ListNode(0);
            dummy.next = head;

            while (end.next != null)
            {
                if (end.next.next != null)
                {
                    end = end.next.next;
                }
                else
                {
                    end = end.next;
                }

                mid = mid.next;
                dummy = dummy.next;
            }

            ListNode rightHead = mid.next;
            TreeNode root = new TreeNode(mid.val);
            dummy.next = null;

            if (head.next == null && head.val != dummy.val)
            {
                return root;
            }
            if (head.val == dummy.val)
            {
                if (root.val == end.val)
                {
                    root.left = new TreeNode(head.val);
                }
                else
                {
                    root.left = new TreeNode(head.val);
                    root.right = new TreeNode(end.val);
                }
            }
            else
            {
                root.left = BuildSubtree(head);
                root.right = BuildSubtree(rightHead);
            }

            return root;
        }

        public static Node ConstructQuadTree(int[][] grid)
        {
            return BuildQuadTree(0, 0, grid.Length - 1, grid.Length - 1, grid);
        }

        private static Node BuildQuadTree(int r1, int r2, int c1, int c2, int[][] grid)
        {
            if (r1 > r2 || c1 > c2)
            {
                return null;
            }

            bool isLeaf = true;
            int val = grid[r1][c1];
            for (int i = r1; i <= r2; i++)
            {
                for (int j = c1; j <= c2; j++)
                {
                    if (grid[i][j] != val)
                    {
                        isLeaf = false;
                        break;
                    }
                }

                if (!isLeaf)
                {
                    break;
                }
            }

            if (isLeaf)
            {
                return new Node(val == 1, isLeaf, null, null, null, null);
            }

            int rowMid = (r1 + r2) / 2;
            int colMid = (c1 + c2) / 2;

            return new Node(val == 1, isLeaf,
                           BuildQuadTree(r1, rowMid, c1, colMid, grid),
                           BuildQuadTree(r1, rowMid, colMid + 1, c2, grid),
                           BuildQuadTree(rowMid + 1, r2, c1, colMid, grid),
                           BuildQuadTree(rowMid + 1, r2, colMid + 1, c2, grid));
        }
    }

    public class TreeNode
    {
        public int val;
        public TreeNode left;
        public TreeNode right;

        public TreeNode(int val)
        {
            this.val = val;
        }
    }

    public class Node
    {
        public bool val;
        public bool isLeaf;
        public Node topLeft;
        public Node topRight;
        public Node bottomLeft;
        public Node bottomRight;

        public Node() { }
        public Node(bool _val, bool _isLeaf, Node _topLeft, Node _topRight, Node _bottomLeft, Node _bottomRight)
        {
            val = _val;
            isLeaf = _isLeaf;
            topLeft = _topLeft;
            topRight = _topRight;
            bottomLeft = _bottomLeft;
            bottomRight = _bottomRight;
        }
    }
}
