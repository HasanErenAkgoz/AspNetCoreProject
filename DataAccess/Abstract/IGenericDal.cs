using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
  public  interface IGenericDal<T> where T:class
    {
        void Insert(T entity);
        void Delete(T entity);
        void Update(T entity);
        List<T> GetList();

        List<T> GetListAll(Expression<Func<T, bool>> filter);
        T GetById(int id);

    }
}
