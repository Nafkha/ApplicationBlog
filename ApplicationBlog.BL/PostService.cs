using ApplicationBlog.DAL;
using ApplicationBlog.DAL.Entities;
using ApplicationBlog.UI.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationBlog.BL
{
    public class PostService : IPost
    {
        public readonly ApplicationDbContext _context;

        public PostService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task Add(Post post)
        {
            _context.Add(post);
            await _context.SaveChangesAsync();
        }

        public async Task AddReply(Reply reply)
        {
            
            _context.Add(reply);   
           await _context.SaveChangesAsync();
        }

        public async Task Delete(Post post)
        {
            _context.Remove(post);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteReply(Reply reply)
        {
            _context.Remove(reply);
            await _context.SaveChangesAsync();
        }

        public async Task EditPostContent(int id, string newContent, string newTitle)
        {
            Post p = _context.posts.Where(post=>post.postId== id).FirstOrDefault();
            p.Title = newTitle;
            p.Content = newContent;
            p.postId = id;
            _context.Update(p);
            await _context.SaveChangesAsync();
        }

        public IEnumerable<Post> GetAll()
        {
            return _context.posts;
        }

        public Post GetById(int id)
        {
            Post p = _context.posts.Where(post=>post.postId == id).Include(post => post.replies).FirstOrDefault();
            
            return p;
        }

        public IEnumerable<Post> GetFilteredPosts(int id, string searchQuery)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Post> GetLatestPosts(int nPosts)
        {
            return GetAll().OrderByDescending(post => post.Created).Take(nPosts);
        }

        public IEnumerable<Post> GetPostsByCategory(int categoryId)
        {
            throw new NotImplementedException();
        }

        public Reply GetReplyById(int id)
        {
            return _context.replies.Where(reply => reply.ReplyId == id).FirstOrDefault();
        }
    }
}
