using Microsoft.AspNetCore.Mvc;
using NewsPortal.Application;
using NLog;
namespace NewsPortal.Api.Controllers
{
    [ApiController]
    [Route("api/news")]

    public class NewsController : ControllerBase
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();
        private readonly INewsAppService _newsAppService;

        public NewsController(INewsAppService newsAppService)
        {
            _newsAppService = newsAppService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] NewsFilter newsFilter)
        {
            try
            {
                ICollection<NewsModel> news = await _newsAppService.GetAllNews(newsFilter);

                return Ok(news);
            }
            catch (ApplicationException ex)
            {
                logger.Error(ex);
                return BadRequest(ex.Message);

            }
            catch (Exception ex)
            {
                logger.Error(ex);
                return BadRequest("something wrong");

            }

}

        [HttpPost]
        public async Task<IActionResult> AddNews(NewsModel newsModel)
        {
            try
            {
                await _newsAppService.AddNewsAplication(newsModel);

                return Ok("Done");
            }
            catch (ApplicationException ex)
            {
                logger.Error(ex);
                return BadRequest(ex.Message);

            }
            catch (Exception ex)
            {
                logger.Error(ex);
                return BadRequest("something wrong");

            }
        }
        [HttpPost]
        [Route("comment")]
        public async Task<IActionResult> AddCommentsToNews(CommentsModel comentsModel, Guid newsId)
        {
            try
            {
                await _newsAppService.AddCommentApl(comentsModel, newsId);

                return Ok("Done adding comments");
            }
            catch (ApplicationException ex)
            {
                logger.Error(ex);
                return BadRequest(ex.Message);

            }
            catch (Exception ex)
            {
                logger.Error(ex);
                return BadRequest("something wrong");

            }
        }

        [HttpDelete]

        public async Task<IActionResult> DeleteComment(Guid commentId, Guid newsId)
        {
            try
            {
                await _newsAppService.DeleteCommentApl(commentId, newsId);

                return Ok($"Coomment {commentId} deleted");
            }
             catch (ApplicationException ex)
            {
                logger.Error(ex);
                return BadRequest(ex.Message);

            }
            catch (Exception ex)
            {
                logger.Error(ex);
                logger.Debug("you are bad programer");
                return BadRequest("something wrong");

            }
        }


    }
}
