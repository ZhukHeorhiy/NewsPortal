using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NewsPortal.Domain;

namespace NewsPortal.Infrastructure.Data
{
    internal static class NewsApiModelMapper
    {
        public static IEnumerable<News> ToNewsList(this IEnumerable<NewsApiModel> newsApiList)
        {
            return newsApiList.Select(news => new News(
                news.Articles.Author,
                news.Articles.Title,
                news.Articles.Description,
                news.Articles.Url,
                news.Articles.UrlToImage,
                news.Articles.PublishedAt,
                news.Articles.Content
                )
            );
        }


    }
}
