using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ApplicationBlog.DAL.Entities
{
    public class Categorie
    {
        [DisplayName("id")]
        public int categorieID { get; set; }
        // public string? Url { get; set; }
        [DisplayName("Title")]
        public string? Title { get; set; }
        public virtual List<Post>? Posts { get; set; }
    }
}
