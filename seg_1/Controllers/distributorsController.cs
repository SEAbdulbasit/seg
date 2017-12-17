﻿using System;
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
    public class distributorsController : Controller
    {
        private seg_1Context db = new seg_1Context();

        // GET: distributors
        public ActionResult Index()
        {
            return View(db.distributors.ToList());
        }

        // GET: distributors/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            distributor distributor = db.distributors.Find(id);
            if (distributor == null)
            {
                return HttpNotFound();
            }
            return View(distributor);
        }

        // GET: distributors/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: distributors/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "distributor_id,distributor_name,distributor_password,distributor_address,distribbutor_mobile_no,distributor_email,distributior_start_date")] distributor distributor)
        {
            if (ModelState.IsValid)
            {
                db.distributors.Add(distributor);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(distributor);
        }

        // GET: distributors/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            distributor distributor = db.distributors.Find(id);
            if (distributor == null)
            {
                return HttpNotFound();
            }
            return View(distributor);
        }

        // POST: distributors/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "distributor_id,distributor_name,distributor_password,distributor_address,distribbutor_mobile_no,distributor_email,distributior_start_date")] distributor distributor)
        {
            if (ModelState.IsValid)
            {
                db.Entry(distributor).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(distributor);
        }

        // GET: distributors/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            distributor distributor = db.distributors.Find(id);
            if (distributor == null)
            {
                return HttpNotFound();
            }
            return View(distributor);
        }

        // POST: distributors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            distributor distributor = db.distributors.Find(id);
            db.distributors.Remove(distributor);
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
