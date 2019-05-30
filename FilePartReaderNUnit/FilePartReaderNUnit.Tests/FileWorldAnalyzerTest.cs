using NUnit.Framework;
using FilePartReaderNUnit.Model;
using System;

namespace FilePartReaderNUnit.Tests
{
    [TestFixture]
    public class FileWorldAnalyzerTest
    {
        [Test]
        public void GetWords_FromLineIs1AndToLineIs2_ShouldGetIndividualWordsFromSpecifiedLines()
        {
            var filePartReader = new FilePartReader();
            filePartReader.Setup(@"D:\code\C#\FilePartReaderNUnit\TestData\test01.txt", 1, 2);
            var fileWorldAnalyzer = new FileWordAnalyzer(filePartReader);
            var expected = "Latjatok feleim Szumthukkel";

            var result = fileWorldAnalyzer.GetWords();

            Assert.AreEqual(expected, String.Join(" ", result));
        }

        [Test]
        public void GetWords_ToLineIsMoreThanTheMaxLineNumber_ShouldGetEveryWords()
        {
            var filePartReader = new FilePartReader();
            filePartReader.Setup(@"D:\code\C#\FilePartReaderNUnit\TestData\test02.txt", 1, 1000);
            var fileWorldAnalyzer = new FileWordAnalyzer(filePartReader);
            var expected = "apacuka fundaluka fundakave kamanduka";

            var result = fileWorldAnalyzer.GetWords();

            Assert.AreEqual(expected, String.Join(" ", result));
        }

        [Test]
        public void WordsByABC_FromAllLines_GetTheWordInAlphabeticalOrder()
        {
            var filePartReader = new FilePartReader();
            filePartReader.Setup(@"D:\code\C#\FilePartReaderNUnit\TestData\test03.txt", 1, 5);
            var fileWorldAnalyzer = new FileWordAnalyzer(filePartReader);
            var expected = "Albert Bela Cicero Dezso Elemer Xaver";

            var result = fileWorldAnalyzer.WordsByABC();

            Assert.AreEqual(expected, String.Join(" ", result.ToArray()));
        }

       [Test]
       public void WordsContainingSubstring_GivenSubString_uka_GetMatchedWords()
        {
            var filePartReader = new FilePartReader();
            filePartReader.Setup(@"D:\code\C#\FilePartReaderNUnit\TestData\test02.txt", 1, 5);
            var fileWorldAnalyzer = new FileWordAnalyzer(filePartReader);
            var expected = "apacuka fundaluka kamanduka";

            var result = fileWorldAnalyzer.WordsContainingSubString("uka");

            Assert.AreEqual(expected, String.Join(" ", result.ToArray()));
        }

        [Test]
        public void IsPalindrome_GivenWord_Hannah_ShouldReturnTrue()
        {
            var filePartReader = new FilePartReader();
            var fileWordAnalyzer = new FileWordAnalyzer(filePartReader);

            var result = fileWordAnalyzer.IsPalindrome("Hannah");

            Assert.AreEqual(result, true);
        }

        [Test]
        public void IsPalindrome_GivenWord_abcd_ShouldReturnFalse()
        {
            var filePartReader = new FilePartReader();
            var fileWordAnalyzer = new FileWordAnalyzer(filePartReader);

            var result = fileWordAnalyzer.IsPalindrome("abcd");

            Assert.AreEqual(result, false);
        }

        [Test]
        public void WordsArePalindrome_FromAllLines_ShouldGetAllPalindromes()
        {
            var filePartReader = new FilePartReader();
            filePartReader.Setup(@"D:\code\C#\FilePartReaderNUnit\TestData\test04.txt", 1, 6);
            var fileWordAnalyzer = new FileWordAnalyzer(filePartReader);
            var expected = "Hannah apa qweewq";

            var result = fileWordAnalyzer.WordsArePalindrome();

            Assert.AreEqual(expected, String.Join(" ", result.ToArray()));
        }
    }
}
