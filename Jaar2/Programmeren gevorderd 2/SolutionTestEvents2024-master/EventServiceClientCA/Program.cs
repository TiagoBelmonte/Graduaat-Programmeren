namespace EventServiceClientCA
{
    internal class Program
    {
        static HttpClient client = new HttpClient();

        static async Task Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            client.BaseAddress = new Uri("http://localhost:5188/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json") );

            var visitor = await GetVisitorAsync("api/visitor/2");
            Console.WriteLine(visitor);
        }

        static async Task<Visitor> GetVisitorAsync(string path)
        {
            try
            {
                Visitor v = null;
                HttpResponseMessage response = await client.GetAsync(path);
                if (response.IsSuccessStatusCode)
                {
                    v=await response.Content.ReadAsAsync<Visitor>();
                   
                }
                return v;
            }
            catch(Exception ex) { Console.WriteLine(ex.ToString()); return null; }
        }
    }
}
