using System;
using System.IO;
using TraversingDirectories.Solutions;



namespace TraversingDirectories {


    class Program {

        private const string _rootDirectory = @"D:\code\Python";
        private const string _searchPattern = "app.py";
       

        static void Main(string[] args) {
            var searchForFile = new SearchForFile();
            //searchForFile.Recursive(new DirectoryInfo(args[0]), args[1]);
            //searchForFile.BuiltIn(new DirectoryInfo(args[0]), args[1] );
            searchForFile.DepthFirstSearch(new DirectoryInfo(args[0]), args[1]);
            Console.ReadKey();
        }
    }


}
