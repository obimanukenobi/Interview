using System;
using System.Collections.Generic;

namespace Interview
{
    public static class Permutations
    {
        /// <summary>
        /// Given n and k, give the kth permutation of the set of numbers from 
        ///  [1,2,3 ... n]. Eg: n = 3, k = 3
        /// Permutations: [123, 132, 213, 231, 312, 321]. k = 3rd permutation 
        /// = 213
        /// </summary>
        /// <returns>The permutation.</returns>
        /// <param name="n">N.</param>
        /// <param name="k">K.</param>
        public static string GetPermutation(int n, int k)
        {
            int[] nums = new int[n];

            for (int i = 0; i < n; i++)
            {
                nums[i] = i + 1;
            }

            List<int> currL = new List<int>();
            List<int> ret = new List<int>();
            k = GetPerm(nums, 0, ref currL, ref ret, k);
            int retI = 0;
            foreach (int i in ret)
            {
                retI = retI * 10 + i;
            }
            return retI.ToString();
        }

        private static int GetPerm(int[] nums, int start, ref List<int> currL, ref List<int> ret, int k)
        {
            if (currL.Count == nums.Length)
            {
                k--;
                if (k == 0)
                {
                    List<int> temp = new List<int>(currL);
                    ret = temp;
                }
                return k;
            }

            for (int i = start; i < nums.Length && k != 0; i++)
            {
                if (currL.Contains(nums[i]))
                {
                    continue;
                }

                currL.Add(nums[i]);
                k = GetPerm(nums, 0, ref currL, ref ret, k);
                currL.RemoveAt(currL.Count - 1);
            }

            return k;
        }

        public static IList<IList<int>> PermuteUnique(int[] nums)
        {
            IList<IList<int>> ret = new List<IList<int>>();
            IList<int> currL = new List<int>();
            IList<int> indAdded = new List<int>();
            GetPermutations(nums, currL, ref ret, indAdded);
            return ret;
        }

        private static void GetPermutations(int[] nums, IList<int> currL, ref IList<IList<int>> ret, IList<int> indexesAdded)
        {
            if (currL.Count == nums.Length)
            {
                ret.Add(new List<int>(currL));
                return;
            }

            for (int i = 0; i < nums.Length; i++)
            {
                if ((i > 0 && nums[i] == nums[i - 1]) || indexesAdded.Contains(i))
                {
                    continue;
                }

                currL.Add(nums[i]);
                indexesAdded.Add(i);
                GetPermutations(nums, currL, ref ret, indexesAdded);
                currL.RemoveAt(currL.Count - 1);
                indexesAdded.RemoveAt(indexesAdded.Count - 1);
            }
        }

        public static long UniquePaths(int m, int n)
        {
            int x = 0;
            int y = 0;
            long ret = 0;

            CalculatePaths(x, y, m, n, ref ret);

            return ret;
        }

        private static void CalculatePaths(int x, int y, int m, int n, ref long ret)
        {
            if (x == n - 1 && y == m - 1)
            {
                ret++;
                return;
            }

            if (x != n - 1)
            {
                CalculatePaths(x + 1, y, m, n, ref ret);
            }

            if (y != m - 1)
            {
                CalculatePaths(x, y + 1, m, n, ref ret);
            }
        }

        public static int UniquePathsWithObstacles(int[,] obstacleGrid)
        {
            int n = obstacleGrid.GetUpperBound(0);
            int m = obstacleGrid.GetUpperBound(1);

            for (int i = 0; i <= n; i++)
            {
                for (int j = 0; j <= m; j++)
                {
                    if (i == 0 || j == 0)
                    {
                        obstacleGrid[i, j] = obstacleGrid[i, j] == 1 ? 0 : 1;
                    }
                    else
                    {
                        obstacleGrid[i, j] = obstacleGrid[i, j] == 1 ? 0 : obstacleGrid[i, j - 1] + obstacleGrid[i - 1, j];
                    }
                }
            }

            return obstacleGrid[n, m];
        }
    }
}
