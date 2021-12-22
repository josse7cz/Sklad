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
            ItemDao itemDao = new ItemDao();
            IList<Item> items = itemDao.GetAll();



            UserDao userDao = new UserDao();
            User user = userDao.GetByLogin(User.Identity.Name);

            if(ViewBag.user != null){
              ViewBag.user = user.Name; 
            } 
            

            return View(items);
        }

        public ActionResult Detail(int id)
        {

            //Item i = (from Item item in Items.GetFakeList where item.Id == id select item).FirstOrDefault();

            ItemDao itemDao = new ItemDao();
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
        //[Authorize(Roles = "seller, admin")]
        //public ActionResult Create()
        //{
        //    ItemCategoryDao iDao = new ItemCategoryDao();
        //    IList<ItemCategory> categories = iDao.GetAll();
        //    ViewBag.Categories = categories;
        //    return View();
        //}


        //[HttpPost]
        //public ActionResult Add(Item item, HttpPostedFileBase picture, int categoryId)
        //{

        //    if (ModelState.IsValid)
        //    {


        //        if (picture != null)
        //        {


        //            if (picture.ContentType == "image/jpeg" || picture.ContentType == "image/png")
        //            {

        //                Image image = Image.FromStream(picture.InputStream);

        //                if (image.Width > 200 || image.Height > 200)
        //                {

        //                    Image smallImage = ImageHelper.ScaleImage(image, 200, 200);
        //                    Bitmap b = new Bitmap(smallImage);
        //                    Guid guid = Guid.NewGuid();
        //                    string imageName = guid.ToString() + ".jpg";
        //                    b.Save(Server.MapPath("~/Uploads/Item/" + imageName), ImageFormat.Jpeg);

        //                    smallImage.Dispose();
        //                    b.Dispose();

        //                    item.ImageName = imageName;

        //                }
        //                else
        //                {
        //                    picture.SaveAs(Server.MapPath("~/Uploads/Item/" + picture.FileName));
        //                }


        //            }

        //        }

        //        ItemCategoryDao itemCategoryDao = new ItemCategoryDao();
        //        ItemCategory itemCategory = itemCategoryDao.GetById(categoryId);
        //        item.Category = itemCategory;

        //        ItemDao iDao = new ItemDao();
        //        iDao.Create(item);

        //        TempData["message-success"] = "Položka byla přidána.";
        //    }
        //    else
        //    {
        //        return View("Create", item);
        //    }


        //    return RedirectToAction("Index");
        //}

        //[Authorize(Roles = "seller, admin")]
        //[HttpGet]
        //public ActionResult Edit(int id)
        //{

        //    ItemDao itemDao = new ItemDao();
        //    ItemCategoryDao itemCategoryDao = new ItemCategoryDao();

        //    Item i = itemDao.GetById(id);
        //    ViewBag.Categories = itemCategoryDao.GetAll();




        //    return View(i);
        //}
        //[Authorize(Roles = "seller, admin")]
        //[HttpPost]
        //public ActionResult Update(Item item, HttpPostedFileBase picture, int categoryId)
        //{
        //    try
        //    {
        //        ItemDao itemDao = new ItemDao();
        //        ItemCategoryDao itemCategoryDao = new ItemCategoryDao();
        //        ItemCategory itemCategory = itemCategoryDao.GetById(categoryId);
        //        item.Category = itemCategory;

        //        if (picture != null)
        //        {

        //            if (picture.ContentType == "image/jpeg" || picture.ContentType == "image/png")
        //            {

        //                Image image = Image.FromStream(picture.InputStream);

        //                Guid guid = Guid.NewGuid();
        //                string imageName = guid.ToString() + ".jpg";


        //                if (image.Width > 200 || image.Height > 200)
        //                {

        //                    Image smallImage = ImageHelper.ScaleImage(image, 200, 200);
        //                    Bitmap b = new Bitmap(smallImage);

        //                    b.Save(Server.MapPath("~/Uploads/Item/" + imageName), ImageFormat.Jpeg);//kdyztak chyba tu?

        //                    smallImage.Dispose();
        //                    b.Dispose();
        //                    picture.SaveAs(Server.MapPath("~/Uploads/Item/" + picture.FileName));
        //                }

        //                else
        //                {

        //                    System.IO.File.Delete(Server.MapPath("~/Uploads/Item/" + imageName));

        //                    item.ImageName = imageName;

        //                }


        //            }

        //        }


        //        itemDao.Update(item);

        //        TempData["message-success"] = "Položka " + item.Name + " byla editována.";

        //    }
        //    catch (Exception)
        //    {
        //        //TempData["message-allert"] = "Položka nebyla editována.";
        //        throw;
        //    }

        //    return RedirectToAction("Index", "Items");

        //}

        //[Authorize(Roles = "seller, admin")]
        //public ActionResult Delete(int id)
        //{

        //    try
        //    {
        //        ItemDao itemDao = new ItemDao();
        //        Item item = itemDao.GetById(id);

        //        if (item.ImageName != null)
        //        {
        //            System.IO.File.Delete(Server.MapPath("~/Uploads/Item/" + item.ImageName));
        //        }

        //        itemDao.Delete(item);

        //        TempData["message-success"] = "Položka " + item.Name + " byla smazána.";
        //    }
        //    catch (Exception e)
        //    {
        //        //dodelat vyjimku
        //        //throw;
        //        Console.Write(e);
        //    }

        //    return RedirectToAction("Index");

        // }

    }
}