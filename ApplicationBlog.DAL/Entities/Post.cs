namespace ApplicationBlog.DAL.Entities
{
    public class Post
    {
        public int postId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime? Created { get; set; }
        public string postImage { get; set; }
        public int CatId { get; set; }
        public Categorie Categorie { get; set; }
        public IEnumerable<Reply>? replies { get; set; }
    }
}
