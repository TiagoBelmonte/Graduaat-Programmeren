using EventServiceClientWPF.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace EventServiceClientWPF.Services
{
    public class EventService
    {
        private HttpClient client;
        public EventService()
        {
            client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:5188/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
        }
        public async Task<Event> GetEventAsync(string path)
        {
            try
            {
                Event v = null;
                HttpResponseMessage response = await client.GetAsync(path);
                if (response.IsSuccessStatusCode)
                {
                    v = await response.Content.ReadAsAsync<Event>();

                }
                return v;
            }
            catch (Exception ex) { Console.WriteLine(ex.ToString());return null; }
        }
    }
}
