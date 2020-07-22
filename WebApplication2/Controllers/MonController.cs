using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication2.Entities;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class MonController : Controller
    {
        // GET: Mon
        public ActionResult Index()
        {
            List<Mon> mons = new List<Mon>()
            {
                new Mon(){ MyProperty = 1, MyProperty1 = "test", MyProperty2 = true },
                new Mon(){ MyProperty = 3, MyProperty1 = "zaeazefghg", MyProperty2 = true },
                new Mon(){ MyProperty = 12, MyProperty1 = "hfghfgh", MyProperty2 = false },
                new Mon(){ MyProperty = -1, MyProperty1 = "lkmklmklmkl", MyProperty2 = false },
                new Mon(){ MyProperty = 1000000, MyProperty1 = "cvbcvbcvb", MyProperty2 = true },
                new Mon(),
            };

            return View(mons);
        }

        // GET: Mon/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Mon/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Mon/Create
        [HttpPost]
        public ActionResult Create(MonVM monVM)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Mon/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Mon/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Mon/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Mon/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
