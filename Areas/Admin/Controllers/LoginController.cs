using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Sklad.Areas.Admin.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SignIn(string login, string password)
        {
            if (Membership.ValidateUser(login, password))
            {
                FormsAuthentication.SetAuthCookie(login, false);
                return RedirectToAction("Index", "Items");
            }
            TempData["message-alert"] = "Nepodařilo se prihlasit.";
            return RedirectToAction("Index", "Login");

        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            Session.Clear();
            return RedirectToAction("Index", "Home", new { Areas = "" });
            

        }

    }
}