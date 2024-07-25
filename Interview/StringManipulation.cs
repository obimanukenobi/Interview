using System;
namespace Interview
{
    public class StringManipulation
    {
        public static double GetShortestDistanceBetweenMidPoints(string document, string word1, string word2)
        {
            string[] words = document.Split(' ');

            double shortest = Int32.MaxValue;
            double word1Loc = -1;
            double word2Loc = -1;
            int index = 0;

            foreach(string word in words)
            {
                if (word.ToLower().Equals(word1.ToLower()))
                {
                    word1Loc = index + (double)(word.Length) / 2;
                }
                else if (word.Equals(word2))
                {
                    word2Loc = index + (double)(word.Length) / 2;
                }

                if (word1Loc >= 0 && word2Loc >= 0)
                {
                    var currD = Math.Abs(word1Loc - word2Loc);
                    if (currD < shortest)
                    {
                        shortest = currD;
                    }
                }

                index += word.Length + 1;
            }

            return shortest;
        }
    }
}
