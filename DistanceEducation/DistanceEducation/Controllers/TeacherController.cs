using DistanceEducation.Data;
using DistanceEducation.Models;
using Microsoft.AspNetCore.Mvc;
using System.Text.RegularExpressions;

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
            List<string> groups = new List<string>();
            foreach (var item in groupId)
            {
                groups.Add(_context.groups.Where(a => a.Id == item).Select(a=>a.GroupName).FirstOrDefault());  //_context.groups.Where(a => a.Id == item).ToList();
            }
            ViewData["Group"] = groups;

            return View();
        }
    }
}
