using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SchoolSystem.Models;

namespace SchoolSystem.Controllers
{
    [Authorize]
    public class AllocateClassroomsController : Controller
    {
        private uniEntities db = new uniEntities();

        // GET: AllocateClassrooms
        public ActionResult Index()
        {
            var allocateClassrooms = db.AllocateClassrooms.Include(a => a.Course);
            return View(allocateClassrooms.ToList());
        }

        // GET: AllocateClassrooms/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AllocateClassroom allocateClassroom = db.AllocateClassrooms.Find(id);
            if (allocateClassroom == null)
            {
                return HttpNotFound();
            }
            return View(allocateClassroom);
        }

        // GET: AllocateClassrooms/Create
        public ActionResult Create()
        {
            ViewBag.CourseId = new SelectList(db.Courses, "CourseId", "CourseName");
            return View();
        }

        // POST: AllocateClassrooms/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ClassId,CourseId,FromTime,ToTime,Action")] AllocateClassroom allocateClassroom)
        {
            if (ModelState.IsValid)
            {
                db.AllocateClassrooms.Add(allocateClassroom);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CourseId = new SelectList(db.Courses, "CourseId", "CourseName", allocateClassroom.CourseId);
            return View(allocateClassroom);
        }

        // GET: AllocateClassrooms/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AllocateClassroom allocateClassroom = db.AllocateClassrooms.Find(id);
            if (allocateClassroom == null)
            {
                return HttpNotFound();
            }
            ViewBag.CourseId = new SelectList(db.Courses, "CourseId", "CourseName", allocateClassroom.CourseId);
            return View(allocateClassroom);
        }

        // POST: AllocateClassrooms/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ClassId,CourseId,FromTime,ToTime,Action")] AllocateClassroom allocateClassroom)
        {
            if (ModelState.IsValid)
            {
                db.Entry(allocateClassroom).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CourseId = new SelectList(db.Courses, "CourseId", "CourseName", allocateClassroom.CourseId);
            return View(allocateClassroom);
        }

        // GET: AllocateClassrooms/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AllocateClassroom allocateClassroom = db.AllocateClassrooms.Find(id);
            if (allocateClassroom == null)
            {
                return HttpNotFound();
            }
            return View(allocateClassroom);
        }

        // POST: AllocateClassrooms/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AllocateClassroom allocateClassroom = db.AllocateClassrooms.Find(id);
            db.AllocateClassrooms.Remove(allocateClassroom);
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
