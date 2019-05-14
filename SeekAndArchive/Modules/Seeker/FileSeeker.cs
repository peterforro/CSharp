using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;
using SeekAndArchive.Control;





namespace SeekAndArchive.Modules.Seeker {


    class FileSeeker : SeekerAndArchiverEntity {

        
        public FileSeeker(FileSeekerAndArchiver controller) : base(controller) {
            FoundFiles = new Dictionary<string, FileInfo>();
        }


        public Dictionary<string, FileInfo> FoundFiles {
            get;
        }


        public long ElapsedTime {
            set;
            get;
        }


        public void SearchForFiles(SearchType type) {
            var rootDir = new DirectoryInfo(controller.RootDir);
            var pattern = controller.Pattern;
            Stopwatch sw = Stopwatch.StartNew();
            switch (type) {
                case SearchType.RECURSIVE:
                    sw.Start();
                    RecursiveTraversing(rootDir,pattern);
                    sw.Stop();
                    break;
                case SearchType.BUILTIN:
                    sw.Start();
                    BuiltIn(rootDir, pattern);
                    sw.Stop();
                    break;
                case SearchType.DFS:
                    sw.Start();
                    DepthFirstSearch(rootDir, pattern);
                    sw.Stop();
                    break;
            }
            ElapsedTime = sw.ElapsedMilliseconds;
            Console.WriteLine(this);

        }


        //--------------------RECURSIVE SOLUTION-------------------
        private void RecursiveTraversing(DirectoryInfo rootDir, string pattern) {

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
                    FoundFiles.Add(file.FullName,file);
                }
                foreach (var subDir in rootDir.GetDirectories()) {
                    RecursiveTraversing(subDir, pattern);
                }
            }

        }



        //---------------BUILTIN SEARCH OPTION SOLUTION---------------
        private void BuiltIn(DirectoryInfo rootDir, string pattern) {
            foreach (var file in rootDir.GetFiles(pattern, SearchOption.AllDirectories)) {
                FoundFiles.Add(file.FullName,file);
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

            try {
                var files = rootDir.GetFiles(pattern);
                foreach (var file in files) {
                    FoundFiles.Add(file.FullName, file);
                }
            } catch (UnauthorizedAccessException exception) {
                Console.WriteLine(exception.Message);
            }
            visited.Add(rootDir.FullName);
        }



        private void DepthFirstSearch(DirectoryInfo rootDir, string pattern) {

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


        public void RemoveFileFromList(string filePath) {
            FoundFiles.Remove(filePath);
        }


        public void OnRename(string oldPath, string newPath) {
            RemoveFileFromList(oldPath);
            FoundFiles.Add(newPath, new FileInfo(newPath));
        }


        public override string ToString() {
            var sb = new StringBuilder();
            sb.Append("Files being watched:\n");
            var fileCounter = 0;
            foreach (var file in FoundFiles.Values) {
                sb.Append($"\t{++fileCounter}. {file.FullName}\n");
            }
            sb.Append($"Search took: {ElapsedTime}ms\n\n");
            return sb.ToString();
        }





    }


}
