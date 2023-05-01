using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Lab5
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            var client = new HttpClient("https://catfact.ninja/fact");

            //GET
            var responseGet = await client.GetAsync<List<string>>();

            if (responseGet.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var get_fact = responseGet.Result.Fact;
                var get_len = responseGet.Result.Length;
                Console.WriteLine($"GET Response OK: \n{get_fact}, \n{get_len}");
            }
            else
            {
                Console.WriteLine($"GET Response Error: \n{responseGet.StatusCode}");
            }

            //POST
            var requestObject = new object();
            var responsePost = await client.PostAsync<string>(requestObject);

            if (responsePost.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var post_fact = responsePost.Result.Fact;
                var post_len = responsePost.Result.Length;
                Console.WriteLine($"\nPOST Response OK: \n{post_fact}, \n{post_len}");
            }
            else
            {
                Console.WriteLine($"\nPOST Response Error: \n{responsePost.StatusCode}");
            }

            Console.ReadKey();
        }
    }
}