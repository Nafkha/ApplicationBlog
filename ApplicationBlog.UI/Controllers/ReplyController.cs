using ApplicationBlog.BL;
using ApplicationBlog.DAL;
using ApplicationBlog.DAL.Entities;
using ApplicationBlog.UI.Models.Post;
using ApplicationBlog.UI.Models.Reply;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;

namespace ApplicationBlog.UI.Controllers
{
    public class ReplyController : Controller
    {
        private readonly IPost _postService;

        public ReplyController(IPost postService)
        {
            _postService = postService;
        }

        public IActionResult Create(int id)
        {
            var post =_postService.GetById(id);
            var model = new ReplyModel
            {
                postId= id

            };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> AddReply(ReplyModel model)
        {
            var reply = BuildReply(model);
            await _postService.AddReply(reply);
            return RedirectToAction("Index", "Post", new { id = reply.PostId });


        }

        private Reply BuildReply(ReplyModel model)
        {
            var post = _postService.GetById(model.postId);
            return new Reply
            {
                Post = post,
                ReplyContent = model.replyContent,
                FirstName = model.authorFirstName,
                LastName = model.authorLastName,
                Email = model.authorEmail
            };

        }
    }
}
