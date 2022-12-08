using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using autorisation.Models;
using autorisation.DDAO;


namespace autorisation.Controllers
{
    public class HomeController : Controller
    {
        RecordsDAO records = new RecordsDAO();

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
            return View(records.GetСписок_пользователей(id));
        }

        // POST: Home/Create
        [HttpPost]
        public ActionResult Create([Bind(Exclude = "id")] Список_пользователей record)
        {
            try
            {
                // TODO: Add insert logic here
                if (records.InsertСписок_пользователей(record))
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
            return View(records.GetСписок_пользователей(id));
        }

        // POST: Home/Edit/5
        [HttpPost]
        public ActionResult Edit([Bind(Include = "ФИО, Группа, Логин, Пароль")] Список_пользователей met)
        {
            if (ModelState.IsValid && records.EditСписок_пользователей(met))
                return RedirectToAction("Index");
            return View();
        }

        // GET: Home/Delete/5
        public ActionResult Delete(int id)
        {
            return View(records.GetСписок_пользователей(id));
        }

        // POST: Home/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            if (ModelState.IsValid && records.DeleteСписок_пользователей(id))
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
    }
}