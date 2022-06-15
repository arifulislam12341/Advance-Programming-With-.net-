using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Student.Models;

namespace Student.Controllers
{
    public class StudentController : Controller
    {
        // GET: Student
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Students st)
        {
            var date = st.dob;
            var presentDate = DateTime.Now;
            var age = presentDate - date;
            var ageDays = age.TotalDays;


         
            if(ModelState.IsValid )
            {
                
                return RedirectToAction("Index");
            }
          return View(st);
        }
    }
}