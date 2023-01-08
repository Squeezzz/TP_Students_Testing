using DistanceEducation.Data;
using DistanceEducation.Models;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography.X509Certificates;
using System.Text.RegularExpressions;
using System;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DistanceEducation.Controllers
{
    public class TeacherController : Controller
    {
        private readonly DistanceTestDbContext _context;

        public TeacherController (DistanceTestDbContext context)
        {
            _context = context;
        }

        public IActionResult MainPageTeacher()
        {
            //ViewData["Teacher"] = _context.teachers.Where(a => a.Id == Convert.ToInt32(Request.Cookies["userId"])).ToList();
            ViewData["Teacher"] = _context.teachers.Where(a => a.Id == 1).ToList();
            return View();
        }

        public IActionResult MakeTest()
        {
            //Получение списка групп у которых преподает данный преподаватель
            List<int> groupId= new List<int>();
            groupId = _context.groupTeachers.Where(a => a.TeachersId == 1).Select(a=>a.GroupsId).ToList();
            List<Models.Group> groups = new List<Models.Group>();
            foreach (var item in groupId)
            {
                groups.Add(_context.groups.Where(a => a.Id == item).FirstOrDefault());
            }
            ViewData["Group"] = groups;

            return View();
        }

        public IActionResult ChooseDiscipline([Bind("TestName,DateOfStart,DateOfEnd,GroupId")] Test test)
        {
            //изменить на куки
            test.TeacherId = 1;

            List<int> disciplineTId = new List<int>();
            disciplineTId = _context.disciplineTeachers.Where(a=>a.TeacherId==test.TeacherId).Select(a=>a.DisciplineId).ToList();

            List<int> disciplineGId = new List<int>();
            disciplineGId = _context.disciplineGroups.Where(a => a.GroupsId == test.GroupId).Select(a => a.DisciplineId).ToList();

            List<Models.Discipline> disciplines = new List<Models.Discipline>();

            foreach (var item1 in disciplineTId)
            {
                foreach (var item2 in disciplineGId)
                {
                    disciplines.Add(_context.disciplines.Where(a => a.Id == item2 && a.Id == item1).FirstOrDefault());
                }

            }

            ViewData["Discipline"] = disciplines;

            
            TempData["TestName"] = test.TestName;
            TempData["DateOfStart"] = test.DateOfStart;
            TempData["DateOfEnd"] = test.DateOfEnd;
            TempData["GroupId"] = test.GroupId;

            return View();
        }

        public async Task<IActionResult> CreateTest([Bind("DisciplineId")] Test test)
        {
            //создание теста, редирект на страницу для редактирования тестов
            test.TestName = TempData["TestName"].ToString();

            test.DateOfStart = Convert.ToDateTime(TempData["DateOfStart"]);
            test.DateOfEnd = Convert.ToDateTime(TempData["DateOfEnd"]);
            test.GroupId =Convert.ToInt32(TempData["GroupId"]);
            //изменить на куки
            test.TeacherId = 1;
            _context.tests.Add(test);
            await _context.SaveChangesAsync();

            return Redirect("~/Teacher/MakeQuestions");
        }

        public IActionResult MakeQuestions()
        {
            return View();
        }

    }
}
