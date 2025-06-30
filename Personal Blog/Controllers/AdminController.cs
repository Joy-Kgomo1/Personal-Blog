using Microsoft.AspNetCore.Mvc;
using Personal_Blog.Models;
using Personal_Blog.Services;

namespace Personal_Blog.Controllers
{
    public class AdminController : Controller
    {
        private readonly ArticleService _service;
        public AdminController(ArticleService service)
        {
            _service = service;
            
        }
        public IActionResult Dashboard()
        {
            var articles = _service.GetArticles();
            return View(articles);
        }

        public IActionResult Add()
        {
            return View();
        }

        public IActionResult Add(Article article)
        {
            if (ModelState.IsValid)
            {
                _service.AddNewArticle(article);
                return RedirectToAction("Dashboard");
            }
            return View(article);
        }

        public IActionResult Edit(int id)
        {
            var article = _service.GetArticles().FirstOrDefault(art => art.ID == id);

            if(article == null)
            {
                return NotFound();
            }
            var model = new Article
            {
                ID = article.ID,
                heading = article.heading,
                date = article.date,
                content = article.content
            };
            return View(model);
        }

        public IActionResult Edit(Article updatedArticle)
        {
            if (ModelState.IsValid)
            {
                bool updated = _service.EditArticleByID(
                    updatedArticle.ID,
                    updatedArticle.heading,
                    updatedArticle.date,
                    updatedArticle.content
                    );

                if (updated)
                {
                    return RedirectToAction("Dashboard");
                }
               
            }
            return View(updatedArticle);
        }

        public IActionResult Delete(int id)
        {
            bool deleted = _service.DeleteArticleByID(id);
            return RedirectToAction("Dashboard");
        }
        
    }
}
