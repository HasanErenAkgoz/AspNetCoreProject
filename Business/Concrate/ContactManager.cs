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
    public class ContactManager:IContactService

    {
        IContactDal _contactDal;
        public ContactManager(IContactDal contactDal)
        {
            _contactDal = contactDal;
        }
        public void Add(Contact contact)
        {
            _contactDal.Insert(contact);
        }

        public int ContactCount()
        {
            return _contactDal.GetList().Count();
        }

        public void Delete(Contact entity)
        {
            throw new NotImplementedException();
        }

        public Contact GetById(int id)
        {
            throw new NotImplementedException();
        }

        public List<Contact> GetList()
        {
            return _contactDal.GetList();
        }

        public void Update(Contact entity)
        {
            throw new NotImplementedException();
        }
    }
}
