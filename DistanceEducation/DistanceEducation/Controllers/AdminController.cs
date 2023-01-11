using DistanceEducation.Data;
using Microsoft.AspNetCore.Mvc;

namespace DistanceEducation.Controllers
{
    public class AdminController : Controller
    {
        private readonly DistanceTestDbContext _context;

        public AdminController(DistanceTestDbContext context)
        {
            _context = context;
        }

        public IActionResult MainPageAdmin()
        {
         
            return View();
        }
    }
}
