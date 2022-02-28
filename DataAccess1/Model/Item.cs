using DataAccess1.Interface;
using DataAccess1.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace DataAccess1.Model
{
    public class Item : IEntity

    {

        public virtual int Id { get; set; }
        [Required(ErrorMessage = "Název je vyžadován")]//validace dat
        [DisplayName("Název")]
        public virtual string Name { get; set; }

        [Required(ErrorMessage = "Producent je vyžadován")]
        [DisplayName("Výrobce")]
        public virtual string Producer { get; set; }
        [Required(ErrorMessage = "Rok je vyžadován")]
        [Range(1960, 2022, ErrorMessage = "Rozsah není 1960-2022")]
        [DisplayName("Rok výroby")]
        public virtual int YearProduct { get; set; }
        [DisplayName("Cena")]
        [Required(ErrorMessage = "Cena je vyžadována")]
        public virtual int Price { get; set; }
        [DisplayName("Množství")]
        [Required(ErrorMessage = "Množství je vyžadováno")]
        [Range(1, 2000, ErrorMessage = "Rozsah není od 1 do 2000")]
        public virtual int Quantity { get; set; }

        [AllowHtml]//pro zachovani HTML je treba pridat system.mvc zavislost
        [DisplayName("Popisek")]

        public virtual string Description { get; set; }

        public virtual string ImageName { get; set; }
        [DisplayName("Kategorie")]
        public virtual ItemCategory Category { get; set; }

    }
}
