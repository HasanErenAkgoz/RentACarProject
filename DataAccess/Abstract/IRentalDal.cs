using Core.DataAccess.EntityFramework;
using Entities.DTOs;
using Entity.Concrate;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace DataAccess.Abstract
{
    public interface IRentalDal : IEntityRepository<Rental>
    {
        List<CarRentDetailDTO> GetRentalDetails();

    }
}