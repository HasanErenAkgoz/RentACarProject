using Core.DataAccess.EntityFramework;
using Entities.DTOs;
using Entity.Concrate;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace DataAccess.Abstract
{
    public interface ICarInfoDal : IEntityRepository<CarInfo>
    {
        List<CarDetailDTO> GetCarDetails(Expression<Func<CarDetailDTO, bool>> filter = null);
        CarDetailDTO GetCarDetailCarId(int carId);
    }
}