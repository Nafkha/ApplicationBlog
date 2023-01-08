using ApplicationBlog.DAL.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ApplicationBlog.UI.Data
{
    public class ApplicationDbContext : IdentityDbContext<User>
    {
       
       public DbSet<Categorie>? categories { get; set; }
        public DbSet<Post> posts { get; set; }

        public DbSet<Reply> replies { get; set; }
        public override DbSet<User> Users { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
           : base(options)
        {
        }

    }
}