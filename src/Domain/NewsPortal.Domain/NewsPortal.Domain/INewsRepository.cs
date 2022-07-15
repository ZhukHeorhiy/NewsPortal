namespace NewsPortal.Domain
{
    public interface INewsRepository<T> where T : News
    {
        Task<ICollection<T>> GetAll();
    }
}
