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
    public class order_quantityController : Controller
    {
        private seg_1Context db = new seg_1Context();

        // GET: order_quantity
        public ActionResult Index()
        {
            return View(db.order_quantity.ToList());
        }

        // GET: order_quantity/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            order_quantity order_quantity = db.order_quantity.Find(id);
            if (order_quantity == null)
            {
                return HttpNotFound();
            }
            return View(order_quantity);
        }

        // GET: order_quantity/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: order_quantity/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "medicine_id,order_quantityy")] order_quantity order_quantity)
        {
            if (ModelState.IsValid)
            {
                db.order_quantity.Add(order_quantity);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(order_quantity);
        }

        // GET: order_quantity/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            order_quantity order_quantity = db.order_quantity.Find(id);
            if (order_quantity == null)
            {
                return HttpNotFound();
            }
            return View(order_quantity);
        }

        // POST: order_quantity/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "medicine_id,order_quantityy")] order_quantity order_quantity)
        {
            if (ModelState.IsValid)
            {
                db.Entry(order_quantity).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(order_quantity);
        }

        // GET: order_quantity/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            order_quantity order_quantity = db.order_quantity.Find(id);
            if (order_quantity == null)
            {
                return HttpNotFound();
            }
            return View(order_quantity);
        }

        // POST: order_quantity/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            order_quantity order_quantity = db.order_quantity.Find(id);
            db.order_quantity.Remove(order_quantity);
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
