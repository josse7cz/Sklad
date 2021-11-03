using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataAccess1.Dao;
using DataAccess1.Model;

namespace Sklad.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
         {
            //ItemCategoryDao iDao = new ItemCategoryDao();
            //IList<ItemCategory> categories = iDao.GetAll();
           

            //ItemCategory ic = new ItemCategory();
            //ic.CategoryName = "šlapadlo";
            //ic.CategoryDescription = "vlastní pohon";
            //iDao.Create(ic);
           


            return View();
        }
       

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}