using DistanceEducation.Data;
using DistanceEducation.Models;
using Microsoft.AspNetCore.Mvc;

namespace DistanceEducation.Controllers
{
    public class AccountController : Controller
    {
        private readonly DistanceTestDbContext _context;

        public AccountController(DistanceTestDbContext context)
        {
            _context = context;
        }

        public IActionResult Login([Bind("Email,Password")] ForLogin forLogin)
        {
            if (_context.students.Any(a => a.Password == forLogin.Password && a.Email == forLogin.Email))
            {
                int id = _context.students.Where(a => a.Password == forLogin.Password && a.Email == forLogin.Email).Select(a => a.Id).FirstOrDefault();
                Response.Cookies.Append("userId", id.ToString());
                return RedirectToAction("MainPageStudent", "Student", new { id = id });
            }
            else if (_context.teachers.Any(a => a.Password == forLogin.Password && a.Email == forLogin.Email))
            {
                int id = _context.teachers.Where(a => a.Password == forLogin.Password && a.Email == forLogin.Email).Select(a => a.Id).FirstOrDefault();
                Response.Cookies.Append("userId", id.ToString());
                return RedirectToAction("MainPageTeacher", "Teacher", new { id = id });
            }
            else if (_context.admins.Any(a => a.Password == forLogin.Password && a.Email == forLogin.Email))
            {
                int id = _context.admins.Where(a => a.Password == forLogin.Password && a.Email == forLogin.Email).Select(a => a.Id).FirstOrDefault();
                Response.Cookies.Append("userId", id.ToString());
                return RedirectToAction("MainPageAdmin", "Admin", new { id = id });
            }
            return View();
        }

        public IActionResult Logout()
        {
            Response.Cookies.Delete("userId");
            return RedirectToAction("Index", "Home");
        }
    }
}
