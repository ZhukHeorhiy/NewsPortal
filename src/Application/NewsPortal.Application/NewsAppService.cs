using NewsPortal.Domain;
namespace NewsPortal.Application
{
    public class NewsAppService : INewsAppService
    {
        private readonly INewsRepository<News> _newsRepository;

        public NewsAppService(INewsRepository<News> newsRepository)
        {
            _newsRepository = newsRepository ?? throw new ArgumentNullException(nameof(newsRepository));
        }

        public IReadOnlyCollection<NewsModel> GetAllNews()
        {
            throw new NotImplementedException();
        }
    }
}
