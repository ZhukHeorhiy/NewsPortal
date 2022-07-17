using NewsPortal.Domain;

namespace InfrastructureWether

{
    public class WetherRepository : INewsRepository<News>
    {
        public async Task<ICollection<News>> GetAll()
        {
            return new List<News> { new News ("wether", "Ukraine Czech war","","/url.com","",DateTime.Now,"USA")};
        }
    }
}