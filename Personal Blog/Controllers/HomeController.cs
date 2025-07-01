using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Personal_Blog.Models;
using Personal_Blog.Services;

namespace Personal_Blog.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly ArticleContext _context;
    private readonly ArticleService _service;

    public HomeController(ILogger<HomeController> logger, ArticleContext context, ArticleService service)
    {
        _logger = logger;
        _context = context;
        _service = service;
    }

    //default landing page
    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    //Homepage that displays all the articles
    public IActionResult HomePage()
    {
        var articles = _service.GetArticles();
        return View(articles);
    }

    //login form page
    [HttpGet]
    public IActionResult Login()
    {
        return View();
    }

    //Handle login form submission
    [HttpPost]
    public IActionResult Login(LoginViewModel model)
    {
        if (ModelState.IsValid)
        {
            //checks if the data matches
            var user = _context.Users
                .FirstOrDefault(u => u.username == model.username && u.password == model.password);

            if (user != null)
            {
                // TODO: Add session/cookie logic if needed
                return RedirectToAction("Dashboard", "Admin");
            }

            // Show error if login fails
            ViewBag.Message = "Invalid username or password.";
        }

        return View(model);
    }

    //Read a single article by ID
    public IActionResult Read(int id)
    {
        var article = _service.GetArticles().FirstOrDefault(art => art.ID == id);

        if(article==null)
        {
            return NotFound(); // Show 404 if article not found
        }

        return View(article);

    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
