using DataAccess.Abstract;
using DataAccess.Repositories;
using Entity.Concrate;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrate.EntityFramework
{
  public  class EfCommentDal : GenericRepository<Comment>, ICommentDal
    {
        public List<Comment> GetListWithBlog()
        {
            using (var c = new Context())
            {
                return c.Comments.Include(x => x.Blog).ToList();
            }
        }
    }
}
