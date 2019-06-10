using System;
using System.Threading;

namespace Threadpool
{
    class Program
    {
        /// <summary>
        /// Prints the concatenated form of the thread's ID and the state parameter to the standard output.
        /// </summary>
        /// <param name="state"></param>
        private static void ShowMyText(object state)
        {
            System.Console.WriteLine($"{(string)state} - {Thread.CurrentThread.ManagedThreadId}");
        }

        /// <summary>
        /// Main entry point.
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            WaitCallback waitCallback = ShowMyText;
            ThreadPool.SetMaxThreads(4, 0);
            string[] states = new string[] { "apacuka", "fundaluka", "fundakave", "kamanduka" };
            for (var i = 0; i < 4; ++i)
            {
                ThreadPool.QueueUserWorkItem(waitCallback, states[i]);
            }
            Console.ReadKey();
        }
    }
}
