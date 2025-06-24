using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Personal_Blog.Models.Seeders
{
    public class UserConfirguration : IEntityTypeConfiguration<Users>
    {
        public void Configure(EntityTypeBuilder<Users> builder)
        {
            builder.HasKey(b => b.ID);
            builder.HasData(

                new Users
                {
                    ID = 1,
                    username = "Admin",
                    password = "AdminPassword123"
                }
                );
        }

    }
}
