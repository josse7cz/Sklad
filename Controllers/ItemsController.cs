using DataAccess1.Model;
using DataAccess.Model;
using Sklad.Class;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
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
           
            return View(Items.GetFakeList);
        }

        public ActionResult Detail(int id)
        {

            Item i = (from Item item in Items.GetFakeList where item.Id == id select item).FirstOrDefault();


            return View(i);

        }

        public ActionResult Create()
        {

            return View();
        }
        [HttpPost]
        public ActionResult Add1(string name, int price, string producer, int quantity, int yearproduct)
        {
            Item i = new Item() { Name = name, Price = price, Producer = producer, Quantity = quantity, YearProduct = yearproduct, Id = Items.Counter };
            Items.GetFakeList.Add(i);

            return RedirectToAction("Index");
        }
        [HttpPost]
        public ActionResult Add(Item item, HttpPostedFileBase picture)
        {

            if (ModelState.IsValid)
            {


                if (picture != null)
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
                            b.Save(Server.MapPath("~/Uploads/Item" + imageName), ImageFormat.Jpeg);

                            smallImage.Dispose();
                            b.Dispose();

                            item.ImageName = imageName;

                        }
                        else
                        {
                            picture.SaveAs(Server.MapPath("~/Uploads/Item" + picture.FileName));
                        }


                    }

                }
                item.Id = Items.Counter;
                Items.GetFakeList.Add(item);

                TempData["message-success"] = "Položka byla přidána.";
            }
            else
            {
                return View("Create", item);
            }


            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {

            Item i = (from Item item in Items.GetFakeList where item.Id == id select item).FirstOrDefault();

            Items.GetFakeList.Remove(i);

            return View();

        }

    }
}