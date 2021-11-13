using Core.Entities.Concrete;
using Core.Utilities.Results;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface IAdminInfoServices
    {
        IResult Add(User admin);

        IResult Update(User admin);

        IResult Delete(User admin);

        IDataResult<List<User>> GetAll();
    }
}