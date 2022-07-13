namespace NewsPortal.Domain
{
    public interface INewsRepository<T> where T : News
    {
        Task<IReadOnlyCollection<T>> GetAll();
    }
}
