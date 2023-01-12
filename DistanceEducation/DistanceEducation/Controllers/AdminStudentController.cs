using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DistanceEducation.Data;
using DistanceEducation.Models;

namespace DistanceEducation.Controllers
{
    public class AdminStudentController : Controller
    {
        private readonly DistanceTestDbContext _context;

        public AdminStudentController(DistanceTestDbContext context)
        {
            _context = context;
        }

        // GET: AdminStudent
        public async Task<IActionResult> Index()
        {
            var distanceTestDbContext = _context.students.Include(s => s.group);
            //Данный userIdToIndex будет служить временными данными для дальнейшей возможности перейти с Index обратно на главную страницу Админа
            TempData["userIdToIndex"] = Convert.ToInt32(Request.Cookies["userId"]);
            return View(await distanceTestDbContext.ToListAsync());
        }

        // GET: AdminStudent/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.students == null)
            {
                return NotFound();
            }

            var student = await _context.students
                .Include(s => s.group)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (student == null)
            {
                return NotFound();
            }

            return View(student);
        }

        // GET: AdminStudent/Create
        public IActionResult Create()
        {
            ViewData["GroupId"] = new SelectList(_context.groups, "Id", "GroupName");
            return View();
        }

        // POST: AdminStudent/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Surname,Patronymic,Email,Password,GroupId")] Student student)
        {

                _context.Add(student);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
        }

        // GET: AdminStudent/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.students == null)
            {
                return NotFound();
            }

            var student = await _context.students.FindAsync(id);
            if (student == null)
            {
                return NotFound();
            }
            ViewData["GroupId"] = new SelectList(_context.groups, "Id", "GroupName", student.GroupId);
            return View(student);
        }

        // POST: AdminStudent/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Surname,Patronymic,Email,Password,GroupId")] Student student)
        {
            if (id != student.Id)
            {
                return NotFound();
            }


                try
                {
                    _context.Update(student);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StudentExists(student.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
        }

        // GET: AdminStudent/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.students == null)
            {
                return NotFound();
            }

            var student = await _context.students
                .Include(s => s.group)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (student == null)
            {
                return NotFound();
            }

            return View(student);
        }

        // POST: AdminStudent/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.students == null)
            {
                return Problem("Entity set 'DistanceTestDbContext.students'  is null.");
            }
            var student = await _context.students.FindAsync(id);
            if (student != null)
            {
                _context.students.Remove(student);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StudentExists(int id)
        {
          return _context.students.Any(e => e.Id == id);
        }
    }
}
