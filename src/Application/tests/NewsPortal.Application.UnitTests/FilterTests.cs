
using NewsPortal.Domain;

namespace NewsPortal.Application.UnitTests
    {
    [TestClass]
    public class FilterTests
    {
        [TestClass]
        public class FilterTest
        {

            [TestMethod]
            public async Task IsRightCountryAsync()
            {
                NewsFilter newsFilter = new NewsFilter();
                newsFilter.Country = Domain.Country.CZH;
                newsFilter.Important = true;
                NewsRepositoryFake fakeRep = new NewsRepositoryFake();

                NewsAppService newsAppService = new NewsAppService(fakeRep);

                ICollection<NewsModel> result = await newsAppService.GetAllNews(newsFilter);
                Assert.IsTrue(result.Where(n => n.IsImportant).Count() == 1);
            }

        }

    }
}