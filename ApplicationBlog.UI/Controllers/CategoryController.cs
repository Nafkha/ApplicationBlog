using ApplicationBlog.DAL;
using ApplicationBlog.DAL.Entities;
using ApplicationBlog.UI.Models.Category;
using ApplicationBlog.UI.Models.Post;
using Microsoft.AspNetCore.Mvc;

namespace ApplicationBlog.UI.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategory _categoryService;
       // private readonly IPost _postSerice;

        public CategoryController(ICategory categoryService)
        {
            _categoryService = categoryService;
          //  _postSerice = postSerice;
        }
        public IActionResult Index() {
            var categories = _categoryService.GetAll().Select(category => new CategoryListingModel
            {
                Id = category.categorieID,
                Name = category.Title,
                posts = category.Posts.Count

            });
            var model = new CategoryIndexModel
            {
                CategoryList= categories
            };
            return View(model);
        }
        public IActionResult Topic(int id) {
            var category = _categoryService.GetById(id);
            var posts = new List<Post>();
            posts = category.Posts.ToList();

            var postListing = posts.Select(post => new PostListingModel
            {
                Id = post.postId,
                Title = post.Title,
                DatePosted = post.Created,
                ImageUrl = post.postImage

            }) ;

            var model = new CategoryTopicModel
            {
                Category = BuildCatListing(category),
                Posts = postListing
        };
            return View(model);

        }
        

        private CategoryListingModel BuildCatListing(Categorie category)
        {
            return new CategoryListingModel
            {
                Id = category.categorieID,
                Name= category.Title
            };
        }

        [HttpPost]
        public async Task<IActionResult> AddCat(NewCategoryModel model)
        {
            var category = BuildCategory(model);

            _categoryService.Create(category).Wait();

            return RedirectToAction("Index","Category");
        }

        private Categorie BuildCategory(NewCategoryModel model)
        {
            return new Categorie
            {
                Title = model.Title,
            };
            
        }

        public IActionResult Update(int id)
        {
            var category = _categoryService.GetById(id);
            var model = new CategoryListingModel
            {
               Id = id,
               Name = category.Title

            };



            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateCategory(CategoryListingModel model)
        {
            _categoryService.UpdateCatTitle(model.Id, model.Name).Wait();
   
              return RedirectToAction("Index", "Category");
        }


    [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            Categorie cat = _categoryService.GetById(id);
            _categoryService.Detlete(cat).Wait();

            return RedirectToAction("Index", "Category");
        }
        public IActionResult Create()
        {
            return View();
        }
    }
    }

