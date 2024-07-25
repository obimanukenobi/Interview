using System;
using System.Collections;
using System.Collections.Generic;

namespace Interview
{
    public class Graph<T>
    {
        private int countOfVertices;
        public IDictionary<T, IList<T>> e;
        public Graph()
        {
            e = new Dictionary<T, IList<T>>();
        }

        public Graph(T[] vertices)
        {
            countOfVertices = vertices.Length;
            e = new Dictionary<T, IList<T>>();
            foreach (T vertex in vertices)
            {
                IList<T> l = new List<T>();
                e.Add(vertex, l);
            }
        }

        public void AddEdge(T vertex, T sink)
        {
            if (e.ContainsKey(vertex))
            {
                var l = e[vertex];
                l.Add(sink);
            }
            else
            {
                var l = new List<T>();
                l.Add(sink);
                e.Add(vertex, l);
                countOfVertices++;
            }
        }

        public T[] PrintTopologicalSort()
        {
            T[] ret = new T[countOfVertices];
            int index = 0;
            foreach(T key in e.Keys)
            {
                ret[index] = key;
                index++;
            }

            return ret;
        }

        public static char[] GetAlienDictionaryOrder(string[] words)
        {
            if (words.Length == 0)
            {
                return new char[0];
            }

            List<char> letter = new List<char>();
            foreach(string word in words)
            {
                foreach (char c in word)
                {
                    if (!letter.Contains(c))
                    {
                        letter.Add(c);
                    }
                }
            }

            Graph<char> g = new Graph<char>(letter.ToArray());
            for (int i = 0; i < words.Length - 1; i++)
            {
                string word1 = words[i];
                string word2 = words[i + 1];

                for (int j = 0; j < Math.Min(word1.Length, word2.Length); j++)
                {
                    if (word1[j] != word2[j])
                    {
                        g.AddEdge(word1[j], word2[j]);
                        break;
                    }
                }
            }

            return g.PrintTopologicalSort();
        }

        public enum Direction
        {
            Up,
            Down,
            Left,
            Right
        }
        
        // Gate = -1
        // Wall = Int32.MinValue
        public static void PopulateMinDistanceFromGates(ref int[,] maze)
        {
            int n = maze.GetUpperBound(0);
            int m = maze.GetUpperBound(1);

            for (int i = 0; i <= n; i++)
            {
                for (int j = 0; j <= m; j++)
                {
                    if (maze[i, j] == Int32.MinValue || maze[i, j] == 0)
                    {
                        continue;
                    }

                    if (maze[i, j] == -1)
                    {
                        PopulateCells(ref maze, i + 1, j, 1, n, m, Direction.Down);
                        PopulateCells(ref maze, i - 1, j, 1, n, m, Direction.Up);
                        PopulateCells(ref maze, i, j + 1, 1, n, m, Direction.Right);
                        PopulateCells(ref maze, i, j - 1, 1, n, m, Direction.Left);
                    }
                }
            }
        }

        private static void PopulateCells(ref int[,] maze, int i, int j, int value, int n, int m, Direction dir)
        {
            if (i < 0 || i > n || j < 0 || j > m || maze[i,j] == Int32.MinValue || maze[i, j] == -1)
            {
                return;
            }

            maze[i, j] = maze[i, j] == 0 ? value : Math.Min(maze[i, j], value);
            if (dir != Direction.Up)
            {
                PopulateCells(ref maze, i + 1, j, value + 1, n, m, Direction.Down);
            }

            if (dir != Direction.Down)
            {
                PopulateCells(ref maze, i - 1, j, value + 1, n, m, Direction.Up);
            }

            if (dir != Direction.Left)
            {
                PopulateCells(ref maze, i, j + 1, value + 1, n, m, Direction.Right);
            }

            if (dir != Direction.Right)
            {
                PopulateCells(ref maze, i, j - 1, value + 1, n, m, Direction.Left);
            }
        }

