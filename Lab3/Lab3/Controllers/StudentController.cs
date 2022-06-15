using Lab3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lab3.Controllers
{
    public class StudentController : Controller
    {
        // GET: Student
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult StudentInfo()
        {
            var db = new DotnetpraacticeEntities();
            var student = db.Students.ToList();
            return View(student);

        }
        public ActionResult StudentDelete(int id)
        {
            var db = new DotnetpraacticeEntities();
            var student = (from p in db.Students where p.Id == id select p).SingleOrDefault();
            db.Students.Remove(student);
            db.SaveChanges();
            return RedirectToAction("StudentInfo");
        }
        public ActionResult StudentAdd()
        {
            return View();
        }

        [HttpPost]
        public ActionResult StudentAdd(Student obj)
        {
            if (ModelState.IsValid)
            {
                var db = new DotnetpraacticeEntities();

                db.Students.Add(obj);
                db.SaveChanges();
                return RedirectToAction("StudentInfo");
            }
            return View();  
        }
      
       
        public ActionResult StudentUpdate(int id)
        {
            var db = new DotnetpraacticeEntities();
            var student = (from p in db.Students where p.Id == id select p).SingleOrDefault();
            return View(student);
        }
        [HttpPost]
        public ActionResult StudentUpdate(Student obj)
        {
            if (ModelState.IsValid)
            {
                var db = new DotnetpraacticeEntities();
                var student = (from p in db.Students where p.Id == obj.Id select p).SingleOrDefault();
                db.Entry(student).CurrentValues.SetValues(obj);
                db.SaveChanges();
                return RedirectToAction("StudentInfo");
            }
            return View(obj);
        }

    }
}