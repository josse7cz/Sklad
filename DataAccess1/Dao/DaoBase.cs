using DataAccess1.Interface;
using NHibernate;
using NHibernate.Criterion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess1.Dao
{

    /*implementace IDaoBase typ T je trida a 
     * implementuje ientity (vygenerovani metod dle rozhrani)
     *  metody pro CRUD ulohy
     */


    public class DaoBase<T> : IDaoBase<T> where T : class, IEntity
    {

        //pripojeni na session NHibernate
        protected ISession session;

        public DaoBase()
        {
            session = NHibernateHelper.Session;//nastavení na NHibernateHelper
        }



        public object Create(T entity)
        {
            object o;
            using (ITransaction transaction = session.BeginTransaction())
            {
                o = session.Save(entity);
                transaction.Commit();
            }
            return o;
        }

        public void Delete(T entity)
        {
            using (ITransaction transaction = session.BeginTransaction())
            {
                session.Delete(entity);
                transaction.Commit();
            }
        }

        public IList<T> GetAll()
        {
            return session.QueryOver<T>().List<T>();
        }

        public T GetById(int id)
        {

            return session.CreateCriteria<T>().Add(Restrictions.Eq("Id", id)).UniqueResult<T>();
        }

        public void Update(T entity)
        {
            using (ITransaction transaction = session.BeginTransaction())
            {
                session.Update(entity);
                transaction.Commit();
            }

        }
        public int GetCount()
        {
            return session.CreateCriteria<T>().SetProjection(Projections.RowCount()).UniqueResult<int>();
        }
    }

}
