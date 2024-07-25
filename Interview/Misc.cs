using System;
using System.Collections.Generic;
using System.Text;

namespace Interview
{
    public static class Misc
    {
        // Given a regular circular wall clock. Print out the times
        // when the hour hand, minute hand and the second hand
        // overlap (are within 0.5 of a tick of each other). At every
        // second each hand moves discretely and the second hand moves 
        // one tick
        public static void PrintHourMinuteSecondHandOverlap()
        {
            bool isDone = false;

            for (int i = 0; i < 12; i++)
            {
                isDone = false;
                for (int j = 0; j < 60; j++)
                {
                    for (int k = 0; k < 60; k++)
                    {
                        var currSec = k;
                        var currMin = j + (double)k / 60;
                        var currHour = (i * 5) + (double)(j / 60) + (double)(k / 3600);

                        if (Math.Abs(currSec - currMin) <= 0.5 && Math.Abs(currMin - currHour) <= 0.5)
                        {
                            Console.WriteLine(string.Format("{0}:{1}:{2}", i, j, k));
                            Console.WriteLine(string.Format("{0}:{1}:{2}", i + 12, j, k));
                            isDone = true;
                            break;
                        }
                    }
                    if (isDone)
                    {
                        break;
                    }
                }
            }
        }


        // Given an array of integers, find the largest sum such that no two
        // neighbouring nodes are part of the sum. 
        // Input: [10,1,2,4,7,8], Output: 10+2+7

        // Reorder a binary tree such that the entire tree is descending.
        // A binary tree is descending, when all the nodes in the left &
        // right subtree are lesser than the node

        // Given a string, reorganize the letters, so no two adjacent 
        // letters are the same
        // Minesweeper game
        public static int NumDecodings(string s)
        {
            if (String.IsNullOrEmpty(s))
            {
                return 0;
            }

            int decodingsCount = 0;
            GetDecodings(s, 0, new List<int>(), ref decodingsCount);
            return decodingsCount;
        }

        private static void GetDecodings(string s, int start, IList<int> currL, ref int decodingsCount)
        {
            if (start == s.Length)
            {
                decodingsCount++;
                return;
            }

            int currCharIndex = 0;
            if (start < s.Length && Int32.TryParse(s.Substring(start, 1), out currCharIndex))
            {
                currL.Add(currCharIndex);
                GetDecodings(s, start + 1, currL, ref decodingsCount);
                currL.RemoveAt(currL.Count - 1);
            }

            if (start < s.Length - 1 && Int32.TryParse(s.Substring(start, 2), out currCharIndex))
            {
                if (currCharIndex < 26 && currCharIndex > 1)
                {
                    currL.Add(currCharIndex);
                    GetDecodings(s, start + 2, currL, ref decodingsCount);
                    currL.RemoveAt(currL.Count - 1);
                }
            }
        }

        public static IList<string> RestoreIpAddresses(string s)
        {
            IList<string> ret = new List<string>();
            IList<int> ipParts = new List<int>();
            FindSubsetIPs(s, 0, ref ret, ipParts, 0);

            return ret;
        }

        private static void FindSubsetIPs(string s, int i, ref IList<string> ret, IList<int> ipParts, int part)
        {
            if (i >= s.Length)
            {
                return;
            }

            if (part == 3)
            {
                var intString = s.Substring(i, s.Length - i);
                int lastPart = -1;
                if (Int32.TryParse(intString, out lastPart))
                {
                    if (lastPart <= 255)
                    {
                        StringBuilder sb = new StringBuilder();
                        foreach (int finalPart in ipParts)
                        {
                            sb.Append(finalPart);
                            sb.Append('.');
                        }

                        sb.Append(lastPart);
                        string returnValue = sb.ToString();
                        ret.Add(returnValue);
                        return;
                    }
                }
            }

            int current = 0;

            for (int j = i; j < i + 3 && j < s.Length; j++)
            {
                var stringNum = s.Substring(j, 1);
                int num = -1;
                if (Int32.TryParse(stringNum, out num))
                {
                    current = current * 10 + num;
                }
                ipParts.Add(current);

                if (current <= 255 && s.Length - (j + 1) <= (3 - part) * 3)
                {
                    FindSubsetIPs(s, j + 1, ref ret, ipParts, part + 1);
                }
                ipParts.RemoveAt(ipParts.Count - 1);
            }
        }

