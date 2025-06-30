using Microsoft.AspNetCore.Mvc;

namespace Personal_Blog.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
