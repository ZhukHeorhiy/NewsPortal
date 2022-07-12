namespace NewsPortal.Application
{
    internal interface INewsAppService
    {
        IReadOnlyCollection<NewsModel> GetAllNews();
    }
}
