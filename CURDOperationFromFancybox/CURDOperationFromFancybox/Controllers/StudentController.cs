using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CURDOperationFromFancybox.Models;

namespace CURDOperationFromFancybox.Controllers
{
    [RoutePrefix("StudentInformation")]
    public class StudentController : Controller
    {
        private DbConnectionContext db = new DbConnectionContext();
        [Route("Index")]
        public ActionResult Index()
        {
            return View(db.Students.ToList());
        }

        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StudentInformation studentinformation = db.Students.Find(id);
            if (studentinformation == null)
            {
                return HttpNotFound();
            }
            return View(studentinformation);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,FirstName,LastName,Course,PhoneNo")] StudentInformation studentinformation)
        {
            if (ModelState.IsValid)
            {
                studentinformation.ID = Guid.NewGuid();
                db.Students.Add(studentinformation);
                db.SaveChanges();
                return Content("success");
            }
            return View(studentinformation);
        }

        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StudentInformation studentinformation = db.Students.Find(id);
            if (studentinformation == null)
            {
                return HttpNotFound();
            }
            return View(studentinformation);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,FirstName,LastName,Course,PhoneNo")] StudentInformation studentinformation)
        {
            if (ModelState.IsValid)
            {
                db.Entry(studentinformation).State = EntityState.Modified;
                db.SaveChanges();
                return Content("success");
            }
            return View(studentinformation);
        }

        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StudentInformation studentinformation = db.Students.Find(id);
            if (studentinformation == null)
            {
                return HttpNotFound();
            }
            return View(studentinformation);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            StudentInformation studentinformation = db.Students.Find(id);
            db.Students.Remove(studentinformation);
            db.SaveChanges();
            return Content("success");
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
