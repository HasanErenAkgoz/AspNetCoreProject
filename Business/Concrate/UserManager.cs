using Business.Abstract;
using DataAccess.Abstract;
using DataAccess.Concrate;
using Entity.Concrate;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrate
{
    public class UserManager : IUserService

    {
        IUserDal _userDal;
        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }
        public void Add(AppUser entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(AppUser entity)
        {
            throw new NotImplementedException();
        }

        public AppUser GetById(int id)
        {
            return _userDal.GetById(id); 
        }

        public List<AppUser> GetList()
        {
            throw new NotImplementedException();
        }

        public void Update(AppUser entity)
        {
            _userDal.Update(entity);
                 
        }
      
    }
}
