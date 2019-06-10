using System;
using System.Threading;
using System.Collections.Generic;

namespace ThreadingPractice
{
    class Program
    {
        /// <summary>
        /// Prints the number of the iteration and the thread ID to the standard output, a hundred times.
        /// There is a 10ms blocking in every iteration. 
        /// </summary>
        private static void Counting()
        {
            for (var i = 0; i < 100; ++i)
            {
                Console.WriteLine($"#{i + 1} - ID:{Thread.CurrentThread.ManagedThreadId}");
                Thread.Sleep(10);
            }
        }

        /// <summary>
        /// Main entry point. 
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            var threads = new List<Thread>();
            for(var i = 0; i < 2; ++i)
            { 
                var thread = new Thread(new ThreadStart(Counting));
                thread.Name = $"thread-{i + 1}";
                threads.Add(thread);
            }
            threads.ForEach(thread => thread.Start());
            threads.ForEach(thread => thread.Join());
            Console.ReadKey();
        }
    }
}
