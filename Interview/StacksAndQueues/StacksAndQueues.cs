using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview.StacksAndQueues
{
    public static class StacksAndQueues
    {
        public static string SimplifyPath(string path)
        {
            if (String.IsNullOrEmpty(path))
            {
                return "";
            }

            string[] segments = path.Split('/');

            StringBuilder ret = new StringBuilder();
            Stack<string> st = new Stack<string>();

            foreach (string s in segments)
            {
                if (s == "." || String.IsNullOrEmpty(s))
                {
                    continue;
                }

                if (s == ".." && st.Count > 0)
                {
                    st.Pop();
                    continue;
                }

                st.Push(s);
            }

            while (st.Count != 0)
            {
                ret.Insert(0, "/" + st.Pop());
            }

            return ret.ToString();
        }

        public static int SingleNumber(int[] nums)
        {
            if (nums.Length == 0)
            {
                return 0;
            }

            Array.Sort(nums);
            Stack<int> s = new Stack<int>();
            s.Push(nums[0]);
            for (int i = 1; i < nums.Length - 1; i++)
            {
                var popped = s.Pop();
                if (nums[i] != popped)
                {
                    return popped;
                }

                s.Push(nums[i + 1]);
                i++;
            }

            if (s.Count != 0)
                return s.Pop();
            else
                return 0;
        }
    }
}
