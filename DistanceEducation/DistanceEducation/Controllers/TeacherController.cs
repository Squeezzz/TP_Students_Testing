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
            //Response.Cookies.Append("userId", 1.ToString());
            //ViewData["Teacher"] = _context.teachers.Where(a => a.Id == Convert.ToInt32(Request.Cookies["userId"])).ToList();
            ViewData["Teacher"] = _context.teachers.Where(a => a.Id == Convert.ToInt32(Request.Cookies["userId"])).ToList();
            return View();
        }

        public IActionResult MakeTest()
        {
            //Получение списка групп у которых преподает данный преподаватель
            List<int> groupId= new List<int>();
            groupId = _context.groupTeachers.Where(a => a.TeachersId == Convert.ToInt32(Request.Cookies["userId"])).Select(a=>a.GroupsId).ToList();
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

            Response.Cookies.Append("DisciplineId", test.DisciplineId.ToString());

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
            //string answer = "Answer";

            if(question.Answer1!=null)
            {
                Response.Cookies.Append("Answer1", question.Answer1);
                ViewData["Answer1"] = question.Answer1;
            } 
            if (question.Answer2 != null)
            {
                Response.Cookies.Append("Answer2", question.Answer2);
                ViewData["Answer2"] = question.Answer2;
            }
            if (question.Answer3 != null)
            {
                Response.Cookies.Append("Answer3", question.Answer3);
                ViewData["Answer3"] = question.Answer3;
            }
            if (question.Answer4 != null)
            {
                Response.Cookies.Append("Answer4", question.Answer4);
                ViewData["Answer4"] = question.Answer4;
            }
            if (question.Answer5 != null)
            {
                Response.Cookies.Append("Answer5", question.Answer5);
                ViewData["Answer5"] = question.Answer5;
            }
            if (question.Answer6 != null)
            {
                Response.Cookies.Append("Answer6", question.Answer6);
                ViewData["Answer6"] = question.Answer6;
            }
            if (question.Answer7 != null)
            {
                Response.Cookies.Append("Answer7", question.Answer7);
                ViewData["Answer7"] = question.Answer7;
            }
            if (question.Answer8 != null)
            {
                Response.Cookies.Append("Answer8", question.Answer8);
                ViewData["Answer8"] = question.Answer8;
            }
            if (question.Answer9 != null)
            {
                Response.Cookies.Append("Answer9", question.Answer9);
                ViewData["Answer9"] = question.Answer9;
            }
            if (question.Answer10 != null)
            {
                Response.Cookies.Append("Answer10", question.Answer10);
                ViewData["Answer10"] = question.Answer10;
            }
            /*Response.Cookies.Append("Answer1", question.Answer1);
            Response.Cookies.Append("Answer2", question.Answer2);
            Response.Cookies.Append("Answer3", question.Answer3);
            Response.Cookies.Append("Answer4", question.Answer4);
            Response.Cookies.Append("Answer5", question.Answer5);
            Response.Cookies.Append("Answer6", question.Answer6);
            Response.Cookies.Append("Answer7", question.Answer7);
            Response.Cookies.Append("Answer8", question.Answer8);
            Response.Cookies.Append("Answer9", question.Answer9);
            Response.Cookies.Append("Answer10", question.Answer10);*/

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

        public async Task<IActionResult> CreateQuestion([Bind("RightAnswer")] Question question)
        {
            //Request.Form["id"] = question.Id;
            question.RightAnswer = Request.Form["answer"];
            question.Title = Request.Cookies["Title"];
            question.typeQuestion =Convert.ToInt32( Request.Cookies["typeQuestion"]);

            question.TestId = _context.tests.Where(a => a.TestName == Request.Cookies["TestName"]
            && a.DateOfStart == Convert.ToDateTime(Request.Cookies["DateOfStart"])
            && a.DateOfEnd == Convert.ToDateTime(Request.Cookies["DateOfEnd"])
            && a.TeacherId == Convert.ToInt32(Request.Cookies["userId"])
            && a.DisciplineId == Convert.ToInt32(Request.Cookies["DisciplineId"])
            && a.GroupId == Convert.ToInt32(Request.Cookies["GroupId"]))
                .Select(a=>a.Id).FirstOrDefault();
            Response.Cookies.Append("TestId", question.TestId.ToString());
            if (Request.Cookies["Answer1"] != null)
            {
                question.Answer1 = Request.Cookies["Answer1"];
            }
            if (Request.Cookies["Answer2"] != null)
            {
                question.Answer2 = Request.Cookies["Answer2"];
            }
            if (Request.Cookies["Answer3"] != null)
            {
                question.Answer3 = Request.Cookies["Answer3"];
            }
            if (Request.Cookies["Answer4"] != null)
            {
                question.Answer4 = Request.Cookies["Answer4"];
            }
            if (Request.Cookies["Answer5"] != null)
            {
                question.Answer5 = Request.Cookies["Answer5"];
            }
            if (Request.Cookies["Answer6"] != null)
            {
                question.Answer6 = Request.Cookies["Answer6"];
            }
            if (Request.Cookies["Answer7"] != null)
            {
                question.Answer7 = Request.Cookies["Answer7"];
            }
            if (Request.Cookies["Answer8"] != null)
            {
                question.Answer8 = Request.Cookies["Answer8"];
            }
            if (Request.Cookies["Answer9"] != null)
            {
                question.Answer9 = Request.Cookies["Answer9"];
            }
            if (Request.Cookies["Answer10"] != null)
            {
                question.Answer10 = Request.Cookies["Answer10"];
            }

            _context.questions.Add(question);
            await _context.SaveChangesAsync();

            return Redirect("~/Teacher/ListQuestions");
        }

        public IActionResult ListQuestions()
        {
            ViewData["Test"] = _context.tests.Where(a => a.Id == Convert.ToInt32(Request.Cookies["TestId"])).ToList();
            ViewData["Question"] = _context.questions.Where(a => a.TestId == Convert.ToInt32(Request.Cookies["TestId"])).ToList();
            return View();
        }

        //Список тестов созданных преподавателем
        public IActionResult TestList()
        {
            ViewData["Tests"] = _context.tests.Where(a => a.TeacherId == Convert.ToInt32(Request.Cookies["userId"])).ToList();
            ViewData["Group"] = _context.groups.ToList();
            ViewData["Discipline"] = _context.disciplines.ToList();

            return View();
        }


        public IActionResult LookTest(int Id)
        {
            ViewData["Test"] = _context.tests.Where(a => a.Id == Id).ToList();
            ViewData["Question"] = _context.questions.Where(a => a.TestId == Id).ToList();
            return View();
        }

        public async Task<IActionResult> DeleteTest(int Id)
        {
            Test test = new Test();
            test.Id = Id;
            _context.tests.Remove(test);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(TestList));
        }

        public IActionResult LookResults(int Id)
        {
            ViewData["Students"] = _context.students.Where(a => a.GroupId == _context.tests.Where(a => a.Id == Id).Select(a => a.GroupId).FirstOrDefault()).ToList();
            ViewData["Results"] = _context.results.Where(a => a.TestId == Id).ToList();
            ViewData["Question"] = _context.questions.Where(a => a.TestId == Id).Count();
            return View();
        }
    }
}
