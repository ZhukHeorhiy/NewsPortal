namespace NewsPortal.Application
{
    public interface INewsAppService
    {
        Task<ICollection<NewsModel>> GetAllNews(NewsFilter newsFilter);
        Task AddNewsAplication(NewsModel news);
        Task DeleteCommentApl(Guid commentId, Guid newsId);
        Task AddCommentApl(CommentsModel comment, Guid newsId);
    }
}
