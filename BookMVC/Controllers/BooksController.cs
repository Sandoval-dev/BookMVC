using BookMVC.Context;
using BookMVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace BookMVC.Controllers
{
    public class BooksController : Controller
    {
        private readonly BookDbContext _context;

        public BooksController(BookDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var books = _context.Books.ToList();
            var category= _context.Categories.ToList();
            return View(books);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Book model)
        {
            var book=_context.Books.Add(model);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult GetBooks()
        {
            var books=_context.Books.ToList();
            return Json(new { status = true, data = books });
        }

        public IActionResult Update(int bookId)
        {
            var book = _context.Books.Find(bookId);
            if (book == null)
            {
                return NotFound();
            }

            book.Kategori = _context.Categories.Where(x => x.Id == book.CategoryId).FirstOrDefault();
            if (book.Kategori == null)
            {
                return NotFound();
            }

            var bookCategory = book.Kategori.MainCategory;
            var category = _context.Categories.Where(x => x.Id == bookCategory).FirstOrDefault();
            if (category == null)
            {
                return NotFound();
            }

            ViewBag.Kategori = category.Id;
            ViewBag.SubCategory = book.CategoryId;
            return View(book);
        }


        [HttpPost]
        public IActionResult Update(Book model) 
        {
            var dBook = _context.Books.Find(model.Id);
            dBook.Author = model.Author;
            dBook.Title=model.Title;
            dBook.Stock = model.Stock;
            dBook.CategoryId = model.CategoryId;

            _context.Books.Update(dBook);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
