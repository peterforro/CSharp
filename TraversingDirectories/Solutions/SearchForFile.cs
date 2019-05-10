using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;


namespace TraversingDirectories.Solutions {


    class SearchForFile {


        private static int recursiveCounter = 0;
        private static int DFScounter = 0;


        //--------------------RECURSIVE SOLUTION-------------------
        public void Recursive(DirectoryInfo rootDir, string pattern) {

            FileInfo[] files = null;

            try {
                files = rootDir.GetFiles(pattern);
            } catch (UnauthorizedAccessException exception) {
                Console.WriteLine(exception.Message);
            } catch (DirectoryNotFoundException) {
                Console.WriteLine("Directory not found");
            }

            if (files != null) {
                foreach (var file in files) {
                    Console.WriteLine($"{++recursiveCounter}.: {file.FullName}");
                }
                foreach (var subDir in rootDir.GetDirectories()) {
                    Recursive(subDir,pattern);
                }
            }

        }


     

        //---------------BUILTIN SEARCH OPTION SOLUTION---------------
        public void BuiltIn(DirectoryInfo rootDir, string pattern) {

            var hitCounter = 0;

            foreach (var file in rootDir.GetFiles(pattern, SearchOption.AllDirectories)) {
                Console.WriteLine($"{++hitCounter}.: {file.FullName}");
            }
        }


        //-----------------DEPTH FIRST SEARCH SOLUTION----------------

        private List<DirectoryInfo> GetAvailableDirs(ICollection<string> visited, DirectoryInfo rootDir) {

            var availableList = new List<DirectoryInfo>();
            DirectoryInfo[] subDirs = null;

            try {
                subDirs = rootDir.GetDirectories();
            } catch (UnauthorizedAccessException exception) {
                Console.WriteLine(exception.Message);
            }

            if (subDirs != null) {
                foreach (var subDir in subDirs) {
                    if (!visited.Contains(subDir.FullName)) {
                        availableList.Add(subDir);
                    }
                }
            }
            return availableList;
        }



        private void VisitDirectory(ICollection<string> visited, DirectoryInfo rootDir, string pattern) {

            if (visited.Contains(rootDir.FullName)) return;
            FileInfo[] files = null;

            try {
                files = rootDir.GetFiles(pattern);
                foreach (var file in files) {
                    Console.WriteLine($"{++DFScounter}.: {file.FullName}");
                }
            } catch (UnauthorizedAccessException exception) {
                Console.WriteLine(exception.Message);
            }

            visited.Add(rootDir.FullName);
        }



        public void DepthFirstSearch(DirectoryInfo rootDir, string pattern) {

            var depth = new Stack<DirectoryInfo>();
            var visited = new List<string>();
            depth.Push(rootDir);

            do {

                VisitDirectory(visited, rootDir, pattern);
                var availableList = GetAvailableDirs(visited, rootDir);

                if (availableList.Count != 0) {
                    depth.Push(rootDir);
                    rootDir = availableList[0];
                } else {
                    rootDir = depth.Pop();
                }

            } while (depth.Count != 0);
        }



    }
}
