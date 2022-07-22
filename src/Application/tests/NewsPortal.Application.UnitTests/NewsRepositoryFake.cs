using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NewsPortal.Domain;

namespace NewsPortal.Application.UnitTests
{
    internal class NewsRepositoryFake : INewsRepository<News>
    {
        public async Task<ICollection<News>> GetAll()
        {
            return new List<News> { new News("", "Czech war", "", "https://url.com", "", DateTime.Now, "Czech war"),
                new News("", "Ukraine", "", "https://url.com", "", DateTime.Now, ""),
                new News("", "USA", "", "https://url.com", "", DateTime.Now, "")
            };
        }
    }
}
