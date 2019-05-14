using System;
using SeekAndArchive.Control;



namespace SeekAndArchive {


    class Program {

        static void Main(string[] args) {
            var controller = new FileSeekerAndArchiver();
            while (Console.Read() != 'q');
        }


    }


}
