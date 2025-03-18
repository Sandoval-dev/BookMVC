using BookMVC.Context;
using BookMVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace BookMVC.Controllers
{
    public class UsersController : Controller
    {
        private readonly BookDbContext _context;

        public UsersController(BookDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var users = _context.Users.ToList();
            return View(users);
        }

        
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(User user)
        {
            if(user.Name==null || user.Email==null || user.Surname==null || user.Phone == null)
            {
                return View(user);
            }
            _context.Users.Add(user);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult GetUsers()
        {
            var users = _context.Users.ToList();
            return Json(new { status = true, data = users });
        }

        public IActionResult Update(int userId)
        {
            var user = _context.Users.Find(userId);
            return View(user);
        }

        [HttpPost]
        public IActionResult Update(User model)
        {
            if (ModelState.IsValid)
            {
                var dUser = _context.Users.Find(model.Id);
                dUser.Name = model.Name;
                dUser.Surname = model.Surname;
                dUser.Phone = model.Phone;
                dUser.Email = model.Email;
                _context.Users.Update(dUser);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return View(model);
            }


        }

        public IActionResult GetUsersCount()
        {
            var user = _context.Users.ToList().Count;
            return Json(new { status=true, data=user});
        }


    }
}
