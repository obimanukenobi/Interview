using System;
using System.Collections.Generic;

namespace Interview
{
    public static class Matrix
    {
        public static void SetZeroes(int[,] matrix)
        {
            int n = matrix.GetUpperBound(0);
            int m = matrix.GetUpperBound(1);

            for (int i = 0; i <= n; i++)
            {
                for (int j = 0; j <= m; j++)
                {
                    if (matrix[i, j] == 0)
                    {
                        matrix[i, 0] = 0;
                        matrix[0, j] = 0;
                    }
                }
            }

            for (int i = 1; i <= n; i++)
            {
                for (int j = 1; j <= m; j++)
                {
                    if (matrix[i, 0] == 0 || matrix[0, j] == 0)
                    {
                        matrix[i, j] = 0;
                    }
                }
            }

            if (matrix[0, 0] == 0)
            {
                for (int i = 0; i <= n; i++)
                {
                    matrix[i, 0] = 0;
                }

                for (int j = 0; j <= m; j++)
                {
                    matrix[0, j] = 0;
                }
            }
        }

        public static bool SearchMatrix(int[,] matrix, int target)
        {
            int n = matrix.GetUpperBound(0);
            int m = matrix.GetUpperBound(1);

            if (n == -1 || m == -1)
            {
                // Empty array
                return false;
            }

            for (int i = 0; i <= n; i++)
            {
                if (i == 0 && matrix[i, 0] > target)
                {
                    return false;
                }

                if (target > matrix[i, m])
                {
                    continue;
                }

                int s = 0;
                int e = m;

                if (s == e)
                {
                    if (target == matrix[s, e])
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }

                while (s < e)
                {
                    int mid = s + (e - s) / 2;

                    if (target == matrix[i, mid])
                    {
                        return true;
                    }

                    if (target > matrix[i, mid])
                    {
                        s = mid + 1;
                    }
                    else
                    {
                        e = mid;
                    }
                }

                return false;
            }

            return false;
        }
    }

    public class CherryPickupProblem
    {
        public int CherryPickup(int[][] grid)
        {
            int n = grid.Length;
            int m = grid[0].Length;
            int cherriesPicked = grid[0][0] == -1 ? 0 : grid[0][0];
            MaxCherriesPickedUpWithVisitedCells cherriesPickedGoingDownRight = GetMaxCherriesGoingRightDown(grid, n, m, 0, 0, new List<VisitedCell>(), cherriesPicked);

            int currentMax = cherriesPickedGoingDownRight.cherriesPickedUp;
            if (cherriesPickedGoingDownRight.visitedCells.Count == 0)
            {
                // Couldn't reach N,N cell
                return 0;
            }
            foreach (VisitedCell visitedCell in cherriesPickedGoingDownRight.visitedCells)
            {
                grid[visitedCell.i][visitedCell.j] = 0;
            }

            var cherriesPickedGoingUpLeft = GetMaxCherriesGoingUpLeft(grid, n, m, n - 1, m - 1, new List<VisitedCell>(), 0);
            return currentMax + cherriesPickedGoingUpLeft.cherriesPickedUp;
        }

