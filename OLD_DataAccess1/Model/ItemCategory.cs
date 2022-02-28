using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace DataAccess1.Model
{
   public class ItemCategory
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Název je vyžadován")]//validace dat
        public string CategoryName { get; set; }
        
        public string CategoryDescription { get; set; }
    }
}
