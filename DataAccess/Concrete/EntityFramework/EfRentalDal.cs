using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.DTOs;
using Entity.Concrate;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Linq;
using Core.Entities.Concrete;

namespace DataAccess.Concrete.EntityFramework
{

    public class EfRentalDal : EfEntityRepositoryBase<Rental, AkgozRentACarContext>, IRentalDal
    {
        public List<CarRentDetailDTO> GetRentalDetails()
        {
            using (AkgozRentACarContext context = new AkgozRentACarContext())
            {
                var result = (from rental in context.Rentals
                             join car in context.CarInfos
                             on rental.CarInfoId equals car.CarId

                             join customer in context.CustomerInfos
                             on rental.CustomerInfoId equals customer.Id
                             select new CarRentDetailDTO
                             {

                                 Id = rental.Id,
                                 plate=car.Plate,
                                 CarInfoId=car.CarId,
                                 BrandName=car.Brand.Name,
                                 ModelName=car.Model.ModelName,
                                 CustomerInfoId = customer.Id,
                                 FirstName=customer.user.FirstName,
                                 LastName=customer.user.LastName,
                                 RentDate=rental.RentDate,
                                 ReturnDate=rental.ReturnDate,
                                 RentEndDate=rental.RentEndDate,
                                 TotalPrice=rental.TotalPrice,
                                 

                             }).ToList();
                return result.ToList();
            }
        }
    }
}