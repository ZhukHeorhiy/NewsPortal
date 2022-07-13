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

        public async Task<IReadOnlyCollection<NewsModel>> GetAllNews(NewsFilter newsFilter)
        {
            IReadOnlyCollection<News> news = await _newsRepository.GetAll();
            IReadOnlyCollection<News> filteredNews = news.Where(n => n.WhatCountry().Contains(newsFilter.Country)).ToList().AsReadOnly();

            return filteredNews.ToNewsModel();
        }
    }
}
