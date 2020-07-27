using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Demo_Module6_P1.Data;
using Demo_Module6_P1.Models;

namespace Demo_Module6_P1.Controllers
{
    public class Class2Controller : Controller
    {
        private AppDbContext db = new AppDbContext();

        // GET: Class2
        public async Task<ActionResult> Index()
        {
            return View(await db.Class2s.ToListAsync());
        }

        // GET: Class2/Details/5
        public async Task<ActionResult> Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Class2 class2 = await db.Class2s.FindAsync(id);
            if (class2 == null)
            {
                return HttpNotFound();
            }
            return View(class2);
        }

        // GET: Class2/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Class2/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Name")] Class2 class2)
        {
            if (ModelState.IsValid)
            {
                db.Class2s.Add(class2);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(class2);
        }

        // GET: Class2/Edit/5
        public async Task<ActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Class2 class2 = await db.Class2s.FindAsync(id);
            if (class2 == null)
            {
                return HttpNotFound();
            }
            return View(class2);
        }

        // POST: Class2/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Name")] Class2 class2)
        {
            if (ModelState.IsValid)
            {
                db.Entry(class2).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(class2);
        }

        // GET: Class2/Delete/5
        public async Task<ActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Class2 class2 = await db.Class2s.FindAsync(id);
            if (class2 == null)
            {
                return HttpNotFound();
            }
            return View(class2);
        }

        // POST: Class2/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(long id)
        {
            Class2 class2 = await db.Class2s.FindAsync(id);
            db.Class2s.Remove(class2);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
