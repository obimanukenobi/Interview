using System;
using System.Collections.Generic;

namespace Interview
{
    public static class DP
    {
        public static int ClimbStairs(int n)
        {
            if (n == 1)
            {
                return 1;
            }

            if (n == 2)
            {
                return 2;
            }

            int[] dp = new int[n + 1];
            dp[1] = 1;
            dp[2] = 2;
            for (int i = 3; i <= n; i++)
            {
                dp[i] = dp[i - 1] + dp[i - 2];
            }

            return dp[n];
        }

        public enum Result
        {
            NOT_SET,
            TRUE,
            FALSE
        }

        public static bool IsMatch(string s, string p)
        {
            if (String.IsNullOrEmpty(s))
            {
                return String.IsNullOrEmpty(p);
            }

            Result[,] memo = new Result[s.Length + 1, p.Length + 1];

            return CheckIfMatch(0, 0, s, p, ref memo);
        }

        private static bool CheckIfMatch(int i, int j, string s, string p, ref Result[,] memo)
        {
            if (memo[i, j] != Result.NOT_SET)
            {
                return memo[i, j] == Result.TRUE;
            }

            bool ret;
            if (j == p.Length)
            {
                ret = i == s.Length;
            }
            else
            {
                bool firstMatch = (i < s.Length && (p[j] == s[i] || p[j] == '.'));

                if (j + 1 < p.Length && p[j] == '*')
                {
                    ret = CheckIfMatch(i, j + 2, s, p, ref memo) || firstMatch && CheckIfMatch(i + 1, j, s, p, ref memo);
                }
                else
                {
                    ret = firstMatch && CheckIfMatch(i + 1, j + 1, s, p, ref memo);
                }
            }

            memo[i, j] = ret ? Result.TRUE : Result.FALSE;
            return ret;
        }

        // Given a list of menu items and prices for each item, and a 
        // total amount available, find all the different combinations
        // of items you can buy. You have an unlimited suppy of each
        // item. Repeating combinations should be skipped
        private static string[] menu = { "Fruits", "Fries", "Salad", "Wings", "Pizza", "Plate" };
        private static double[] prices = { 2.15, 2.75, 3.35, 3.55, 4.20, 5.80 };
        public static IList<IList<string>> GetOrderItems(double total)
        {
            if (Math.Abs(total) > 0.001)
            {
                return new List<IList<string>>();
            }

            IList<IList<string>> ret = new List<IList<string>>();
            IList<string> currL = new List<string>();
            GetMenuItemCombinations(total, 0.0, 0, currL, ref ret);
            return ret;
        }

        private static void GetMenuItemCombinations(double total, double currentSum, int start, IList<string> currentList, ref IList<IList<string>> ret)
        {
            if (Math.Abs(total - currentSum) < 0.001)
            {
                List<String> temp = new List<String>(currentList);
                ret.Add(temp);
                return;
            }

            if (total < currentSum)
            {
                return;
            }

            if (start == menu.Length)
            {
                return;
            }

            currentList.Add(menu[start]);
            currentSum += prices[start];
            GetMenuItemCombinations(total, currentSum, start, currentList, ref ret);
            currentSum -= prices[start];
            currentList.RemoveAt(currentList.Count - 1);
            GetMenuItemCombinations(total, currentSum, start + 1, currentList, ref ret);
        }

        public static int ZeroOneKnapsack(int[] W, int[] V, int totalWeight)
        {
            var s = DateTime.Now;
            var ret = GetSubMaxValues(W, V, 0, totalWeight, 0, 0);
            var e = DateTime.Now;
            var timeTaken1 = e - s;
            s = DateTime.Now;
            ret = GetZeroOneKnapsack(W, V, totalWeight);
            e = DateTime.Now;
            var timeTaken2 = e - s;
            return ret;
        }

        // Runtime: O(2^n)
        // Space Complexity: O(1)
        private static int GetSubMaxValues(int[] W, int[] V, int s, int tw, int cw, int cv)
        {
            if (s == W.Length || cw + W[s] > tw)
            {
                return 0;
            }

            int mv = 0;

            for (int i = s; i < W.Length; i++)
            {
                int nw = cw + W[i];
                if (nw <= tw)
                {
                    int nv = cv + V[i];
                    int sv = GetSubMaxValues(W, V, i + 1, tw, nw, nv);
                    mv = Math.Max(mv, Math.Max(nv, sv));
                }
                else
                {
                    break;
                }
            }

            return mv;
        }

        // Runtime: O(n*totalWeight)
        // Space Complexity: O(n * totalWeight);
        private static int GetZeroOneKnapsack(int[] W, int[] V, int totalWeight)
        {
            int[,] K = new int[W.Length + 1, totalWeight + 1];

            for (int i = 1; i <= W.Length; i++)
            {
                for (int j = 0; j <= totalWeight; j++)
                {
                    if (W[i - 1] > j)
                    {
                        K[i, j] = K[i-1, j];
                    }
                    else 
                    {
                        K[i, j] = Math.Max(V[i - 1], V[i - 1] + K[i - 1, j - W[i - 1]]);
                    }
                }
            }

            return K[W.Length, totalWeight];
        }

        public static int NKnapSack(int[] W, int[] V, int totalWeight)
        {
            int[] mem = new int[totalWeight + 1];

            for (int i = 1; i <= totalWeight; i++)
            {
                for (int j = 0; j < W.Length; j++)
                {
                    if (i >= W[j])
                    {
                        mem[i] = Math.Max(mem[i], mem[i - W[j]] + V[j]);
                    }
                }
            }

            return mem[totalWeight];
        }

        public static int MinimumTotal(IList<IList<int>> triangle)
        {
            int n = triangle.Count;
            int[,] mem = new int[n, n];

            for (int i = n - 1; i >= 0; i--)
            {
                for (int j = 0; j < triangle[i].Count; j++)
                {
                    if (i == n - 1)
                    {
                        mem[i, j] = triangle[i][j];
                        continue;
                    }

                    mem[i, j] = Math.Min((mem[i + 1, j] + triangle[i][j]), (mem[i + 1, j + 1] + triangle[i][j]));
                }
            }

            return mem[0,0];
        }
    }
}
