using NewsPortal.Domain;

namespace NewsPortal.Infrastructure.Data
{
    public class NewsRepository : INewsRepository<News>
    {
        public async Task<ICollection<News>> GetAll()
        {
            return new List<News>() { new News("Bbc", "Usa", "Usa Desc", "https://site.com", "", DateTime.Now, "Usa helped Ukraine") };
        }
    }
}