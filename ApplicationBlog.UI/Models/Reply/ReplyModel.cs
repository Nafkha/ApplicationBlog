namespace ApplicationBlog.UI.Models.Reply
{
    public class ReplyModel
    {
        public int Id { get; set; }
        public int postId { get; set; } 
        public string authorFirstName { get; set; }
        public string authorLastName { get; set; }
        public string authorEmail { get; set; }
        public string replyContent { get; set; }

    }
}
