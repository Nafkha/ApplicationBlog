using ApplicationBlog.DAL.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

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
     /*   protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Post>().HasOne(p => p.Categorie).WithMany(p => p.Posts).HasForeignKey(c => c.CatId).OnDelete(DeleteBehavior.Cascade);
                
        }*/

    }
}