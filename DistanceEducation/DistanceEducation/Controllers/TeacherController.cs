using DistanceEducation.Data;
using DistanceEducation.Models;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography.X509Certificates;
using System.Text.RegularExpressions;
using System;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using static System.Net.Mime.MediaTypeNames;

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

            Response.Cookies.Append("TestName", test.TestName);
            Response.Cookies.Append("DateOfStart",test.DateOfStart.ToString());
            Response.Cookies.Append("DateOfEnd", test.DateOfEnd.ToString());
            Response.Cookies.Append("GroupId", test.GroupId.ToString() );

            return View();
        }

        public async Task<IActionResult> CreateTest([Bind("DisciplineId")] Test test)
        {
            //создание теста, редирект на страницу для редактирования тестов
            test.TestName = Request.Cookies["TestName"];

            test.DateOfStart = Convert.ToDateTime(Request.Cookies["DateOfStart"]);
            test.DateOfEnd = Convert.ToDateTime(Request.Cookies["DateOfEnd"]);
            test.GroupId =Convert.ToInt32(Request.Cookies["GroupId"]);
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

        public IActionResult WriteAnswers([Bind("Title,typeQuestion")] Question question)
        {
            Response.Cookies.Append("Title", question.Title);
            Response.Cookies.Append("typeQuestion", question.typeQuestion.ToString());

            ViewData["typeQuestion"] = Request.Cookies["typeQuestion"];

            return View();
        }

        public IActionResult ChooseRightAnswer([Bind("Answer1,Answer2,Answer3,Answer4,Answer5,Answer6,Answer7,Answer8,Answer9,Answer10")] Question question)
        {
            Response.Cookies.Append("Answer1", question.Answer1);
            Response.Cookies.Append("Answer2", question.Answer2);
            Response.Cookies.Append("Answer3", question.Answer3);
            Response.Cookies.Append("Answer4", question.Answer4);
            Response.Cookies.Append("Answer5", question.Answer5);
            Response.Cookies.Append("Answer6", question.Answer6);
            Response.Cookies.Append("Answer7", question.Answer7);
            Response.Cookies.Append("Answer8", question.Answer8);
            Response.Cookies.Append("Answer9", question.Answer9);
            Response.Cookies.Append("Answer10", question.Answer10);

            ViewData["typeQuestion"] = Request.Cookies["typeQuestion"];


            ViewData["Answer1"] = question.Answer1;
            ViewData["Answer2"] = question.Answer2;
            ViewData["Answer3"] = question.Answer3;
            ViewData["Answer4"] = question.Answer4;
            ViewData["Answer5"] = question.Answer5;
            ViewData["Answer6"] = question.Answer6;
            ViewData["Answer7"] = question.Answer7;
            ViewData["Answer8"] = question.Answer8;
            ViewData["Answer9"] = question.Answer9;
            ViewData["Answer10"] = question.Answer10;

            return View();
        }
    }
}
