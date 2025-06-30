using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Personal_Blog.Models;
using Personal_Blog.Models.Seeders;
using System.Collections.Generic;
using System.Linq;


namespace Personal_Blog.Services
{
    public class ArticleService
    {
        ArticleContext articlecontext;
        private const string connectionString = "Data Source=blogData.db";
        public ArticleService(ArticleContext articleContext)
        {
            this.articlecontext = articlecontext;
            this.articlecontext.Database.EnsureCreated();
        }
        public int AddNewArticle(Article article)
        {
            if (articlecontext == null)
            {
                Console.WriteLine("Database context is full");
                return 0;
            }

            articlecontext.Articles.Add(article);
            articlecontext.SaveChanges();

            return article.ID;

        }

        public List<ArticleViewModel> GetArticles()
        {
            return articlecontext.Articles
                 .Select(article => new ArticleViewModel
                 {
                     ID = article.ID,
                     heading = article.heading,
                     date = article.date,
                     content = article.content
                 })
                 .ToList();

        }

        public bool DeleteArticleByID(int id)
        {
            var article = articlecontext.Articles.Find(id);
            if (article == null) return false;

            articlecontext.Articles.Remove(article);
            return articlecontext.SaveChanges() > 0;

        }

        public bool EditArticleByID(int id, string heading, DateTime date, string content)
        {
            var article = articlecontext.Articles.FirstOrDefault(a => a.ID == id);
            if (article == null) return false;

            article.heading = heading;
            article.date = date;
            article.content = content;

            return articlecontext.SaveChanges() > 0;

        }
    }
}
