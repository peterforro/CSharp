using System;
using System.Collections.Generic;

namespace FilePartReaderNUnit.Model
{
    /// <summary>
    /// Provides instance methods to do some analysis on the readed text file
    /// </summary>
    public class FileWordAnalyzer
    {
        private readonly FilePartReader _filePartReader;

        /// <summary>
        /// Gets the individual words from the selected lines (between fromLine and toLine)
        /// </summary>
        /// <returns>string array with the words</returns>
        public string[] GetWords()
        {
            var lines = _filePartReader.ReadLines();
            var words = lines.Replace('\n', ' ').Split(' ');
            return words;
        }

        /// <summary>
        /// Decides whether the word given in the argument, is a palindrome or not.
        /// </summary>
        /// <param name="word">word to examine</param>
        /// <returns>bool value: if the word is palindrome, returns with true</returns>
        public bool IsPalindrome(string word)
        {
            var charArrayOfWord = word.ToCharArray();
            Array.Reverse(charArrayOfWord);
            var reversedVersion = String.Join("", charArrayOfWord);
            if (word.ToLower().Equals(reversedVersion.ToLower()))
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Initializes the instance variable with the FilePartReader object's reference given in the argument.
        /// </summary>
        /// <param name="filePartReader"></param>
        public FileWordAnalyzer(FilePartReader filePartReader)
        {
            _filePartReader = filePartReader;
        }

        /// <summary>
        /// Gets the words from selected lines (between fromLine and toLine) and puts them in alphabetical order.
        /// </summary>
        /// <returns>with an enumerable collection of the ordered words</returns>
        public List<string> WordsByABC()
        {
            var words = GetWords();
            Array.Sort(words);
            var result = new List<string>();
            result.AddRange(words);
            return result;
        }

        /// <summary>
        /// Gets the words from selected lines (between fromLine and toLine) which contain the subString given in the argument
        /// </summary>
        /// <param name="subString">A part of a word that we are looking for in in the words of the text</param>
        /// <returns>with an enumerable collection of the words that contain the subString</returns>
        public List<string> WordsContainingSubString(string subString)
        {
            var words = GetWords();
            var wordsWithSubString = new List<string>();
            foreach (var word in words)
            {
                if (word.Contains(subString))
                {
                    wordsWithSubString.Add(word);
                }
            }

            return wordsWithSubString;
        }

        /// <summary>
        /// Gets the words from selected lines (between fromLine and toLine) which are palindromes
        /// </summary>
        /// <returns>with an enumerable collection of the palindromes</returns>
        public List<string> WordsArePalindrome()
        {
            var words = GetWords();
            var palindromes = new List<string>();
            foreach (var word in words)
            {
                if (IsPalindrome(word))
                {
                    palindromes.Add(word);
                }
            }

            return palindromes;
        }

    }

}
