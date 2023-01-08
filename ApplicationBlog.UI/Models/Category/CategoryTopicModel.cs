using ApplicationBlog.UI.Models.Post;

namespace ApplicationBlog.UI.Models.Category
{
    public class CategoryTopicModel
    {
        public CategoryListingModel Category { get; set; }
        public IEnumerable<PostListingModel> Posts { get; set; }
    }
}
