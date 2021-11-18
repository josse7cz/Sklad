using DataAccess1.Dao;
using DataAccess1.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Sklad.Areas.Admin.Controllers
{
    [Authorize]
    public class MenuController : Controller
    {
        // GET: Admin/Menu
        [ChildActionOnly]//muze byt zavolano pouze zevnitr aplikace (ne prews prikazovy radek)
        public ActionResult Index()
        {

            UserDao userDao = new UserDao();
            User user = userDao.GetByLogin(User.Identity.Name);

             

            return View(user);
        }
    }
}