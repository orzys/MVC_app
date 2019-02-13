using BlogApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace BlogApp.Controllers
{
    [AllowAnonymous]
    public class AccountController : Controller
    {
        private BlogContext db = new BlogContext();
        // GET: Account
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(User U)
        {
            var count = db.Users.Where(x => x.Username == U.Username && x.Password == U.Password).Count();
            if(count == 0)
            {
                return View();
            }
            else
            {
                FormsAuthentication.SetAuthCookie(U.Username, false);
                return RedirectToAction("Index", "Posts");
            }
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }
    }
}