using System;
using System.Collections.Generic;
using System.IO;
using SeekAndArchive.Control;



namespace SeekAndArchive.Modules.Watcher {


    class FileWatcher : SeekerAndArchiverEntity {


        private Dictionary<string, FileSystemWatcher> watchers;


        public FileWatcher(FileSeekerAndArchiver controller) : base(controller) {
            watchers = new Dictionary<string, FileSystemWatcher>();
        }

      
        public void CreateWatcher(FileInfo file) {
            var watcher = new FileSystemWatcher();
                watcher.Path = Path.GetDirectoryName(file.FullName);
                watcher.Filter = file.Name;
                watcher.NotifyFilter = NotifyFilters.LastWrite | NotifyFilters.FileName;
                watcher.Changed += OnChanged;
                watcher.Deleted += OnChanged;
                watcher.Renamed += OnRenamed;
                watchers.Add(file.FullName, watcher);
                watcher.EnableRaisingEvents = true;
        }


        private void OnChanged(object source, FileSystemEventArgs fileEvent) {
            switch (fileEvent.ChangeType) {
                case WatcherChangeTypes.Changed:
                    Console.WriteLine($"File: {fileEvent.FullPath} {fileEvent.ChangeType}, so it has been archived!");
                    controller.ArchiveModifiedFile(fileEvent.FullPath);
                    break;
                case WatcherChangeTypes.Deleted:
                    Console.Clear();
                    Console.WriteLine($"Deleted file {fileEvent.FullPath}");
                    watchers.Remove(fileEvent.FullPath);
                    controller.OnDelete(fileEvent.FullPath);
                    break;
            }
        }


        private void OnRenamed(object source, RenamedEventArgs fileEvent) {
            Console.Clear();
            Console.WriteLine($"File: {fileEvent.OldFullPath} renamed to {fileEvent.FullPath}");
            var watcher = watchers[fileEvent.OldFullPath];
            watcher.Filter = fileEvent.Name;
            watchers[fileEvent.FullPath] = watcher;
            watchers.Remove(fileEvent.OldFullPath);
            controller.OnRename(fileEvent.OldFullPath, fileEvent.FullPath);
        }


    }


}
