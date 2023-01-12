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
    public class AdminGroupsController : Controller
    {
        private readonly DistanceTestDbContext _context;

        public AdminGroupsController(DistanceTestDbContext context)
        {
            _context = context;
        }

        // GET: AdminGroups
        public async Task<IActionResult> Index()
        {
            //Получение списка дисциплин у которые преподает данный преподаватель
            /*List<int> disId = new List<int>();
            disId = _context.disciplineGroups.Where(a => a.GroupsId == 1).Select(a => a.DisciplineId).ToList();
            List<Models.Discipline> disciplines = new List<Models.Discipline>();
            foreach (var item in disId)
            {
                disciplines.Add(_context.disciplines.Where(a => a.Id == item).FirstOrDefault());
            }*/
            //ViewData["Discipline"] = disciplines;
            ViewData["Discipline"] = _context.disciplines.ToList();
            ViewData["DisciplineGroup"] = _context.disciplineGroups.ToList();
            //Данный userIdToIndex будет служить временными данными для дальнейшей возможности перейти с Index обратно на главную страницу Админа
            TempData["userIdToIndex"] = Convert.ToInt32(Request.Cookies["userId"]);

            return View(await _context.groups.ToListAsync());
        }

        public IActionResult AddDiscipline(int Id)
        {
            //Получение списка дисциплин
            List<int> disId = new List<int>();
            disId = _context.disciplines.Select(a => a.Id).ToList();
            List<Models.Discipline> disciplines = new List<Models.Discipline>();
            foreach (var item in disId)
            {
                if (_context.disciplines.Where(a => a.Id == item &&
                a.Id != _context.disciplineGroups.Where(a => a.GroupsId == Id && a.DisciplineId == item).Select(a => a.DisciplineId).FirstOrDefault()).FirstOrDefault() != null)
                    disciplines.Add(_context.disciplines.Where(a => a.Id == item &&
                    a.Id != _context.disciplineGroups.Where(a => a.GroupsId == Id && a.DisciplineId == item).Select(a => a.DisciplineId).FirstOrDefault()).FirstOrDefault());
            }
            ViewData["Discipline"] = disciplines;

            TempData["GroupId"] = Id;

            return View();
        }

        public IActionResult DeleteDiscipline(int Id)
        {
            //Получение списка дисциплин которые преподает данный преподаватель
            List<int> disId = new List<int>();
            disId = _context.disciplineGroups.Where(a => a.GroupsId == Id).Select(a => a.DisciplineId).ToList();
            List<Models.Discipline> disciplines = new List<Models.Discipline>();
            foreach (var item in disId)
            {
                disciplines.Add(_context.disciplines.Where(a => a.Id == item).FirstOrDefault());
            }
            ViewData["Discipline"] = disciplines;
            TempData["GroupId"] = Id;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> DeleteDiscipline([Bind("DisciplineId")] DisciplineGroup disciplineGroup)
        {
            disciplineGroup.GroupsId = Convert.ToInt32(TempData["GroupId"]);

            _context.disciplineGroups.Remove(disciplineGroup);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> AddDiscipline([Bind("DisciplineId")] DisciplineGroup disciplineGroup)
        {
            disciplineGroup.GroupsId = Convert.ToInt32(TempData["GroupId"]);

            _context.disciplineGroups.Add(disciplineGroup);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }

        // GET: AdminGroups/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.groups == null)
            {
                return NotFound();
            }

            var @group = await _context.groups
                .FirstOrDefaultAsync(m => m.Id == id);
            if (@group == null)
            {
                return NotFound();
            }

            return View(@group);
        }

        // GET: AdminGroups/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: AdminGroups/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,GroupName")] Group @group)
        {
                _context.Add(@group);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
        }

        // GET: AdminGroups/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.groups == null)
            {
                return NotFound();
            }

            var @group = await _context.groups.FindAsync(id);
            if (@group == null)
            {
                return NotFound();
            }
            return View(@group);
        }

        // POST: AdminGroups/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,GroupName")] Group @group)
        {
            if (id != @group.Id)
            {
                return NotFound();
            }

                try
                {
                    _context.Update(@group);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GroupExists(@group.Id))
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

        // GET: AdminGroups/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.groups == null)
            {
                return NotFound();
            }

            var @group = await _context.groups
                .FirstOrDefaultAsync(m => m.Id == id);
            if (@group == null)
            {
                return NotFound();
            }

            return View(@group);
        }

        // POST: AdminGroups/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.groups == null)
            {
                return Problem("Entity set 'DistanceTestDbContext.groups'  is null.");
            }
            var @group = await _context.groups.FindAsync(id);
            if (@group != null)
            {
                _context.groups.Remove(@group);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GroupExists(int id)
        {
          return _context.groups.Any(e => e.Id == id);
        }
    }
}
