namespace ApplicationBlog.UI.Models.Post
{
    public class PostListingModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime? DatePosted { get; set; }
        public string? ImageUrl;
    }
}
