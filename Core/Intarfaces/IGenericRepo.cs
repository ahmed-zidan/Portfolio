using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Intarfaces
{
    public interface IGenericRepo<T> where T : class
    {

        IEnumerable<T> getAll();
        T GetBYId(object id);

        void insert(T entity);
        void update(T entity);
        void delete(T entity);


    }

}
