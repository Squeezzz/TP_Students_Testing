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
    public class AdminDisciplinesController : Controller
    {
        private readonly DistanceTestDbContext _context;

        public AdminDisciplinesController(DistanceTestDbContext context)
        {
            _context = context;
        }

        // GET: AdminDisciplines
        public async Task<IActionResult> Index()
        {
            //Данный userIdToIndex будет служить временными данными для дальнейшей возможности перейти с Index обратно на главную страницу Админа
            TempData["userIdToIndex"] = Convert.ToInt32(Request.Cookies["userId"]);
            return View(await _context.disciplines.ToListAsync());
        }

        // GET: AdminDisciplines/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.disciplines == null)
            {
                return NotFound();
            }

            var discipline = await _context.disciplines
                .FirstOrDefaultAsync(m => m.Id == id);
            if (discipline == null)
            {
                return NotFound();
            }

            return View(discipline);
        }

        // GET: AdminDisciplines/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: AdminDisciplines/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,DisciplineName")] Discipline discipline)
        {

                _context.Add(discipline);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));

        }

        // GET: AdminDisciplines/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.disciplines == null)
            {
                return NotFound();
            }

            var discipline = await _context.disciplines.FindAsync(id);
            if (discipline == null)
            {
                return NotFound();
            }
            return View(discipline);
        }

        // POST: AdminDisciplines/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,DisciplineName")] Discipline discipline)
        {
            if (id != discipline.Id)
            {
                return NotFound();
            }

                try
                {
                    _context.Update(discipline);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DisciplineExists(discipline.Id))
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

        // GET: AdminDisciplines/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.disciplines == null)
            {
                return NotFound();
            }

            var discipline = await _context.disciplines
                .FirstOrDefaultAsync(m => m.Id == id);
            if (discipline == null)
            {
                return NotFound();
            }

            return View(discipline);
        }

        // POST: AdminDisciplines/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.disciplines == null)
            {
                return Problem("Entity set 'DistanceTestDbContext.disciplines'  is null.");
            }
            var discipline = await _context.disciplines.FindAsync(id);
            if (discipline != null)
            {
                _context.disciplines.Remove(discipline);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DisciplineExists(int id)
        {
          return _context.disciplines.Any(e => e.Id == id);
        }
    }
}
