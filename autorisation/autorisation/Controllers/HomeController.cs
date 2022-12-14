using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using autorisation.Models;
using autorisation.DAO;


namespace autorisation.Controllers
{
    public class HomeController : Controller
    {
        ASttudentDAO ASttudent = new ASttudentDAO();
        APrrepodDAO AprrepodDAO = new APrrepodDAO();
        AGrroupsDAO GrroupsDAO = new AGrroupsDAO();

        // ПОПЫТКИ СДЕЛАТЬ АДМИНА

        // GET: Home/Create
        [Authorize(Roles = "Admin")]
        public ActionResult Create()
        {
            return View();
        }

        public ActionResult Index()
        {
            return View();
        }

        // GET: Home/Details/5
        public ActionResult Details(int id)
        {
            return View(ASttudent.GetA_list_of_users(id));
        }

        // POST: Home/Create
        [HttpPost]
        public ActionResult Create([Bind(Exclude = "id")] A_list_of_users record)
        {
            try
            {
                // TODO: Add insert logic here
                if (ASttudent.InsertA_list_of_users(record))
                    return RedirectToAction("Index");
                else
                    return View("Create");

            }
            catch
            {
                return View();
            }
        }

        // GET: Home/Edit/5
        public ActionResult Edit(int id)
        {
            return View(ASttudent.GetA_list_of_users(id));
        }

        // POST: Home/Edit/5
        [HttpPost]
        public ActionResult Edit([Bind(Include = "Full_name, Group, Login, Password, id, Role")] A_list_of_users met)
        {
            if (ModelState.IsValid && ASttudent.EditA_list_of_users(met))
                return RedirectToAction("Index");
            return View();
        }

        // GET: Home/Delete/5
        public ActionResult Delete(int id)
        {
            return View(ASttudent.GetA_list_of_users(id));
        }

        // POST: Home/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            if (ModelState.IsValid && ASttudent.DeleteA_list_of_users(id))
                return RedirectToAction("Index");
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        // ПОПЫТКИ СДЕЛАТЬ ПРЕПОДА

        // ПОПЫТКИ СДЕЛАТЬ СТУДЕНТА
    }
}