using System;
using System.Collections.Generic;
using System.Threading;

namespace practice
{
    /// <summary>
    /// Just a simple Test class, to do something while testing the Mutex object
    /// </summary>
    class Test
    {
        /// <summary>
        /// It counts to infinite, and prints the numbers to the standard output
        /// </summary>
        public void CounterMethod()
        {
            int cnt = 0;
            while (true)
            {
                Console.WriteLine($"{++cnt}");
            }
        }

        /// <summary>
        /// Waits for user interaction. If the user presses "y" then ENTER, the program exists with status code 0
        /// </summary>
        public void ExitMethod()
        {
            while (true)
            {
                if (Console.ReadLine() == "y") System.Environment.Exit(0);
            }
        }
    }

    /// <summary>
    /// Main Class of the program
    /// </summary>
    class Program
    {
        /// <summary>
        /// The name of the Mutex, to provide single instance running of the program
        /// </summary>
        private const string _mutexName = "THINGY";

        /// <summary>
        /// Main Entry point
        /// </summary>
        public static void Main()
        {
            Mutex mutex = null;
            try
            {
                mutex = Mutex.OpenExisting(_mutexName);
                mutex.Close();
                System.Environment.Exit(1);
            }
            catch (WaitHandleCannotBeOpenedException)
            {
                mutex = new Mutex(false, _mutexName);
                var test = new Test();
                var threads = new List<Thread>();
                threads.Add(new Thread(new ThreadStart(test.CounterMethod)));
                threads.Add(new Thread(new ThreadStart(test.ExitMethod)));
                threads.ForEach(thread => thread.Start());
                threads.ForEach(thread => thread.Join());
            }
        }
    }
}
