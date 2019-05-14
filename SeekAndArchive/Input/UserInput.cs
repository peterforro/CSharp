using System;

namespace SeekAndArchive.Input {


    static class UserInput {

        public static Options GetUserOptions() {
            Console.Write("Root directory?: ");
            var rootDir = Console.ReadLine();
            Console.Write("Search pattern?: ");
            var pattern = Console.ReadLine();
            Console.Write("Archive directory?: ");
            var archiveDir = Console.ReadLine();
            Console.Write("Search type?: ");
            var searchType = Console.ReadLine();
            Console.Clear();
            return new Options(rootDir,pattern,archiveDir,searchType);
        }


    }
}
