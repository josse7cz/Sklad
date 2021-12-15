using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;
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
            UserDao userDao = new UserDao();
            User user = userDao.GetByLogin(User.Identity.Name);

            return View();
        }
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        //contact form

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Contact(ContactModel model)
        {
            if (ModelState.IsValid)
            {
                var mail = new MailMessage();
                //mail.To.Add(new MailAddress(model.SenderEmail));
                mail.To.Add("esell@post.cz");
                mail.Subject = "Dotaz z kontaktního formuláře aplikace";
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


    }
}