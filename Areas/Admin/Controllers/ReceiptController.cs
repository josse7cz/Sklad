using DataAccess1.Dao;
using DataAccess1.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Sklad.Areas.Admin.Controllers
{
    public class ReceiptController : Controller
    {
        // GET: Admin/Receipt
        public ActionResult Index()
        {

            ReceiptDao receiptDao = new ReceiptDao();
            IList<Receipt> receipts = receiptDao.GetAll();
             
                           
            return View(receipts);

        }


        public ActionResult GetPrice(int id)
        {
            ItemDao iDao = new ItemDao();

            if (id >= 0)
            {
                Item i = iDao.GetById(id);
                ViewBag.Price = i.Price;
            }


            return View();
        }


        public ActionResult Create(Receipt receipt, int itemId, int userId)
        {

            ItemDao iDao = new ItemDao();
            IList<Item> items = iDao.GetAll();
            ViewBag.Items = items;


            UserDao userDao = new UserDao();
            ViewBag.UserName = userDao.GetByLogin(User.Identity.Name);


            ReceiptDao receiptDao = new ReceiptDao();
            receipt.User_Id = userId;
            receipt.Item_Id = itemId;
            receiptDao.Create(receipt);
            TempData["message-success"] = "Položka byla přidána.";


            return View("Add",receipt);

        }
    }
}