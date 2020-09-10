using System;
using System.Collections.Generic;

namespace FindAndReplacePattern
{
    class Program
    {
        static void Main(string[] args)
        {
            IList<string> results = FindAndReplacePattern(new string[] { "abc", "deq", "mee", "aqq", "dkd", "ccc" }, "abb");
            foreach (string res in results)
                Console.WriteLine(res);
        }

        public static IList<string> FindAndReplacePattern(string[] words, string pattern)
        {
            List<string> results = new List<string>();

            foreach(string word in words)
            {
                Dictionary<char, char> map = new Dictionary<char, char>();
                HashSet<char> used = new HashSet<char>();
                int i;
                for (i = 0; i < word.Length; i++)
                {
                    if (!map.ContainsKey(word[i]))
                    {
                        if (used.Contains(pattern[i]))
                            break;//Letter was already used 
                        map.Add(word[i], pattern[i]);
                        used.Add(pattern[i]);
                    }
                    else if (map[word[i]] != pattern[i])
                        break; //Pattern mismatch
                }
                if(i == word.Length)
                    results.Add(word);
            }
            return results; 
        }
    }
}
