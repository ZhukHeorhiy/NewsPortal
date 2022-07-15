namespace NewsPortal.Application
{
    public interface INewsAppService
    {
        Task<ICollection<NewsModel>> GetAllNews(NewsFilter newsFilter);
    }
}
