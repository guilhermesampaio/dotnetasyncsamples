using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;

namespace ConsoleSample
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Main: Starting program");
            var asyncClass = new AsyncClass();

            //Console.WriteLine("Main: Before call asyncClass.AsyncMethodWithAwait()");
            //asyncClass.AsyncMethodWithAwait();
            //Console.WriteLine("Main: After call asyncClass.AsyncMethodWithAwait()");

            Console.WriteLine("Main: Before call asyncClass.AsyncMethodWithoutAwait()");
            asyncClass.AsyncMethodWithoutAwait();
            Console.WriteLine("Main: After call asyncClass.AsyncMethodWithoutAwait()");

            Console.ReadLine();

            
        }
        

    }

    public class AsyncClass
    {
        /// <summary>
        /// Example 01: Will await for seconds until return some data.
        /// If the caller call it with "await" keyword, the control will be passed to previous caller. 
        /// Otherwise, the execution will proceed.
        /// </summary>
        /// <returns></returns>
        public async Task<string> AsyncMethodWithAwait()
        {
            Console.WriteLine("AsyncMethodWithAwait: It will await for Task.Delay");

            await Task.Delay(TimeSpan.FromSeconds(10)); // Here the control will be passed to caller of GetSomeStringAsync

            Console.WriteLine("AsyncMethodWithAwait: After Task.Delay");

            Console.WriteLine("AsyncMethodWithAwait: Returning some data");

            return "Data from Task.";
        }


        /// <summary>
        /// Example 02: When a async method does not contain a "await" inside it, It will be executed synchronously. Even if caller use await.
        /// </summary>
        /// <returns></returns>
        public async Task<string> AsyncMethodWithoutAwait()
        {
            Console.WriteLine("AsyncMethodWithoutAwait: It will await for Task.Delay");

            Task.Delay(TimeSpan.FromSeconds(10)); // It will create a task that will finishes after 10 seconds, but will not await for that. Then the execution will pass for it.

            Console.WriteLine("AsyncMethodWithoutAwait: After Task.Delay");

            Console.WriteLine("AsyncMethodWithoutAwait: Returning some data");

            return "Data from Task.";
        }


        /// <summary>
        /// Example 03: When a thread starts a background task and it self is killed, the task kill too.
        /// </summary>
        /// <returns></returns>
        public async Task WriteFileAsync()
        {
            Console.WriteLine("WriteFileAsync: Creating array.");
            var lines = new List<string>();

            for (int i = 0; i < 1000000; i++)
            {
                lines.Add($"Linha legal muito louca {i}");
            }

            Console.WriteLine("WriteFileAsync: Starting write file");
            await File.WriteAllLinesAsync("./asyncfile.txt", lines);
            Console.WriteLine("WriteFileAsync: Finishing write file");
        }
    }
}
