using System;
using System.IO;
using System.Net;
using System.Runtime.CompilerServices;
using System.Text;


namespace Practice {
    class Program {

        private const string _path = @"D:\code\";


        static void Main(string[] args) {
            var dirs = Directory.EnumerateDirectories(_path);
            foreach (var dir in dirs) {
                Console.WriteLine(dir);
            }
            Console.ReadKey();
        }
      

    }
} 
