using Core.DataAccess.EntityFramework;
using Core.Entities.Concrete;
using DataAccess.Abstract;
using Entity.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfUserOperationClaimDal : EfEntityRepositoryBase<UserOperationClaim, AkgozRentACarContext>,
        IUserOperationClaimDal
    {
        public UserOperationClaimDto getOperationClaimList(int carId)
        {
            using (var context = new AkgozRentACarContext())
            {
                var result = from userOperationClaims in context.UserOperationClaims.Where(x=>x.Id==carId)
                             join User in context.Users
                             on userOperationClaims.UserId equals User.Id

                             join claim in context.OperationClaims
                             on userOperationClaims.OperationClaimId equals claim.Id

                             select new UserOperationClaimDto
                             {
                                 id = userOperationClaims.Id,
                                 userId = User.Id,
                                 Email = User.Email,
                                 FirstName = User.FirstName,
                                 LastName = User.LastName,
                                 OperationClaimId = claim.Id,
                                 claimName = claim.Name,

                             };
                return result.FirstOrDefault();

            }
        }

        public List<UserOperationClaimDto> userOperationClaimList(Expression<Func<UserOperationClaimDto, bool>> filter = null)
        {
            using (var context = new AkgozRentACarContext())
            {
                var result = from userOperationClaims in context.UserOperationClaims
                             join User in context.Users
                             on userOperationClaims.UserId equals User.Id

                             join claim in context.OperationClaims
                             on userOperationClaims.OperationClaimId equals claim.Id


                             select new UserOperationClaimDto
                             {
                                 id = userOperationClaims.Id,
                                 userId = User.Id,
                                 Email = User.Email,
                                 FirstName = User.FirstName,
                                 LastName = User.LastName,
                                 OperationClaimId = claim.Id,
                                 claimName = claim.Name,
                                 Status=userOperationClaims.Status,

                             };
                return result.Where(x => x.Status == true).ToList();
            }
        }
    }
}
