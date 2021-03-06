using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Sep3Blazor.Model;

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
            Task<string> stringAsync = client.GetStringAsync(uri + "/Group/" + s);
            string message = await stringAsync;
            List<String> result = JsonSerializer.Deserialize<List<String>>(message);
            Console.WriteLine("Hi2");
            return result;
        }

        public async Task AddNoteAsync(Message message)
        {
            string noteAsJson = JsonSerializer.Serialize(message);
            HttpContent content = new StringContent(noteAsJson,
                Encoding.UTF8,
                "application/json");
            Console.WriteLine(2);
            HttpResponseMessage responseMessage = await client.PutAsync(uri + "/Group", content);
            Console.WriteLine(responseMessage.Content);

            if (!responseMessage.IsSuccessStatusCode)
            {
                throw new Exception(@"Error : (responseMessage.Status), (responseMessage.ReasonPhrase");
            }
        }
    }
}