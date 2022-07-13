using NewsPortal.Domain;

namespace NewsPortal.Application
{
    internal static class NewsModelMapper
    {
        public static IReadOnlyCollection<NewsModel> ToNewsModel(this IReadOnlyCollection<News> newsList)
        {
            return newsList.Select(news => new NewsModel()
            {
                Author = news.Author,
                Content = news.Content,
                Description = news.Description,
                ImageUrl = news.ImageUrl,
                IsImportant = news.IsImportant(),
                PublishedAt = news.PublishedAt,
                Title = news.Title,
                Url = news.Url,
            }).ToList().AsReadOnly();
        }
    }
}
