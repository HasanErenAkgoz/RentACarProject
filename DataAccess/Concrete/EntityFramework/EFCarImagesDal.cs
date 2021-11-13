using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entity.Concrate;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EFCarImagesDal : EfEntityRepositoryBase<CarImages, AkgozRentACarContext>, ICarImagesDal
    {
    }
}
