using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CV_TASK.Controllers
{
    public class CVController : Controller
    {
        // GET: CV
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Reference()
        { 
            return View(); 
        }
        public ActionResult Education()
        {
            return View();

        }
        public ActionResult Project()
        {
            return View();
        }
        public ActionResult Personal()
        {
            return View();
        }
    }
}