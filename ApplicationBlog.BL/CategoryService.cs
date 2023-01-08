using ApplicationBlog.DAL;
using ApplicationBlog.DAL.Entities;
using ApplicationBlog.UI.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationBlog.BL
{
    public class CategoryService : ICategory
    {
        private readonly ApplicationDbContext _context;

        public CategoryService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task Create(Categorie categorie)
        {
            _context.Add(categorie);
            await _context.SaveChangesAsync();  
        }

        public async Task Detlete(Categorie cat)
        {
            _context.Remove(cat);
            await _context.SaveChangesAsync(); 
        }

        public IEnumerable<Categorie> GetAll()
        {
            return _context.categories.Include(c => c.Posts);
        }

        public Categorie GetById(int id)
        {
            var categorie = _context.categories.Where(c => c.categorieID == id).Include(c=>c.Posts).First();
            return categorie;
        }

        public async Task UpdateCatTitle(int id, string title)
        {
            var cat = GetById(id);
            cat.Title = title;
            _context.Update(cat);
            await _context.SaveChangesAsync();
            
        }
    }
}
