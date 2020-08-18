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
    public class LecturersController : Controller
    {
        private dtcollegeEntities db = new dtcollegeEntities();

        // GET: Lecturers
        public ActionResult Index()
        {
            var lecturers = db.Lecturers.Include(l => l.registStudent2Course);
            return View(lecturers.ToList());
        }

        public ActionResult MySchedule()
        {
            return View();
        }

        [HttpPost]

        public ActionResult MySchedule(registStudent2Course rl)
        {
            using (dtcollegeEntities db = new dtcollegeEntities())
            {
                var obj = db.courses.Where(a => a.Id.Equals(rl.Id_lecturer));

                if (obj != null)
                {

                    return View(obj.ToList());
                    //eturn RedirectToAction("AdminRoom", "Admins");


                }
                else
                {
                    ModelState.AddModelError("", "The user name or password Inncrorect");

                }
            }

            var lecturers = db.Lecturers.Include(l => l.registStudent2Course);
            return View(lecturers.ToList());
        }

        public ActionResult GardeStudent()
        {
            var lecturers = db.Lecturers.Include(l => l.registStudent2Course);
            return View(lecturers.ToList());
        }

        public ActionResult LecturerRoom()
        {
            return View();
        }

        public ActionResult StudentAtCourse()
        {
            return View();
        }

        public ActionResult StudentAtCourse(course c)
        {
            /* var selectedItem = fruit.Fruits.Find(p => p.Value == fruit.FruitId.ToString());
             if (selectedItem != null)
             {
                 selectedItem.Selected = true;
                 ViewBag.Message = "Fruit: " + selectedItem.Text;
                 ViewBag.Message += "\\nQuantity: " + fruit.Quantity;
             }*/
            //var selectedItem = c.Id.Find(p => p.Value == fruit.FruitId.ToString());
            using (dtcollegeEntities db = new dtcollegeEntities())
            {
                var st = db.registStudent2Course.Where(a => a.id_course.Equals(c.Id));
                if (st != null)
                {
                    var st2 = db.registStudent2Course.Where(a => a.id_course.Equals(c.Id) && a.id_student != null);
                    return View(st2.ToList());
                }
                else
                {

                    ModelState.AddModelError("", "there is no student at the course");
                }
                return View(st.ToList());

            }

        }



        // GET: Lecturers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Lecturer lecturer = db.Lecturers.Find(id);
            if (lecturer == null)
            {
                return HttpNotFound();
            }
            return View(lecturer);
        }

        // GET: Lecturers/Create
        public ActionResult Create()
        {
           // ViewBag.Id = new SelectList(db.registStudent2Course, "Id_lecturer", "Id_lecturer");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,FirstName,LastName,UserName,password,Email")] Lecturer lecturer)
        {
            if (ModelState.IsValid)
            {
                db.Lecturers.Add(lecturer);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

           // ViewBag.Id = new SelectList(db.registStudent2Course, "Id_lecturer", "Id_lecturer", lecturer.Id);
            return View(lecturer);
        }

        // GET: Lecturers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Lecturer lecturer = db.Lecturers.Find(id);
            if (lecturer == null)
            {
                return HttpNotFound();
            }
            ViewBag.Id = new SelectList(db.registStudent2Course, "Id_lecturer", "Id_lecturer", lecturer.Id);
            return View(lecturer);
        }

        // POST: Lecturers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,FirstName,LastName,UserName,password,Email")] Lecturer lecturer)
        {
            if (ModelState.IsValid)
            {
                db.Entry(lecturer).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Id = new SelectList(db.registStudent2Course, "Id_lecturer", "Id_lecturer", lecturer.Id);
            return View(lecturer);
        }

        // GET: Lecturers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Lecturer lecturer = db.Lecturers.Find(id);
            if (lecturer == null)
            {
                return HttpNotFound();
            }
            return View(lecturer);
        }

        // POST: Lecturers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Lecturer lecturer = db.Lecturers.Find(id);
            db.Lecturers.Remove(lecturer);
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
