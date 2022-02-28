using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess1.Model
{
    public class Result
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Count { get; set; }
        //public Result(string Name, int Count)
        //{
        //    this.Name = Name;
        //    this.Count = Count;
        //}
        public Result(int id, string Name, int Count)
        {
            this.Id = id;
            this.Name = Name;
            this.Count = Count;
        }
    }

}
