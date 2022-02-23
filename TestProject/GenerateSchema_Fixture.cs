using DataAccess1.Model;
using NHibernate.Cfg;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate.Tool.hbm2ddl;


namespace TestProject
{
    class GenerateSchema_Fixture
    {
        [Test]
        public void Can_generate_schema()
        {
            var cfg = new Configuration();
            cfg.Configure();
            cfg.AddAssembly(typeof(Item).Assembly);

            new SchemaExport(cfg).Execute(true, false, false);
        }
    }
}