        private MaxCherriesPickedUpWithVisitedCells GetMaxCherriesGoingUpLeft(int[][] grid, int n, int m, int i, int j, List<VisitedCell> visitedCells, int cherriesPicked)
        {
            List<VisitedCell> currVisitedCells = new List<VisitedCell>(visitedCells);
            currVisitedCells.Add(new VisitedCell(i, j));
            // if (i == 0 && j == 0)
            // {
            //     int finalCherriesPicked = grid[i][j] == -1 ? cherriesPicked : cherriesPicked + grid[i][j];
            //     return new MaxCherriesPickedUpWithVisitedCells(finalCherriesPicked, currVisitedCells);
            // }

            MaxCherriesPickedUpWithVisitedCells cherriesPickedUp = null;
            MaxCherriesPickedUpWithVisitedCells cherriesPickedLeft = null;
            if (i - 1 >= 0 && grid[i - 1][j] != -1)
            {
                // Going up
                cherriesPickedUp = GetMaxCherriesGoingUpLeft(grid, n, m, i - 1, j, currVisitedCells, cherriesPicked + grid[i - 1][j]);
            }

            if (j - 1 >= 0 && grid[i][j - 1] != -1)
            {
                // Going right
                cherriesPickedLeft = GetMaxCherriesGoingUpLeft(grid, n, m, i, j - 1, currVisitedCells, cherriesPicked + grid[i][j - 1]);
            }

            if (cherriesPickedUp == null && cherriesPickedLeft != null)
            {
                return cherriesPickedLeft;
            }
            else if (cherriesPickedUp != null && cherriesPickedLeft == null)
            {
                return cherriesPickedUp;
            }
            else if (cherriesPickedUp == null && cherriesPickedLeft == null)
            {
                if (i != 0 && j != 0)
                {
                    return new MaxCherriesPickedUpWithVisitedCells(0, new List<VisitedCell>());
                }
                return new MaxCherriesPickedUpWithVisitedCells(cherriesPicked, currVisitedCells);
            }
            else if (cherriesPickedUp.cherriesPickedUp > cherriesPickedLeft.cherriesPickedUp)
            {
                return cherriesPickedUp;
            }
            else
            {
                return cherriesPickedLeft;
            }
        }

        private MaxCherriesPickedUpWithVisitedCells GetMaxCherriesGoingRightDown(int[][] grid, int n, int m, int i, int j, List<VisitedCell> visitedCells, int cherriesPicked)
        {
            List<VisitedCell> currVisitedCells = new List<VisitedCell>(visitedCells);
            currVisitedCells.Add(new VisitedCell(i, j));
            // if (i == n && j == m)
            // {
            //     int finalCherriesPicked = grid[i][j] == -1 ? cherriesPicked : cherriesPicked + grid[i][j];
            //     return new MaxCherriesPickedUpWithVisitedCells(finalCherriesPicked, currVisitedCells);
            // }

            MaxCherriesPickedUpWithVisitedCells cherriesPickedDown = null;
            MaxCherriesPickedUpWithVisitedCells cherriesPickedRight = null;
            if (i + 1 < n && grid[i + 1][j] != -1)
            {
                // Going down
                cherriesPickedDown = GetMaxCherriesGoingRightDown(grid, n, m, i + 1, j, currVisitedCells, cherriesPicked + grid[i + 1][j]);
            }

            if (j + 1 < m && grid[i][j + 1] != -1)
            {
                // Going right
                cherriesPickedRight = GetMaxCherriesGoingRightDown(grid, n, m, i, j + 1, currVisitedCells, cherriesPicked + grid[i][j + 1]);
            }

            if (cherriesPickedDown == null && cherriesPickedRight != null)
            {
                return cherriesPickedRight;
            }
            else if (cherriesPickedDown != null && cherriesPickedRight == null)
            {
                return cherriesPickedDown;
            }
            else if (cherriesPickedDown == null && cherriesPickedRight == null)
            {
                if (i != n - 1 && j != m - 1)
                {
                    return new MaxCherriesPickedUpWithVisitedCells(0, new List<VisitedCell>());
                }
                return new MaxCherriesPickedUpWithVisitedCells(cherriesPicked, currVisitedCells);
            }
            else if (cherriesPickedDown.cherriesPickedUp > cherriesPickedRight.cherriesPickedUp)
            {
                return cherriesPickedDown;
            }
            else
            {
                return cherriesPickedRight;
            }
        }
    }

    public class VisitedCell
    {
        public int i;
        public int j;

        public VisitedCell(int i, int j)
        {
            this.i = i;
            this.j = j;
        }
    }

    public class MaxCherriesPickedUpWithVisitedCells
    {
        public List<VisitedCell> visitedCells;
        public int cherriesPickedUp;

        public MaxCherriesPickedUpWithVisitedCells(int max, List<VisitedCell> currVisitedCells)
        {
            this.visitedCells = currVisitedCells;
            this.cherriesPickedUp = max;
        }
    }
}
