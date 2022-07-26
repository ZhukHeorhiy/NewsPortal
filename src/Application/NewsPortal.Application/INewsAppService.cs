namespace NewsPortal.Application
{
    public interface INewsAppService
    {
        Task<ICollection<NewsModel>> GetAllNews(NewsFilter newsFilter);
        Task AddNewsAplication(NewsModel news);
        Task DeleteCommentApl(int commentId);
    }
}
