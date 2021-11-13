using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entity.Concrate;
using System.Collections.Generic;

namespace Business.Concrete
{
    public class AdminInfoManager : IAdminInfoServices
    {
        private IUsernfoDal _adminInfoDal;

        public AdminInfoManager(IUsernfoDal adminInfoDal)
        {
            _adminInfoDal = adminInfoDal;
        }

        public IResult Add(Core.Entities.Concrete.User user)
        {
            if (user.Email == "" || user.Email == null)
            {
                return new ErrorResult(Messages.ItemAddFailed);
            }
            _adminInfoDal.Add(user);
            return new SuccessResult(Messages.ItemAdded);
        }

        public IResult Delete(Core.Entities.Concrete.User user)
        {
            _adminInfoDal.Delete(user);
            return new SuccessResult(Messages.ItemDeleted);
        }

        public IDataResult<List<Core.Entities.Concrete.User>> GetAll()
        {
            return new SuccessDataResult<List<Core.Entities.Concrete.User>>(_adminInfoDal.GetAll(), Messages.ItemsListed);
        }

        public IResult Update(Core.Entities.Concrete.User admin)
        {
            _adminInfoDal.Update(admin);
            return new Result(Messages.ItemUpdated);
        }
    }
}