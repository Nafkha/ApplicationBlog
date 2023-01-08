using ApplicationBlog.UI.Models.Post;

namespace ApplicationBlog.UI.Models.Home
{
    public class HomeIndexModel
    {
        public IEnumerable<PostListingModel> LatestPosts { get; set; }
    }
}