        // Given a string abc{xy,zdf}gh, output is { abcxygh, abczdfgh }
        public static IList<string> GetExpandedString(string s)
        {
            if (String.IsNullOrEmpty(s))
            {
                return new List<string>();
            }

            IList<string> middleStrings = new List<string>();
            GetExpandedString(s, 0, ref middleStrings);
            return middleStrings;
        }

        private static int GetExpandedString(string s, int i, ref IList<string> expandedStrings)
        {
            IList<string> vals = new List<string>();
            int index = i;
            while (index < s.Length)
            {
                int currI = index;
                while (s[index] != '{' && s[index] != '}' && s[index] != ',')
                {
                    index++;
                }

                if (s[index] == ',' || index == s.Length - 1)
                {
                    vals.Add(s.Substring(currI, index - currI));
                }
                else if (s[index] == '}')
                {
                    string suffix = s.Substring(currI, index - currI);
                    if (vals.Count != 0)
                    {
                        foreach (string val in vals)
                        {
                            expandedStrings.Add(val + suffix);
                        }
                    }
                    else
                    {
                        expandedStrings.Add(suffix);
                    }
                    return index;
                }
                else if (s[index] == '{')
                {
                    string prefix = s.Substring(currI, index - currI);
                    IList<string> middleVals = new List<string>();
                    index = GetExpandedString(s, index + 1, ref middleVals);
                    foreach (string val in middleVals)
                    {
                        vals.Add(prefix + val);
                    }
                }
                index++;
            }

            return index;
        }
    }

    // Given an API Get4Bytes that gets 4 bytes, implement a new API
    // GetNBytes(int n), that uses Get4Bytes() to get n bytes
    public class Get4BytesModule
    {
        private int[] stream;
        private readonly int BYTES_TO_GET = 4;
        private int lastIndex;

        public Get4BytesModule(int[] stream)
        {
            this.stream = stream;
            this.lastIndex = 0;
        }

        public List<int> Get4Bytes()
        {
            List<int> ret = new List<int>();
            int bytesToGet = BYTES_TO_GET;
            for (int i = this.lastIndex; i < this.lastIndex + 4 && i < this.stream.Length; i++)
            {
                ret.Add(stream[i]);
                bytesToGet--;

                if (bytesToGet == 0)
                {
                    break;
                }
            }

            this.lastIndex += BYTES_TO_GET - bytesToGet;
            return ret;
        }
    }

    public class GetNBytesModule
    {
        private Get4BytesModule fbm;
        private List<int> overflow;

        public GetNBytesModule(int[] stream)
        {
            this.fbm = new Get4BytesModule(stream);
            this.overflow = new List<int>();
        }

        public List<int> GetNBytes(int n)
        {
            List<int> ret = new List<int>();
            int index = n;

            while (index > 0)
            {
                while (this.overflow.Count > 0)
                {
                    ret.Add(this.overflow[0]);
                    index--;
                    this.overflow.Remove(this.overflow[0]);

                    if (index == 0)
                    {
                        break;
                    }
                }

                if (index != 0)
                {
                    var fourBytes = this.fbm.Get4Bytes();
                    bool isOverflow = false;

                    foreach (var i in fourBytes)
                    {
                        if (isOverflow)
                        {
                            this.overflow.Add(i);
                        }
                        else
                        {
                            ret.Add(i);
                            index--;

                            if (index == 0)
                            {
                                isOverflow = true;
                            }
                        }
                    }
                }
            }

            return ret;
        }
    }

}
