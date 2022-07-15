using Microsoft.AspNetCore.Mvc;
using NewsPortal.Application;

namespace NewsPortal.Api.Controllers
{
    [ApiController]
    [Route("api/news")]
    public class NewsController : ControllerBase
    {
        private readonly INewsAppService _newsAppService;

        public NewsController(INewsAppService newsAppService)
        {
            _newsAppService = newsAppService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] NewsFilter newsFilter)
        {
            ICollection<NewsModel> news = await _newsAppService.GetAllNews(newsFilter);

            return Ok(news);
        }
    }
}
