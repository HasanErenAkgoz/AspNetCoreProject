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
    public class AdminManager : IAdminService
    {
        IAdminDal _adminDal;
        public AdminManager(IAdminDal adminDal)
        {
            _adminDal = adminDal;
        }
        public void Add(Admin admin)
        {
            _adminDal.Insert(admin);
        }

        public string AdminName()
        {
            return _adminDal.GetList().Where(x => x.Id == 1).Select(y => y.Name).FirstOrDefault();
        }

        public void Delete(Admin admin)
        {
            throw new NotImplementedException();
        }

  

        public Admin GetById(int id)
        {
            return _adminDal.GetById(id);
        }

        public List<Admin> GetList()
        {
            throw new NotImplementedException();
        }

        public void Update(Admin admin)
        {
            throw new NotImplementedException();
        }
    }
}
