using NewsPortal.Domain;

namespace NewsPortal.Application
{
    internal static class NewsModelMapper
    {
        public static ICollection<NewsModel> ToNewsModel(this IEnumerable<News> newsList)
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
            }).ToList();
        }
        public static News ToNews(this NewsModel newsModel)
        {
            News news = new News(
                author: newsModel.Author,
                title: newsModel.Title,
                newsModel.Description,
                newsModel.Url,
                newsModel.ImageUrl,
                newsModel.PublishedAt,
                newsModel.Content
                );
            foreach(CommentsModel commentsModel in newsModel.Comments)
            {
                news.AddComment(new Comment(commentsModel.Content, commentsModel.Likes, commentsModel.CommentId));
            }
            
            return news;

        }


    }
}
