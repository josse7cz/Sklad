using NHibernate;
using NHibernate.Cfg;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess1
{
    public class NHibernateHelper
    {
        //Session objekt zaklad pro session factory-Singlton
        private static ISessionFactory _factory;

        public static ISession session
        {
            get
            {
                if (_factory == null)
                {
                    var cfg = new Configuration();
                    _factory = cfg.Configure(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "hibernate.cfg.xml")).BuildSessionFactory();
                }
                return _factory.OpenSession();
            }

        }



    }
}
