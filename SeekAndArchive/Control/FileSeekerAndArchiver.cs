using System;
using SeekAndArchive.Input;
using SeekAndArchive.Modules.Archiver;
using SeekAndArchive.Modules.Seeker;
using SeekAndArchive.Modules.Watcher;



namespace SeekAndArchive.Control {


    class FileSeekerAndArchiver {


        private readonly Options options = UserInput.GetUserOptions();
        private readonly FileSeeker seeker;
        private readonly FileWatcher watcher;
        private readonly FileArchiver archiver;


        public FileSeekerAndArchiver() {
            seeker = new FileSeeker(this);
            watcher = new FileWatcher(this);
            archiver = new FileArchiver(this);
            seeker.SearchForFiles(SearchType);
            CreateWatchers();
            ArchiveFiles();
        }

        public string RootDir {
            get => options.rootDir;
        }

        public string Pattern {
            get => options.pattern;
        }


        public string ArchiveDir {
            get => options.archiveDir;
        }


        public SearchType SearchType {
            get => options.searchType;
        }


        public void CreateWatchers() {
            foreach (var file in seeker.FoundFiles.Values) {
                watcher.CreateWatcher(file);
            }
        }


        public void ArchiveFiles() {
            foreach (var file in seeker.FoundFiles.Values) {
                archiver.ArchiveFile(file);
            }
        }


        public void ArchiveModifiedFile(string filePath) {
            var file = seeker.FoundFiles[filePath];
            archiver.ArchiveFile(file);
        }


        public void OnDelete(string filePath) {
            seeker.RemoveFileFromList(filePath);
            Console.WriteLine(seeker);
        }


        public void OnRename(string oldPath, string newPath) {
            seeker.OnRename(oldPath,newPath);
            Console.WriteLine(seeker);
        }


    }
}
