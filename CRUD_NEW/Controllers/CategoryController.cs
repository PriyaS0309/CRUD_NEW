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
    public class CategoryController : Controller
    {
        AppDbContext db = new AppDbContext();
        // GET: Category
        public ActionResult Index()
        {
            var data = db.Categories.ToList();
            return View(data);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]

        public ActionResult Create(Category c)
        {
            db.Categories.Add(c);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            var row = db.Categories.Where(model => model.ID == id).FirstOrDefault();
            return View(row);
        }

        [HttpPost]
        public ActionResult Edit(Category c)
        {
            db.Entry(c).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            var db_row = db.Categories.Where(model => model.ID == id).FirstOrDefault();
            return View(db_row);
        }

        [HttpPost]
        public ActionResult Delete(Category c)
        {
            db.Entry(c).State = EntityState.Deleted;
            db.SaveChanges();
            return RedirectToAction("Index");
        }





    }
}