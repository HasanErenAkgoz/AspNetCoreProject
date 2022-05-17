using DataAccess.Abstract;
using DataAccess.Repositories;
using Entity.Concrate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrate.EntityFramework
{
  public  class EfCategoryDal:GenericRepository<Category>,ICategoryDal
    {
    }
}
