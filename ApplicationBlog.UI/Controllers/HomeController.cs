using ApplicationBlog.DAL;
using ApplicationBlog.UI.Models;
using ApplicationBlog.UI.Models.Home;
using ApplicationBlog.UI.Models.Post;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace ApplicationBlog.UI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IPost _postService;

        public HomeController(ILogger<HomeController> logger, IPost postService)
        {
            _logger = logger;
            _postService = postService;
        }

        public IActionResult Index()
        {
            var model = BuildHomeIndexModel();
            return View(model);
        }

        private HomeIndexModel BuildHomeIndexModel()
        {
            var latestPosts = _postService.GetLatestPosts(10);
            var posts = latestPosts.Select(post => new PostListingModel
            {
                Id = post.postId,
                Title = post.Title,
                DatePosted= post.Created,
                ImageUrl = post.postImage,
                category = post.Categorie.Title

            });
            return new HomeIndexModel
            {
                LatestPosts = posts
            };
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}