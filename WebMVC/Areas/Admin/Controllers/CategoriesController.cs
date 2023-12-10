using Business.Abstract;
using Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebMVC.Areas.Admin.Controllers
{
    //[Authorize(Roles = "Admin")]
    [Area("Admin")]
    public class CategoriesController : Controller
    {
        private readonly ICategoryService _categoryService;

        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public async Task<IActionResult> Index()
        {
            var categories = await _categoryService.GetAllAsync();
            return View(categories.Data.ToList());
        }

        [HttpPost]
        public async Task<IActionResult> Create(Category category)
        {
            var result = await _categoryService.CreateAsync(category);

            if(!result.Success)
            {
                ViewBag.ErrorMessage = result.Message;
            }
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Category category)
        {
            var result = await _categoryService.UpdateAsync(category);

            if (!result.Success)
            {
                ViewBag.ErrorMessage = result.Message;
            }
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> Delete(Category category)
        {
            var result = await _categoryService.DeleteAsync(category);

            if (!result.Success)
            {
                ViewBag.ErrorMessage = result.Message;
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
