using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview
{
    class Program
    {
        static void Main(string[] args)
        {
            //var s = Permutations.GetPermutation(9, 161191);
            //var ret = Permutations.PermuteUnique(new int[] { 1, 1, 2 });
            //var ret = Permutations.UniquePaths(23, 12);

            //int[,] obstacleGrid = new int[3, 4];
            //for (int i = 0; i < 3; i++)
            //{
            //    for (int j = 0; j < 4; j++)
            //    {
            //        if ((i == 0 && j == 0) || (i == 0 && j == 3))
            //        {
            //            obstacleGrid[i, j] = 0;
            //        }
            //        else
            //        {
            //            obstacleGrid[i, j] = 1;
            //        }
            //    }
            //}

            //var ret = Permutations.UniquePathsWithObstacles(obstacleGrid);
            //var ret = DP.ClimbStairs(44);
            //var ret = StacksAndQueues.StacksAndQueues.SimplifyPath("/../");
            //Matrix.SetZeroes(obstacleGrid);

            //int[,] matrix = { { 1, 3 } };
            //var ret = Matrix.SearchMatrix(matrix, 3);
            //var ret = StringManipulation.GetShortestDistanceBetweenMidPoints(
            //"This the ant ate an test test ate the", "ate", "test");

            //var ret = DP.IsMatch("aa", "a*");
            //Misc.PrintHourMinuteSecondHandOverlap();
            //int[] A = { 0, 1, 1, 2, 3 };
            //var ret = APaper.CanBuild(A);
            //var ret = Misc.NumDecodings("226");
            //Tree.TreeDriver();
            //Misc.RestoreIpAddresses("255255");
            //ListNode l1 = ListNode.GenerateLinkedList(1, 9, true, 4);
            //ListNode l2 = ListNode.GenerateLinkedList(1, 9, true, 5);
            //ListNode l3 = ListNode.GenerateLinkedList(1, 9, true, 3);
            //ListNode l4 = ListNode.GenerateLinkedList(1, 9, true, 6);

            //ListNode[] lists = new ListNode[] { l1, l2, l3, l4 };
            //Heap.MergeKSortedList(lists);
            //int[,] maze = new int[4, 4]
            //{
            //    {-1, 0, 0, 0},
            //    {0, 0, Int32.MinValue, 0},
            //    {Int32.MinValue, 0, 0, Int32.MinValue},
            //    {0, 0, -1, 0},
            //};

            //DateTime now = DateTime.Now;
            //Graph.PopulateMinDistanceFromGates(ref maze);
            //DateTime end = DateTime.Now;

            //var timeTaken1  = end - now;
            //now = DateTime.Now;
            //Graph.PopulateMinDistanceFromGatesStack(ref maze);
            //end = DateTime.Now;
            //var timeTaken2 = end - now;
            //int[] nums = { 17, 12, 5, -6, 12, 4, 17, -5, 2, -3, 2, 4, 5, 16, -3, -4, 15, 15, -4, -5, -6 };
            //var ret = StacksAndQueues.StacksAndQueues.SingleNumber(nums);
            //var ret = DP.GetOrderItems(15.05);
            //ListNode head = new ListNode(-1);
            //ListNode temp = head;
            //temp.next = new ListNode(0);
            //temp = temp.next;
            //temp.next = new ListNode(1);
            //temp = temp.next;
            //temp.next = new ListNode(2);

            //var ret = Tree.SortedListToBST(head);
            //int[] W = { 10, 20, 30 };
            //int[] V = { 100, 120, 160 };
            //var ret = DP.ZeroOneKnapsack(W, V, 50);
            //var ret = DP.NKnapSack(W, V, 50);

            //string[] words = { "baa", "abcd", "abca", "cab", "cad" };
            //var ret = Graph<char>.GetAlienDictionaryOrder(words);
            //string s = "abs{xy, zd}klm";
            //var ret = Misc.GetExpandedString(s);

            //int[][] grid = new int[][]
            //{
            //    new int[] {
            //        1,1,1,1,0,0,0
            //    },
            //    new int[] {
            //        0,0,0,1,0,0,0
            //    },
            //    new int[] {
            //        0,0,0,1,0,0,1
            //    },
            //    new int[] {
            //        1,0,0,1,0,0,0
            //    },
            //    new int[] {
            //        0,0,0,1,0,0,0
            //    },
            //    new int[] {
            //        0,0,0,1,0,0,0
            //    },
            //    new int[] {
            //        0,0,0,1,1,1,1
            //    },
            //};

            //CherryPickupProblem cpp = new CherryPickupProblem();
            //var ret = cpp.CherryPickup(grid);

            //int[][] grid = new int[][]
            //{
            //    new int[] { 1,1,1,1,0,0,0,0 },
            //    new int[] { 1, 1, 1, 1, 0, 0, 0, 0 },
            //    new int[] { 1, 1, 1, 1, 1, 1, 1, 1 },
            //    new int[] { 1, 1, 1, 1, 1, 1, 1, 1 },
            //    new int[] { 1, 1, 1, 1, 0, 0, 0, 0 },
            //    new int[] { 1, 1, 1, 1, 0, 0, 0, 0 },
            //    new int[] { 1, 1, 1, 1, 0, 0, 0, 0 },
            //    new int[] { 1, 1, 1, 1, 0, 0, 0, 0 }
            //};
            //Tree.ConstructQuadTree(grid);

            //string[][] itin = new string[][]
            //{
            //    new string[] { "EZE", "AXA" },
            //    new string[] { "TIA", "ANU" },
            //    new string[] { "ANU", "JFK" },
            //    new string[] { "JFK", "ANU" },
            //    new string[] { "ANU", "EZE" },
            //    new string[] { "TIA", "ANU" },
            //    new string[] { "AXA", "TIA" },
            //    new string[] { "TIA", "JFK" },
            //    new string[] { "ANU", "TIA" },
            //    new string[] { "JFK", "TIA" },
            //};
            //var ret = Graph<string>.FindItinerary(itin);

            int[] stream = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 };
            //Get4BytesModule fourBytesMod = new Get4BytesModule(stream);
            //var ret = fourBytesMod.Get4Bytes();
            //ret = fourBytesMod.Get4Bytes();
            //GetNBytesModule nBytesModule = new GetNBytesModule(stream);
            //var ret = nBytesModule.GetNBytes(4);
            //var ret1 = nBytesModule.GetNBytes(2);
            //var ret2 = nBytesModule.GetNBytes(3);
            //var ret3 = nBytesModule.GetNBytes(3);

            //IList<IList<int>> t = new List<IList<int>>()
            //{
            //    new List<int> {2},
            //    new List<int> {3,4},
            //    new List<int> {6,5,7},
            //    new List<int> {4,1,8,3},
            //};
            //var ret = DP.MinimumTotal(t);

            int numCourses = 7;
            int[][] p = new int[][]
            {
                new int[] { 3,1 },
                new int[] { 4,2 },
                new int[] { 5,3 },
                new int[] { 5,4 },
                new int[] { 6,5 },

            };

            Graph<int> g = new Graph<int>();
            var ret = g.CanFinish(numCourses, p);
        }
    }
}