        public static void PopulateMinDistanceFromGatesStack(ref int[,] maze)
        {
            int n = maze.GetUpperBound(0);
            int m = maze.GetUpperBound(1);
            Queue<int[]> q = new Queue<int[]>();

            for (int i = 0; i <= n; i++)
            {
                for (int j = 0; j <= m; j++)
                {
                    if (maze[i, j] == -1)
                    {
                        q.Enqueue(new int[] { i, j });
                    }
                }
            }

            while(q.Count != 0)
            {
                int[] rowCols = q.Dequeue();
                int i = rowCols[0];
                int j = rowCols[1];

                if (i + 1 < 0 || i + 1 > n || j < 0 || j > m || maze [i + 1, j] != 0)
                {
                    continue;
                }
                else
                {
                    maze[i + 1, j] = maze[i, j] + 1;
                    q.Enqueue(new int[] { i + 1, j });
                }

                if (i - 1 < 0 || i - 1 > n || j < 0 || j > m || maze[i - 1, j] != 0)
                {
                    continue;
                }
                else
                {
                    maze[i - 1, j] = maze[i, j] + 1;
                    q.Enqueue(new int[] { i - 1, j });
                }

                if (i < 0 || i > n || j + 1 < 0 || j + 1 > m || maze[i, j + 1] != 0)
                {
                    continue;
                }
                else
                {
                    maze[i, j + 1] = maze[i, j] + 1;
                    q.Enqueue(new int[] { i, j + 1 });
                }

                if (i < 0 || i > n || j - 1 < 0 || j - 1 > m || maze[i, j - 1] != 0)
                {
                    continue;
                }
                else
                {
                    maze[i, j - 1] = maze[i, j] + 1;
                    q.Enqueue(new int[] { i, j - 1 });
                }

            }
        }

        public static IList<string> FindItinerary(string[][] tickets)
        {
            IDictionary<string, SortedSet<string>> itineraryGraph = new Dictionary<string, SortedSet<string>>();

            foreach (string[] ticket in tickets)
            {
                SortedSet<string> arrivalVals;
                if (itineraryGraph.TryGetValue(ticket[0], out arrivalVals))
                {
                    arrivalVals.Add(ticket[1]);
                }
                else
                {
                    arrivalVals = new SortedSet<string>();
                    arrivalVals.Add(ticket[1]);
                    itineraryGraph.Add(ticket[0], arrivalVals);
                }
            }
            IList<string> ret = new List<string>();
            GraphTraversal(itineraryGraph, "JFK", ref ret);
            return ret;
        }

        private static void GraphTraversal(IDictionary<string, SortedSet<string>> graph, string startDeparture, ref IList<string> ret)
        {
            SortedSet<string> arrivals;

            if (graph.TryGetValue(startDeparture, out arrivals))
            {
                while(arrivals.Count != 0)
                {
                    string tempCity = arrivals.Min;
                    arrivals.Remove(arrivals.Min);
                    GraphTraversal(graph, tempCity, ref ret);
                }
            }

            ret.Insert(0, startDeparture);
        }

        public bool CanFinish(int numCourses, int[][] prerequisites)
        {
            if (numCourses == 0)
            {
                return true;
            }

            IDictionary<int, List<int>> courseMap = new Dictionary<int, List<int>>();
            int[] isPrereqOfCount = new int[numCourses];
            List<int> notDoneCourses = new List<int>();

            for (int i = 0; i < numCourses; i++)
            {
                notDoneCourses.Add(i);
            }

            for (int i = 0; i < prerequisites.Length; i++)
            {
                List<int> prereqs = null;
                var gotPreReqs = courseMap.TryGetValue(prerequisites[i][0], out prereqs);
                if (gotPreReqs)
                {
                    prereqs.Add(prerequisites[i][1]);
                    isPrereqOfCount[prerequisites[i][1]]++;
                }
                else
                {
                    prereqs = new List<int>();
                    prereqs.Add(prerequisites[i][1]);
                    courseMap.Add(prerequisites[i][0], prereqs);
                    isPrereqOfCount[prerequisites[i][1]]++;
                }
            }

            List<int> doneCourses = new List<int>();
            List<int> courseToTraverse = new List<int>();
            for (int i = 0; i < numCourses; i++)
            {
                if (isPrereqOfCount[i] == 0)
                {
                    courseToTraverse.Add(i);
                }
            }

            foreach (int currentCourse in courseToTraverse)
            {
                bool canCompleteNextCourses = CanCompleteNextCourses(currentCourse, ref courseMap, ref notDoneCourses, ref doneCourses);
                if (!canCompleteNextCourses)
                {
                    return false;
                }
            }

            return true;
        }

        private bool CanCompleteNextCourses(int currentCourse, ref IDictionary<int, List<int>> courseMap, ref List<int> notDoneCourses, ref List<int> doneCourses)
        {
            if (doneCourses.Contains(currentCourse))
            {
                return false;
            }

            List<int> nextCourses = new List<int>();
            var gotNextCourses = courseMap.TryGetValue(currentCourse, out nextCourses);
            notDoneCourses.Remove(currentCourse);
            doneCourses.Add(currentCourse);

            foreach (int nextCourse in nextCourses)
            {
                var completedNextCourses = CanCompleteNextCourses(nextCourse, ref courseMap, ref notDoneCourses, ref doneCourses);
                if (!completedNextCourses)
                {
                    return false;
                }
            }

            return true;
        }

    }

}
