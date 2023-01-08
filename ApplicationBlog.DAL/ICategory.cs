using ApplicationBlog.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationBlog.DAL
{
    public interface ICategory
    {
        Categorie GetById(int id);
        IEnumerable<Categorie> GetAll();

        Task Create(Categorie categorie);
        Task Detlete(Categorie cat);
        Task UpdateCatTitle(int id, string title);

    }
}
