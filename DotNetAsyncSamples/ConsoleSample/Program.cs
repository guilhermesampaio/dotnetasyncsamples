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

            //int worker = 0;
            //int io = 0;
            //ThreadPool.GetAvailableThreads(out worker, out io);

            //Console.WriteLine("Thread pool threads available at startup: ");
            //Console.WriteLine("   Worker threads: {0:N0}", worker);
            //Console.WriteLine("   Asynchronous I/O threads: {0:N0}", io);

            //Console.WriteLine("Main: Starting program");

            //var asyncClass = new AsyncClass();

            //Console.WriteLine("Main: Before call asyncClass.GetSomeStrinAsync()");

            ////ExecutionWithAwait(asyncClass);

            //////ExecutionWithoutAwait(asyncClass);

            //asyncClass.WriteFileAsync();

            //Console.WriteLine("Main: After call asyncClass.GetSomeStrinAsync()");


            //Console.WriteLine("Before method B");
            //BDiferente();


            var soma = HandleMultipleTasks();
            Console.WriteLine($"After HandleMultipleTasks");

            Console.ReadLine();

            
        }

        static async Task B()
        {
            Console.WriteLine("Antes do await C");
            var resultado = await C();
            Console.WriteLine($"Resultado: {resultado}");
            Console.WriteLine("Depois do await C");
        }


        static void BDiferente()
        {
            Console.WriteLine("Antes do await C");
            var resultado = C().ContinueWith((antecedent) => Console.WriteLine("Após execução da tarefa que não foi aguardada!!!!"));
            Console.WriteLine($"Resultado: {resultado}");
            Console.WriteLine("Depois do await C");
        }


        static async Task<int> C()
        {

            await Task.Delay(TimeSpan.FromSeconds(5));

            return 10;

        }


        static async Task HandleMultipleTasks()
        {
            //Task task1 = Task.Run(() => PerformSomeWork(1));
            //Task task2 = Task.Run(() => PerformSomeWork(2));
            //Task task3 = Task.Run(() => PerformSomeWork(3));
            //Task task4 = Task.Run(() => PerformSomeWork(4));
            
            //var tasks = new Task[4] { task1, task2, task3, task4 };

            var tasks2 = new List<Task>();

            for (int i = 0; i <= 3; i++)
            {
                tasks2.Add(Task.Run(() => PerformSomeWork(i)));
            }

            

            Console.WriteLine("Before await all");
            //await Task.WhenAll(tasks2);
            await Task.WhenAny(tasks2);
            Console.WriteLine("After await all");
        }

        private static void PerformSomeWork(int id)
        {
            Console.WriteLine($"Task {id}");
            //Thread.Sleep(TimeSpan.FromSeconds(1));
            var currentThread = Thread.CurrentThread.ManagedThreadId;
            Console.WriteLine($"Current Thread: {currentThread}");
            
        }






        private static async Task ExecutionWithAwait(AsyncClass asyncClass)
        {
            await asyncClass.AsyncMethodWithAwait(); // Here the program will pause execution and await the task finishes to proceed the execution.

            //await asyncClass.AsyncMethodWithoutAwait(); // Here the program will not await for the task and will continue execution until "Console.ReadLine()".
        }

        private static Task ExecutionWithoutAwait(AsyncClass asyncClass)
        {
            return Task.Factory.StartNew(() =>
            {
                asyncClass.AsyncMethodWithAwait(); // Here the program will pause execution and await the task finishes to proceed the execution.
                asyncClass.AsyncMethodWithoutAwait(); // Here the program will not await for the task and will continue execution until "Console.ReadLine()".
            });
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
