using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess1.Interface;
using System.ComponentModel.DataAnnotations;
using System.Web.Security;
using NHibernate.Util;


namespace DataAccess1.Model
{
    public class User:MembershipUser,IEntity//misto Identity 

    {
        public virtual int Id { get; set; }
        [Required(ErrorMessage = "Jméno je vyžadováno")]//validace dat
        public virtual string Name { get; set; }
        [Required(ErrorMessage = "Příjmení je vyžadováno")]
        public virtual string Surname { get; set; }
      
        
        [Required(ErrorMessage = "Login je vyžadován")]
         public virtual string Login { get; set; }

        [Required(ErrorMessage = "Heslo je vyžadováno")]
        public virtual string Password { get; set; }
        
        public virtual Role Role { get; set; }
    }
}
