namespace NewsPortal.Application
{
    internal interface INewsAppService
    {
        Task<IReadOnlyCollection<NewsModel>> GetAllNews(NewsFilter newsFilter);
    }
}
