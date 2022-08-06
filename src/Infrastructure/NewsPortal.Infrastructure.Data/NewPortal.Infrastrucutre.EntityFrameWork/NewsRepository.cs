using Microsoft.EntityFrameworkCore;
using NewsPortal.Domain;
namespace NewPortal.Infrastrucutre.EntityFrameWork
{
    public class NewsRepository : INewsRepository<News>
    {
        private readonly NewsPortalContext _newsPortalContext;
        private readonly IRestService _restService;
        private readonly string _apiKey;
        public NewsRepository(IRestService restService, IOptions<NewsApiSettings> options)
        {
            _restService = restService;
            _restService.Init(options.Value.ApiHost);
            _apiKey = options.Value.ApiKey;
        }
        public NewsRepository(NewsPortalContext newsPortalContext)
        {
            _newsPortalContext = newsPortalContext;
        }
        public async Task<ICollection<News>> GetAll()
        {
            return null;
            //ICollection<New> apiNews = await _restService.GetItem<News>("everything?q=Ukraine&from=2022-07-08&sortBy=publishedAt&apiKey=" + _apiKey);
            //return apiNews.ToNewsList().ToList();
        }
        public async Task AddNewsRepository(News news)
        {

        }
        public async Task<News> GetOneNews(Guid NewsId)
        {
            return await _newsPortalContext.News.Where(n => n.Id == NewsId).Include(c => c.Comments).SingleOrDefaultAsync();
        }
        public async Task AddCommentsRep(Comment comment, Guid newsId)
        {

        }
        public async Task DeleteCommentsRep(Guid commentId, Guid newsId)
        {

        }

    }
}