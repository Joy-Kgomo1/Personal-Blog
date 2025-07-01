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
        //Diplays the dashboard with the list of articles
        public IActionResult Dashboard()
        {
            var articles = _service.GetArticles();
            return View(articles);
        }

        //Displays the form to add the article
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        //Submit the form to add a new article to the database
        [HttpPost]
        public IActionResult Add(Article article)
        {
            if (ModelState.IsValid)
            {
                _service.AddNewArticle(article);
                return RedirectToAction("Dashboard");
            }
            //form returned with vadidation messaes
            return View(article);
        }

        //displays the edit form for an existing article
        [HttpGet]
        public IActionResult Edit(int id)
        {
            //get the article by ID
            var article = _service.GetArticles().FirstOrDefault(art => art.ID == id);

            if(article == null)
            {
                return NotFound();//return 404 if article not found
            }
            var model = new Article
            {
                // Map to Article model
                ID = article.ID,
                heading = article.heading,
                date = article.date,
                content = article.content
            };
            return View(model);
        }

        //Saves the edited article
        [HttpPost]
        public IActionResult Edit(Article updatedArticle)
        {
            if (ModelState.IsValid)
            {
                // Update the article using the service
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
            // Return the form again if update failed or model was invalid
            return View(updatedArticle);
        }

        //deletes article by ID
        [HttpGet]
        public IActionResult Delete(int id)
        {
            bool deleted = _service.DeleteArticleByID(id);
            return RedirectToAction("Dashboard");
        }
        
    }
}
