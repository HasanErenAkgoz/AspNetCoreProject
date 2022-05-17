using Business.Abstract;
using DataAccess.Abstract;
using Entity.Concrate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrate
{
    public class NewsLetterManager : INewsLetterService
    {
        INewsLetterDal _INewsLetterDal;
        public NewsLetterManager(INewsLetterDal newsLetter)
        {
            _INewsLetterDal = newsLetter;
        }
        public void Add(NewsLetter newsLetter)
        {
             _INewsLetterDal.Insert(newsLetter);
        }

        public void Delete(NewsLetter newsLetter)
        {
            throw new NotImplementedException();
        }

        public NewsLetter GetById(int id)
        {
            throw new NotImplementedException();
        }

        public List<NewsLetter> GetList()
        {
            throw new NotImplementedException();
        }

        public void Update(NewsLetter newsLetter)
        {
            throw new NotImplementedException();
        }
    }
}
