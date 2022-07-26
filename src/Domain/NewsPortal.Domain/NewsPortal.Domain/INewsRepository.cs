namespace NewsPortal.Domain
{
    public interface INewsRepository<T> where T : News
    {
        Task<ICollection<T>> GetAll();
        Task AddNewsRepository(T news);
        Task DeleteCommentsNewsRep(int commentId);
        Task<News> GetOneNews(int commentId);
    }
}
