using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using autorisation.Models;
using autorisation.DAO;
using System.Data.Entity;
using System.IO;
using autorisation.DAL;


namespace autorisation.Controllers
{

    public class HomeController : Controller
    {
        private readonly DTSContext _context;
        public HomeController(DTSContext context)
        {
            _context = context;
        }


        public ActionResult Index()
        {
            return View();
        }


        public ActionResult Prrepod()
        {
            return View(GetAllPrrepod());
        }


        IEnumerable<A_list_of_users> GetAllPrrepod()
        {
            return _context.A_list_of_users.ToList<A_list_of_users>();
        }

        public ActionResult PAdd(int id = 0)
        {
            A_list_of_users emp = new A_list_of_users();
            if (id != 0)
            {
                emp = _context.A_list_of_users.Where(x => x.id == id).FirstOrDefault<A_list_of_users>();
            }
            return View(emp);
        }

        [HttpPost]
        public ActionResult PAdd(A_list_of_users emp)
        {
            try
            {
                if (emp.ImageUpload != null)
                {
                    string fileName = Path.GetFileNameWithoutExtension(emp.ImageUpload.FileName);
                    string extension = Path.GetExtension(emp.ImageUpload.FileName);
                    fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
                    emp.ImagePath = "~/AppFiles/Images/" + fileName;
                    emp.ImageUpload.SaveAs(Path.Combine(Server.MapPath("~/AppFiles/Images/"), fileName));
                }

                if (emp.id == 0)
                {
                    _context.A_list_of_users.Add(emp);
                    _context.SaveChanges();
                }
                else
                {
                    _context.Entry(emp).State = EntityState.Modified;
                    _context.SaveChanges();

                }

                return Json(new { success = true, html = GlobalClass.RenderRazorViewToString(this, "Prrepod", GetAllPrrepod()), message = "Submitted Successfully" }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {

                return Json(new { success = false, message = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }


        public ActionResult PEdit(int id = 0)
        {
            A_list_of_users emp = new A_list_of_users();
            if (id != 0)
            {
                emp = _context.A_list_of_users.Where(x => x.id == id).FirstOrDefault<A_list_of_users>();
            }
            return View(emp);
        }

        [HttpPost]
        public ActionResult PEdit(A_list_of_users emp)
        {
            try
            {
                if (emp.ImageUpload != null)
                {
                    string fileName = Path.GetFileNameWithoutExtension(emp.ImageUpload.FileName);
                    string extension = Path.GetExtension(emp.ImageUpload.FileName);
                    fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
                    emp.ImagePath = "~/AppFiles/Images/" + fileName;
                    emp.ImageUpload.SaveAs(Path.Combine(Server.MapPath("~/AppFiles/Images/"), fileName));
                }

                if (emp.id == 0)
                {
                    _context.A_list_of_users.Add(emp);
                    _context.SaveChanges();
                }
                else
                {
                    _context.Entry(emp).State = EntityState.Modified;
                    _context.SaveChanges();

                }

                return Json(new { success = true, html = GlobalClass.RenderRazorViewToString(this, "Prrepod", GetAllPrrepod()), message = "Submitted Successfully" }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {

                return Json(new { success = false, message = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult PDelete(int id)
        {
            try
            {

                A_list_of_users emp = _context.A_list_of_users.Where(x => x.id == id).FirstOrDefault<A_list_of_users>();
                _context.A_list_of_users.Remove(emp);
                _context.SaveChanges();

                return Json(new { success = true, html = GlobalClass.RenderRazorViewToString(this, "Prrepod", GetAllPrrepod()), message = "Deleted Successfully" }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }



        /// /////////////////////////////////////////////



        public ActionResult Sttudent()
        {
            return View(GetAllSttudent());
        }

        IEnumerable<A_list_of_users> GetAllSttudent()
        {

            return _context.A_list_of_users.ToList<A_list_of_users>();

        }

        public ActionResult SAdd(int id = 0)
        {
            A_list_of_users emp = new A_list_of_users();
            if (id != 0)
            {

                emp = _context.A_list_of_users.Where(x => x.id == id).FirstOrDefault<A_list_of_users>();

            }
            return View(emp);
        }

        [HttpPost]
        public ActionResult SAdd(A_list_of_users emp)
        {
            try
            {
                if (emp.ImageUpload != null)
                {
                    string fileName = Path.GetFileNameWithoutExtension(emp.ImageUpload.FileName);
                    string extension = Path.GetExtension(emp.ImageUpload.FileName);
                    fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
                    emp.ImagePath = "~/AppFiles/Images/" + fileName;
                    emp.ImageUpload.SaveAs(Path.Combine(Server.MapPath("~/AppFiles/Images/"), fileName));
                }

                if (emp.id == 0)
                {
                    _context.A_list_of_users.Add(emp);
                    _context.SaveChanges();
                }
                else
                {
                    _context.Entry(emp).State = EntityState.Modified;
                    _context.SaveChanges();

                }

                return Json(new { success = true, html = GlobalClass.RenderRazorViewToString(this, "Sttudent", GetAllSttudent()), message = "Submitted Successfully" }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {

                return Json(new { success = false, message = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult SEdit(int id = 0)
        {
            A_list_of_users emp = new A_list_of_users();
            if (id != 0)
            {
                emp = _context.A_list_of_users.Where(x => x.id == id).FirstOrDefault<A_list_of_users>();
            }
            return View(emp);
        }

        [HttpPost]
        public ActionResult SEdit(A_list_of_users emp)
        {
            try
            {
                if (emp.ImageUpload != null)
                {
                    string fileName = Path.GetFileNameWithoutExtension(emp.ImageUpload.FileName);
                    string extension = Path.GetExtension(emp.ImageUpload.FileName);
                    fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
                    emp.ImagePath = "~/AppFiles/Images/" + fileName;
                    emp.ImageUpload.SaveAs(Path.Combine(Server.MapPath("~/AppFiles/Images/"), fileName));
                }

                if (emp.id == 0)
                {
                    _context.A_list_of_users.Add(emp);
                    _context.SaveChanges();
                }
                else
                {
                    _context.Entry(emp).State = EntityState.Modified;
                    _context.SaveChanges();

                }

                return Json(new { success = true, html = GlobalClass.RenderRazorViewToString(this, "Sttudent", GetAllSttudent()), message = "Submitted Successfully" }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {

                return Json(new { success = false, message = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult SDelete(int id)
        {
            try
            {

                A_list_of_users emp = _context.A_list_of_users.Where(x => x.id == id).FirstOrDefault<A_list_of_users>();
                _context.A_list_of_users.Remove(emp);
                _context.SaveChanges();

                return Json(new { success = true, html = GlobalClass.RenderRazorViewToString(this, "Sttudent", GetAllSttudent()), message = "Deleted Successfully" }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }




        /// /////////////////////////////////////////////



        public ActionResult Grroups()
        {
            return View(GetAllGrroups());
        }

        IEnumerable<Groups> GetAllGrroups()
        {

            return _context.Groups.ToList<Groups>();


        }

        public ActionResult GAdd(int Name = 0)
        {
            Groups emp = new Groups();
            if (Name != 0)
            {

                emp = _context.Groups.Where(x => x.Name == Name).FirstOrDefault<Groups>();

            }
            return View(emp);
        }

        [HttpPost]
        public ActionResult GAdd(Groups emp)
        {
            try
            {
                if (emp.ImageUpload != null)
                {
                    string fileName = Path.GetFileNameWithoutExtension(emp.ImageUpload.FileName);
                    string extension = Path.GetExtension(emp.ImageUpload.FileName);
                    fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
                    emp.ImagePath = "~/AppFiles/Images/" + fileName;
                    emp.ImageUpload.SaveAs(Path.Combine(Server.MapPath("~/AppFiles/Images/"), fileName));
                }

                if (emp.Name == 0)
                {
                    _context.Groups.Add(emp);
                    _context.SaveChanges();
                }
                else
                {
                    _context.Entry(emp).State = EntityState.Modified;
                    _context.SaveChanges();

                }

                return Json(new { success = true, html = GlobalClass.RenderRazorViewToString(this, "Grroups", GetAllGrroups()), message = "Submitted Successfully" }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {

                return Json(new { success = false, message = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult GEdit(int Name = 0)
        {
            Groups emp = new Groups();
            if (Name != 0)
            {

                emp = _context.Groups.Where(x => x.Name == Name).FirstOrDefault<Groups>();

            }
            return View(emp);
        }

        [HttpPost]
        public ActionResult GEdit(Groups emp)
        {
            try
            {
                if (emp.ImageUpload != null)
                {
                    string fileName = Path.GetFileNameWithoutExtension(emp.ImageUpload.FileName);
                    string extension = Path.GetExtension(emp.ImageUpload.FileName);
                    fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
                    emp.ImagePath = "~/AppFiles/Images/" + fileName;
                    emp.ImageUpload.SaveAs(Path.Combine(Server.MapPath("~/AppFiles/Images/"), fileName));
                }

                if (emp.Name == 0)
                {
                    _context.Groups.Add(emp);
                    _context.SaveChanges();
                }
                else
                {
                    _context.Entry(emp).State = EntityState.Modified;
                    _context.SaveChanges();

                }

                return Json(new { success = true, html = GlobalClass.RenderRazorViewToString(this, "Grroups", GetAllGrroups()), message = "Submitted Successfully" }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {

                return Json(new { success = false, message = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult GDelete(int Name)
        {
            try
            {

                Groups emp = _context.Groups.Where(x => x.Name == Name).FirstOrDefault<Groups>();
                _context.Groups.Remove(emp);
                _context.SaveChanges();

                return Json(new { success = true, html = GlobalClass.RenderRazorViewToString(this, "Grroups", GetAllGrroups()), message = "Deleted Successfully" }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }
























        public ActionResult AddOrEdit(int id = 0)
        {
            A_list_of_users emp = new A_list_of_users();
            if (id != 0)
            {
                emp = _context.A_list_of_users.Where(x => x.id == id).FirstOrDefault<A_list_of_users>();
            }
            return View(emp);
        }

        [HttpPost]
        public ActionResult AddOrEdit(A_list_of_users emp)
        {
            try
            {
                if (emp.ImageUpload != null)
                {
                    string fileName = Path.GetFileNameWithoutExtension(emp.ImageUpload.FileName);
                    string extension = Path.GetExtension(emp.ImageUpload.FileName);
                    fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
                    emp.ImagePath = "~/AppFiles/Images/" + fileName;
                    emp.ImageUpload.SaveAs(Path.Combine(Server.MapPath("~/AppFiles/Images/"), fileName));
                }

                if (emp.id == 0)
                {
                    _context.A_list_of_users.Add(emp);
                    _context.SaveChanges();
                }
                else
                {
                    _context.Entry(emp).State = EntityState.Modified;
                    _context.SaveChanges();

                }

                return Json(new { success = true, html = GlobalClass.RenderRazorViewToString(this, "Prrepod", GetAllPrrepod()), message = "Submitted Successfully" }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {

                return Json(new { success = false, message = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }

    }
}
