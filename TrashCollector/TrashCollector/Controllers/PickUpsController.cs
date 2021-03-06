﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TrashCollector.Models;

namespace TrashCollector.Controllers
{
    public class PickUpsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: PickUps
        public ActionResult Index()
        {
            var pickUps = db.PickUps.Include(p => p.Customer);
            return View(pickUps.ToList());
        }

        // GET: PickUps/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PickUp pickUp = db.PickUps.Find(id);
            if (pickUp == null)
            {
                return HttpNotFound();
            }
            return View(pickUp);
        }

        // GET: PickUps/Create
        public ActionResult Create()
        {
            ViewBag.CustomerId = new SelectList(db.Customers, "Id", "Name");
            return View();
        }

        // POST: PickUps/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,WeekDay,CustomPickUp,PickUpComplete,CustomerId")] PickUp pickUp)
        {
            if (ModelState.IsValid)
            {
                db.PickUps.Add(pickUp);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CustomerId = new SelectList(db.Customers, "Id", "Name", pickUp.CustomerId);
            return View(pickUp);
        }

        // GET: PickUps/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PickUp pickUp = db.PickUps.Find(id);
            if (pickUp == null)
            {
                return HttpNotFound();
            }
            ViewBag.CustomerId = new SelectList(db.Customers, "Id", "Name", pickUp.CustomerId);
            return View(pickUp);
        }

        // POST: PickUps/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,WeekDay,CustomPickUp,PickUpComplete,CustomerId")] PickUp pickUp)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pickUp).State = EntityState.Modified;
                db.SaveChanges();
                if (pickUp.PickUpComplete == true)
                {
                    Customer customer = db.Customers.Where(n => n.Id == pickUp.CustomerId).SingleOrDefault();
                    customer.AccountBalance += 10;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }

        ViewBag.CustomerId = new SelectList(db.Customers, "Id", "Name", pickUp.CustomerId);
               
        return View(pickUp);
            
        }

        // GET: PickUps/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PickUp pickUp = db.PickUps.Find(id);
            if (pickUp == null)
            {
                return HttpNotFound();
            }
            return View(pickUp);
        }

        // POST: PickUps/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PickUp pickUp = db.PickUps.Find(id);
            db.PickUps.Remove(pickUp);
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
