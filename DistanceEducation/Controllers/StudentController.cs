using DistanceEducation.Data;
using DistanceEducation.Models;
using Microsoft.AspNetCore.Mvc;

namespace DistanceEducation.Controllers
{
    public class StudentController : Controller
    {
        private readonly DistanceTestDbContext _context;

        public StudentController (DistanceTestDbContext context)
        {
            _context = context;
        }

        public IActionResult MainPageStudent()
        {
            //Response.Cookies.Append("userId", 1.ToString());
            ViewData["Student"] = _context.students.Where(a => a.Id ==Convert.ToInt32(Request.Cookies["userId"])).ToList();
            return View();
        }

        //список доступных тестов
        public IActionResult ChooseTest()
        {
            //изменить на куки
            ViewData["Test"] = _context.tests
                .Where(a => 
                a.GroupId == _context.students.Where(a=>a.Id== Convert.ToInt32(Request.Cookies["userId"]))
                .Select(a=>a.GroupId).FirstOrDefault() 
                && a.DateOfStart<DateTime.Now && a.DateOfEnd>DateTime.Now
                //&& a.Id != _context.results.Where(a=>a.StudentId == Convert.ToInt32(Request.Cookies["StudentId"])).Select(a=>a.TestId).FirstOrDefault()
                ).ToList();
            ViewData["Discipline"] = _context.disciplines.ToList();
            ViewData["Result"] = _context.results.Where(a => a.StudentId == Convert.ToInt32(Request.Cookies["userId"])).ToList();
            return View();
        }

        public IActionResult MakeTest(int Id)
        {
            ViewData["Test"] = _context.tests.Where(a => a.Id == Id).ToList();
            ViewData["Question"] = _context.questions.Where(a => a.TestId == Id).ToList();
            Response.Cookies.Append("TestId", Id.ToString());
            return View();
        }

        public IActionResult ResultTesting()
        {
            int maxpoints = 0;
            int points = 0;

            List<Question> questions = _context.questions.Where(a => a.TestId == Convert.ToInt32(Request.Cookies["TestId"])).ToList();
            foreach (var item in questions)
            {
                String answer = Request.Form[item.Id.ToString()];
                if (item.RightAnswer == answer)
                {
                    points++;
                }
                maxpoints++;

            }

            Result result = new Result();

            result.TestId = Convert.ToInt32(Request.Cookies["TestId"]);
            result.StudentId = Convert.ToInt32(Request.Cookies["userId"]);
            result.Itog = points;
            _context.Add(result);
            _context.SaveChanges();

            Response.Cookies.Delete("TestId");
            ViewData["YourResult"] = points;
            ViewData["MaxResult"] = maxpoints;

            return View();
        }

        //
        public IActionResult AllResults()
        {
            ViewData["Test"] = _context.tests.Where(a => a.GroupId ==
            _context.students.Where(a => a.Id == Convert.ToInt32(Request.Cookies["userId"])).Select(a => a.GroupId).FirstOrDefault()).ToList();
            //&& a.Id != _context.results.Where(a=>a.StudentId== Convert.ToInt32(Request.Cookies["userId"])).Select(a=>a.TestId).FirstOrDefault()).ToList();
            ViewData["Result"] = _context.results.Where(a => a.StudentId == Convert.ToInt32(Request.Cookies["userId"])).ToList();
            //ViewData["Discipline"] = _context.disciplines.Where(a=>a.Id ==
            //_context.disciplineGroups.Where(a=>a.GroupsId==
            //_context.students.Where(a=>a.Id ==Convert.ToInt32(Request.Cookies["StudentId"])).Select(a=>a.GroupId).FirstOrDefault()).Select(a=>a.DisciplineId).FirstOrDefault()).ToList();
            ViewData["Discipline"] = _context.disciplines.ToList();
            ViewData["Question"] = _context.questions.ToList();

            return View();
        }
    }
}
