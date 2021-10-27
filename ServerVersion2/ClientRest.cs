using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace ServerVersion2
{
    public class ClientRest
    {
        private string uri = "http://localhost:8080";
        private readonly HttpClient client;

        public ClientRest()
        {
            client = new HttpClient();
        }
        
        public async Task<IList<String>> GetNoteAsync(String s)
        {
            Console.WriteLine("Hi");
            Task<string> stringAsync = client.GetStringAsync(uri + "/Group/"+s);
            string message = await stringAsync;
            List<String> result = JsonSerializer.Deserialize<List<String>>(message);
            Console.WriteLine("Hi2");
            return result;
        }
    }
}