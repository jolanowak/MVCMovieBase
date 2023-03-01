using Microsoft.AspNetCore.Mvc;

namespace MVCMovieBase.Web.Controllers
{
    public class HomeController : Controller
    {
        public HomeController(ILogger<HomeController> logger)
        {
        }

        public IActionResult Index()
        {
            //return RedirectToRoute("/Movie/Index");
            return Redirect("movie");
        }
    }
}