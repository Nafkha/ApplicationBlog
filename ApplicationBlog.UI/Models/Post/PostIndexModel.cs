using ApplicationBlog.UI.Models.Reply;

namespace ApplicationBlog.UI.Models.Post
{
    public class PostIndexModel
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Content { get; set; }
        public IEnumerable<ReplyModel>? replies { get; set; } 
        public ReplyModel? Reply { get; set; } 
        public string? image { get; set; }
    }
}
