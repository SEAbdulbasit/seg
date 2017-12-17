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
    public class shopkeepersController : Controller
    {
        private seg_1Context db = new seg_1Context();

        // GET: shopkeepers
        public ActionResult Index()
        {
            return View(db.shopkeepers.ToList());
        }

        // GET: shopkeepers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            shopkeeper shopkeeper = db.shopkeepers.Find(id);
            if (shopkeeper == null)
            {
                return HttpNotFound();
            }
            return View(shopkeeper);
        }

        // GET: shopkeepers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: shopkeepers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "shopkeeper_id,shopkeeper_name,shopkeeper_password,ConfirmPassword,shopkeeper_address,shopkeeper_mobile_no,shopeeper_email,shop_start_date")] shopkeeper shopkeeper)
        {
            if (ModelState.IsValid)
            {
                db.shopkeepers.Add(shopkeeper);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(shopkeeper);
        }

        // GET: shopkeepers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            shopkeeper shopkeeper = db.shopkeepers.Find(id);
            if (shopkeeper == null)
            {
                return HttpNotFound();
            }
            return View(shopkeeper);
        }

        // POST: shopkeepers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "shopkeeper_id,shopkeeper_name,shopkeeper_password,ConfirmPassword,shopkeeper_address,shopkeeper_mobile_no,shopeeper_email,shop_start_date")] shopkeeper shopkeeper)
        {
            if (ModelState.IsValid)
            {
                db.Entry(shopkeeper).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(shopkeeper);
        }

        // GET: shopkeepers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            shopkeeper shopkeeper = db.shopkeepers.Find(id);
            if (shopkeeper == null)
            {
                return HttpNotFound();
            }
            return View(shopkeeper);
        }

        // POST: shopkeepers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            shopkeeper shopkeeper = db.shopkeepers.Find(id);
            db.shopkeepers.Remove(shopkeeper);
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
