using DataAccess1.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Sklad.Areas.Admin.Controllers
{
    public class HomeController : Controller
    {
        // GET: Admin/Home
        public ActionResult Index()
        {
            return View();
        }

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

    }
}