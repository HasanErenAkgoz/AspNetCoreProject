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
    public class EfBlogDal : GenericRepository<Blog>, IBlogDal
    {
        
        public List<Blog> GetListWithCategory()
        {
            using (var context=new Context()) 
            {
                return context.Blogs.Include(x => x.Category).OrderByDescending(x=>x.CreateDate).ToList();
            }
        }

        public List<Blog> GetListWithCategoryByWriter(int id)
        {
            using (var context = new Context())
            {
                return context.Blogs.Include(x => x.Category).Where(x=>x.WriterId==id).ToList();
            }
        }
    }
}
