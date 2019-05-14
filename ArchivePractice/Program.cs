using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Compression;

using System.IO;

namespace ArchivePractice {


    class Program {

        private static readonly string _zipPath = @"D:\hello.zip";
        private static readonly string _filePath = @"D:\bla.txt";

        static void Main(string[] args) {

            using (FileStream zipToHandle = new FileStream(_zipPath, FileMode.OpenOrCreate, FileAccess.ReadWrite)) {
                using (ZipArchive archive = new ZipArchive(zipToHandle, ZipArchiveMode.Update)) {
                    ZipArchiveEntry entry = archive.CreateEntryFromFile(_filePath, Path.GetFileName(_filePath));
                }
            }

          

        }
    }
}
