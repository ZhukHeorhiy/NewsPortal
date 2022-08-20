using Microsoft.EntityFrameworkCore;
using NewsPortal.Domain;

namespace NewsPortal.Infrastrucutre.EntityFrameWork
{
    public class NewsRepository : INewsRepository<News>
    {
        private readonly NewsPortalContext _newsPortalContext;
        public NewsRepository(NewsPortalContext newsPortalContext)
        {
            _newsPortalContext = newsPortalContext;
        }

        public async Task<ICollection<News>> GetAll()
        {
            return await _newsPortalContext.News.Include(c => c.Comments).ToListAsync();
            //    //var query1 = _newsPortalContext.News.Include(c => c.Comments);
            //    //var query2 = query1.OrderBy(n => n.PublishedAt);
            //    //return await query2.ToListAsync();
        }

        public async Task AddNewsRepository(News news)
        {
            _newsPortalContext.News.Add(news);
            await SubmitChanges();
        }
        public async Task<News> GetOneNews(Guid NewsId)
        {
            return await _newsPortalContext.News.Where(n => n.NewsID == NewsId).Include(c => c.Comments).SingleOrDefaultAsync();
        }
        public async Task SubmitChanges()
        {
            await _newsPortalContext.SaveChangesAsync();
        }
        public async Task<News> GetOneNewsNonTracking(Guid NewsId)
        {
            return await _newsPortalContext.News.AsNoTracking().Where(n => n.NewsID == NewsId).Include(c => c.Comments).SingleOrDefaultAsync();
        }
        public async Task<ICollection<News>> GetAllNonTracking()
        {
            var query1 = _newsPortalContext.News.Include(c => c.Comments);
            var query2 = query1.OrderBy(n => n.PublishedAt);
            return await query2.AsNoTracking().ToListAsync();
        }

        public async Task AddCommentsRep(Comments comment)
        {
            _newsPortalContext.Comments.Add(comment);
            await SubmitChanges();
        }

        public Task DeleteCommentsRep(Guid commentId, Guid newsId)
        {
            throw new NotImplementedException();
        }

    }
}