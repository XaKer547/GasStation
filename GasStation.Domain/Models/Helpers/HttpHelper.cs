namespace GasStation.Domain.Models.Helpers
{
    public static class HttpHelper
    {
        private const string URI = "https://localhost:7146/";

        private static HttpClient _client;

        public static HttpClient Instance()
        {
            _client ??= new(new HttpClientHandler() { UseProxy = false })
            {
                BaseAddress = new Uri(URI)
            };

            return _client;
        }
    }
}
