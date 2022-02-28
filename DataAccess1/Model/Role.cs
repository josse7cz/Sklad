using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess1.Interface;
using System.ComponentModel.DataAnnotations;
using System.Web.Security;

namespace DataAccess1.Model
{
    public class Role:IEntity
    {
        public virtual int Id { get; set; }
        [Required(ErrorMessage = "Identifikator je vyžadováno")]//validace dat
        public virtual string Identificator { get; set; }
        
        public virtual string RoleDescription { get; set; }

       
    }
}
