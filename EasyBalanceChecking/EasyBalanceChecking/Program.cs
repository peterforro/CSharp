using System;
using System.Collections.Generic;
using System.Text;

namespace EasyBalanceChecking
{
  

    class Program
    {
        private const string b2 = @"1242.00
122 Hardware;! 13.60
127 Hairdresser 13.10
123 Fruits 93.50?;
132 Stamps;!{ 13.60?;
160 Pen;! 17.60?;
002 Car;! 34.00";

        private static string CleanRawString(string raw)
        {
            var sb = new StringBuilder();
            foreach (var chr in raw)
            {
                if (chr >= 'a' && chr <= 'z' || chr >= 'A' && chr <= 'Z' || chr >= '0' && chr <= '9' || " .\n".Contains($"{chr}"))
                {
                    sb.Append(chr);
                }
            }
            return sb.ToString();
        }

        private static List<string> ProcessData(string cleanedBook, ref double sum)
        {
            var rows = cleanedBook.Split('\n');
            var originalBalance = double.Parse(rows[0]);
            rows[0] = "Original Balance: " + rows[0];
            for (var i = 1; i < rows.Length; ++i)
            {
                var data = new List<string>();
                var tmp = rows[i].Split(' ');
                foreach (var str in tmp)
                {
                    if (str.Length > 0) data.Add(str);
                }
                sum += double.Parse(data[2]);
                originalBalance -= double.Parse(data[2]);
                rows[i] = $"{data[0]} {data[1]} {data[2]} Balance {String.Format("{0:0.00}", originalBalance)}";
            }
            var result= new List<string>();
            foreach (var row in rows)
            {
                if (row.Length != 0) result.Add(row);
            }
            return result;
        }

        public static string GetResultString(List<string> data, double sum)
        {
            var sb = new StringBuilder();
            sb.Append(string.Join("\n", data));
            sb.Append($"\nTotal expense  {String.Format("{0:0.00}", sum)}");
            sb.Append($"\nAverage expense  {String.Format("{0:0.00}", sum / (data.Count - 1), 2)}");
            return sb.ToString();
        }

        public static string Balance(string Book)
        {
            Book = CleanRawString(Book);
            double sum = 0;
            var data = ProcessData(Book, ref sum);
            return GetResultString(data, sum);
        }

        static void Main()
        {
            Console.WriteLine(Balance(b2));
            Console.ReadKey();
        }
    }
}
