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
    public class regional_managerController : Controller
    {
        private seg_1Context db = new seg_1Context();

        // GET: regional_manager
        public ActionResult Index()
        {
            return View(db.regional_manager.ToList());
        }

        // GET: regional_manager/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            regional_manager regional_manager = db.regional_manager.Find(id);
            if (regional_manager == null)
            {
                return HttpNotFound();
            }
            return View(regional_manager);
        }

        // GET: regional_manager/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: regional_manager/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "regional_manager_id,regional_manager_name,regional_manager_password,ConfirmPassword,regional_manager_mobile_no,regional_manager_email,regional_manager_start_date,distributor_id")] regional_manager regional_manager)
        {
            if (ModelState.IsValid)
            {
                db.regional_manager.Add(regional_manager);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(regional_manager);
        }

        // GET: regional_manager/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            regional_manager regional_manager = db.regional_manager.Find(id);
            if (regional_manager == null)
            {
                return HttpNotFound();
            }
            return View(regional_manager);
        }

        // POST: regional_manager/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "regional_manager_id,regional_manager_name,regional_manager_password,ConfirmPassword,regional_manager_mobile_no,regional_manager_email,regional_manager_start_date,distributor_id")] regional_manager regional_manager)
        {
            if (ModelState.IsValid)
            {
                db.Entry(regional_manager).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(regional_manager);
        }

        // GET: regional_manager/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            regional_manager regional_manager = db.regional_manager.Find(id);
            if (regional_manager == null)
            {
                return HttpNotFound();
            }
            return View(regional_manager);
        }

        // POST: regional_manager/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            regional_manager regional_manager = db.regional_manager.Find(id);
            db.regional_manager.Remove(regional_manager);
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
