using DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Sklad.Controllers
{
    public class ItemsController : Controller
    {
        // GET: Polozky
        public ActionResult Index()
        {
            //string pozdrav = "Hello world";
            //ViewBag.Pozdrav = pozdrav;

          


            return View(Item.GetFakeList);
        }

        public ActionResult Detail(int id)
        {

            Item i = (from Item item in Item.GetFakeList where item.Id == id select item).FirstOrDefault(); 


            return View(i);

        }

    }
}