using DataAccess1.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate.Criterion;
using NHibernate.Transform;
using NHibernate.SqlCommand;
using NHibernate;

namespace DataAccess1.Dao
{
    public class ItemDao : DaoBase<Item>
    {
        public ItemDao() : base()//dedení z předka
        {
        }
        public IList<Item> GetPagedItems(int count, int page, out int totalItems)//metoda pro nacitani rozumneho mnozstvi polozek z databaze
        {
            totalItems = session.CreateCriteria<Item>()
                 .SetProjection(Projections.RowCount())
                 .UniqueResult<int>();

            return session.CreateCriteria<Item>()//vypocet pro nastaveni indexu prvniho prvku na vybrané stránce 
                .AddOrder(Order.Asc("Name"))
                .SetFirstResult((page - 1) * count)
                .SetMaxResults(count)
                .List<Item>();
        }

        public Item GetById(int? id)
        {
            //throw new NotImplementedException();

            return session.CreateCriteria<Item>().Add(Restrictions.Eq("Id", id)).UniqueResult<Item>();
        }


        public IList<Item> SearchItems(string searchStr)//metoda pro nacitani rozumneho mnozstvi polozek z databaze
        {
            return session.CreateCriteria<Item>()
                .Add(Restrictions
                .Like("Name", string.Format("%{0}%", searchStr)))
                .List<Item>();
        }

        public IList<Item> FilterItemsByCategory(int id)//metoda pro nacitani dle categorie
        {
            return session.CreateCriteria<Item>()
                .CreateAlias("Category", "cat")
                .Add(Restrictions.Eq("cat.Id", id))
                .List<Item>();
        }
        //public IList<Result> TestItems3()

        //{
        //    var countByProduct = (from od in session.Query<Item>()
        //                          group od by od.Category.CategoryName into p
        //                          select new { Product = p.Key, Count = p.Count() });

        //    return session.CreateQuery("select od.Item, count(od) from Item od group by od.Item.Category").List<Result>();
        //    //return null;
        //}

        //public IList<Result> TestCountItemsByCategory()
        //{
        //    var countByProduct = (from od in session.Query<Item>()
        //                          group od by od.Category.CategoryName into p
        //                          select new { Product = p.Key, Count = p.Count() }).ToList();

        //    return null;    // null otherwise call error
        //}
        ////grouping and counting 
        //public IList<Result> TestItems3()
        //{
        //    var countByProduct = session.CreateQuery(
        //"select od.Item.Category.CategoryName, count(od) from Category od group by od.Item.Category.CategoryName").List<Object[]>();
        //    return null;
        //}
        //public IEnumerable<Result> TestItems3()
        //{
        //    var personsPerLetter = session.Query<Item>()
        //                            .GroupBy(p => p.Category.CategoryName)
        //                            .Select(g => new { Id = g.Key, Count = g.Count() });
        //    return null;
        //}
        public IList<Result> TestItems3()
        {

            var query = session.CreateSQLQuery("SELECT c.categoryid, c.categoryname, COUNT(p.categoryid) "
                + "FROM `categories` c " +
                "LEFT JOIN `products` p" +
                "ON c.categoryid = p.categoryid" +
                "GROUP BY c.categoryid;");
            //var countByProduct = session.CreateQuery("select od.Product.Name, count(od) from OrderDetail od group by od.Product.Name").List<Result[]>(); 



            query.AddEntity("l", typeof(Item));

            return query.List<Result>();
        }

    }
}
