using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Runtime.CompilerServices;
using System.Text;


namespace Practice {




    class FileSystemNode {


        private static int _instanceCounter;

        public int ID { get; }
        public string Name { get; }
        public string Path { get; }
        public bool Opened { get; }
        public Dictionary<string, FileInfo> Files { get; } = new Dictionary<string, FileInfo>();
        public Dictionary<string, FileInfo> SelectedFiles { get; } = new Dictionary<string, FileInfo>();
        public Dictionary<string, FileSystemNode> Directories { get; } = new Dictionary<string, FileSystemNode>();

        public FileSystemNode(DirectoryInfo dir) {
            ID = ++_instanceCounter;
            Name = dir.Name;
            Path = dir.FullName;
            foreach (var file in dir.GetFiles()) {
                try {
                    Files.Add(file.FullName, file);
                }
                catch (UnauthorizedAccessException exception) {
                    Console.WriteLine(exception.Message);
                }
            }
            foreach (var subDir in dir.GetDirectories()) {
                try {
                    Directories.Add(subDir.FullName, new FileSystemNode(subDir));
                }
                catch (UnauthorizedAccessException exception) {
                    Console.WriteLine(exception.Message);
                }
            }

        }


    }












    class Program {

        private const string _path = @"D:\code\";


        static void Main(string[] args) {

            FileSystemNode node = new FileSystemNode(new DirectoryInfo(@"D:\"));

        }
      

    }
} 
