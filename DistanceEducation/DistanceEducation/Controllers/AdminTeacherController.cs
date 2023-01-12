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
    public class AdminTeacherController : Controller
    {
        private readonly DistanceTestDbContext _context;

        public AdminTeacherController(DistanceTestDbContext context)
        {
            _context = context;
        }

        // GET: AdminTeacher
        public async Task<IActionResult> Index()
        {
            //Получение списка групп у которых преподает данный преподаватель
            /*List<int> groupId = new List<int>();
            groupId = _context.groupTeachers.Where(a => a.TeachersId == 1).Select(a => a.GroupsId).ToList();
            List<Models.Group> groups = new List<Models.Group>();
            foreach (var item in groupId)
            {
                groups.Add(_context.groups.Where(a => a.Id == item).FirstOrDefault());
            }*/
            //ViewData["Group"] = groups;
            ViewData["Group"] = _context.groups.ToList();
            ViewData["GroupTeacher"] = _context.groupTeachers.ToList();
            //Получение списка дисциплин у которые преподает данный преподаватель
            /*List<int> disId = new List<int>();
            disId = _context.disciplineTeachers.Where(a => a.TeacherId == 1).Select(a => a.DisciplineId).ToList();
            List<Models.Discipline> disciplines = new List<Models.Discipline>();
            foreach (var item in disId)
            {
                disciplines.Add(_context.disciplines.Where(a => a.Id == item).FirstOrDefault());
            }*/
            //ViewData["Discipline"] = disciplines;
            ViewData["Discipline"] = _context.disciplines.ToList();
            ViewData["DisciplineTeacher"] = _context.disciplineTeachers.ToList();
            TempData["userIdToIndex"] = Convert.ToInt32(Request.Cookies["userId"]);
            return View(await _context.teachers.ToListAsync());
        }

        public IActionResult AddGroup(int Id)
        {
            //Получение списка групп у которых не преподает данный преподаватель
            List<int> groupId = new List<int>();
            groupId = _context.groups.Select(a => a.Id).ToList();
            List<Models.Group> groups = new List<Models.Group>();
            foreach (var item in groupId)
            {
                if(_context.groups.Where(a => a.Id == item &&
                a.Id != _context.groupTeachers.Where(a => a.TeachersId == Id && a.GroupsId == item).Select(a => a.GroupsId).FirstOrDefault()).FirstOrDefault()!=null)
                groups.Add(_context.groups.Where(a => a.Id == item && 
                a.Id != _context.groupTeachers.Where(a=>a.TeachersId == Id && a.GroupsId == item).Select(a=>a.GroupsId).FirstOrDefault()).FirstOrDefault());
            }
            ViewData["Group"] = groups;

            TempData["TeacherId"] = Id;

            //ViewData["Groups"] = _context.groupTeachers.Where(a=>a.TeachersId!=Id).Select(a=>a.GroupsId).ToList();
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddGroup([Bind("GroupsId")] GroupTeacher groupTeacher)
        {
            groupTeacher.TeachersId =Convert.ToInt32(TempData["TeacherId"]);

            _context.groupTeachers.Add(groupTeacher);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }

        public IActionResult DeleteGroup(int Id)
        {
            //Получение списка групп у которых преподает данный преподаватель
            List<int> groupId = new List<int>();
            groupId = _context.groupTeachers.Where(a => a.TeachersId == Id).Select(a => a.GroupsId).ToList();
            List<Models.Group> groups = new List<Models.Group>();
            foreach (var item in groupId)
            {
                groups.Add(_context.groups.Where(a => a.Id == item).FirstOrDefault());
            }
            ViewData["Group"] = groups;
            TempData["TeacherId"] = Id;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> DeleteGroup([Bind("GroupsId")] GroupTeacher groupTeacher)
        {
            groupTeacher.TeachersId = Convert.ToInt32(TempData["TeacherId"]);

            _context.groupTeachers.Remove(groupTeacher);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }

        public IActionResult AddDiscipline(int Id)
        {
            //Получение списка дисциплин которые не преподает данный преподаватель
            List<int> disId = new List<int>();
            disId = _context.disciplines.Select(a => a.Id).ToList();
            List<Models.Discipline> disciplines = new List<Models.Discipline>();
            foreach (var item in disId)
            {
                if (_context.disciplines.Where(a => a.Id == item &&
                a.Id != _context.disciplineTeachers.Where(a => a.TeacherId == Id && a.DisciplineId == item).Select(a => a.DisciplineId).FirstOrDefault()).FirstOrDefault() != null)
                    disciplines.Add(_context.disciplines.Where(a => a.Id == item &&
                    a.Id != _context.disciplineTeachers.Where(a => a.TeacherId == Id && a.DisciplineId == item).Select(a => a.DisciplineId).FirstOrDefault()).FirstOrDefault());
            }
            ViewData["Discipline"] = disciplines;

            TempData["TeacherId"] = Id;

            //ViewData["Groups"] = _context.groupTeachers.Where(a=>a.TeachersId!=Id).Select(a=>a.GroupsId).ToList();
            return View();
        }

        public IActionResult DeleteDiscipline(int Id)
        {
            //Получение списка дисциплин которые преподает данный преподаватель
            List<int> disId = new List<int>();
            disId = _context.disciplineTeachers.Where(a => a.TeacherId == Id).Select(a => a.DisciplineId).ToList();
            List<Models.Discipline> disciplines = new List<Models.Discipline>();
            foreach (var item in disId)
            {
                disciplines.Add(_context.disciplines.Where(a => a.Id == item).FirstOrDefault());
            }
            ViewData["Discipline"] = disciplines;
            TempData["TeacherId"] = Id;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> DeleteDiscipline([Bind("DisciplineId")] DisciplineTeacher disciplineTeacher)
        {
            disciplineTeacher.TeacherId = Convert.ToInt32(TempData["TeacherId"]);

            _context.disciplineTeachers.Remove(disciplineTeacher);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> AddDiscipline([Bind("DisciplineId")] DisciplineTeacher disciplineTeacher)
        {
            disciplineTeacher.TeacherId = Convert.ToInt32(TempData["TeacherId"]);

            _context.disciplineTeachers.Add(disciplineTeacher);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }


        // GET: AdminTeacher/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.teachers == null)
            {
                return NotFound();
            }

            var teacher = await _context.teachers
                .FirstOrDefaultAsync(m => m.Id == id);
            if (teacher == null)
            {
                return NotFound();
            }

            return View(teacher);
        }

        // GET: AdminTeacher/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: AdminTeacher/Create
       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateT([Bind("Name,Surname,Patronymic,Email,Password")] Teacher teacher)
        {
                _context.Add(teacher);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
        }
                                                                                
        // GET: AdminTeacher/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.teachers == null)
            {
                return NotFound();
            }

            var teacher = await _context.teachers.FindAsync(id);
            if (teacher == null)
            {
                return NotFound();
            }
            return View(teacher);
        }

        // POST: AdminTeacher/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Surname,Patronymic,Email,Password")] Teacher teacher)
        {
            if (id != teacher.Id)
            {
                return NotFound();
            }

                try
                {
                    _context.Update(teacher);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TeacherExists(teacher.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            
            return View(teacher);
        }

        // GET: AdminTeacher/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.teachers == null)
            {
                return NotFound();
            }

            var teacher = await _context.teachers
                .FirstOrDefaultAsync(m => m.Id == id);
            if (teacher == null)
            {
                return NotFound();
            }

            return View(teacher);
        }

        // POST: AdminTeacher/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.teachers == null)
            {
                return Problem("Entity set 'DistanceTestDbContext.teachers'  is null.");
            }
            var teacher = await _context.teachers.FindAsync(id);
            if (teacher != null)
            {
                _context.teachers.Remove(teacher);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TeacherExists(int id)
        {
          return _context.teachers.Any(e => e.Id == id);
        }
    }
}
