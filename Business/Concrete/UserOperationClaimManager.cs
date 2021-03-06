using Business.Abstract;
using Business.BusinessAspects.AutoFac;
using Business.Constants;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entity.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class UserOperationClaimManager : IUserOperationClaimService
    {
        private readonly IOperationClaimService _operationClaimService;
        private readonly IUserOperationClaimDal _userOperationClaimDal;

        public UserOperationClaimManager(IOperationClaimService operationClaimService,
            IUserOperationClaimDal userOperationClaimDal
        )
        {
            _operationClaimService = operationClaimService;
            _userOperationClaimDal = userOperationClaimDal;
        }

        //[SecuredOperation("admin")]
        public IDataResult<List<UserOperationClaimDto>> GetById(int id)
        {
            return new SuccessDataResult<List<UserOperationClaimDto>>(_userOperationClaimDal.userOperationClaimList(x=>x.id==id));
        }

        //[SecuredOperation("admin")]
        public IDataResult<List<UserOperationClaimDto>> GetAll()
        {
            return new SuccessDataResult<List<UserOperationClaimDto>>(_userOperationClaimDal.userOperationClaimList(), Messages.ItemsListed);
        }

        public IResult AddUserClaim(User user)
        {
            var operationClaim = _operationClaimService.GetByName("user").Data;
            var userOperationClaim = new UserOperationClaim { OperationClaimId = operationClaim.Id, UserId = user.Id };
            _userOperationClaimDal.Add(userOperationClaim);
            return new SuccessResult(Messages.UserOperationClaimAdded);
        }

        [SecuredOperation("admin")]
        public IResult Add(UserOperationClaim userOperationClaim)
        {
            userOperationClaim.Status = true;
            _userOperationClaimDal.Add(userOperationClaim);
            return new SuccessResult(Messages.UserOperationClaimAdded);
        }

        [SecuredOperation("admin")]
        public IResult Update(UserOperationClaim userOperationClaim)
        {
            _userOperationClaimDal.Update(userOperationClaim);
            return new SuccessResult(Messages.UserOperationClaimUpdated);
        }

        //[SecuredOperation("admin")]
        public IResult Delete(UserOperationClaim userOperationClaim)
        {
            _userOperationClaimDal.Update(userOperationClaim);
            return new SuccessResult(Messages.UserOperationClaimDeleted);
        }

        public IDataResult<List<UserOperationClaimDto>> GetByUserId(int id)
        {
            return new SuccessDataResult<List<UserOperationClaimDto>>(_userOperationClaimDal.userOperationClaimList(x => x.userId == id));
        }
    }
}
