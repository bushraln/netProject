using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using netProject.Models;

namespace netProject.Controllers
{
    public class registStudent2CourseController : Controller
    {
        private dtcollegeEntities db = new dtcollegeEntities();

        // GET: registStudent2Course
        public ActionResult Index()
        {
            var registStudent2Course = db.registStudent2Course.Include(r => r.course).Include(r => r.Lecturer).Include(r => r.student);
            return View(registStudent2Course.ToList());
        }

        // GET: registStudent2Course/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            registStudent2Course registStudent2Course = db.registStudent2Course.Find(id);
            if (registStudent2Course == null)
            {
                return HttpNotFound();
            }
            return View(registStudent2Course);
        }



       /* public ActionResult UpdateG(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            registStudent2Course registStudent2Course = db.registStudent2Course.Find(id);
            if (registStudent2Course == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_course = new SelectList(db.courses, "Id", "day", registStudent2Course.id_course);
            ViewBag.Id_lecturer = new SelectList(db.Lecturers, "Id", "Id", registStudent2Course.Id_lecturer);
            ViewBag.id_student = new SelectList(db.students, "Id", "Id", registStudent2Course.id_student);
            return View(registStudent2Course);
        }*/

        // POST: registStudent2Course/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
       /* public ActionResult UpdateG([Bind(Include = "Id_lecturer,id_course,id_student")] registStudent2Course registStudent2Course)
        {
            if (ModelState.IsValid)
            {
                db.Entry(registStudent2Course).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_course = new SelectList(db.courses, "Id", "day", registStudent2Course.id_course);
            ViewBag.Id_lecturer = new SelectList(db.Lecturers, "Id", "Id", registStudent2Course.Id_lecturer);
            ViewBag.id_student = new SelectList(db.students, "Id", "Id", registStudent2Course.id_student);
            return View(registStudent2Course);
        }*/



        // GET: registStudent2Course/Create
        public ActionResult Create()
        {
            ViewBag.id_course = new SelectList(db.courses, "Id", "Id");
            ViewBag.Id_lecturer = new SelectList(db.Lecturers, "Id", "Id");
            ViewBag.id_student = new SelectList(db.students, "Id", "Id");
            return View();
        }

        // POST: registStudent2Course/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id_lecturer,id_course,id_student,FinalGrade")] registStudent2Course registStudent2Course)
        {
            registStudent2Course.FinalGrade = 0;
            if (ModelState.IsValid)
            {
                db.registStudent2Course.Add(registStudent2Course);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id_course = new SelectList(db.courses, "Id", "Id", registStudent2Course.id_course);
            ViewBag.Id_lecturer = new SelectList(db.Lecturers, "Id", "Id", registStudent2Course.Id_lecturer);
            ViewBag.id_student = new SelectList(db.students, "Id", "Id", registStudent2Course.id_student);
            
            return View(registStudent2Course);
        }

        // GET: registStudent2Course/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            registStudent2Course registStudent2Course = db.registStudent2Course.Find(id);
            if (registStudent2Course == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_course = new SelectList(db.courses, "Id", "Id", registStudent2Course.id_course);
            ViewBag.Id_lecturer = new SelectList(db.Lecturers, "Id", "Id", registStudent2Course.Id_lecturer);
            ViewBag.id_student = new SelectList(db.students, "Id", "Id", registStudent2Course.id_student);
            return View(registStudent2Course);
        }

        // POST: registStudent2Course/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id_lecturer,id_course,id_student")] registStudent2Course registStudent2Course)
        {
            if (ModelState.IsValid)
            {
                db.Entry(registStudent2Course).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_course = new SelectList(db.courses, "Id", "Id", registStudent2Course.id_course);
            ViewBag.Id_lecturer = new SelectList(db.Lecturers, "Id", "Id", registStudent2Course.Id_lecturer);
            ViewBag.id_student = new SelectList(db.students, "Id", "Id", registStudent2Course.id_student);
            return View(registStudent2Course);
        }


        public ActionResult UpdateG(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            registStudent2Course grade = db.registStudent2Course.Find(id);
            if (grade == null)
            {
                return HttpNotFound();
            }
            return View(grade);
        }

        public ActionResult UpdateGradeAdmin(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            registStudent2Course course = db.registStudent2Course.Find(id);
            if (course == null)
            {
                return HttpNotFound();
            }
            return View(course);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UpdategGradeAdmin([Bind(Include = "Id_lecturer,id_course,id_student,FinalGrade")] registStudent2Course course)
        {
            if (ModelState.IsValid)
            {
                db.Entry(course).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(course);
        }


        // GET: registStudent2Course/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            registStudent2Course registStudent2Course = db.registStudent2Course.Find(id);
            if (registStudent2Course == null)
            {
                return HttpNotFound();
            }
            return View(registStudent2Course);
        }

        // POST: registStudent2Course/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            registStudent2Course registStudent2Course = db.registStudent2Course.Find(id);
            db.registStudent2Course.Remove(registStudent2Course);
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
