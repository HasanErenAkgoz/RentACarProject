using Core.DataAccess.EntityFramework;
using Entity.Concrate;
using Entity.DTOs;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace DataAccess.Abstract
{
    public interface ICustomerInfoDal : IEntityRepository<CustomerInfo>
    {
        List<CustomerInfoDTO> GetCustomerDetail(Expression<Func<CustomerInfoDTO, bool>> filter = null);
        CustomerInfoDTO GetCustomerDetailId(int carId);
        CustomerInfoDTO getCustomerUserDetailId(int UserId);


    }
}