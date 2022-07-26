using Microsoft.Extensions.Options;
using NewsPortal.Domain;
using NewsPortal.Networking;
namespace NewsPortal.Infrastructure.Data
    
{
    public class NewsRepository : INewsRepository<News>
    {
        private readonly IRestService _restService;
        private readonly string _apiKey;
        public NewsRepository(IRestService restService, IOptions<NewsApiSettings> options)
        {
            _restService = restService;
            _restService.Init(options.Value.ApiHost);
            _apiKey = options.Value.ApiKey;
        }
        public async Task<ICollection<News>> GetAll()
        {
            NewsApiModel apiNews = await _restService.GetItem<NewsApiModel>("everything?q=Ukraine&from=2022-07-08&sortBy=publishedAt&apiKey=" + _apiKey);
            return apiNews.ToNewsList().ToList();
        }
        public async Task AddNewsRepository(News news)
        {
            News Repository = news;
            //imitation that works 
            //here add logic which ads it to repo 
        }
        public async Task DeleteCommentsNewsRep(int commentId)
        {
            
        }
        public async Task<News> GetOneNews(int commentId)
        {
            News news = new News("", "title", "", "https://url.com", "", DateTime.Now, "Content");
            news.AddComment(new Comment("kek", 0, 4535));
            news.AddComment(new Comment("lol", 300, 4536));
            return news;
        }
    }
}