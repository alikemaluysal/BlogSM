using Business.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebMVC.Controllers
{
    public class PostsController : Controller
    {
        IPostService _postService;

        public PostsController(IPostService postService, ICategoryService categoryService)
        {
            _postService = postService;
        }
        public async Task<IActionResult> Detail(int id)
        {
            var post = await _postService.GetByIdAsync(id);
            return View(post.Data);
        }
    }
}
