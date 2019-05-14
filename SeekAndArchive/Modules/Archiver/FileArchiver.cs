using System;
using System.IO;
using System.IO.Compression;
using System.IO.IsolatedStorage;
using SeekAndArchive.Control;


namespace SeekAndArchive.Modules.Archiver {


    class FileArchiver : SeekerAndArchiverEntity {


        public FileArchiver(FileSeekerAndArchiver controller) : base(controller) {
            CreateDirectory(controller.ArchiveDir);
        }


        private void CreateDirectory(string path) {
            var dir = new DirectoryInfo(path);
            dir.Create();
        }


        private string CreatePathForCompression(FileInfo file) {

            return string.Concat(
                controller.ArchiveDir,
                $@"{file.Name}\",
                Path.GetFileNameWithoutExtension(file.FullName),
                DateTime.Now.ToString("yyyyMMddHHmmssfff"),
                Path.GetExtension(file.FullName) + ".gz");
        }


        public void ArchiveFile(FileInfo file) {

            string filePath = CreatePathForCompression(file);
            CreateDirectory(Path.GetDirectoryName(filePath));

            using (var fileStream = new FileStream(file.FullName, FileMode.Open, FileAccess.Read, FileShare.ReadWrite)) {
                using (var compressedFileStream = File.Create(filePath)) {
                    using (var compressionStream = new GZipStream(compressedFileStream, CompressionMode.Compress)) {
                        fileStream.CopyTo(compressionStream);
                    }
                }

                ArchiveIntoIsolatedStorage(new FileInfo(filePath));
            }
        }


        private void ArchiveIntoIsolatedStorage(FileInfo file) {

            var isoStore =
                IsolatedStorageFile.GetStore(IsolatedStorageScope.User | IsolatedStorageScope.Assembly, null, null);

            using (var isoStream = new IsolatedStorageFileStream(file.Name, FileMode.CreateNew, isoStore)) {
                using (var fileStream = new FileStream(file.FullName, FileMode.Open)) {
                    fileStream.CopyTo(isoStream);
                }
            }
        }



    }



}


