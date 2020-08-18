using netProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace netProject.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult LoginStudent()
        {
            return View();
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LoginStudent(student objchk)
        {
            if (ModelState.IsValid)
            {
                using (dtcollegeEntities db = new dtcollegeEntities())
                {
                    var obj = db.students.Where(a => a.UserName.Equals(objchk.UserName) && a.password.Equals(objchk.password)).FirstOrDefault();

                    if (obj != null)
                    {

                        Session["userID"] = obj.Id.ToString();
                        Session["userName"] = obj.UserName.ToString();
                        return RedirectToAction("StudentRoom", "students");


                    }
                    else
                    {
                        ModelState.AddModelError("", "The user name or password Inncrorect");

                    }
                }

            }
            return View(objchk);
        } 

        public ActionResult LoginLecturer()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LoginLecturer(Lecturer objchk)
        {
            if (ModelState.IsValid)
            {
                using (dtcollegeEntities db = new dtcollegeEntities())
                {
                    var obj = db.Lecturers.Where(a => a.UserName.Equals(objchk.UserName) && a.password.Equals(objchk.password)).FirstOrDefault();

                    if (obj != null)
                    {

                        Session["userID"] = obj.Id.ToString();
                        Session["userName"] = obj.UserName.ToString();
                        return RedirectToAction("LectuererRoom", "Lecturers");


                    }
                    else
                    {
                        ModelState.AddModelError("", "The user name or password Inncrorect");

                    }
                }

            }
            return View(objchk);
        }

        public ActionResult LoginAdmin()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LoginAdmin(Admin objchk)
        {
            if (ModelState.IsValid)
            {
                using (dtcollegeEntities db = new dtcollegeEntities())
                {
                    var obj = db.Admins.Where(a => a.UserName.Equals(objchk.UserName) && a.Password.Equals(objchk.Password)).FirstOrDefault();

                    if (obj != null)
                    {

                        Session["userID"] = obj.Id.ToString();
                        Session["userName"] = obj.UserName.ToString();
                        return RedirectToAction("AdminRoom", "Admins");


                    }
                    else
                    {
                        ModelState.AddModelError("", "The user name or password Inncrorect");

                    }
                }

            }
            return View(objchk);
        }
    }
}