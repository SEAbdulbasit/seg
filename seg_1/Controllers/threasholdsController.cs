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
    public class threasholdsController : Controller
    {
        private seg_1Context db = new seg_1Context();

        // GET: threasholds
        public ActionResult Index()
        {
            var threasholds = db.threasholds.Include(t => t.medicine);
            return View(threasholds.ToList());
        }

        // GET: threasholds/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            threashold threashold = db.threasholds.Find(id);
            if (threashold == null)
            {
                return HttpNotFound();
            }
            return View(threashold);
        }

        // GET: threasholds/Create
        public ActionResult Create()
        {
            ViewBag.medicine_id = new SelectList(db.medicines, "medicine_id", "medicine_name");
            return View();
        }

        // POST: threasholds/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "medicine_id,medicine_quantity,medicine_threashold_quantity")] threashold threashold)
        {
            if (ModelState.IsValid)
            {
                db.threasholds.Add(threashold);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.medicine_id = new SelectList(db.medicines, "medicine_id", "medicine_name", threashold.medicine_id);
            return View(threashold);
        }

        // GET: threasholds/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            threashold threashold = db.threasholds.Find(id);
            if (threashold == null)
            {
                return HttpNotFound();
            }
            ViewBag.medicine_id = new SelectList(db.medicines, "medicine_id", "medicine_name", threashold.medicine_id);
            return View(threashold);
        }

        // POST: threasholds/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "medicine_id,medicine_quantity,medicine_threashold_quantity")] threashold threashold)
        {
            if (ModelState.IsValid)
            {
                db.Entry(threashold).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.medicine_id = new SelectList(db.medicines, "medicine_id", "medicine_name", threashold.medicine_id);
            return View(threashold);
        }

        // GET: threasholds/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            threashold threashold = db.threasholds.Find(id);
            if (threashold == null)
            {
                return HttpNotFound();
            }
            return View(threashold);
        }

        // POST: threasholds/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            threashold threashold = db.threasholds.Find(id);
            db.threasholds.Remove(threashold);
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
