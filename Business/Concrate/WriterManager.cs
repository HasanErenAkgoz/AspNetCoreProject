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
    public class WriterManager : IWriterService
    {
        IWriterDal _writerDal;
        public WriterManager(IWriterDal writerDal)
        {
            _writerDal = writerDal;
        }
        public void Add(Writer writer)
        {
            _writerDal.Insert(writer);
        }

        public void Delete(Writer writer)
        {
            _writerDal.Delete(writer);
        }

        public List<Writer> GetWriterById(int id)
        {
            return _writerDal.GetListAll(x => x.Id == id);
        }

        public Writer GetById(int id)
        {
            return _writerDal.GetById(id);
        }

        public List<Writer> GetList()
        {
            return _writerDal.GetList();
        }
        public void Update(Writer writer)
        {
            writer.City = "İstanbul";
            writer.Status = true;
            _writerDal.Update(writer);
        }
    }
}
