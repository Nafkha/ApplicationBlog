using ApplicationBlog.DAL;
using ApplicationBlog.DAL.Entities;
using ApplicationBlog.UI.Models.Category;
using ApplicationBlog.UI.Models.Post;
using ApplicationBlog.UI.Models.Reply;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Net.Http.Headers;
using System.ComponentModel;

namespace ApplicationBlog.UI.Controllers
{
    public class PostController : Controller
    {
        public readonly IPost _postService;
        public readonly ICategory _categoryService;
        private readonly IConfiguration _configuration;
        private readonly IUpload _uploadService;
        public PostController(IPost postService, ICategory categoryService, IConfiguration configuration, IUpload uploadservice)
        {
            _postService = postService;
            _categoryService = categoryService;
            _configuration = configuration;
            _uploadService = uploadservice;
        }

        public IActionResult Update(int id)
        {
            var post = _postService.GetById(id);
            var model = new PostIndexModel
            {
                Title = post.Title,
                Content = post.Content
            };

            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> UpdatePost(PostIndexModel model)
        {
            _postService.EditPostContent(model.Id, model.Content, model.Title).Wait();
            return RedirectToAction("Index", "Post", new { id = model.Id });

        }


        public IActionResult Create(int id)
        {
            var category = _categoryService.GetById(id);
            var model = new NewPostModel
            {
                CategorieId = category.categorieID,
                Category = category.Title,
                


            };
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> AddPost(NewPostModel model)
        {
            

            var connectionString = _configuration.GetConnectionString("AzureStorageAccount");

            // Get Blob Container
            var container = _uploadService.GetBlobContainer(connectionString);

            // Parse the content diposition response header

            var contentDisposition = ContentDispositionHeaderValue.Parse(model.ImageUpload.ContentDisposition);

            // Grab the filename

            var filename = contentDisposition.FileName.ToString().Trim('"');


            //Get a reference to a block blob

            var blockBlob = container.GetBlockBlobReference(filename);


            // On that block blob, Upload our file

            await blockBlob.UploadFromStreamAsync(model.ImageUpload.OpenReadStream());
            var post = BuildPost(model,blockBlob.Uri.ToString());




            _postService.Add(post).Wait();
            return RedirectToAction("Index","Post",new {id = post.postId});

        }

        private Post BuildPost(NewPostModel model,string image)
        {
            var category = _categoryService.GetById(model.CategorieId);
            return new Post
            {
                Title = model.Title,
                Content = model.Content,
                Created = DateTime.Now,
                Categorie = category,
                CatId = category.categorieID,
                postImage = image        };
        }

        public IActionResult Index(int id)
        {
            var post = _postService.GetById(id);

            var reps = BuildPostReplies(post.replies);
            var model = new PostIndexModel
            {
                Id = id,
                Title = post.Title,
                Content = post.Content,
                replies = reps,
                image = post.postImage
            };

            return View(model);
        }

        private IEnumerable<ReplyModel> BuildPostReplies(IEnumerable<Reply>? replies)
        {
            return replies.Select(r => new ReplyModel
            {
                Id = r.ReplyId,
                postId= r.PostId,
                authorFirstName = r.FirstName, authorLastName = r.LastName, authorEmail=r.Email, replyContent = r.ReplyContent
            });
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var post = _postService.GetById(id);
            _postService.Delete(post).Wait();
            
            return RedirectToAction("Index","Category");
        }

        [HttpPost]
        public async Task<IActionResult> DeleteReply(int id)
        {
            var reply = _postService.GetReplyById(id);
            var postId = reply.PostId;
            _postService.DeleteReply(reply).Wait();
            return RedirectToAction("Index", "Post",new {id = postId});
        }

       
    }
}
