using Business.Abstract;
using Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Security.Claims;
using WebMVC.Areas.Admin.Models;

namespace WebMVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class PostsController : Controller
    {
        IPostService _postService;
        ICategoryService _categoryService;

        public PostsController(IPostService postService, ICategoryService categoryService)
        {
            _postService = postService;
            _categoryService = categoryService;
        }

        public async Task<IActionResult> Index()
        {
            string role = HttpContext.User.FindFirst(ClaimTypes.Role).Value;
            int userId = int.Parse(HttpContext.User.FindFirst(ClaimTypes.Sid).Value);

            var result = await _postService.GetByRoleAsync(role, userId);

            return View(result.Data);
        }

        public async Task<IActionResult> Create()
        {
            var result = await _categoryService.GetAllAsync();
            var categories = result.Data;
            ViewBag.Categories = new SelectList(categories, "Id", "Name");



            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(PostCreateModel model)
        {
            if(ModelState.IsValid)
            {
                Post post = new Post();
                post.Title = model.Title;
                post.Content = model.Content;
                post.CategoryId = model.CategoryId;

                post.UserId = int.Parse(HttpContext.User.FindFirst(ClaimTypes.Sid).Value);

                await _postService.CreateAsync(post);
                return RedirectToAction("Index");
            }

            var categories = (await _categoryService.GetAllAsync()).Data;
            ViewBag.Categories = new SelectList(categories, "Id", "Name");

            return View(model);
        }
    }
}
