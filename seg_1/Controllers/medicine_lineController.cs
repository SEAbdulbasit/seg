using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using seg_1.Models;

namespace seg_1.Controllers
{
    public class medicine_lineController : Controller
    {
        private seg_1Context db = new seg_1Context();

        // GET: medicine_line
        public ActionResult Index()
        {
            var medicine_line = db.medicine_line.Include(m => m.medicine).Include(m => m.sales);
            return View(medicine_line.ToList());
        }

        // GET: medicine_line/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            medicine_line medicine_line = db.medicine_line.Find(id);
            if (medicine_line == null)
            {
                return HttpNotFound();
            }
            return View(medicine_line);
        }

        // GET: medicine_line/Create
        public ActionResult Create()
        {
            ViewBag.medicine_id = new SelectList(db.medicines, "medicine_id", "medicine_name");
            ViewBag.sales_id = new SelectList(db.sales, "sales_id", "sales_id");
            return View();
        }

        // POST: medicine_line/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "medicine_line_id,sales_id,medicine_id")] medicine_line medicine_line)
        {
            if (ModelState.IsValid)
            {
                db.medicine_line.Add(medicine_line);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.medicine_id = new SelectList(db.medicines, "medicine_id", "medicine_name", medicine_line.medicine_id);
            ViewBag.sales_id = new SelectList(db.sales, "sales_id", "sales_id", medicine_line.sales_id);
            return View(medicine_line);
        }

        // GET: medicine_line/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            medicine_line medicine_line = db.medicine_line.Find(id);
            if (medicine_line == null)
            {
                return HttpNotFound();
            }
            ViewBag.medicine_id = new SelectList(db.medicines, "medicine_id", "medicine_name", medicine_line.medicine_id);
            ViewBag.sales_id = new SelectList(db.sales, "sales_id", "sales_id", medicine_line.sales_id);
            return View(medicine_line);
        }

        // POST: medicine_line/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "medicine_line_id,sales_id,medicine_id")] medicine_line medicine_line)
        {
            if (ModelState.IsValid)
            {
                db.Entry(medicine_line).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.medicine_id = new SelectList(db.medicines, "medicine_id", "medicine_name", medicine_line.medicine_id);
            ViewBag.sales_id = new SelectList(db.sales, "sales_id", "sales_id", medicine_line.sales_id);
            return View(medicine_line);
        }

        // GET: medicine_line/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            medicine_line medicine_line = db.medicine_line.Find(id);
            if (medicine_line == null)
            {
                return HttpNotFound();
            }
            return View(medicine_line);
        }

        // POST: medicine_line/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            medicine_line medicine_line = db.medicine_line.Find(id);
            db.medicine_line.Remove(medicine_line);
            db.SaveChanges();
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
