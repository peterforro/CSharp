using System.Collections.Generic;

namespace Dojo
{
    public static class IsomorphicStrings
    {
        public static bool AreIsomorphic(string word1, string word2)
        {
            if (word1.Length != word2.Length) return false;
            var chars = new Dictionary<char, char>();
            for(var i = 0; i < word1.Length; ++i)
            {
                if(chars.ContainsKey(word1[i]) && chars[word1[i]] != word2[i])
                {
                    return false;
                }
                else
                {
                    chars[word1[i]] = word2[i];
                }
            }
            return true;
        }
    }
}
