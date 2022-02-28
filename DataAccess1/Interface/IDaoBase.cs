using DataAccess1.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess1.Interface
{
    //nezavisle co do listu prijde jedna se tedy o mozne vyuziti pro tridy jez to budou implementovat
    //slucuje zakladni entity pro CRUD operacemi
    interface IDaoBase<T>
    {
        IList<T> GetAll();
        object Create(T entity);

        void Update(T entity);

        void Delete(T entity);

        T GetById(int id);

    }
}
