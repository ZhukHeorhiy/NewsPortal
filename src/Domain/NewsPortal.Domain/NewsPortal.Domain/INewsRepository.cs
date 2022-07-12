namespace NewsPortal.Domain
{
    public interface INewsRepository<T> where T : News
    {
        IReadOnlyCollection<T> GetAll();
    }
}
