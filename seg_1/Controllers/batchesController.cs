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
    public class batchesController : Controller
    {
        private seg_1Context db = new seg_1Context();

        // GET: batches
        public ActionResult Index()
        {
            var batches = db.batches.Include(b => b.medicine);
            return View(batches.ToList());
        }

        // GET: batches/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            batch batch = db.batches.Find(id);
            if (batch == null)
            {
                return HttpNotFound();
            }
            return View(batch);
        }

        // GET: batches/Create
        public ActionResult Create()
        {
            ViewBag.medicine_id = new SelectList(db.medicines, "medicine_id", "medicine_name");
            return View();
        }

        // POST: batches/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "batch_id,medicine_arrival_date,medicine_expiry_date,medicine_id")] batch batch)
        {
            if (ModelState.IsValid)
            {
                db.batches.Add(batch);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.medicine_id = new SelectList(db.medicines, "medicine_id", "medicine_name", batch.medicine_id);
            return View(batch);
        }

        // GET: batches/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            batch batch = db.batches.Find(id);
            if (batch == null)
            {
                return HttpNotFound();
            }
            ViewBag.medicine_id = new SelectList(db.medicines, "medicine_id", "medicine_name", batch.medicine_id);
            return View(batch);
        }

        // POST: batches/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "batch_id,medicine_arrival_date,medicine_expiry_date,medicine_id")] batch batch)
        {
            if (ModelState.IsValid)
            {
                db.Entry(batch).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.medicine_id = new SelectList(db.medicines, "medicine_id", "medicine_name", batch.medicine_id);
            return View(batch);
        }

        // GET: batches/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            batch batch = db.batches.Find(id);
            if (batch == null)
            {
                return HttpNotFound();
            }
            return View(batch);
        }

        // POST: batches/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            batch batch = db.batches.Find(id);
            db.batches.Remove(batch);
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
