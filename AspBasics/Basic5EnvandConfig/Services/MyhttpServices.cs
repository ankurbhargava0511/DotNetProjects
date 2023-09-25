namespace Basic5EnvandConfig.Services
{
    public class MyhttpServices : IMyhttpServices
    {
        public MyhttpServices(IHttpClientFactory clientFactory)
        {
            ClientFactory = clientFactory;
        }

        public IHttpClientFactory ClientFactory { get; }

        public async Task<String> method()
        {
            string outputResponse = string.Empty; 
            using (HttpClient webClient = ClientFactory.CreateClient())
            {
                HttpRequestMessage message = new HttpRequestMessage()
                {
                    RequestUri = new Uri("https://jsonplaceholder.typicode.com/posts"),
                    Method = HttpMethod.Get
                    // Header  , etc

                };

                HttpResponseMessage rMessage = await webClient.SendAsync(message);
                Stream reader = rMessage.Content.ReadAsStream();
                StreamReader readerStream = new StreamReader(reader);
                outputResponse = readerStream.ReadToEnd();
               
            }
            return outputResponse;
        }
    }
}
