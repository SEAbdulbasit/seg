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
    public class distributionsController : Controller
    {
        private seg_1Context db = new seg_1Context();

        // GET: distributions
        public ActionResult Index()
        {
            var distributions = db.distributions.Include(d => d.distributor);
            return View(distributions.ToList());
        }

        // GET: distributions/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            distribution distribution = db.distributions.Find(id);
            if (distribution == null)
            {
                return HttpNotFound();
            }
            return View(distribution);
        }

        // GET: distributions/Create
        public ActionResult Create()
        {
            ViewBag.distributor_id = new SelectList(db.distributors, "distributor_id", "distributor_name");
            return View();
        }

        // POST: distributions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "distribution_id,distribution_name,distribution_address,distributor_id")] distribution distribution)
        {
            if (ModelState.IsValid)
            {
                db.distributions.Add(distribution);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.distributor_id = new SelectList(db.distributors, "distributor_id", "distributor_name", distribution.distributor_id);
            return View(distribution);
        }

        // GET: distributions/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            distribution distribution = db.distributions.Find(id);
            if (distribution == null)
            {
                return HttpNotFound();
            }
            ViewBag.distributor_id = new SelectList(db.distributors, "distributor_id", "distributor_name", distribution.distributor_id);
            return View(distribution);
        }

        // POST: distributions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "distribution_id,distribution_name,distribution_address,distributor_id")] distribution distribution)
        {
            if (ModelState.IsValid)
            {
                db.Entry(distribution).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.distributor_id = new SelectList(db.distributors, "distributor_id", "distributor_name", distribution.distributor_id);
            return View(distribution);
        }

        // GET: distributions/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            distribution distribution = db.distributions.Find(id);
            if (distribution == null)
            {
                return HttpNotFound();
            }
            return View(distribution);
        }

        // POST: distributions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            distribution distribution = db.distributions.Find(id);
            db.distributions.Remove(distribution);
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
