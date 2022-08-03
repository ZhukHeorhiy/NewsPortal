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

        public static IEnumerable<News> ToNewsList(this NewsApiModel newsApiList)
        {
            return newsApiList.Articles.Select(news => new News(
                Guid.Empty,
                news.Author,
                news.Title,
                news.Description,
                news.Url,
                news.UrlToImage,
                news.PublishedAt,
                news.Content
                )
            );
        }


    }
}
