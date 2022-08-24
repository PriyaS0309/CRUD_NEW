using CRUD_NEW.App_DbContext;
using CRUD_NEW.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace CRUD_NEW.Controllers
{
     
    public class LoginController : Controller
    {
        AppDbContext db = new AppDbContext();
        // GET: Login

        [AllowAnonymous]   // AllowAnonymous is used because we have globally authorized the application so to allow access login page we use AllowAnonymous
        public ActionResult Index()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public ActionResult Index(User u,string ReturnUrl)
        {
            if(IsValid(u)==true)
            {
                FormsAuthentication.SetAuthCookie(u.Username, false);
                Session["User"] = u.Username.ToString();

                if(ReturnUrl!=null)
                {
                    return Redirect(ReturnUrl);
                }
                else
                {
                    return RedirectToAction("Index", "Category");
                }

            }
            else
            {
                return View();
            }
           
        }

        public bool IsValid(User u)
        {
            var credentials = db.Users.Where(model => model.Username == u.Username && model.Password == u.Password).FirstOrDefault();
            return (u.Username == credentials.Username && u.Password == credentials.Password);
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            Session["User"] = null;
            return RedirectToAction("Index", "Category");
        }
    }
}