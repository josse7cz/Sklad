using DataAccess1.Model;
using Sklad.Class;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Web;
using System.Web.Mvc;
using DataAccess1.Dao;

namespace Sklad.Controllers
{

    // [Authorize]
    public class ItemsController : Controller
    {
        IItemsService _itemsService;
        public ItemsController()
        {
        }
        public ItemsController(IItemsService itemsService)
        {
            _itemsService = itemsService;
        }


        // GET: Polozky
        public ActionResult Index()
        {
            IDaoBase itemDao = new IDaoBase();
            IList<Item> items = itemDao.GetAll();
            UserDao userDao = new UserDao();
            User user = userDao.GetByLogin(User.Identity.Name);

            if (ViewBag.user != null)
            {
                ViewBag.user = user.Name;
            }
            return View(items);
        }

        public ActionResult Detail(int id)
        {
            IDaoBase itemDao = new IDaoBase();
            Item i = itemDao.GetById(id);


            if (i.Name != null)
            {
                return View(i);
            }

            var data = _itemsService.GetMyItems();

            return View(data);
        }

        public interface IItemsService
        {
            IEnumerable<Item> GetMyItems();
        }
    }
}