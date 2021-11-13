using Core.DataAccess.EntityFramework;
using Core.Entities.Concrete;
using Entity.Concrate;
using System.Collections.Generic;

namespace DataAccess.Abstract
{
    public interface IUsernfoDal : IEntityRepository<User>
    {
        List<OperationClaim> GetClaims(User user);

    }
}