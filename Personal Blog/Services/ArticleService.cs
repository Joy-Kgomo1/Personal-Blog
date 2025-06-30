using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Personal_Blog.Models;
using Personal_Blog.Models.Seeders;
using System.Collections.Generic;


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

        public static List<ArticleViewModel> GetArticles()
        {
            List<ArticleViewModel> articles = new();

            using var connection = new SqliteConnection(connectionString);
            connection.Open();

            string query = "SELECT ID, heading, date, content FROM Article";

            using var cmd = new SqliteCommand(query, connection);
            using var reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                ArticleViewModel article = new()
                {
                    ID = reader.GetInt32(0),
                    heading = reader.GetString(1),
                    date = reader.GetDateTime(2),
                    content = reader.GetString(3)
                };

                articles.Add(article);
            }
            return articles;
        }

        public static bool DeleteArticleByID(int id)
        {
            using var con = new SqliteConnection(connectionString);
            con.Open();

            string qry = "DELETE FROM Articles WHERE Id = @ID";

            using var cmd = new SqliteCommand(qry, con);
            cmd.Parameters.AddWithValue("@ID", id);

            int affectedRows = cmd.ExecuteNonQuery();
            return affectedRows > 0;
           
        }

        public static bool EditArticleByID(int id, string heading, DateTime date, string content)
        {
            using var con = new SqliteConnection(connectionString);
            con.Open();

            string qry = @"UPDATE Articles SET heading = @heading, date = @date, content =@content where ID =@ID ";

            using var cmd = new SqliteCommand(qry, con);
            cmd.Parameters.AddWithValue("@heading", heading);
            cmd.Parameters.AddWithValue("@date", date);
            cmd.Parameters.AddWithValue("@content", content);
            cmd.Parameters.AddWithValue("@ID", id);

            int affectedRows = cmd.ExecuteNonQuery();
            return affectedRows > 0;

        }
    }
}
