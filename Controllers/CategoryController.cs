using Microsoft.AspNetCore.Mvc;
using MockApi.Services;
using System.Threading.Tasks;

namespace MockApi.Controllers
{
    public class CategoryController : Controller
    {
        private readonly CategoryService _categoryService;

        public CategoryController(CategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        public async Task<IActionResult> Index()
        {
            var categories = await _categoryService.GetAllCategoriesAsync();
            return View(categories);
        }

        public async Task<IActionResult> Details(string id)
        {
            var category = await _categoryService.GetCategoryByIdAsync(id);
            if (category  ==  null)
            {
                return NotFound();
            }
            return View(category);
        }
    }
}