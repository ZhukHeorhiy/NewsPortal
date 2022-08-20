using NewsPortal.Domain;

namespace NewsPortal.Application
{
    internal static class NewsModelMapper
    {
        public static ICollection<NewsModel> ToNewsModel(this IEnumerable<News> newsList)
        {
            ICollection<NewsModel> newsM = newsList.Select(news => new NewsModel()
            {
                Id = news.NewsID,
                Author = news.Author,
                Content = news.Content,
                Description = news.Description,
                ImageUrl = news.ImageUrl,
                IsImportant = news.IsImportant(),
                PublishedAt = news.PublishedAt,
                Title = news.Title,
                Url = news.Url,
                //Comments = news.Comments.,
                
            }).ToList();
            //foreach (News news in newsList)
            //{
            //    foreach (Comments comments in news.Comments)
            //    {
            //        news.AddComment(new Comments(comments.CommentContent, comments.CommentLikes, comments.CommentId, comments.NewsId));
            //    }
            //}
            return newsM;
            
        }
        public static News ToNews(this NewsModel newsModel)
        {
            News news = new News(
                id: newsModel.Id,
                author: newsModel.Author,
                title: newsModel.Title,
                newsModel.Description,
                newsModel.Url,
                newsModel.ImageUrl,
                newsModel.PublishedAt,
                newsModel.Content
                );
            foreach (CommentsModel commentsModel in newsModel.Comments)
            {
                news.AddComment(new Comments(commentsModel.Content, commentsModel.Likes, commentsModel.CommentId, newsModel.Id));
            }

            return news;

        }


    }
}
