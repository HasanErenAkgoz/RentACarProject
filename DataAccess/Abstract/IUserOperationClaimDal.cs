using Core.DataAccess.EntityFramework;
using Core.Entities.Concrete;
using Entity.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{

    public interface IUserOperationClaimDal : IEntityRepository<UserOperationClaim>
    {

        List<UserOperationClaimDto> userOperationClaimList(Expression<Func<UserOperationClaimDto, bool>> filter = null);
        UserOperationClaimDto getOperationClaimList(int carId);


    }
}
