using CRUD_NEW.App_DbContext;
using CRUD_NEW.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CRUD_NEW.Controllers
{
    public class ProductController : Controller
    {
        AppDbContext db = new AppDbContext();
        // GET: Product
        public ActionResult Index()
        {
            //ViewBag.Categories = db.Categories.ToList();
            var data = db.Products.ToList();
            return View(data);
        }

        public ActionResult Create()
        {
            ViewBag.Categories = db.Categories.ToList(); 
            return View();
        }

        [HttpPost]

        public ActionResult Create(Product p)
        {
            
            db.Products.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            ViewBag.Category_ID = new SelectList(db.Categories, "ID", "Name");
            var row = db.Products.Where(model => model.ID == id).FirstOrDefault();            
            return View(row);
        }

        [HttpPost]

        public ActionResult Edit(Product p)
        {
            db.Entry(p).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }


        public ActionResult Delete(int id)
        {
            var db_row = db.Products.Where(model => model.ID == id).FirstOrDefault();
            return View(db_row);
        }

        [HttpPost]

        public ActionResult Delete(Product p)
        {
            db.Entry(p).State = EntityState.Deleted;
            db.SaveChanges();
            return RedirectToAction("Index");
        }



    }
}