using Business.Abstract;
using DataAccess.Abstract;
using DataAccess.Concrate.EntityFramework;
using Entity.Concrate;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Business.Concrate
{
    public class CategoryManager : ICategoryService
    {
        ICategoryDal _categoryDal;
        public CategoryManager(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }
        public void Add(Category category)
        {
            _categoryDal.Insert(category);
        }

        public void Delete(Category category)
        {
            if (category.Status == true)
            {
                category.Status = false;
               
            }
            else if (category.Status == false)
            {
                category.Status = true;
             
            }
            _categoryDal.Update(category);
        }

        public Category GetById(int id)
        {
            return _categoryDal.GetById(id);
        }

        public List<Category> GetList()
        {
            return _categoryDal.GetList().Where(x=>x.Status==true).ToList();
        }

        public void Update(Category category)
        {
            _categoryDal.Update(category);

        }
    }
}
