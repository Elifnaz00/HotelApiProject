using HotelProject.BusinessLayer.Abstract;
using HotelProject.DataAccesLayer.Abstract;
using HotelProject.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.BusinessLayer.Concrete
{
    public class AppUserManager : IAppUserService
    {
        private readonly IAppUserDal _appuserDal;

        public AppUserManager(IAppUserDal appuserDal)
        {
            _appuserDal = appuserDal;
        }

        public AppUser GetByID(int id)
        {
            throw new NotImplementedException();
        }

        public int TAppUserCount()
        {
            return _appuserDal.AppUserCount();
        }

        public void TDelete(AppUser t)
        {
            throw new NotImplementedException();
        }

        public List<AppUser> TGetList()
        {
            
            return _appuserDal.GetList();
        }

        public void TInsert(AppUser t)
        {
            throw new NotImplementedException();
        }

        public void TUpdate(AppUser t)
        {
            throw new NotImplementedException();
        }

        public List<AppUser> TUserListWithWorkLocation()
        {
            return _appuserDal.UserListWithWorkLocation();
        }

        public List<AppUser> TUserListWithWorkLocations()
        {
            return _appuserDal.UserListWithWorkLocations();
        }
    }
}
