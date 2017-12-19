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
    public class communicationsController : Controller
    {
        private seg_1Context db = new seg_1Context();

        // GET: communications
        public ActionResult Index()
        {
            var communications = db.communications.Include(c => c.distributor).Include(c => c.shopkeeper);
            return View(communications.ToList());
        }

        // GET: communications/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            communication communication = db.communications.Find(id);
            if (communication == null)
            {
                return HttpNotFound();
            }
            return View(communication);
        }

        // GET: communications/Create
        public ActionResult Create()
        {
            ViewBag.distributor_id = new SelectList(db.distributors, "distributor_id", "distributor_name");
            ViewBag.shopkeeper_id = new SelectList(db.shopkeepers, "shopkeeper_id", "shopkeeper_name");
            return View();
        }

        // POST: communications/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "communication_id,distributor_id,shopkeeper_id,message,msg_status,send_time")] communication communication)
        {
            if (ModelState.IsValid)
            {
                db.communications.Add(communication);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.distributor_id = new SelectList(db.distributors, "distributor_id", "distributor_name", communication.distributor_id);
            ViewBag.shopkeeper_id = new SelectList(db.shopkeepers, "shopkeeper_id", "shopkeeper_name", communication.shopkeeper_id);
            return View(communication);
        }

        // GET: communications/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            communication communication = db.communications.Find(id);
            if (communication == null)
            {
                return HttpNotFound();
            }
            ViewBag.distributor_id = new SelectList(db.distributors, "distributor_id", "distributor_name", communication.distributor_id);
            ViewBag.shopkeeper_id = new SelectList(db.shopkeepers, "shopkeeper_id", "shopkeeper_name", communication.shopkeeper_id);
            return View(communication);
        }

        // POST: communications/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "communication_id,distributor_id,shopkeeper_id,message,msg_status,send_time")] communication communication)
        {
            if (ModelState.IsValid)
            {
                db.Entry(communication).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.distributor_id = new SelectList(db.distributors, "distributor_id", "distributor_name", communication.distributor_id);
            ViewBag.shopkeeper_id = new SelectList(db.shopkeepers, "shopkeeper_id", "shopkeeper_name", communication.shopkeeper_id);
            return View(communication);
        }

        // GET: communications/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            communication communication = db.communications.Find(id);
            if (communication == null)
            {
                return HttpNotFound();
            }
            return View(communication);
        }

        // POST: communications/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            communication communication = db.communications.Find(id);
            db.communications.Remove(communication);
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
