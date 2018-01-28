using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace ApiSamples.Controllers
{

    public class AsyncSamplesController : Controller
    {
        
        [HttpGet("/sincrono/{id}")]        
        public string Get(string id)
        {
            var initialThread = Thread.CurrentThread.ManagedThreadId;
            Console.WriteLine($"Starting sync request: [{id}] with thread: [{initialThread}]");
            
            Thread.Sleep(TimeSpan.FromSeconds(30));

            var finalThread = Thread.CurrentThread.ManagedThreadId;
            Console.WriteLine($"Finishing sync request: [{id}] with thread: [{finalThread}]");

            return $"sync request {id}";
        }

        [HttpGet("/assincrono/{id}")]
        public async Task<string> Get(int id)
        {
            var initialThread = Thread.CurrentThread.ManagedThreadId;
            Console.WriteLine($"Starting async request: [{id}] with thread: [{initialThread}]");

            await Task.Delay(TimeSpan.FromSeconds(30));

            var finalThread = Thread.CurrentThread.ManagedThreadId;
            Console.WriteLine($"Finishing async request: [{id}] with thread: [{finalThread}]");

            return $"async request {id}";
        }

       
    }
}
