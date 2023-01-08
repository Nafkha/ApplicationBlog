namespace ApplicationBlog.DAL.Entities
{
    public class Categorie
    {
        public int categorieID { get; set; }
       // public string? Url { get; set; }
        public string? Title { get; set; }
        public virtual List<Post>? Posts { get; set; }
    }
}
