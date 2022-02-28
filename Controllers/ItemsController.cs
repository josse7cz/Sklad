using DataAccess1.Model;
using Sklad.Class;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Web;
using System.Web.Mvc;
using DataAccess1.Dao;
using System.Linq;

namespace Sklad.Controllers
{

    // [Authorize]
    public class ItemsController : Controller
    {
        ItemDao itemDao = new ItemDao();
        ItemCategoryDao itemCategoryDao = new ItemCategoryDao();
        List<Result> result = new List<Result>();
        UserDao userDao = new UserDao();
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
            IList<Item> items = itemDao.GetAll();
            IList<ItemCategory> itemCategories = itemCategoryDao.GetAll();
            List<int> Id = new List<int>();//Id už nejdou po sobě od nuly, třeba mít jejich seznam pro indexaci

            if (itemCategories != null)
            {

                foreach (ItemCategory i in itemCategories)

                {
                    Id.Add(i.Id);
                }
                for (int i = 0; i < itemCategories.Count; i++)
                {
                    int id = itemCategoryDao.GetById(Id[i]).Id;
                    String a = itemCategoryDao.GetById(Id[i]).CategoryName;
                    int b = itemDao.FilterItemsByCategory(Id[i]).Count;
                    result.Add(new Result(id, a, b));

                }
                ViewBag.Result = result;

            }
            User user = userDao.GetByLogin(User.Identity.Name);

            if (ViewBag.user != null)
            {
                ViewBag.user = user.Name;
            }

            return View(items);
        }

        public ActionResult Detail(int id)
        {
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