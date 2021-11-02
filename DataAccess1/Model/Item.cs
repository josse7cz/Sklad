using DataAccess.Model;
using DataAccess1.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace DataAccess.Model
{
    public class Item
    {

        public int Id { get; set; }
        [Required(ErrorMessage ="Název je vyžadován")]//validace dat
        public string Name { get; set; }
        [Required(ErrorMessage = "Producent je vyžadován")]
        public string Producer { get; set; }
        [Required(ErrorMessage = "Rok je vyžadován")]
        [Range(2000, 2050, ErrorMessage = "Rozsah není 2000-2050")]
        public int YearProduct { get; set; }

        [Required(ErrorMessage = "Cena je vyžadována")]
        public int Price { get; set; }
        [Required(ErrorMessage = "Producent je vyžadován")]
        [Range (1,2000,ErrorMessage = "Rozsah není od 1 do 2000")]
        public int Quantity { get; set; }

       [AllowHtml]
        public string Description { get; set; }

        public string ImageName { get; set; }

        public ItemCategory Category { get; set; }




    }
}
