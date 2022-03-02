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
using System.Threading.Tasks;
using System.Net.Mail;

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
        public ActionResult ReservationView(int id)
        {

            Item i = itemDao.GetById(id);
            ViewBag.Name = i.Name;
            ViewBag.Id = i.Id;
            return View();

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Reservation(ReservationModel model)
        {
            if (ModelState.IsValid)
            {
                var mail = new MailMessage();
                //mail.To.Add(new MailAddress(model.SenderEmail));
                mail.To.Add("esell@post.cz");
                mail.Subject = "Dotaz z kontaktního formuláře aplikace na vozidlo";
                mail.Body = string.Format("<p>Email Od: {0} ({1})</p><p>Zpráva:</p><p>{2}</p>", model.SenderName, model.SenderEmail, model.Message);
                mail.IsBodyHtml = true;
                using (var smtp = new SmtpClient())
                {
                    await smtp.SendMailAsync(mail);
                    return RedirectToAction("SuccessMessage");
                }
            }
            return View();
        }

        public ActionResult SuccessMessage()
        {
            return View();
        }





        public ActionResult Reservation(int id)
        {
            Item i = itemDao.GetById(id);
            ViewBag.Id = id;

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