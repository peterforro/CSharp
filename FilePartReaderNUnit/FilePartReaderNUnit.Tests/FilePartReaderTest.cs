using NUnit.Framework;
using FilePartReaderNUnit.Model;
using System;
using System.IO;

namespace FilePartReaderNUnit.Tests
{

    [TestFixture]
    public class FilePartReaderTest
    {
        [Test]
        public void Setup_ToLineIsLessThenFromLine_ShouldRaiseArgumentException()
        {
            string filePath = @"dummy.txt";
            int fromLine = 2;
            int toLine = 1;
            var filePartReader = new FilePartReader();

            Assert.Throws<ArgumentException>(() => filePartReader.Setup(filePath, fromLine, toLine));
        }

        [Test]
        public void Setup_FromLineIsLessThan1_ShouldRaiseArgumentException()
        {
            string filePath = @"dummy.txt";
            int fromLine = 0;
            int toLine = 2;
            var filePartReader = new FilePartReader();

            Assert.Throws<ArgumentException>(() => filePartReader.Setup(filePath, fromLine, toLine));
        }

        [Test]
        public void Read_ReadEmptyFile_ShouldGetEmptyString()
        {
            var filePartReader = new FilePartReader();
            filePartReader.Setup(@"D:\code\C#\FilePartReaderNUnit\TestData\empty.txt", 1, 100);

            var result = filePartReader.Read();

            Assert.AreEqual(String.Empty, result);
        }

        [Test]
        public void Read_IfFilePathIsInvalid_ShouldRaiseFileNotFoundException()
        {
            var filePartReader = new FilePartReader();
            filePartReader.Setup(filePath: @"dummy.txt");

            Assert.Throws<FileNotFoundException>(() => filePartReader.Read());
        }

        [Test]
        public void Read_CheckingIfTheMethodReadsFileProperly_ShouldGetEveryLines()
        {
            var filePartReader = new FilePartReader();
            filePartReader.Setup(filePath: @"D:\code\C#\FilePartReaderNUnit\TestData\test02.txt");
            var expected = "apacuka\nfundaluka fundakave\nkamanduka";

            var content = filePartReader.Read();

            Assert.AreEqual(expected, content);
        }

        [Test]
        public void ReadLines_CheckingIfTheMethodReadsFileProperly_ShouldGetSpecifiedRows()
        {
            var filePartReader = new FilePartReader();
            filePartReader.Setup(@"D:\code\C#\FilePartReaderNUnit\TestData\test01.txt", 2, 3);
            var expected = "Szumthukkel\nmik vogymuk?";

            var content = filePartReader.ReadLines();

            Assert.AreEqual(expected, content);
        }

        [Test]
        public void ReadLines_ReadingEmptyFiles_ShouldGetEmptyString()
        {
            var filePartReader = new FilePartReader();
            filePartReader.Setup(@"D:\code\C#\FilePartReaderNUnit\TestData\empty.txt", 1, 3);

            var result = filePartReader.ReadLines();

            Assert.AreEqual(String.Empty, result);
        }

        [Test]
        public void ReadLines_FromLineAndToLineIs1_ShouldGetTheFirstLine()
        {
            var filePartReader = new FilePartReader();
            filePartReader.Setup(@"D:\code\C#\FilePartReaderNUnit\TestData\test01.txt", 1, 1);
            var expected = "Latjatok feleim";

            var content = filePartReader.ReadLines();

            Assert.AreEqual(expected, content);
        }
    }

}
