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

        [HttpPost]

        public async Task<IActionResult> AddNews(NewsModel newsModel)
        {
            await _newsAppService.AddNewsAplication(newsModel);
            return Ok("Done");
            
            //adding logic to controler logic
        }
        [HttpDelete]

        public async Task<IActionResult> DeleteComment(int commentId)
        {
            await _newsAppService.DeleteCommentApl(commentId);

            return Ok($"Coomment {commentId} deleted");
        }
        //[HttpPost] 
        //public async Task<IActionResult> AddCommentsToNews(CommentsModel comentsModel)
        //{
            
        //    return Ok("Done adding comments");
        //}


    }
}
