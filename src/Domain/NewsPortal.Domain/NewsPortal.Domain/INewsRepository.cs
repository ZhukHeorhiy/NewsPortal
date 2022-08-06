﻿namespace NewsPortal.Domain
{
    public interface INewsRepository<T> where T : AgregateRoot
    {
        Task<ICollection<T>> GetAll();
        Task AddNewsRepository(T news);
        Task<T> GetOneNews(Guid NewsId);
        Task AddCommentsRep(Comment comment, Guid newsId);
        Task DeleteCommentsRep(Guid commentId, Guid newsId);

    }
}
