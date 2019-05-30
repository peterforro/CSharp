using System;
using System.Linq;
using System.IO;
using System.Collections.Generic;

namespace FilePartReaderNUnit.Model
{
    /// <summary>
    /// It provides instance variables to read in a text file in different ways
    /// </summary>
    public class FilePartReader
    {
        //Due to the specification the line numbers in the textfile starts with 1, so we have to shift the for loop's iterator with 1
        private const int _shift = 1;
        private string _filePath;
        private int _fromLine;
        private int _toLine;

        /// <summary>
        /// Ctor. It initializes the instance variables with invalid values (due to the specification)
        /// </summary>
        public FilePartReader()
        {
            _filePath = @"..\..\TestData\Test.txt";
            _fromLine = 0;
            _toLine = -1;
        }

        /// <summary>
        /// It sets the instance variables to the values given in the argument
        /// if toLine is smaller than fromLine or fromLine is smaller than 1 then it raises ArgumentException
        /// </summary>
        /// <param name="filePath">Path of the text file, its default value is empty string</param>
        /// <param name="fromLine">Starting line number of the reading, default value is 1</param>
        /// <param name="toLine">Finishing line number of the reading, default value is 1</param>
        public void Setup(string filePath = "", int fromLine = 1, int toLine = 1)
        {
            if (toLine < fromLine)
            {
                throw new ArgumentException("Setup error: toLine is smaller than fromLine");
            }
            else if (fromLine < 1)
            {
                throw new ArgumentException("Setup error: fromLine is smaller than 1");
            }
            else
            {
                _filePath = filePath;
                _fromLine = fromLine;
                _toLine = toLine;
            }

        }

        /// <summary>
        /// Reads in the whole content of the text file (_filePath) and returns it as a string;
        /// </summary>
        /// <returns></returns>
        public string Read()
        {
            return String.Join("\n", File.ReadLines(_filePath).ToArray());
        }

        /// <summary>
        /// Reads in the lines of the text file between _fromLine and _toLine (bilateral closed intervall)
        /// Uses this.Read() for getting the full content
        /// </summary>
        /// <returns>Returns the lines as a string</returns>
        public string ReadLines()
        {
            var AllRows = Read().Split('\n');
            var rows = new List<string>();
            for (var i = _fromLine - _shift; i + _shift <= _toLine && i + _shift <= AllRows.Length; ++i)
            {
                rows.Add(AllRows[i]);
            }

            return String.Join("\n", rows.ToArray());
        }

    }
}
