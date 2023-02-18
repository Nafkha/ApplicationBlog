using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace ApplicationBlog.UI.Models.Post
{
    public class NewPostModel
    {
        public string Category { get; set; }
        [Required(ErrorMessage ="a title is required")]
        [StringLength(160)]
        public string Title { get; set; }
        [Required(ErrorMessage ="Content is required")]
        public string Content { get; set; }
        public int CategorieId { get; set; }
        public DateTime Created { get; set; }
        public string? image { get; set; }
        [Required(ErrorMessage ="Image is required")]
        public IFormFile ImageUpload { get; set; }
    }
}
