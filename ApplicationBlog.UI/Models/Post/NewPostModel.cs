namespace ApplicationBlog.UI.Models.Post
{
    public class NewPostModel
    {
        public string Category { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public int CategorieId { get; set; }
        public DateTime Created { get; set; }
        public string? image { get; set; }
        public IFormFile ImageUpload { get; set; }
    }
}
