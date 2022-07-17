using Newtonsoft.Json;
using System.Net;
using System.Net.Http.Headers;

namespace NewsPortal.Networking
{
    public class RestService : IRestService
    {
        private HttpClient _httpClient;

        public void Init(string host)
        {
            _httpClient = new HttpClient { BaseAddress = new Uri(host) };
            _httpClient.DefaultRequestHeaders.Accept.Clear();
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            _httpClient.DefaultRequestHeaders.Add("user-agent", "News-API-csharp/0.1");
        }

        public async Task<T> GetItem<T>(string path)
        {
            if (_httpClient == null) throw new ApplicationException("http client is not initialized.");

            var response = await _httpClient.GetAsync(path);

            if (!response.IsSuccessStatusCode)
            {
                throw new WebException(await response.Content.ReadAsStringAsync());
            }

            var item = JsonConvert.DeserializeObject<T>(await response.Content.ReadAsStringAsync());
            return item;
        }

        public async Task<ICollection<T>> GetItems<T>(string path)
        {
            if (_httpClient == null) throw new ApplicationException("http client is not initialized.");

            var response = await _httpClient.GetAsync(path);

            if (!response.IsSuccessStatusCode)
            {
                throw new WebException(await response.Content.ReadAsStringAsync());
            }

            var items = JsonConvert.DeserializeObject<ICollection<T>>(await response.Content.ReadAsStringAsync());
            return items;
        }
    }

}