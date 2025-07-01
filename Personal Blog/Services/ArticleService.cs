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

        public ArticleService(ArticleContext articleContext)
        {
            this.articlecontext = articlecontext;
            //this.articlecontext.Database.EnsureCreated();
        }
        public int AddNewArticle(Article article)
        {
            try
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
            catch (Exception ex)
            {
                Console.WriteLine($"Error adding article: {ex.Message}");
                return 0;
            }

        }

        public List<ArticleViewModel> GetArticles()
        {
            try {
                if (articlecontext == null)
                {
                    Console.WriteLine("Database context is full");
                    return new List<ArticleViewModel>();
                }
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
            catch (Exception ex)
            {
                Console.WriteLine($"Error retrieving articles: {ex.Message}");
                return new List<ArticleViewModel>();
            }
        }

        public bool DeleteArticleByID(int id)
        {
            try {
                if (articlecontext == null)
                {
                    Console.WriteLine("Database context is full");
                    return false;

                }
                var article = articlecontext.Articles.Find(id);
                if (article == null) return false;

                articlecontext.Articles.Remove(article);
                return articlecontext.SaveChanges() > 0;

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error deleting articles: {ex.Message}");
                return false;
            }
        }

        public bool EditArticleByID(int id, string heading, DateTime date, string content)
        {
            try {
                if (articlecontext == null)
                {
                    Console.WriteLine("Database context is full");
                    return false;

                }
                var article = articlecontext.Articles.FirstOrDefault(a => a.ID == id);
                if (article == null) return false;

                article.heading = heading;
                article.date = date;
                article.content = content;

                return articlecontext.SaveChanges() > 0;

            }
            catch(Exception ex)
            {
                Console.WriteLine($"Error editing articles: {ex.Message}");
                return false;

            }
        }   
    }
}
