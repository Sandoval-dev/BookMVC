using BookMVC.Context;
using BookMVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace BookMVC.Controllers
{
    public class CategoriesController : Controller
    {
        private readonly BookDbContext _context;

        public CategoriesController(BookDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var categories = _context.Categories.ToList();
            return View(categories);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Category category)
        {
            _context.Categories.Add(category);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult GetMainCategory()
        {
            var mainCategories = _context.Categories.Where(x => x.MainCategory == 0).ToList();
            return Json(new { status=true,data=mainCategories});
        }

        public IActionResult GetSubCategory(int mainCategoryId)
        {
            var subCategory = _context.Categories.Where(x => x.MainCategory == mainCategoryId).ToList();
            return Json(new { status = true, data = subCategory });
        }
    }
}
