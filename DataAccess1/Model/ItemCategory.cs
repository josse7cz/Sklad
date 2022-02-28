using System;
using System.Collections.Generic;
using DataAccess1.Interface;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace DataAccess1.Model
{
    public class ItemCategory : IEntity
    {
        public virtual int Id { get; set; }
        [Required(ErrorMessage = "Název je vyžadován")]//validace dat
        public virtual string CategoryName { get; set; }
        [AllowHtml]
        public virtual string CategoryDescription { get; set; }

        // public virtual int? Count { get; set; }
    }
}
