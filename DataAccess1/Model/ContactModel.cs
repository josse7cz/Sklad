using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DataAccess1.Model
{
    public class ContactModel
    {
        [Required(ErrorMessage = "Jméno je vyžadováno"), Display(Name = "Vaše jméno"),StringLength(20,ErrorMessage ="Rozsah znaků 3 až 20",MinimumLength =3)]
        public string SenderName { get; set; }
        [Required(ErrorMessage = "Email je vyžadován"), Display(Name = "Váš email"), EmailAddress]
        public string SenderEmail { get; set; }
        [Required(ErrorMessage = "Nezadali jste zprávu."),Display(Name = "Text zprávy")]
        public string Message { get; set; }
    }
}