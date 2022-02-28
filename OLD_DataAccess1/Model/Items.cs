using DataAccess.Model;
using DataAccess1.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Model
{
    public class Items
    {
        private static List<Item> items = null;
        private static int counter = 5;

        public static int Counter
        {
            get { return ++counter; }

        }

        public static List<Item> GetFakeList
        {
            get
            {

                if (items == null)
                {
                    items = new List<Item>();
                    items.Add(new Item() { Id = 1, Name = "Párek", Price = 20, Producer = "Vodnany", Quantity = 1, YearProduct = 2000 });
                    items.Add(new Item() { Id = 2, Name = "Sýr", Price = 25, Producer = "Laktos", Quantity = 1, YearProduct = 2000 });
                    items.Add(new Item() { Id = 3, Name = "Banán", Price = 11, Producer = "Fruits", Quantity = 1, YearProduct = 2000 });
                    items.Add(new Item() { Id = 4, Name = "Buřt", Price = 8, Producer = "Vodnany", Quantity = 1, YearProduct = 2000 });
                    items.Add(new Item() { Id = 5, Name = "Klobas", Price = 40, Producer = "Vodnany", Quantity = 1, YearProduct = 2000 });
                }

                return items;
            }



        }
                

            //SqlConnection connection = new SqlConnection(@"Data Source=COOLMASTER2020\SQLEXPRESS;Initial Catalog=SkladDB;integrated security=SSPI;");
            


    }
}
