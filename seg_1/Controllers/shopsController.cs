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
    public class shopsController : Controller
    {
        private seg_1Context db = new seg_1Context();

        // GET: shops
        public ActionResult Index()
        {
            var shops = db.shops.Include(s => s.shopkeeper);
            return View(shops.ToList());
        }

        // GET: shops/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            shop shop = db.shops.Find(id);
            if (shop == null)
            {
                return HttpNotFound();
            }
            return View(shop);
        }

        // GET: shops/Create
        public ActionResult Create()
        {
            ViewBag.shopkeeper_id = new SelectList(db.shopkeepers, "shopkeeper_id", "shopkeeper_name");
            return View();
        }

        // POST: shops/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "shop_id,shop_name,shop_address,shop_mobile_num,shopkeeper_id")] shop shop)
        {
            if (ModelState.IsValid)
            {
                db.shops.Add(shop);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.shopkeeper_id = new SelectList(db.shopkeepers, "shopkeeper_id", "shopkeeper_name", shop.shopkeeper_id);
            return View(shop);
        }

        // GET: shops/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            shop shop = db.shops.Find(id);
            if (shop == null)
            {
                return HttpNotFound();
            }
            ViewBag.shopkeeper_id = new SelectList(db.shopkeepers, "shopkeeper_id", "shopkeeper_name", shop.shopkeeper_id);
            return View(shop);
        }

        // POST: shops/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "shop_id,shop_name,shop_address,shop_mobile_num,shopkeeper_id")] shop shop)
        {
            if (ModelState.IsValid)
            {
                db.Entry(shop).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.shopkeeper_id = new SelectList(db.shopkeepers, "shopkeeper_id", "shopkeeper_name", shop.shopkeeper_id);
            return View(shop);
        }

        // GET: shops/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            shop shop = db.shops.Find(id);
            if (shop == null)
            {
                return HttpNotFound();
            }
            return View(shop);
        }

        // POST: shops/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            shop shop = db.shops.Find(id);
            db.shops.Remove(shop);
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
