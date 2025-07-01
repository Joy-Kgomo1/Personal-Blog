using Microsoft.EntityFrameworkCore;
using Personal_Blog.Models;
using Personal_Blog.Models.Seeders;

namespace Personal_Blog.Services
{
    public class ArticleContext : DbContext
    {
        public ArticleContext(DbContextOptions options) : base(options)
        {
          
        }

        //Articles table in the database
        public DbSet<Article> Articles { get; set; }

        //Users table in the database
        public DbSet<Users> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=blogData.sqlite");
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // Set primary key for Users entity 
            modelBuilder.Entity<Users>().HasKey(x => x.ID);
            // Apply seeder classes
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new ArticleConfiguration());
        }
    }
}
