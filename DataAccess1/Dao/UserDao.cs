using DataAccess1.Model;
using NHibernate.Criterion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess1.Dao
{
    public class UserDao:DaoBase<User>
    {
        public User GetByLoginAndPassword(string login, string password)
        {
            return session.CreateCriteria<User>()//conjunction and disjunction možno i pro vyhledavaní
                .Add(Restrictions.Eq("Login", login))
                .Add(Restrictions.Eq("Password", password))
                .UniqueResult<User>();
        }

        public User GetByLogin(string login)
        {
            return session.CreateCriteria<User>()//conjunction and disjunction možno i pro vyhledavaní
                .Add(Restrictions.Eq("Login", login))
                .UniqueResult<User>();
        }
    }
}
