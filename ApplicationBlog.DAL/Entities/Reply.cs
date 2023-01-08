using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationBlog.DAL.Entities
{
    public class Reply
    {
        public int ReplyId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string ReplyContent { get; set; }
        public int PostId { get; set; }
        public Post Post { get; set; }

    }
}
