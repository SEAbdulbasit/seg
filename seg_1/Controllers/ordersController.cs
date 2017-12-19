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
    public class ordersController : Controller
    {
        private seg_1Context db = new seg_1Context();

        // GET: orders
        public ActionResult Index()
        {
            var orders = db.orders.Include(o => o.distributor).Include(o => o.shopkeeper);
            return View(orders.ToList());
        }

        // GET: orders/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            order order = db.orders.Find(id);
            if (order == null)
            {
                return HttpNotFound();
            }
            return View(order);
        }

        // GET: orders/Create
        public ActionResult Create()
        {
            ViewBag.distributor_id = new SelectList(db.distributors, "distributor_id", "distributor_name");
            ViewBag.shopkeeper_id = new SelectList(db.shopkeepers, "shopkeeper_id", "shopkeeper_name");
            return View();
        }

        // POST: orders/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "order_id,distributor_id,shopkeeper_id,order_status,order_date")] order order)
        {
            if (ModelState.IsValid)
            {
                db.orders.Add(order);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.distributor_id = new SelectList(db.distributors, "distributor_id", "distributor_name", order.distributor_id);
            ViewBag.shopkeeper_id = new SelectList(db.shopkeepers, "shopkeeper_id", "shopkeeper_name", order.shopkeeper_id);
            return View(order);
        }

        // GET: orders/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            order order = db.orders.Find(id);
            if (order == null)
            {
                return HttpNotFound();
            }
            ViewBag.distributor_id = new SelectList(db.distributors, "distributor_id", "distributor_name", order.distributor_id);
            ViewBag.shopkeeper_id = new SelectList(db.shopkeepers, "shopkeeper_id", "shopkeeper_name", order.shopkeeper_id);
            return View(order);
        }

        // POST: orders/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "order_id,distributor_id,shopkeeper_id,order_status,order_date")] order order)
        {
            if (ModelState.IsValid)
            {
                db.Entry(order).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.distributor_id = new SelectList(db.distributors, "distributor_id", "distributor_name", order.distributor_id);
            ViewBag.shopkeeper_id = new SelectList(db.shopkeepers, "shopkeeper_id", "shopkeeper_name", order.shopkeeper_id);
            return View(order);
        }

        // GET: orders/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            order order = db.orders.Find(id);
            if (order == null)
            {
                return HttpNotFound();
            }
            return View(order);
        }

        // POST: orders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            order order = db.orders.Find(id);
            db.orders.Remove(order);
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
