using Microsoft.Extensions.Options;
using System.Data.SqlClient;
using NewsPortal.Domain;
using NewsPortal.Networking;


namespace NewsPortal.Infrastructure.Data
    
{
    public class NewsRepository : INewsRepository<News>
    {
        private readonly IRestService _restService;
        private readonly string _apiKey;
        public NewsRepository(IRestService restService, IOptions<NewsApiSettings> options)
        {
            _restService = restService;
            _restService.Init(options.Value.ApiHost);
            _apiKey = options.Value.ApiKey;
        }
        public async Task<ICollection<News>> GetAll()
        {
            NewsApiModel apiNews = await _restService.GetItem<NewsApiModel>("everything?q=Ukraine&from=2022-07-08&sortBy=publishedAt&apiKey=" + _apiKey);
            return apiNews.ToNewsList().ToList();
        }
        public async Task AddNewsRepository(News news)
        {
            Guid guid = Guid.NewGuid();
            string query = $@"INSERT INTO News(NewsID,Author,Title,Description,Url,ImageUrl,PublishedAt,Content) 
            VALUES (@guid,@author,@title,@description,@url,@imageUrl,@publishedAt,@content)";
            await using SqlConnection connection = new("Data Source=.;Initial Catalog=NewsPortal;Integrated Security=True;");
            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@guid", guid);
            command.Parameters.AddWithValue("@author", news.Author);
            command.Parameters.AddWithValue("@title", news.Title);
            command.Parameters.AddWithValue("@description", news.Description);
            command.Parameters.AddWithValue("@url", news.Url);
            command.Parameters.AddWithValue("@imageUrl", news.ImageUrl);
            command.Parameters.AddWithValue("@publishedAt", news.PublishedAt);
            command.Parameters.AddWithValue("@content", news.Content);
            try
            {
                connection.Open();
                command.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                throw new ApplicationException("problems with sql conection:" + $"{ex}");
            }


        }
        public async Task DeleteCommentsNewsRep(Guid commentId)
        {
            string query = $@"DELETE FROM Comments 
            WHERE CommentId =={commentId}";
            await using SqlConnection connection = new("Data Source=.;Initial Catalog=NewsPortal;Integrated Security=True;");
            SqlCommand command = new SqlCommand(query, connection);
            
            try
            {
                connection.Open();
                command.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                throw new ApplicationException("problems with sql conection:" + $"{ex}");
            }
        }
        public async Task<News> GetOneNews(Guid NewsId)
        {
            string query = @"SELECT * FROM News n
            WHERE NewsId = @newsId";
            await using SqlConnection connection = new("Data Source=.;Initial Catalog=NewsPortal;Integrated Security=True;");
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@newsId", NewsId);
            News news = null;
            try
            {
                connection.Open();
                SqlDataReader reader = await command.ExecuteReaderAsync();
                await reader.ReadAsync();
                news = new News(
                        await reader.GetFieldValueAsync<Guid>(reader.GetOrdinal("NewsID")),
                        await reader.GetFieldValueAsync<string>(reader.GetOrdinal("Author")),
                        await reader.GetFieldValueAsync<string>(reader.GetOrdinal("Title")),
                        await reader.GetFieldValueAsync<string>(reader.GetOrdinal("Description")),
                        await reader.GetFieldValueAsync<string>(reader.GetOrdinal("Url")),
                        await reader.GetFieldValueAsync<string>(reader.GetOrdinal("ImageUrl")),
                        await reader.GetFieldValueAsync<DateTime>(reader.GetOrdinal("PublishedAt")),
                        await reader.GetFieldValueAsync<string>(reader.GetOrdinal("Content"))
                 );
                foreach(Comment comment in await GetComments(NewsId))
                {
                    news.AddComment(comment);
                }
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Cannot get one news, error: "+$"{ex}");
            }
            return news;
        }
        private async Task<List<Comment>> GetComments(Guid NewsId)
        {
            string query = @"SELECT CommentId, CommentContent, CommentLikes FROM Comments
            WHERE NewsId = @newsId";
            await using SqlConnection connection = new("Data Source=.;Initial Catalog=NewsPortal;Integrated Security=True;");
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@newsId", NewsId);
            List<Comment> comments = new List<Comment>();
            try
            {
                connection.Open();
                SqlDataReader reader = await command.ExecuteReaderAsync();
                while (await reader.ReadAsync())
                {
                    
                    comments.Add(
                        new Comment(await reader.GetFieldValueAsync<string>(reader.GetOrdinal("CommentContent")),
                        await reader.GetFieldValueAsync<int> (reader.GetOrdinal("CommentLikes")),
                        await reader.GetFieldValueAsync<Guid>(reader.GetOrdinal("CommentId"))
                        ));
                }
            }catch(Exception ex)
            {
                throw new ApplicationException("Cannot get a comment");
            }
            return comments;
        }
        public async Task AddCommentsRep(Comment comment, Guid newsId)
        {
            string query = @$"INSERT INTO Comments 
            ([CommentId]
           ,[CommentContent]
           ,[CommentLikes]
           ,[NewsID]) VALUES
            (@CommentId,
            @CommentContent,
            @CommentLikes,
            @NewsID)";
            await using SqlConnection connection = new("Data Source =.; Initial Catalog = NewsPortal; Integrated Security = True;");
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@CommentId", comment.CommentId);
            command.Parameters.AddWithValue("@CommentContent", comment.CommentContent);
            command.Parameters.AddWithValue("@CommentLikes", comment.CommentLikes);
            command.Parameters.AddWithValue("@NewsID", newsId);

            try
            {
                connection.Open();
                command.ExecuteNonQuery();
            }catch(Exception ex)
            {
                throw new ApplicationException("cannot add comment to Rep");
            }
            


        }
    }
}