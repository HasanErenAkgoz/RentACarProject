using Core.Entities.Concrete;
using Core.Utilities.Results;
using Entity.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IUserOperationClaimService
    {
        IDataResult<List<UserOperationClaimDto>> GetById(int id);
        IDataResult<List<UserOperationClaimDto>> GetByUserId(int id);

        IDataResult<List<UserOperationClaimDto>> GetAll();

        IResult AddUserClaim(User user);

        IResult Add(UserOperationClaim userOperationClaim);

        IResult Update(UserOperationClaim userOperationClaim);

        IResult Delete(UserOperationClaim userOperationClaim);
    }
}
