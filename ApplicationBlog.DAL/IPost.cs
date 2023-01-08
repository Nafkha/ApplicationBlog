using ApplicationBlog.DAL;
using ApplicationBlog.DAL.Entities;
using ApplicationBlog.UI.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationBlog.DAL
{
    public interface IPost
    {
        Post GetById(int id);
        Reply GetReplyById(int id);
        IEnumerable<Post> GetAll();
        IEnumerable<Post> GetFilteredPosts(int id, string searchQuery);
        IEnumerable<Post> GetPostsByCategory(int categoryId);
        IEnumerable<Post> GetLatestPosts(int nPosts);

        Task Add(Post post);
        Task Delete(Post id);
        Task EditPostContent(int id, string newContent, string newTitle);
        Task AddReply(Reply reply);
        
        Task DeleteReply(Reply reply);
    }
}
