using Core.Entities.Concrete;
using Core.Utilities.Results;
using Entity.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IUserService
    {
        IDataResult<List<OperationClaim>> GetClaims(User user);
        IResult Add(User user);
        IResult ProfileUpdate(User user, string password);

        User GetByMail(string email);
        IResult Update(User user);
        IResult UpdateInfos(User user);
        IDataResult<List<User>> GetAll();

        IDataResult<User> GetById(int id);
    }
}
