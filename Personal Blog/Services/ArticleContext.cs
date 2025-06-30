using Microsoft.EntityFrameworkCore;
using Personal_Blog.Models;
using Personal_Blog.Models.Seeders;

namespace Personal_Blog.Services
{
    public class ArticleContext : DbContext
    {
        public ArticleContext(DbContextOptions options) : base(options)
        {
          // Database.EnsureCreated;
        }

        public DbSet<Article> Articles { get; set; }
        public DbSet<Users> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=blogData.sqlite");
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Users>().HasKey(x => x.ID);
            modelBuilder.ApplyConfiguration(new UserConfirguration());
        }
    }
}
