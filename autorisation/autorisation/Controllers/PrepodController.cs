using autorisation.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using autorisation.DAO;
using autorisation.DAL;

namespace autorisation.Controllers
{
    public class PrepodController : Controller
    {

        private readonly DTSContext _context;
        public PrepodController(DTSContext context)
        {
            _context = context;
        }


        [HttpPost]
        [Authorize(Roles = "Prepod")]
        public async Task<IActionResult> Create([Bind("Name,Teacher,The_date_of_the_beginning,End_date,Groups,Subject")] Tests tests)
        {
            if (ModelState.IsValid)
            {
                var Groups = await _context.Groups.FindAsync(tests.id);
                var Teacher = await _context.Teacher.FirstOrDefaultAsync(x =>
                    x.AccountId.ToString() == User.FindFirstValue(ClaimTypes.NameIdentifier));
                if (Groups == null || Groups.Teacher != Teacher.Id || tests.End_date.CompareTo(tests.The_date_of_the_beginning) <= 0)
                {
                    return BadRequest(new { error = "Data is invalid." });
                }
                await _context.AddAsync(tests);
                await _context.SaveChangesAsync();
                return (IActionResult)RedirectToAction("Details", "Groups", new { Name = Groups.Name });
            }
            return (IActionResult)View(tests);
        }
    }
}