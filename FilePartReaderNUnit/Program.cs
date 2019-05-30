using System;
using FilePartReaderNUnit.Model;

namespace FilePartReaderNUnit
{
    class Program
    {
        static void Main()
        {
            var FPT = new FilePartReader();
            FPT.Setup(@"..\..\TestData\Test.txt", 1, 1);
            var analyser = new FileWordAnalyzer(FPT);
            try
            { 
                foreach(var word in FPT.ReadLines())
                {
                    Console.WriteLine(word);
                }
            }
            catch(Exception exception)
            {
                Console.WriteLine($"Reading error: {exception.Message}");
            }

            Console.ReadKey();
        }
    }
}
