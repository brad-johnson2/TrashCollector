using Microsoft.AspNet.Identity;
using System;
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
    public class EmployeesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Employees
        public ActionResult Index()
        {
            var FoundUserId = User.Identity.GetUserId();
            var employeeUser = db.Employees.Where(x => x.ApplicationUserId == FoundUserId).FirstOrDefault();
            var DayPickUps = db.PickUps.Where(p => p.Customer.CustZip == employeeUser.EmpZip);

            return View(DayPickUps.ToList());
        }

        // GET: Employees/Details/5
        public ActionResult Details(int? id)
        {
            var FoundUserId = User.Identity.GetUserId();

            Employee employee = db.Employees.Include(m => m.ApplicationUser).Where(c => c.ApplicationUserId == FoundUserId).FirstOrDefault();

            if (id == null)
            {
                var FoundEmployee = db.Employees.Where(c => c.ApplicationUserId == FoundUserId).FirstOrDefault();
                return View(FoundEmployee);

                //return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            
            //if (employee == null)
            //{
            //    return HttpNotFound();
            //}
            return View(employee);
        }

        // GET: Employees/Create
        public ActionResult Create()
        {
            Employee employee = new Employee();
            var FoundUserId = User.Identity.GetUserId();

            employee.ApplicationUserId = FoundUserId;
            db.SaveChanges();
            return View(employee);
        }

        // POST: Employees/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,EmpZip,ApplicationUserId")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                db.Employees.Add(employee);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(employee);
        }

        // GET: Employees/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                var FoundUserId = User.Identity.GetUserId();
                var FoundEmployee = db.Employees.Where(c => c.ApplicationUserId == FoundUserId).FirstOrDefault();
                return View(FoundEmployee);
            }
            Employee employee = db.Employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        // POST: Employees/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,EmpZip")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                db.Entry(employee).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(employee);
        }

        // GET: Employees/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = db.Employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        // POST: Employees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Employee employee = db.Employees.Find(id);
            db.Employees.Remove(employee);
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
