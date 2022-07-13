using Microsoft.AspNetCore.Mvc;

namespace NewsPortal.Api.Controllers
{
    public class NewsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
