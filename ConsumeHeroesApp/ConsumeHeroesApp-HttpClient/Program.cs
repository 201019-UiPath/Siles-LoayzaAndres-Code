using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Http;
using ConsumeHeroesApp_HttpClient.Models;

namespace ConsumeHeroesApp_HttpClient
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            GetAllHeros();
        }

        public static void GetAllHeros()
        {
            string url = "https://localhost:44379/Superhero/get";
            using (var client= new HttpClient() )
            {
                client.BaseAddress = new Uri(url);
                var response = client.GetAsync("");
                response.Wait();

                var result = response.Result;
                if(result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<SuperHero[]>();
                    readTask.Wait();
                    var superHeros = readTask.Result;
                    foreach (var superhero in superHeros)
                    {
                        Console.WriteLine($"{superhero.id} {superhero.alias}");
                    }
                }
            }
        }
    }
}
