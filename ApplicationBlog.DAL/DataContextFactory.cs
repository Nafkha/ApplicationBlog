using ApplicationBlog.DAL;
using ApplicationBlog.UI.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationBlog.DAL
{
    public class DataContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>

    {
        public ApplicationDbContext CreateDbContext(string[] args)
        {
            var optionBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
            optionBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=ApplicationBlog;Trusted_Connection=True;MultipleActiveResultSets=true");
            return new ApplicationDbContext(optionBuilder.Options);
        }
    }
}
