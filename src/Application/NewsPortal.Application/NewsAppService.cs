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
        public async Task AddCommentApl(CommentsModel comments, Guid newsId)
        {
            
            News news = await _newsRepository.GetOneNews(newsId);
            Comment comment = new Comment(comments.Content, comments.Likes, comments.CommentId);
            news.AddComment(comment);
            News oldNews = await _newsRepository.GetOneNews(newsId);

            if (oldNews.Comments.Count < news.Comments.Count)
            {
                await _newsRepository.AddCommentsRep(comment, news.Id);
            }
        }
        public async Task AddNewsAplication(NewsModel news)
        {
           await _newsRepository.AddNewsRepository(news.ToNews());
        }
        public async Task DeleteCommentApl(Guid commentId, Guid newsId)
        {
            News news = await _newsRepository.GetOneNews(newsId);
            //тут ми визиваємо метод який вертає значення доменого рівня 
            news.DeleteComment(commentId);

        }
    }
}