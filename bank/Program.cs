using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace bank
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            string city = "Дніпропетровськ";

            using (HttpClient client = new HttpClient())
            {
                try
                {
                    string apiUrl = $"https://api.privatbank.ua/p24api/pboffice?city={city}"; //{"response_code":200,"response_description":"The service is closed since August 31, 2022"}
                    HttpResponseMessage response = await client.GetAsync(apiUrl);
                    if (response.IsSuccessStatusCode)
                    {
                        string responseBody = await response.Content.ReadAsStringAsync();
                        Console.WriteLine(responseBody);
                    }
                    else
                    {
                        Console.WriteLine($"HTTP Error: {response.StatusCode}");
                    }
                }
                catch (HttpRequestException e)
                {
                    Console.WriteLine($"Request exception: {e.Message}");
                }
            }
        }
    }
}