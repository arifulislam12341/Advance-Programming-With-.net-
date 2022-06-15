using Lab3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lab3.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult ProductList()
        {
            var db = new DotnetpraacticeEntities();
            var products = db.Products.ToList();
            return View(products);
        }
        public ActionResult ProductDelete(int id)
        {
            var db = new DotnetpraacticeEntities();
            var product = (from p in db.Products where p.Id == id select p).SingleOrDefault();
            db.Products.Remove(product);
            db.SaveChanges();
            return RedirectToAction("ProductList");
        }
        public ActionResult ProductAdd()
        {
            return View();
        }
        [HttpPost]
        public ActionResult ProductAdd(Product obj)
        {
            if(ModelState.IsValid )
            {
                var totalprice=obj.Price*obj.Quantity;
                TempData["totalprice"]=totalprice;
                var db = new DotnetpraacticeEntities();
                db.Products.Add(obj);
                db.SaveChanges();
                return RedirectToAction("ProductList");
                
            }
            return View(obj);
        }
        public ActionResult ProductUpdate(int Id)
        {
            var db=new DotnetpraacticeEntities();
            var product = (from p in db.Products where p.Id == Id select p).SingleOrDefault();
            return View(product);
        }
        [HttpPost]
        public ActionResult ProductUpdate(Product obj)
        {
            if (ModelState.IsValid)
            {
                var db=new DotnetpraacticeEntities();
                var product = (from p in db.Products where p.Id == obj.Id select p).SingleOrDefault();
                db.Entry(product).CurrentValues.SetValues(obj);
                db.SaveChanges();
                return RedirectToAction("ProductList");
            }
            return View(obj);
        }
    }
}