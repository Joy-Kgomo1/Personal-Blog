using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Personal_Blog.Models.Seeders
{
    public class ArticleConfiguration : IEntityTypeConfiguration<Article>
    {
        public void Configure(EntityTypeBuilder<Article> builder)
        {
            builder.HasKey(b => b.ID);
            builder.HasData(

                new Article
                {
                    ID = 1,
                    heading = "The Rise of AI in Everyday Life",
                    date = new DateTime(2025, 07, 01),
                    content = @"Artificial Intelligence (AI) has become an integral part of our daily lives. 
From personalized recommendations on streaming platforms to voice assistants in our homes, 
AI is transforming the way we live, work, and interact with technology.

The healthcare sector is leveraging AI to improve diagnostics and treatment planning, 
while industries like finance and retail are using it to predict trends and optimize operations.

As the technology continues to evolve, it is crucial to ensure responsible and ethical use of AI 
to maximize benefits while minimizing risks."
                }

                );
        }
    }
}
