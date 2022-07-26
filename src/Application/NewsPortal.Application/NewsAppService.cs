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

        public async Task<ICollection<NewsModel>> GetAllNews(NewsFilter newsFilter)
        {
            IEnumerable<News> news = await _newsRepository.GetAll();

            if (newsFilter.Important.HasValue)
            {
                news = news.Where(n => n.IsImportant() == newsFilter.Important);
            }
            if (newsFilter.Country != Country.All)
            {
                news = news.Where(n => n.WhatCountry().Contains(newsFilter.Country));
            }

            return news.ToNewsModel();
        }
        public async Task AddNewsAplication(NewsModel news)
        {
           await _newsRepository.AddNewsRepository(news.ToNews());
        }
        public async Task DeleteCommentApl(int commentId)
        {
            News news = await _newsRepository.GetOneNews(commentId);

            news.DeleteComment(commentId);

        }
    }
}