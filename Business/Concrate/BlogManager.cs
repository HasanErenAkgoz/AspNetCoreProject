using Business.Abstract;
using DataAccess.Abstract;
using Entity.Concrate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrate
{
    public class BlogManager : IBlogService
    {

        IBlogDal _blogDal;
        public BlogManager(IBlogDal blogDal)
        {
            _blogDal = blogDal;
        }
        public void Add(Blog blog)
        {
            _blogDal.Insert(blog);
        }

        public void Delete(Blog blog)
        {
            blog.Status = false;
            _blogDal.Update(blog);
        }

        public List<Blog> GetBlogByWriter(int id)
        {
            return _blogDal.GetListAll(x => x.WriterId == id).ToList();
        }

        public List<Blog> GetBlogListWithCategory()
        {
            return _blogDal.GetListWithCategory();
        }

        public List<Blog> GetListWritCategoryByWriter(int id)
        {
            return _blogDal.GetListWithCategoryByWriter(id);
        }
        public Blog GetById(int id)
        {
            return _blogDal.GetById(id);
        }

        public List<Blog> GetList()
        {

            return _blogDal.GetList();
        }

        public List<Blog> GetLas3Blog()
        {
            return _blogDal.GetList().Take(3).ToList();
        }

        public void Update(Blog blog)
        {
            _blogDal.Update(blog);
        }

        public int BlogCount()
        {
            return  _blogDal.GetList().Count;
        }
    }
}
