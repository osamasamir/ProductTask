using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Task.Models;
namespace Task.Controllers
{
    public class UsersController : Controller
    {
        ProductContext db = new ProductContext();

        // GET: User
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(User us)
        {
            Session["x"] = us.UserName;

            if (Membership.ValidateUser(us.UserName, us.UserPassword))
            {
                FormsAuthentication.SetAuthCookie(us.UserName, false);

                if (Roles.IsUserInRole(us.UserName, "authenticated user"))
                {
                    return RedirectToAction("index", "Products");
                }
                
            }
            TempData["z"] = "user name or password are not correct";

            return View();

        }

        [HttpGet]
        public ActionResult Regist()
        {

            return View();
        }
        [HttpPost]
        public ActionResult Regist(User us)
        {

            if (ModelState.IsValid)
            {
                Membership.CreateUser(us.UserName, us.UserPassword, us.UserEmail);
                Roles.AddUserToRole(us.UserName, "authenticated user");
                db.Users.Add(us);
                db.SaveChanges();
                return RedirectToAction("login", "Users");
            }
            else
            {
                return View(us);
            }
        }
    }
}