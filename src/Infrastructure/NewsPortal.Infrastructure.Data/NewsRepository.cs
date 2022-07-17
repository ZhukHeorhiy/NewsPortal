using NewsPortal.Domain;
using NewsPortal.Networking;
namespace NewsPortal.Infrastructure.Data
    
{
    public class NewsRepository : INewsRepository<News>
    {
        private IRestService _restService;
        public NewsRepository(IRestService restService)
        {
            _restService = restService;
            _restService.Init("https://newsapi.org/v2/");
        }
        public async Task<ICollection<News>> GetAll()
        {
            IEnumerable<NewsApiModel> apiNews = await _restService.GetItems<NewsApiModel>("everything?q=Ukraine&from=2022-07-08&sortBy=publishedAt&apiKey=e62091573e424b8aa6e13e8d55aad13b");
            return apiNews.ToNewsList().ToList();

        }
    }
}