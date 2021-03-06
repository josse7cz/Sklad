using DataAccess1.Dao;
using DataAccess1.Model;
using Sklad.Class;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Sklad.Areas.Admin.Controllers
{
    [Authorize]//vstup pouze přihlášený uživatel
    public class ItemsController : Controller
    {
        ItemDao itemDao = new ItemDao();
        ItemCategoryDao itemCategoryDao = new ItemCategoryDao();
        List<Result> result = new List<Result>();
        UserDao userDao = new UserDao();
        // Polozky
        public ActionResult Index(int? page)
        {
            int itemsOnPage = 4;//pocet polozeek na strance
            int pg = page.HasValue ? page.Value : 1;//pokud prijde hodnota bude pouzita a kdyz ne nastavi se na 1; TERNARNI DOTAZ
            int totalItems;//celokvy pocet polozek

            IList<Item> items = itemDao.GetPagedItems(itemsOnPage, pg, out totalItems);
            ViewBag.Pages = Math.Ceiling((double)totalItems / (double)itemsOnPage);  //vypocet poctu stranek + ceiling= zaokrouhlení nahoru
            ViewBag.Result = GetResult();//vrací počet items by category
            User user = userDao.GetByLogin(User.Identity.Name);//aktuálně přihlášený uživatel

            if (user.Name != null)
            {
                ViewBag.User = user.Name;

            }
            else
                user.Name = "Nepřihlášený uživatel";


            if (user.Role.Identificator == "customer")
            {
                return View("Customer", items);
            }

            return View(items);
        }

        //pocitani item by category osetreno proti pripadu, že kategory id  není poporade
        public IEnumerable<Result> GetResult()
        {
            IList<ItemCategory> itemCategories = itemCategoryDao.GetAll();
            List<int> Id = new List<int>();

            if (itemCategories != null)
            {
                foreach (ItemCategory i in itemCategories)//naplnění listu Id intovými Idečkami

                {
                    Id.Add(i.Id);
                }

                for (int i = 0; i < itemCategories.Count; i++)//vypočet kusů po categoriích
                {
                    int id = itemCategoryDao.GetById(Id[i]).Id;
                    String a = itemCategoryDao.GetById(Id[i]).CategoryName;
                    int b = itemDao.FilterItemsByCategory(Id[i]).Count;
                    result.Add(new Result(id, a, b));
                }
                ViewBag.Result = result;

                return result;
            }
            return null;
        }


        public ActionResult Search(string searchStr)//vyhledá položky dle zadaného stringu, používá metodu (SearchString) v ItemDao
        {
            IList<Item> items = itemDao.SearchItems(searchStr);
            User user = userDao.GetByLogin(User.Identity.Name);

            if (user.Role.Identificator == "customer")
            {
                return View("Customer", items);
            }
            return View(items);
        }

        public ActionResult Category(int id)//vraci pohled s kategorií dle kategory id 
        {
            IList<Item> items = new ItemDao().FilterItemsByCategory(id);
            ViewBag.Result = GetResult();
            return View("Customer", items);
        }

        public ActionResult CreateCategory()//pohled pro vytvoření kategorie
        {
            return View();
        }

        public ActionResult AddCategory(ItemCategory category) //metoda pro přidání kategorie používá add v itemcategorydao
        {
            if (ModelState.IsValid)
            {

                itemCategoryDao.Create(category);
            }

            return RedirectToAction("Index");
        }


        public ActionResult Detail(int id)//spusti pohled pro detail položky
        {
            Item i = itemDao.GetById(id);


            if (i.Name != null)
            {
                return View(i);
            }
            return View();
        }

        [Authorize(Roles = "seller, admin")]//metoda pouze pro prodavace a admina, pohled pro vytvoření nové položky
        public ActionResult Create()
        {
            IList<ItemCategory> categories = itemCategoryDao.GetAll();
            ViewBag.Categories = categories;
            return View();
        }

        [HttpPost]//metoda pro pridani polozky do DB
        public ActionResult Add(Item item, HttpPostedFileBase picture, int categoryId)
        {

            if (ModelState.IsValid)
            {

                if (picture != null)//pokud byl přiložen obrázek
                {

                    if (picture.ContentType == "image/jpeg" || picture.ContentType == "image/png")
                    {

                        Image image = Image.FromStream(picture.InputStream);

                        if (image.Width > 200 || image.Height > 200)
                        {

                            Image smallImage = ImageHelper.ScaleImage(image, 200, 200);
                            Bitmap b = new Bitmap(smallImage);
                            Guid guid = Guid.NewGuid();
                            string imageName = guid.ToString() + ".jpg";
                            b.Save(Server.MapPath("~/Uploads/Item/" + imageName), ImageFormat.Jpeg);
                            smallImage.Dispose();
                            b.Dispose();
                            item.ImageName = imageName;

                        }
                        else
                        {
                            picture.SaveAs(Server.MapPath("~/Uploads/Item/" + picture.FileName));
                        }
                    }
                }

                ItemCategory itemCategory = itemCategoryDao.GetById(categoryId);
                item.Category = itemCategory;
                itemDao.Create(item);

                TempData["message-success"] = "Položka byla přidána.";
            }
            else
            {
                return View("Create", item);
            }


            return RedirectToAction("Index");
        }

        [Authorize(Roles = "seller, admin")]
        [HttpGet]
        public ActionResult Edit(int id)
        {

            Item i = itemDao.GetById(id);
            ViewBag.Categories = itemCategoryDao.GetAll();

            return View(i);
        }
        [Authorize(Roles = "seller, admin")]
        [HttpPost]
        public ActionResult Update(Item item, HttpPostedFileBase picture, int categoryId)
        {
            try
            {

                ItemCategory itemCategory = itemCategoryDao.GetById(categoryId);
                item.Category = itemCategory;


                if (item.ImageName != null && picture != null)
                {
                    System.IO.File.Delete(Server.MapPath("~/Uploads/Item/" + item.ImageName));

                    if (picture != null)//kdyz prijde novy obrazek tak ho uprav a uloz do slozky
                    {

                        if (picture.ContentType == "image/jpeg" || picture.ContentType == "image/png")
                        {

                            Image image = Image.FromStream(picture.InputStream);
                            Guid guid = Guid.NewGuid();
                            string imageName = guid.ToString() + ".jpg";

                            if (image.Width > 200 || image.Height > 200)
                            {
                                Image smallImage = ImageHelper.ScaleImage(image, 200, 200);
                                Bitmap b = new Bitmap(smallImage);

                                b.Save(Server.MapPath("~/Uploads/Item/" + imageName), ImageFormat.Jpeg);
                                item.ImageName = imageName;
                                smallImage.Dispose();
                                b.Dispose();

                            }

                            else
                            {
                                picture.SaveAs(Server.MapPath("~/Uploads/Item/" + picture.FileName));
                                item.ImageName = picture.FileName;
                            }

                        }
                    }

                }

                itemDao.Update(item);

                TempData["message-success"] = "Položka " + item.Name + " byla editována.";

            }
            catch (Exception e)
            {
                TempData["message-allert"] = "Položka nebyla editována z důvodu: " + e + ".";
                throw;
            }

            return RedirectToAction("Index", "Items");

        }

        [Authorize(Roles = "seller, admin")]
        public ActionResult Delete(int id)
        {

            try
            {

                Item item = itemDao.GetById(id);

                if (item.ImageName != null)
                {
                    System.IO.File.Delete(Server.MapPath("~/Uploads/Item/" + item.ImageName));
                }

                itemDao.Delete(item);

                TempData["message-success"] = "Položka " + item.Name + " byla smazána.";
            }
            catch (Exception e)
            {
                TempData["message-allert"] = "Akce nebyla dokončena z důvodu: " + e + ".";
                Console.Write(e);
            }

            return RedirectToAction("Index");
        }

    }
}