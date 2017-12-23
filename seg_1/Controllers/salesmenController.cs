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
    public class salesmenController : Controller
    {
        private seg_1Context db = new seg_1Context();

        // GET: salesmen
        public ActionResult Index()
        {
            var salesmen = db.salesmen.Include(s => s.shopkeeper);
            return View(salesmen.ToList());
        }

        // GET: salesmen/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            salesman salesman = db.salesmen.Find(id);
            if (salesman == null)
            {
                return HttpNotFound();
            }
            return View(salesman);
        }

        // GET: salesmen/Create
        public ActionResult Create()
        {
            ViewBag.shopkeeper_id = new SelectList(db.shopkeepers, "shopkeeper_id", "shopkeeper_name");
            return View();
        }

        // POST: salesmen/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "salesman_id,salesman_name,salesman_password,ConfirmPassword,salesman_address,salesman_mobile_num,salesman_email,salesman_start_date,shopkeeper_id")] salesman salesman)
        {
            if (ModelState.IsValid)
            {
                db.salesmen.Add(salesman);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.shopkeeper_id = new SelectList(db.shopkeepers, "shopkeeper_id", "shopkeeper_name", salesman.shopkeeper_id);
            return View(salesman);
        }

        // GET: salesmen/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            salesman salesman = db.salesmen.Find(id);
            if (salesman == null)
            {
                return HttpNotFound();
            }
            ViewBag.shopkeeper_id = new SelectList(db.shopkeepers, "shopkeeper_id", "shopkeeper_name", salesman.shopkeeper_id);
            return View(salesman);
        }

        // POST: salesmen/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "salesman_id,salesman_name,salesman_password,ConfirmPassword,salesman_address,salesman_mobile_num,salesman_email,salesman_start_date,shopkeeper_id")] salesman salesman)
        {
            if (ModelState.IsValid)
            {
                db.Entry(salesman).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.shopkeeper_id = new SelectList(db.shopkeepers, "shopkeeper_id", "shopkeeper_name", salesman.shopkeeper_id);
            return View(salesman);
        }

        // GET: salesmen/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            salesman salesman = db.salesmen.Find(id);
            if (salesman == null)
            {
                return HttpNotFound();
            }
            return View(salesman);
        }

        // POST: salesmen/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            salesman salesman = db.salesmen.Find(id);
            db.salesmen.Remove(salesman);
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
