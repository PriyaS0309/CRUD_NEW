using CRUD_NEW.App_DbContext;
using CRUD_NEW.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
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
            var categories = db.Categories.ToList();
            return View(categories);
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
            var category = db.Categories.Where(model => model.ID == id).FirstOrDefault();
            if (category == null)
            {
                return HttpNotFound();
                //return Content("No Category Found");
            }

            return View(category);
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
            var category = db.Categories.Where(model => model.ID == id).FirstOrDefault();
            return View(category);
        }

        [HttpPost]
        public ActionResult Delete(Category c)
        {
            db.Entry(c).State = EntityState.Deleted;
            
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult CategoryIsActivate(int id)
        {
            var category = db.Categories.FirstOrDefault(model => model.ID == id);
            var products = db.Products.Where(model => model.Category_ID == category.ID).ToList();
            foreach (var product in products)
            {
                product.IsActive = false;
            }
            return View();
        }
    }
}