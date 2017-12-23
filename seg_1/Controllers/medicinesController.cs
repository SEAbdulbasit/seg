using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using seg_1.Models;
using seg_1.Controllers;

namespace seg_1.Controllers
{
    public class medicinesController : Controller
    {
        private seg_1Context db = new seg_1Context();

        // GET: medicines
        public ActionResult Index()
        {
            var medicines = db.medicines.Include(m => m.threashold);
            return View(medicines.ToList());
        }
         // GET: medicines/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            medicine medicine = db.medicines.Find(id);
            if (medicine == null)
            {
                return HttpNotFound();
            }
            return View(medicine);
        }

        // GET: medicines/Create
        public ActionResult Create()
        {
            ViewBag.medicine_id = new SelectList(db.threasholds, "medicine_id", "medicine_id");
            return View();
        }

        // POST: medicines/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "medicine_id,medicine_name,medicine_description,medicine_purchasee_price,medicine_siling_price,medicine_dose")] medicine medicine)
        {
            if (ModelState.IsValid)
            {
                db.medicines.Add(medicine);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.medicine_id = new SelectList(db.threasholds, "medicine_id", "medicine_id", medicine.medicine_id);
            return View(medicine);
        }

        // GET: medicines/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            medicine medicine = db.medicines.Find(id);
            if (medicine == null)
            {
                return HttpNotFound();
            }
            ViewBag.medicine_id = new SelectList(db.threasholds, "medicine_id", "medicine_id", medicine.medicine_id);
            return View(medicine);
        }

        // POST: medicines/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "medicine_id,medicine_name,medicine_description,medicine_purchasee_price,medicine_siling_price,medicine_dose")] medicine medicine)
        {
            if (ModelState.IsValid)
            {
                db.Entry(medicine).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.medicine_id = new SelectList(db.threasholds, "medicine_id", "medicine_id", medicine.medicine_id);
            return View(medicine);
        }



        public  ActionResult Details_quantity(int ? id)
        {

            return RedirectToAction("Details/" + id.ToString(), "threasholds");

        }









        // GET: medicines/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            medicine medicine = db.medicines.Find(id);
            if (medicine == null)
            {
                return HttpNotFound();
            }
            return View(medicine);
        }

        // POST: medicines/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            medicine medicine = db.medicines.Find(id);
            db.medicines.Remove(medicine);
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
