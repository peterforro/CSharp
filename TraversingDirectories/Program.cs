using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;
using TraversingDirectories.Solutions;



namespace TraversingDirectories {


    class Program {

        private const string _rootDirectory = @"D:\code\Python";
        private const string _searchPattern = "app.py";
       

        static void Main(string[] args) {
            var searchForFile = new SearchForFile();
            searchForFile.Recursive(new DirectoryInfo(_rootDirectory), _searchPattern);
            //searchForFile.BuiltIn(new DirectoryInfo(_rootDirectory), _searchPattern );
            //searchForFile.DepthFirstSearch(new DirectoryInfo(_rootDirectory), _searchPattern);
            Console.ReadKey();
        }
    }
}
